using System;
using Styles.Drawing;

namespace Styles.Color
{
    public class EllipticalGradient : Gradient
    {
        public Styles.Drawing.PointF Center { get; set; }

        // -360 -> 0 <- 360
        public double Rotation { get; set; }

        public EllipticalGradient(IRgb[] colors) : base(colors)
        {
            Center = new Styles.Drawing.PointF(.5f, .5f);
            Type = GradientType.Ellipse;
        }

        public EllipticalGradient(IRgb[] colors, float locationX, float locationY) : base(colors)
        {
            Center = new Styles.Drawing.PointF(locationX, locationY);
            Type = GradientType.Ellipse;
        }

        public EllipticalGradient(IRgb[] colors, Styles.Drawing.PointF location) : base(colors)
        {
            Center = location;
            Type = GradientType.Ellipse;
        }

        // Work around method while not working in bait and switch
        public void SetCenter(float x, float y)
        {
            this.Center = new PointF(x, y);
        }

        new public EllipticalGradient Clone()
        {
            return new EllipticalGradient((IRgb[])Colors.Clone(), this.Center.X, this.Center.Y)
            {
                Locations = this.Locations,
                Reversed = this.Reversed,
                Repeating = this.Repeating,
                Scale = this.Scale,
                Frame = this.Frame,
                Center = this.Center,
                Rotation = this.Rotation,
                DrawingOptions = this.DrawingOptions
            };
        }
    }
}
