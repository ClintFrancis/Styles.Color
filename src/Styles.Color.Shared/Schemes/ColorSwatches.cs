using System;
namespace Styles.Color
{
	public struct Swatch
	{
		public IColorSpace Color { get; set; }
		public string Name { get; set; }

		public Swatch(string name, IColorSpace color)
		{
			Name = name;
			Color = color;
		}
	}

	public static class ColorSwatches
	{
		// Light colors
		public static readonly ColorHSB FlatBlack = new ColorHSB (0, 0, 17);
		public static readonly ColorHSB FlatBlue = new ColorHSB (224, 50, 63);
		public static readonly ColorHSB FlatBrown = new ColorHSB (24, 45, 37);
		public static readonly ColorHSB FlatCoffee = new ColorHSB (25, 31, 64);
		public static readonly ColorHSB FlatForestGreen = new ColorHSB (138, 45, 37);
		public static readonly ColorHSB FlatGray = new ColorHSB (184, 10, 65);
		public static readonly ColorHSB FlatGreen = new ColorHSB (145, 77, 80);
		public static readonly ColorHSB FlatLime = new ColorHSB (74, 70, 78);
		public static readonly ColorHSB FlatMagenta = new ColorHSB (283, 51, 71);
		public static readonly ColorHSB FlatMaroon = new ColorHSB (5, 65, 47);
		public static readonly ColorHSB FlatMint = new ColorHSB (168, 86, 74);
		public static readonly ColorHSB FlatNavyBlue = new ColorHSB (210, 45, 37);
		public static readonly ColorHSB FlatOrange = new ColorHSB (28, 85, 90);
		public static readonly ColorHSB FlatPink = new ColorHSB (324, 49, 96);
		public static readonly ColorHSB FlatPlum = new ColorHSB (300, 45, 37);
		public static readonly ColorHSB FlatPowderBlue = new ColorHSB (222, 24, 95);
		public static readonly ColorHSB FlatPurple = new ColorHSB (253, 52, 77);
		public static readonly ColorHSB FlatRed = new ColorHSB (6, 74, 91);
		public static readonly ColorHSB FlatSand = new ColorHSB (42, 25, 94);
		public static readonly ColorHSB FlatSkyBlue = new ColorHSB (204, 76, 86);
		public static readonly ColorHSB FlatTeal = new ColorHSB (195, 55, 51);
		public static readonly ColorHSB FlatWatermelon = new ColorHSB (356, 53, 94);
		public static readonly ColorHSB FlatWhite = new ColorHSB (192, 2, 95);
		public static readonly ColorHSB FlatYellow = new ColorHSB (48, 99, 100);

		// Dark colors
		public static readonly ColorHSB FlatBlackDark = new ColorHSB (0, 0, 15);
		public static readonly ColorHSB FlatBlueDark = new ColorHSB (224, 56, 51);
		public static readonly ColorHSB FlatBrownDark = new ColorHSB (25, 45, 31);
		public static readonly ColorHSB FlatCoffeeDark = new ColorHSB (25, 34, 56);
		public static readonly ColorHSB FlatForestGreenDark = new ColorHSB (135, 44, 31);
		public static readonly ColorHSB FlatGrayDark = new ColorHSB (184, 10, 55);
		public static readonly ColorHSB FlatGreenDark = new ColorHSB (145, 78, 68);
		public static readonly ColorHSB FlatLimeDark = new ColorHSB (74, 81, 69);
		public static readonly ColorHSB FlatMagentaDark = new ColorHSB (282, 61, 68);
		public static readonly ColorHSB FlatMaroonDark = new ColorHSB (4, 68, 40);
		public static readonly ColorHSB FlatMintDark = new ColorHSB (168, 86, 63);
		public static readonly ColorHSB FlatNavyBlueDark = new ColorHSB (210, 45, 31);
		public static readonly ColorHSB FlatOrangeDark = new ColorHSB (24, 100, 83);
		public static readonly ColorHSB FlatPinkDark = new ColorHSB (327, 57, 83);
		public static readonly ColorHSB FlatPlumDark = new ColorHSB (300, 46, 31);
		public static readonly ColorHSB FlatPowderBlueDark = new ColorHSB (222, 28, 84);
		public static readonly ColorHSB FlatPurpleDark = new ColorHSB (253, 56, 64);
		public static readonly ColorHSB FlatRedDark = new ColorHSB (6, 78, 75);
		public static readonly ColorHSB FlatSandDark = new ColorHSB (42, 30, 84);
		public static readonly ColorHSB FlatSkyBlueDark = new ColorHSB (204, 78, 73);
		public static readonly ColorHSB FlatTealDark = new ColorHSB (196, 54, 45);
		public static readonly ColorHSB FlatWatermelonDark = new ColorHSB (358, 61, 85);
		public static readonly ColorHSB FlatWhiteDark = new ColorHSB (204, 5, 78);
		public static readonly ColorHSB FlatYellowDark = new ColorHSB (40, 100, 100);

		public static ColorHSB [] FlatColors = new ColorHSB [] { FlatBlack, FlatBlackDark, FlatBlue, FlatBlueDark, FlatBrown, FlatBrownDark, FlatCoffee, FlatCoffeeDark, FlatForestGreen, FlatForestGreenDark, FlatGray, FlatGrayDark, FlatGreen, FlatGreenDark, FlatLime, FlatLimeDark, FlatMagenta, FlatMagentaDark, FlatMaroon, FlatMaroonDark, FlatMint, FlatMintDark, FlatNavyBlue, FlatNavyBlueDark, FlatOrange, FlatOrangeDark, FlatPink, FlatPinkDark, FlatPlum, FlatPlumDark, FlatPowderBlue, FlatPowderBlueDark, FlatPurple, FlatPurpleDark, FlatRed, FlatRedDark, FlatSand, FlatSandDark, FlatSkyBlue, FlatSkyBlueDark, FlatTeal, FlatTealDark, FlatWatermelon, FlatWatermelonDark, FlatWhite, FlatWhiteDark, FlatYellow, FlatYellowDark };


		// Secondard Colors TDB
		public static ColorRGB Red { get { return new ColorRGB(241, 69, 61); } }
		public static ColorRGB Pink { get { return new ColorRGB(230, 37, 101); } }
		public static ColorRGB Purple { get { return new ColorRGB(155, 47, 174); } }
		public static ColorRGB DeepPurple { get { return new ColorRGB(103, 63, 180); } }
		public static ColorRGB Indigo { get { return new ColorRGB(64, 84, 178); } }
		public static ColorRGB Blue { get { return new ColorRGB(43, 152, 240); } }
		public static ColorRGB LightBlue { get { return new ColorRGB(30, 170, 241); } }
		public static ColorRGB Cyan { get { return new ColorRGB(31, 188, 210); } }
		public static ColorRGB Teal { get { return new ColorRGB(21, 149, 136); } }
		public static ColorRGB Green { get { return new ColorRGB(80, 174, 85); } }
		public static ColorRGB LightGreen { get { return new ColorRGB(140, 193, 82); } }
		public static ColorRGB Lime { get { return new ColorRGB(205, 218, 73); } }
		public static ColorRGB Yellow { get { return new ColorRGB(254, 233, 78); } }
		public static ColorRGB Amber { get { return new ColorRGB(253, 192, 47); } }
		public static ColorRGB Orange { get { return new ColorRGB(253, 151, 39); } }
		public static ColorRGB DeepOrange { get { return new ColorRGB(252, 88, 48); } }
		public static ColorRGB Brown { get { return new ColorRGB(120, 85, 73); } }
		public static ColorRGB Grey { get { return new ColorRGB(158, 158, 158); } }
		public static ColorRGB BlueGrey { get { return new ColorRGB(97, 125, 138); } }

		public static ColorRGB [] FlatColors2 = new ColorRGB []{
			   Red.Lightened(),          Red.Darkened(),
			   Pink.Lightened(),         Pink.Darkened(),
			   Purple.Lightened(),       Purple.Darkened(),
			   DeepPurple.Lightened(),   DeepPurple.Darkened(),
			   Indigo.Lightened(),       Indigo.Darkened(),
			   Blue.Lightened(),         Blue.Darkened(),
			   LightBlue.Lightened(),    LightBlue.Darkened(),
			   Cyan.Lightened(),         Cyan.Darkened(),
			   Teal.Lightened(),         Teal.Darkened(),
			   Green.Lightened(),        Green.Darkened(),
			   LightGreen.Lightened(),   LightGreen.Darkened(),
			   Lime.Lightened(),         Lime.Darkened(),
			   Yellow.Lightened(),       Yellow.Darkened(),
			   Amber.Lightened(),        Amber.Darkened(),
			   Orange.Lightened(),       Orange.Darkened(),
			   DeepOrange.Lightened(),   DeepOrange.Darkened(),
			   Brown.Lightened(),        Brown.Darkened(),
			   Grey.Lightened(),         Grey.Darkened(),
			   BlueGrey.Lightened(),     BlueGrey.Darkened()
		};
	}
}

