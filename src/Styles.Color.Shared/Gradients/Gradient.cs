using System;
using System.Drawing;

namespace Styles.Color.Shared
{
	// CSS Gradients
	// https://www.w3schools.com/css/css3_gradients.asp

	public class Gradient
	{
		public IRgb[] Colors { get; set; }

		public float[] Locations { get; set; }

		public float[] Alphas { get; set; }

		public bool Reversed { get; set; }

		public PointF ScaleMultiplier { get; set; } = new PointF(1f, 1f);

		public Gradient(IRgb[] colors)
		{
			this.Colors = colors;
		}

		/*
		Picks up and returns the color at the given scale by interpolating the colors.

	   For example, given this color array `[red, green, blue]` and a scale of `0.25` you will get a kaki color.

	   - Parameter scale: A float value between 0.0 and 1.0.
	   - Parameter colorspace: The color space used to mix the colors. By default it uses the RBG color space.
	   - Returns: A DynamicColor object corresponding to the color at the given scale.
	   */
		public IRgb GetColorAt(float position){
			throw new NotImplementedException();
		}

		/**
	   Returns the color palette of `amount` elements by grabbing equidistant colors.

	   - Parameter amount: An amount of colors to return. 2 by default.
	   - Parameter colorspace: The color space used to mix the colors. By default it uses the RBG color space.
	   - Returns: An array of DynamicColor objects with equi-distant space in the gradient.
	   */
		public void CreateColorPalette(int steps, IColorSpace colorspace ) {
			throw new NotImplementedException();
		}
	}

	public class LinearGradient : Gradient
	{
		// -360 -> 0 <- 360
		public float Orientation { get; set; }

		public LinearGradient(IRgb[] colors):base(colors)
		{
			
		}
	}

	public class RadialGradient:Gradient
	{
		public PointF CenterPoint { get; set; }

		public RadialGradient(IRgb[] colors):base(colors)
		{
			
		}
	}
}
