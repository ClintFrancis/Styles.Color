using System;
namespace Styles.Color
{
	public sealed class ComplementaryColorScheme : ColorScheme
	{
		const string ComplimentaryColorID = "complimentary";

		public IRgb ComplimentaryColor { get { return Colors[ComplimentaryColorID]; } }

		// no public constructor
		ComplementaryColorScheme (Swatch[] colors)
		{
			Type = ColorSchemeType.Complementary;
			SetColors (colors);
		}

		public override void SetColors (Swatch[] colors)
		{
			if (colors.Length != 2)
				throw new Exception ("Invalid range of colors supplied, complementary color arrays must be 2 colors in length");

			base.SetColors(colors);
		}

		public static ComplementaryColorScheme FromColor (ColorRGB color, bool flatten)
		{
			var primary = new Swatch(PrimaryColorID, color);
			var compilmentary = new Swatch(ComplimentaryColorID, color.AdjustHue(180));

			if (flatten) {
				throw new NotImplementedException("Lab colors still need to be generated correctly");

				// HACK this needs to be set as a parameter
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);

				//Flatten colors
				primary.Color = primary.Color.NearestFlatColor (labColors);
				compilmentary.Color = compilmentary.Color.NearestFlatColor (labColors);

			}

			return new ComplementaryColorScheme (new Swatch [] { primary, compilmentary });
		}

	}
}

