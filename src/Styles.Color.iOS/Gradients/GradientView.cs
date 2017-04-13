using System;
using CoreGraphics;
using UIKit;

namespace Styles.Color
{
	public class GradientView:UIView
	{
		public GradientType Type { get; private set;}

		LinearGradient linearGradient;
		RadialGradient radialGradient;
		MultiGradient multiGradient;

		public GradientView(LinearGradient gradient)
		{
			this.linearGradient = gradient;
			Type = GradientType.Linear;
			BackgroundColor = UIColor.Clear;
		}

		public GradientView(RadialGradient gradient)
		{
			this.radialGradient = gradient;
			Type = GradientType.Radial;
			BackgroundColor = UIColor.Clear;
		}

		public GradientView(MultiGradient gradient)
		{
			this.multiGradient = gradient;
			Type = GradientType.Multi;
			BackgroundColor = UIColor.Clear;
		}

		public override void Draw(CGRect rect)
		{
			base.Draw(rect);

			using (CGContext ctx = UIGraphics.GetCurrentContext())
			{
				switch (Type)
				{
					case GradientType.Linear:
						linearGradient.Draw(ctx, rect);
						break;
					case GradientType.Radial:
						radialGradient.Draw(ctx, rect);
						break;
					case GradientType.Multi:
						multiGradient.Draw(ctx, rect);
						break;
					default:
						throw new NotImplementedException("The target gradient type is not supported: " + Type);
				}
			}
		}
	}
}
