using System;
using System.Drawing;

namespace Styles.Color
{
	// CSS Gradients
	// https://www.w3schools.com/css/css3_gradients.asp

	public enum GradientType
	{
		None,
		Linear,
		Radial,
		Multi,
		Custom
	}

	public class ColorOffset
	{
		public IRgb Color { get; set;}
		public double Offset { get; set;}

		public ColorOffset(IRgb color, double offset)
		{
			Color = color;
			Offset = offset;
		}	
	}

	public class Gradient
	{
		public GradientType Type { get; protected set;}

		public IRgb[] Colors { get; set; }

		public float[] Locations { get; set; } = new float[0];

		// TODO Reversed
		public bool Reversed { get; set; }

		// TODO repeating
		public bool Repeating { get; set; }	

		// TODO ScaleMultipliers
		public PointF ScaleMultiplier { get; set; } = new PointF(1f, 1f);

		public ColorOffset[] Offsets 
		{
			get{
				var offsets = new ColorOffset[Colors.Length];
				for (int i = 0; i< Colors.Length; i++)
				{
					offsets[i] = new ColorOffset(Colors[i], Locations[i]);
				}
				return offsets;
			}
		}

		public Gradient(IRgb[] colors)
		{
			this.Colors = colors;
		}

		public void Update()
		{
			// todo check for colors == 2 as well
			if (Colors.Length < 2)
			{
				throw new Exception("Gradients must contain a minimum of two colors");
			}

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

		public Gradient ShiftHues(double value)
		{
			var target = this.Clone();
			for (int i = 0; i < target.Colors.Length; i++)
			{
				target.Colors[i] = target.Colors[i].AdjustHue(value);
			}

			return target;
		}

		/// <summary>
		/// Returns the color at the given scale by interpolating the colors.
		/// </summary>
		/// <returns>IRgb<see cref="T:Styles.IRgb"/>.</returns>
		/// <param name="percent">Percent</param>
		public IRgb GetColorAt(double percent){
			return GradientUtils.GetColorByOffset(this, percent);
		}

		/// <summary>
		/// Returns a color IRgb palette of x steps by selecting equidistant colors.
		/// </summary>
		/// <returns>Array of IRgb colors</returns>
		/// <param name="steps">The number of color steps to return. 2 by default</param>
		public IRgb[] CreateColorPalette(int steps = 2)
		{
			var stepSize = 1.0 / steps;
			var colorPalette = new IRgb[steps];
			for (int i = 0; i < steps; i++)
			{
				var step = stepSize * i;
				colorPalette[i] = GradientUtils.GetColorByOffset(this, step);
			}

			return colorPalette;
		}

		public Gradient Clone()
		{
			return new Gradient((IRgb[])Colors.Clone())
			{
				Locations = this.Locations,
				Reversed = this.Reversed,
				Repeating = this.Repeating,
				ScaleMultiplier = this.ScaleMultiplier
			};
		}
	}

	public class LinearGradient : Gradient
	{
		// -360 -> 0 <- 360
		public double Rotation { get; set; }

		public LinearGradient(IRgb[] colors, double rotation):base(colors)
		{
			Rotation = rotation;
			Type = GradientType.Linear;
		}

		new public LinearGradient Clone()
		{
			return new LinearGradient((IRgb[])Colors.Clone(), this.Rotation)
			{
				Locations = this.Locations,
				Reversed = this.Reversed,
				Repeating = this.Repeating,
				ScaleMultiplier = this.ScaleMultiplier
			};
		}
	}

	public class RadialGradient:Gradient
	{
		public PointF Location { get; set; }

		public RadialGradient(IRgb[] colors):base(colors)
		{
			Location = new PointF(0, 0);
			Type = GradientType.Radial;
		}

		public RadialGradient(IRgb[] colors, float locationX, float locationY):base(colors)
		{
			Location = new PointF(locationX, locationY);
			Type = GradientType.Radial;
		}

		new public RadialGradient Clone()
		{
			return new RadialGradient((IRgb[])Colors.Clone(), this.Location.X, this.Location.Y)
			{
				Locations = this.Locations,
				Reversed = this.Reversed,
				Repeating = this.Repeating,
				ScaleMultiplier = this.ScaleMultiplier
			};
		}
	}

	public class MultiGradient
	{
		public Gradient[] Gradients { get; set; } // Do I need to bother with this? could I just Set this up as an extension to Gradient[]'s?
		// todo consider how offset points, radius, etc would work with these - do i need to extend the base classes?
	}
}
