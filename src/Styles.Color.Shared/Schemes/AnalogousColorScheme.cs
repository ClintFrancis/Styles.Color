using System;
namespace Styles.Color
{
	public sealed class AnalogousColorScheme : ColorScheme
	{
		public AnalogousColorScheme (string name)
		{
			Name = name;
			Type = ColorSchemeType.Analogous;
		}

		public AnalogousColorScheme (string name, IRgb [] colors)
		{
			Name = name;
			SetColors (colors);
			Type = ColorSchemeType.Analogous;
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
				throw new Exception ("Invalid range of colors supplied, analogous color arrays must be 3, 5 or 7 colors in length");

			Colors = colors;
			PrimaryIndex = (int)Math.Floor (length / 2d);
		}

		public static AnalogousColorScheme FromColor (ColorRGB color, bool flatten, double stepSize = 30)
		{
			var hsb = ColorHSB.FromColor (color);
			double hue = hsb.H;
			double saturation = hsb.S;
			double brightness = hsb.B;

			var firstColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue - stepSize * 2,
				saturation: saturation,
				brightness: brightness + .1
			);

			var secondColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue - stepSize,
				saturation: saturation,
				brightness: brightness
			);

			var thirdColor = color;

			var fourthColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue + stepSize,
				saturation: saturation,
				brightness: brightness
			);

			var fifthColor = (ColorRGB)ColorHSB.ToColor (
				hue: hue + stepSize * 2,
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

				/*
				//Make sure returned colors are unique
				//Inner Colors
				if (secondColor == thirdColor) {
					var adjustedColor = new ColorHSB (
						hue - step * 2,
						saturation,// + 0.05,
						brightness// + 0.09
					);

					var rgb = (ColorRGB)adjustedColor.ToRgb ();
					secondColor = rgb.FlattenTo (labColors);
				}

				if (fourthColor == thirdColor) {
					var adjustedColor = new ColorHSB (
						hue + step * 2,
						saturation,// + 0.05,
						brightness + 0.09
					);

					var rgb = (ColorRGB)adjustedColor.ToRgb ();
					fourthColor = rgb.FlattenTo (labColors);
				}

				// Outer Colors
				if (firstColor == secondColor) {
					var adjustedColor = new ColorHSB (
						hue - 64,
						saturation + 0.05,
						brightness + 0.09
					);

					var rgb = (ColorRGB)adjustedColor.ToRgb ();
					firstColor = rgb.FlattenTo (labColors);
				}

				if (firstColor == thirdColor) {
					var adjustedColor = new ColorHSB (
						hue - 80,
						saturation + 0.05,
						brightness + 0.09
					);

					var rgb = (ColorRGB)adjustedColor.ToRgb ();
					firstColor = rgb.FlattenTo (labColors);
				}

				if (fifthColor == fourthColor) {
					var adjustedColor = new ColorHSB (
						hue + 64,
						saturation + 0.05,
						brightness + 0.09
					);

					var rgb = (ColorRGB)adjustedColor.ToRgb ();
					fifthColor = rgb.FlattenTo (labColors);
				}

				if (fifthColor == thirdColor) {
					var adjustedColor = new ColorHSB (
						hue + 80,
						saturation + 0.05,
						brightness + 0.09
					);

					var rgb = (ColorRGB)adjustedColor.ToRgb ();
					fifthColor = rgb.FlattenTo (labColors);
				}
				*/
			}

			return new AnalogousColorScheme ("", new IRgb [] { firstColor, secondColor, thirdColor, fourthColor, fifthColor });
		}


	}
}

