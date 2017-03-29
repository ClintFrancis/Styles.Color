using System;
using System.Collections.Generic;
using Styles.Color;

namespace Styles.Color
{

	public class Swatch
	{
		public ColorRGB Color { get; set; }
		public string Name { get; set; }
		public int Weight { get; set; }
	}

	public abstract class ColorScheme
	{
		#region Parameters
		public ColorSchemeType Type { get; internal set; }
		public string Name { get; internal set; }
		public int PrimaryIndex { get; internal set; }
		public IRgb [] Colors { get; set; }
		public IRgb PrimaryColor { get { return Colors [PrimaryIndex]; } }
		#endregion

		#region Methods
		public abstract IRgb GetColorStep (int offset);

		public abstract void SetColors (IRgb [] colors);

		public static ColorScheme CreateColorScheme (ColorRGB primaryColor, ColorSchemeType type, bool useFlatColors)
		{
			switch (type) {
			case ColorSchemeType.Analogous:
				return AnalogousColorScheme.FromColor (primaryColor, useFlatColors);
			case ColorSchemeType.Complementary:
				return ComplementaryColorScheme.FromColor (primaryColor, useFlatColors);
			case ColorSchemeType.SplitComplementary:
				return SplitComplementaryColorScheme.FromColor (primaryColor, useFlatColors);
			case ColorSchemeType.Triadic:
				return TriadicColorScheme.FromColor (primaryColor, useFlatColors);
			case ColorSchemeType.Monochromatic:
				return MonochromaticColorScheme.FromColor (primaryColor, useFlatColors);
			default:
				throw new NotImplementedException ();
			}
		}

		// Steps 5, 6, 8, 9, 10, 12, 15, 18, 20, 24, 30, 36, 40, 45, 60, 72, 90, 120, 180
		public static IColorSpace [] GenerateColors (int steps, double hue, double saturation, double brightness)
		{
			int distance = 360 / steps;
			var colors = new IColorSpace [steps];
			var startColor = new ColorHSB (hue, saturation, brightness);
			colors [0] = startColor;
			for (int i = 1; i < steps; i++) {
				colors [i] = new ColorHSB (
					startColor.H + i * distance,
					startColor.S,
					startColor.B
				);
			}

			return colors;
		}

		public T [] ConvertColorsTo<T> () where T : IColorSpace, new()
		{
			var converted = new T [Colors.Length];

			for (int i = 0; i < Colors.Length; i++) {
				var color = Colors [i];

				var newColorSpace = new T ();
				newColorSpace.Initialize (color.ToRgb ());

				converted [i] = newColorSpace;
			}

			return converted;
		}
		#endregion
	}
}

