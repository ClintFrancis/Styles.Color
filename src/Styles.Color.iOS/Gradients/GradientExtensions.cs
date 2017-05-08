using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using Foundation;

namespace Styles.Color
{

    public static class GradientExtensions
    {
        #region Helper methods
        static double[] DetermineGradientPoints(LinearGradient target)
        {
            // create coordinates
            var x = target.Rotation / 360d;
            var a = Math.Pow(Math.Sin((2 * Math.PI * ((x + 0.75) / 2))), 2);
            var b = Math.Pow(Math.Sin((2 * Math.PI * ((x + 0.0) / 2))), 2);
            var c = Math.Pow(Math.Sin((2 * Math.PI * ((x + 0.25) / 2))), 2);
            var d = Math.Pow(Math.Sin((2 * Math.PI * ((x + 0.5) / 2))), 2);

            return new double[] { a, b, c, d };
        }

        static nfloat[] ConvertToNativeArray(float[] target)
        {
            var converted = new nfloat[target.Length];
            for (int i = 0; i < target.Length; i++)
            {
                converted[i] = target[i];
            }
            return converted;
        }

        static nfloat[] GenerateGradientColors(IRgb[] colors)
        {
            var totalColors = colors.Length * 4;
            nfloat[] gradColors = new nfloat[totalColors];

            var offset = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                gradColors[offset] = (nfloat)colors[i].R;
                gradColors[offset + 1] = (nfloat)colors[i].G;
                gradColors[offset + 2] = (nfloat)colors[i].B;
                gradColors[offset + 3] = (nfloat)colors[i].A;

                offset += 4;
            }

            return gradColors;
        }
        #endregion

        #region View Extensions
        public static GradientView ToNativeView(this LinearGradient target, CGRect frame)
        {
            return new GradientView(target) { Frame = frame };
        }

        public static GradientView ToNativeView(this RadialGradient target, CGRect frame)
        {
            return new GradientView(target) { Frame = frame };
        }

        public static GradientView ToNativeView(this MultiGradient target, CGRect frame)
        {
            return new GradientView(target) { Frame = frame };
        }

        public static GradientView ToNativeView(this Gradient[] targets, CGRect frame)
        {

            return new GradientView(targets) { Frame = frame };
        }

        public static CAGradientLayer ToNativeLayer(this LinearGradient target, CGRect frame)
        {
            target.Update();

            var gradLayer = new CAGradientLayer();
            gradLayer.Frame = frame;

            var colors = new CGColor[target.Colors.Length];
            for (int i = 0; i < target.Colors.Length; i++)
            {
                var rgb = (ColorRGB)target.Colors[i];
                colors[i] = rgb.ToNative().CGColor;
            }

            gradLayer.Colors = colors;

            var locations = new NSNumber[target.Locations.Length];
            for (int i = 0; i < target.Locations.Length; i++)
            {
                locations[i] = target.Locations[i];
            }

            gradLayer.Locations = locations;

            var points = DetermineGradientPoints(target);
            gradLayer.StartPoint = new CGPoint(points[0], points[1]);
            gradLayer.EndPoint = new CGPoint(points[2], points[3]);

            return gradLayer;
        }
        #endregion

        #region Draw Extensions
        public static void Draw(this LinearGradient target, CGContext ctx, CGRect bounds)
        {
            target.Update();

            CGRect clippingBounds = bounds;
            if (!target.Frame.IsEmpty)
                bounds = new CGRect(target.Frame.X, target.Frame.Y, target.Frame.Width, target.Frame.Height);

            var gradColors = GenerateGradientColors(target.Colors);
            var colorSpace = CGColorSpace.CreateDeviceRGB();
            var grad = new CGGradient(colorSpace, gradColors, ConvertToNativeArray(target.Locations));

            var points = DetermineGradientPoints(target);
            var startPoint = new CGPoint(points[0] * bounds.Width, points[1] * bounds.Height);
            var endPoint = new CGPoint(points[2] * bounds.Width, points[3] * bounds.Height);

            // Crop to frame
            if (!target.Frame.IsEmpty)
            {
                ctx.SaveState();
                ctx.ClipToRect(clippingBounds);
                ctx.DrawLinearGradient(grad, startPoint, endPoint, CGGradientDrawingOptions.DrawsBeforeStartLocation | CGGradientDrawingOptions.DrawsAfterEndLocation);
                ctx.RestoreState();
            }
            else
            {
                ctx.DrawLinearGradient(grad, startPoint, endPoint, CGGradientDrawingOptions.DrawsBeforeStartLocation | CGGradientDrawingOptions.DrawsAfterEndLocation);
            }

            grad.Dispose();
            colorSpace.Dispose();
        }

        public static void Draw(this RadialGradient target, CGContext ctx, CGRect bounds)
        {
            target.Update();

            CGRect clippingBounds = bounds;
            if (!target.Frame.IsEmpty)
                bounds = new CGRect(target.Frame.X, target.Frame.Y, target.Frame.Width, target.Frame.Height);

            var gradColors = GenerateGradientColors(target.Colors);
            var colorSpace = CGColorSpace.CreateDeviceRGB();
            var grad = new CGGradient(colorSpace, gradColors, ConvertToNativeArray(target.Locations));
            var gradCenter = new CGPoint(bounds.Width * target.Location.X, bounds.Height * target.Location.Y);
            var gradRadius = (float)Math.Min(bounds.Size.Width * target.ScaleMultiplier.X, bounds.Size.Height * target.ScaleMultiplier.Y);

            // Crop to frame
            if (!target.Frame.IsEmpty)
            {
                ctx.SaveState();
                ctx.ClipToRect(clippingBounds);
                ctx.DrawRadialGradient(grad, gradCenter, 0, gradCenter, gradRadius, CGGradientDrawingOptions.DrawsBeforeStartLocation | CGGradientDrawingOptions.DrawsAfterEndLocation);
                ctx.RestoreState();
            }
            else
            {
                ctx.DrawRadialGradient(grad, gradCenter, 0, gradCenter, gradRadius, CGGradientDrawingOptions.DrawsBeforeStartLocation | CGGradientDrawingOptions.DrawsAfterEndLocation);
            }

            grad.Dispose();
            colorSpace.Dispose();
        }

        public static void Draw(this Gradient[] items, CGContext ctx, CGRect bounds)
        {
            throw new NotImplementedException();
        }

        public static void Draw(this MultiGradient target, CGContext ctx, CGRect bounds)
        {
            for (int i = 0; i < target.Gradients.Length; i++)
            {
                var gradient = target.Gradients[i];
                switch (gradient.Type)
                {
                    case GradientType.Linear:
                        var linearGradient = gradient as LinearGradient;
                        linearGradient.Draw(ctx, bounds);
                        break;
                    case GradientType.Radial:
                        var radialGradient = gradient as RadialGradient;
                        radialGradient.Draw(ctx, bounds);
                        break;
                    default:
                        throw new NotImplementedException("Multigradients does not support the supplied gradient type: " + gradient.Type);
                }
            }
        }
        #endregion
    }
}
