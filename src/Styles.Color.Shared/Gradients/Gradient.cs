using System;
using System.Drawing;

namespace Styles.Color
{
	// CSS Gradients
	// https://www.w3schools.com/css/css3_gradients.asp

	public enum GradientType
	{
		Linear,
		Radial,
		Multi,
		Custom
	}

	public class Gradient
	{
		public GradientType Type { get; private set;}

		public IRgb[] Colors { get; set; }

		public float[] Locations { get; set; } = new float[0];

		public bool Reversed { get; set; }

		public bool Repeating { get; set; }	

		public PointF ScaleMultiplier { get; set; } = new PointF(1f, 1f);

		public Gradient(IRgb[] colors)
		{
			this.Colors = colors;
		}

		public void Update()
		{
			if (Locations.Length == 0)
			{
				float stepSize = 1f / (Colors.Length - 1f);
				float currentStep = 0;
				Locations = new float[Colors.Length];

				for (int i = 0; i < Colors.Length; i++)
				{
					Locations[i] = currentStep;
					currentStep += stepSize;
				}
			} else if (Locations.Length != Colors.Length)
			{
				throw new Exception("Gradient Colors length is not equal to its Locations length");
			}
		}

		public static Gradient FromColors<T>(IColorSpace[] colors)
		{
			throw new NotImplementedException();
		}

		public LinearGradient ToLinear(double orientation = 0)
		{
			return new LinearGradient(this.Colors, orientation) { Locations = this.Locations };
		}

		public RadialGradient ToRadial(float locationX = .5f, float locationY = .5f)
		{
			return new RadialGradient(this.Colors, locationX, locationY){ Locations = this.Locations };
		}

		public void ShiftHues(double value)
		{
			throw new NotImplementedException();	
		}

		/*
		Picks up and returns the color at the given scale by interpolating the colors.

	   For example, given this color array `[red, green, blue]` and a scale of `0.25` you will get a kaki color.

	   - Parameter scale: A float value between 0.0 and 1.0.
	   - Parameter colorspace: The color space used to mix the colors. By default it uses the RBG color space.
	   - Returns: A DynamicColor object corresponding to the color at the given scale.
	   */
		public IRgb GetColorAt(float percent){
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns a color palette of x steps by selecting equidistant colors.
		/// </summary>
		/// <returns>Array of IColorSpace colors</returns>
		/// <param name="steps">The number of color steps to return. 2 by default</param>
		/// <typeparam name="T">The target ColorSpace type</typeparam>
		public T[] CreateColorPalette<T>(int steps = 2) where T : IColorSpace {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns a color IRgb palette of x steps by selecting equidistant colors.
		/// </summary>
		/// <returns>Array of IRgb colors</returns>
		/// <param name="steps">The number of color steps to return. 2 by default</param>
		public IRgb[] CreateColorPalette(int steps = 2)
		{
			throw new NotImplementedException();
		}
	}

	public class LinearGradient : Gradient
	{
		// -360 -> 0 <- 360
		public double Rotation { get; set; }

		public LinearGradient(IRgb[] colors, double rotation):base(colors)
		{
			Rotation = rotation;
		}

		//public static LinearGradient FromColors<T>(IColorSpace[] colors, double Orientation)
		//{
		//	throw new NotImplementedException();
		//}
	}

	public class RadialGradient:Gradient
	{
		public PointF Location { get; set; }

		public RadialGradient(IRgb[] colors):base(colors)
		{
			Location = new PointF(0, 0);
		}

		public RadialGradient(IRgb[] colors, float locationX, float locationY):base(colors)
		{
			Location = new PointF(locationX, locationY);
		}

		//public RadialGradient(IRgb[] colors, PointF location):base(colors)
		//{
		//	Location = location;
		//}

		//public static RadialGradient FromColors<T>(IColorSpace[] colors, PointF center)
		//{
		//	throw new NotImplementedException();
		//}
	}

	public class MultiGradient
	{
		public Gradient[] Gradients { get; set; } // Do I need to bother with this? could I just Set this up as an extension to Gradient[]'s?
		// todo consider how offset points, radius, etc would work with these - do i need to extend the base classes?
	}
}
