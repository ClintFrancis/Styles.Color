using System;
using System.Collections.Generic;
using Styles.Color;

namespace Styles.Color
{
	public class ColorScheme
	{
		internal const string PrimaryColorID = "primary";

		// TODO store colors by name, have each color scheme name their steps as a constant
		public Dictionary<string, IRgb> Colors { get; set; } = new Dictionary<string, IRgb>();

		#region OLD Parameters
		public ColorSchemeType Type { get; internal set; }
		public string Name { get; set; }
		//public int PrimaryIndex { get; internal set; }
		//public IRgb [] Colors { get; set; }

		public IRgb PrimaryColor { get { return Colors [PrimaryColorID]; } }

		#endregion

		#region Methods

		public virtual void SetColors (Swatch [] colors) 
		{
			foreach (var color in colors)
			{
				Colors[color.Name] = color.Color.ToRgb();
			}
		}

		public virtual void SetPrimaryColor(IRgb primary)
		{
			Colors[PrimaryColorID] = primary;
		}

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
				throw new ArgumentException ("Unsupported ColorSchemeType supplied " + type);
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
			var totalColors = Colors.Count;
			var converted = new T [totalColors];
			int count = 0;

			foreach (var color in Colors.Values)
			{
				var newColorSpace = new T();
				newColorSpace.Initialize(color.ToRgb());

				converted[count] = newColorSpace;
				count++;
			}

			return converted;
		}
		#endregion
	}
}

