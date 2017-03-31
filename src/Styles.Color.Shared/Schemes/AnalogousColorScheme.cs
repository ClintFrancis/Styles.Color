using System;
namespace Styles.Color
{
	public sealed class AnalogousColorScheme : ColorScheme
	{
		const string SecondaryColorID = "secondary";
		const string TertiaryColorID = "tertiary";

		public IRgb SecondaryColor { get { return Colors[SecondaryColorID]; } }
		public IRgb TertiaryColor { get { return Colors[TertiaryColorID]; } }

		AnalogousColorScheme(Swatch[] colors)
		{
			Type = ColorSchemeType.Analogous;
			SetColors(colors);
		}

		public override void SetColors (Swatch[] colors)
		{
			var length = colors.Length;
			if (length != 3 &&
				length != 5 &&
				length != 7)
				throw new Exception ("Invalid range of colors supplied, analogous color arrays must be 3, 5 or 7 colors in length");

			base.SetColors(colors);
		}

		public static AnalogousColorScheme FromColor (ColorRGB color, bool flatten, double stepSize = 30)
		{
			var hsb = ColorHSB.FromColor (color);
			double hue = hsb.H;
			double saturation = hsb.S;
			double brightness = hsb.B;

			var primary = new Swatch(PrimaryColorID, color);

			var secondary = new Swatch(SecondaryColorID, ColorHSB.ToColor (
				hue: hue - stepSize,
				saturation: saturation,
				brightness: brightness
			));

			var tertiary = new Swatch(SecondaryColorID, ColorHSB.ToColor (
				hue: hue + stepSize,
				saturation: saturation,
				brightness: brightness
			));

			if (flatten) {
				throw new NotImplementedException("Lab colors still need to be generated correctly");

				// HACK this needs to be set as a parameter
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);

				////Flatten colors
				primary.Color = primary.Color.NearestFlatColor (labColors);
				secondary.Color = secondary.Color.NearestFlatColor (labColors);
				tertiary.Color = tertiary.Color.NearestFlatColor (labColors);

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

			return new AnalogousColorScheme(new Swatch[] { primary, secondary, tertiary });
		}
	}
}

