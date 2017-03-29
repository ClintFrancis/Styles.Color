using System;
namespace Styles.Color
{
	public sealed class ComplementaryColorScheme : ColorScheme
	{
		public ComplementaryColorScheme (string name)
		{
			Name = name;
			Type = ColorSchemeType.Complementary;
		}

		public ComplementaryColorScheme (string name, IRgb [] colors)
		{
			Name = name;
			SetColors (colors);
			Type = ColorSchemeType.Complementary;
		}

		public override IRgb GetColorStep (int offset)
		{
			int targetIndex = PrimaryIndex + offset;
			if (targetIndex > Colors.Length - 1) {
				targetIndex = Colors.Length - 1;
			} else if (targetIndex < 0) {
				throw new Exception ("Complementary Color Index cannot be less than 0");
			}

			return Colors [targetIndex];
		}

		public override void SetColors (IRgb [] colors)
		{
			var length = colors.Length;
			if (length != 2 &&
				length != 4)
				throw new Exception ("Invalid range of colors supplied, complementary color arrays must be 2 or 4 colors in length");

			Colors = colors;
			PrimaryIndex = (int)Math.Floor (length / 2d);
		}

		public static ComplementaryColorScheme FromColor (ColorRGB color, bool flatten)
		{

			var firstColor = color;
			var secondColor = color.AdjustHue (180);

			if (flatten) {
				throw new NotImplementedException("Lab colors still need to be generated correctly");

				// HACK this needs to be set as a parameter
				var labColors = ColorScheme.GenerateColors (24, 0, .66, .81);

				//Flatten colors
				firstColor = firstColor.NearestFlatColor (labColors);
				secondColor = secondColor.NearestFlatColor (labColors);

			}

			return new ComplementaryColorScheme ("", new IRgb [] { firstColor, secondColor });
		}

	}
}

