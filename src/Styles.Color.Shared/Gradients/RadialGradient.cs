using System;
using System.Drawing;

namespace Styles.Color
{
    public class RadialGradient : Gradient
    {
        // TODO Implement in Bait & Switch
        public PointF Location { get; set; }

        public RadialGradient(IRgb[] colors) : base(colors)
        {
            Location = new PointF(0, 0);
            Type = GradientType.Radial;
        }

        public RadialGradient(IRgb[] colors, float locationX, float locationY) : base(colors)
        {
            Location = new PointF(locationX, locationY);
            Type = GradientType.Radial;
        }

        public RadialGradient(IRgb[] colors, PointF location) : base(colors)
        {
            Location = location;
            Type = GradientType.Radial;
        }

        new public RadialGradient Clone()
        {
            return new RadialGradient((IRgb[])Colors.Clone(), this.Location.X, this.Location.Y)
            {
                Locations = this.Locations,
                Reversed = this.Reversed,
                Repeating = this.Repeating,
                Scale = this.Scale,
                Frame = this.Frame,
                DrawingOptions = this.DrawingOptions
            };
        }
    }
}
