using System;
namespace Styles.Color
{
	public sealed class TriadicColorScheme : ColorScheme
	{
		public TriadicColorScheme (string name)
		{
			Name = name;
			Type = ColorSchemeType.Triadic;
		}

		public TriadicColorScheme (string name, IRgb [] colors)
		{
			Name = name;
			SetColors (colors);
			Type = ColorSchemeType.Triadic;
		}

		public override IRgb GetColorStep (int offset)
		{
			int targetIndex = PrimaryIndex + offset;
			if (targetIndex > Colors.Length - 1) {
				targetIndex = Colors.Length - 1;
			} else if (targetIndex < 0) {
				targetIndex = 0;
			}

			return Colors [targetIndex];
		}

		public override void SetColors (IRgb [] colors)
		{
			var length = colors.Length;
			if (length != 3)
				throw new Exception ("Invalid range of colors supplied, triadic color arrays must be 3 colors in length");

			Colors = colors;
			PrimaryIndex = (int)Math.Floor (length / 2d);
		}

		public static TriadicColorScheme FromColor (ColorRGB color, bool flatten)
		{
			var hsb = ColorHSB.FromColor (color);

			var firstColor = (ColorRGB)ColorHSB.ToColor (
				hue: hsb.H - 120,
				saturation: hsb.S,
				brightness: hsb.B
			);

			var secondColor = color;

			var thirdColor = (ColorRGB)ColorHSB.ToColor (
				hue: hsb.H + 120,
				saturation: hsb.S,
				brightness: hsb.B
			);

			if (flatten) {
				throw new NotImplementedException("Lab colors still need to be generated correctly");

				// HACK this needs to be set as a parameter
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);

				//Flatten colors
				firstColor = firstColor.NearestFlatColor (labColors);
				secondColor = secondColor.NearestFlatColor (labColors);
				thirdColor = thirdColor.NearestFlatColor (labColors);
			}

			return new TriadicColorScheme ("", new IRgb [] { firstColor, secondColor, thirdColor });
		}
	}
}

