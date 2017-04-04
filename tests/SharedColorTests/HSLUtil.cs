using System;
using Styles;

namespace SharedColorTests
{
	public class HSLUtil
	{
		

		public static IHsl ToColorSpace(ColorRGB color)
		{
			var result = ColorHSL.Empty;
			var max = Math.Max(color.R, Math.Max(color.G, color.B));
			var min = Math.Min(color.R, Math.Min(color.G, color.B));

			// hue
			if (max == min)
			{
				result.H = 0d; // undefined
			}
			else if (max == color.R && color.G >= color.B)
			{
				result.H = 60d * (color.G - color.B) / (max - min);
			}
			else if (max == color.R && color.G < color.B)
			{
				result.H = 60d * (color.G - color.B) / (max - min) + 360d;
			}
			else if (max == color.G)
			{
				result.H = 60d * (color.B - color.R) / (max - min) + 120d;
			}
			else if (max == color.B)
			{
				result.H = 60d * (color.R - color.G) / (max - min) + 240d;
			}

			// luminance
			result.L = (max + min) / 2;

			// saturation
			if (result.L == 0 || max == min)
			{
				result.S = 0;
			}
			else if (0 < result.L && result.L <= 0.5)
			{
				result.S = (max - min) / (max + min);
			}
			else if (result.L > 0.5)
			{
				result.S = (max - min) / (2 - (max + min));
			}

			return result;
		}

		// works fine
		public static ColorRGB ToColor(IHsl item)
		{
			if (item.S == 0)
			{
				// achromatic color (gray scale)
				return new ColorRGB(item.L, item.L, item.L, 1);
			}
			else
			{
				double q = (item.L < 0.5) ? (item.L * (1.0 + item.S)) : (item.L + item.S - (item.L * item.S));
				double p = (2 * item.L) - q;

				double Hk = item.H / 360d;
				double[] T = new double[3];
				T[0] = Hk + (1d / 3d);     // Red
				T[1] = Hk;                 // Blue
				T[2] = Hk - (1d / 3d);     // Green

				for (int i = 0; i < 3; i++)
				{
					if (T[i] < 0) T[i] += 1;
					if (T[i] > 1) T[i] -= 1;

					if ((T[i] * 6d) < 1)
					{
						T[i] = p + ((q - p) * 6d * T[i]);
					}
					else if ((T[i] * 2.0) < 1)
					{
						T[i] = q;
					}
					else if ((T[i] * 3d) < 2)
					{
						T[i] = p + (q - p) * ((2 / 3) - T[i]) * 6d;
					}
					else T[i] = p;
				}

				return new ColorRGB(T[0], T[1], T[2], 1);
			}
		}
	}
}
