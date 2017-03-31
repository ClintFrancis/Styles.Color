using System;
namespace Styles.Color
{
	public sealed class SplitComplementaryColorScheme : ColorScheme
	{
		const string SecondaryColorID = "secondary";
		const string TertiaryColorID = "tertiary";

		public IRgb SecondaryColor { get { return Colors[SecondaryColorID]; } }
		public IRgb TertiaryColor { get { return Colors[TertiaryColorID]; } }

		SplitComplementaryColorScheme (Swatch [] colors)
		{
			Type = ColorSchemeType.SplitComplementary;
			SetColors (colors);
		}

		public override void SetColors (Swatch [] colors)
		{
			var length = colors.Length;
			if (length != 3)
				throw new Exception ("Invalid range of colors supplied, split complementary color arrays must be 3 colors in length");

			base.SetColors(colors);
		}

		public static SplitComplementaryColorScheme FromColor (ColorRGB color, bool flatten, int stepSize = 30)
		{
			var hsb = ColorHSB.FromColor (color);
			double hue = hsb.H;
			double saturation = hsb.S;
			double brightness = hsb.B;

			var primary = new Swatch(PrimaryColorID, color);

			var secondary = new Swatch(SecondaryColorID, ColorHSB.ToColor (
				hue: hue - (stepSize - 180),
				saturation: saturation,
				brightness: brightness
			));

			var tertiary = new Swatch(TertiaryColorID ,ColorHSB.ToColor (
				hue: hue + (stepSize + 180),
				saturation: saturation,
				brightness: brightness
			));

			if (flatten) {
				throw new NotImplementedException("Lab colors still need to be generated correctly");

				// HACK this needs to be set as a parameter
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);

				//Flatten colors
				primary.Color = primary.Color.NearestFlatColor (labColors);
				secondary.Color = primary.Color.NearestFlatColor (labColors);
				tertiary.Color = primary.Color.NearestFlatColor (labColors);
			}

			return new SplitComplementaryColorScheme (new Swatch [] { primary, secondary, tertiary });
		}


	}
}


