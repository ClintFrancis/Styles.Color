using System;
namespace Styles.Color
{
	public sealed class TriadicColorScheme : ColorScheme
	{
		const string SecondaryColorID = "secondary";
		const string TertiaryColorID = "tertiary";

		public IRgb SecondaryColor { get { return Colors[SecondaryColorID]; } }
		public IRgb TertiaryColor { get { return Colors[TertiaryColorID]; } }

		TriadicColorScheme (Swatch [] colors)
		{
			Type = ColorSchemeType.Triadic;
			SetColors (colors);
		}

		public override void SetColors (Swatch [] colors)
		{
			var length = colors.Length;
			if (length != 3)
				throw new Exception ("Invalid range of colors supplied, triadic color arrays must be 3 colors in length");

			base.SetColors(colors);
		}

		public static TriadicColorScheme FromColor (ColorRGB color, bool flatten)
		{
			var hsb = ColorHSB.FromColor (color);

			var primary = new Swatch(PrimaryColorID, color);

			var secondary = new Swatch(SecondaryColorID, ColorHSB.ToColor (
				hue: hsb.H - 120,
				saturation: hsb.S,
				brightness: hsb.B
			));

			var tertiary = new Swatch(TertiaryColorID, ColorHSB.ToColor (
				hue: hsb.H + 120,
				saturation: hsb.S,
				brightness: hsb.B
			));

			if (flatten) {
				throw new NotImplementedException("Lab colors still need to be generated correctly");

				// HACK this needs to be set as a parameter
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);

				//Flatten colors
				primary.Color = primary.Color.NearestFlatColor (labColors);
				secondary.Color = secondary.Color.NearestFlatColor (labColors);
				tertiary.Color = tertiary.Color.NearestFlatColor (labColors);
			}

			return new TriadicColorScheme (new Swatch [] { primary, secondary, tertiary });
		}
	}
}

