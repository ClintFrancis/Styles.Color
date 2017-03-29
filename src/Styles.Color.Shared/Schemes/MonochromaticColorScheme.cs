using System;
namespace Styles.Color
{
	public sealed class MonochromaticColorScheme : ColorScheme
	{
		public MonochromaticColorScheme (string name)
		{
			Name = name;
			Type = ColorSchemeType.Monochromatic;
		}

		public MonochromaticColorScheme (string name, IRgb [] colors)
		{
			Name = name;
			SetColors (colors);
			Type = ColorSchemeType.Monochromatic;
		}

		public override IRgb GetColorStep (int offset)
		{
			int targetIndex = PrimaryIndex + offset;
			if (targetIndex > Colors.Length - 1) {
				targetIndex = Colors.Length - 1;
			} else if (targetIndex < 0) {
				throw new Exception ("Monochromatic Color Index cannot be less than 0");
			}

			return Colors [targetIndex];
		}

		public override void SetColors (IRgb [] colors)
		{
			var length = colors.Length;
			if (length > 8)
				throw new Exception ("Invalid range of colors supplied, monochromatic color arrays must be 8 or less colors in length");

			Colors = colors;
			PrimaryIndex = (int)Math.Floor (length / 2d);
		}

		public static MonochromaticColorScheme FromColor (ColorRGB color, bool flatten)
		{
			if (flatten) {
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);
				color = color.NearestFlatColor (labColors);
			}

			var lab = (ColorLAB)ColorLAB.FromColor (color);

			var firstColor = (ColorRGB)ColorLAB.ToColor (lab.L - 20, lab.A, lab.B);
			var secondColor = (ColorRGB)ColorLAB.ToColor (lab.L - 10, lab.A, lab.B);
			var fourthColor = (ColorRGB)ColorLAB.ToColor (lab.L + 10, lab.A, lab.B);
			var fifthColor = (ColorRGB)ColorLAB.ToColor (lab.L + 20, lab.A, lab.B);

			return new MonochromaticColorScheme ("", new IRgb [] { firstColor, secondColor, color, fourthColor, fifthColor });
		}
	}
}

