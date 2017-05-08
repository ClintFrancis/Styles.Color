using System;
using System.Drawing;

namespace Styles.Color
{
    public class EllipticalGradient : Gradient
    {
        public PointF Location { get; set; }

        // -360 -> 0 <- 360
        public double Rotation { get; set; }

        public EllipticalGradient(IRgb[] colors) : base(colors)
        {
            Location = new PointF(.5f, .5f);
            Type = GradientType.Ellipse;
        }

        public EllipticalGradient(IRgb[] colors, float locationX, float locationY) : base(colors)
        {
            Location = new PointF(locationX, locationY);
            Type = GradientType.Ellipse;
        }

        public EllipticalGradient(IRgb[] colors, PointF location) : base(colors)
        {
            Location = location;
            Type = GradientType.Ellipse;
        }

        new public EllipticalGradient Clone()
        {
            return new EllipticalGradient((IRgb[])Colors.Clone(), this.Location.X, this.Location.Y)
            {
                Locations = this.Locations,
                Reversed = this.Reversed,
                Repeating = this.Repeating,
                Scale = this.Scale,
                Frame = this.Frame,
                Location = this.Location,
                Rotation = this.Rotation,
                DrawingOptions = this.DrawingOptions
            };
        }
    }
}
