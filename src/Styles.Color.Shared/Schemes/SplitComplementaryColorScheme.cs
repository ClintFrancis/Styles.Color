using System;
namespace Styles.Color
{
	public sealed class SplitComplementaryColorScheme : ColorScheme
	{
		public SplitComplementaryColorScheme (string name)
		{
			Name = name;
			Type = ColorSchemeType.SplitComplementary;
		}

		public SplitComplementaryColorScheme (string name, IRgb [] colors)
		{
			Name = name;
			SetColors (colors);
			Type = ColorSchemeType.SplitComplementary;
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
			if (length != 3 &&
				length != 5 &&
				length != 7)
				throw new Exception ("Invalid range of colors supplied, split complementary color arrays must be 3, 5 or 7 colors in length");

			Colors = colors;
			PrimaryIndex = (int)Math.Floor (length / 2d);
		}

		public static SplitComplementaryColorScheme FromColor (ColorRGB color, bool flatten, int stepSize = 30)
		{
			var hsb = ColorHSB.FromColor (color);
			double hue = hsb.H;
			double saturation = hsb.S;
			double brightness = hsb.B;

			var firstColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue - (stepSize * 2 + 180),
				saturation: saturation,
				brightness: brightness + .1
			);

			var secondColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue - (stepSize - 180),
				saturation: saturation,
				brightness: brightness
			);

			var thirdColor = color;

			var fourthColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue + (stepSize + 180),
				saturation: saturation,
				brightness: brightness
			);

			var fifthColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue + (stepSize * 2 + 180),
				saturation: saturation,
				brightness: brightness + .1
			);

			if (flatten) {
				throw new NotImplementedException("Lab colors still need to be generated correctly");

				// HACK this needs to be set as a parameter
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);

				//Flatten colors
				firstColor = firstColor.NearestFlatColor (labColors);
				secondColor = secondColor.NearestFlatColor (labColors);
				thirdColor = thirdColor.NearestFlatColor (labColors);
				fourthColor = fourthColor.NearestFlatColor (labColors);
				fifthColor = fifthColor.NearestFlatColor (labColors);
			}

			return new SplitComplementaryColorScheme ("", new IRgb [] { firstColor, secondColor, thirdColor, fourthColor, fifthColor });
		}


	}
}


