// This file has been autogenerated from a class added in the UI designer.

using System;
using CoreGraphics;
using Styles;
using Styles.Color;
using UIKit;

namespace ColorStyleDemo.iOS
{
	public partial class GradientsViewController : UIViewController
	{
		public GradientsViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var frame = View.Frame;

			var gradientBox = new UIView(new CGRect(0, 60, frame.Width, 200)); ;
			Add(gradientBox);

			var gradient1 = new Gradient(
				new IRgb[]{
					ColorSwatches.DeepOrange,
					ColorSwatches.Yellow
				}
			);

			var gradient2 = new Gradient(
				new IRgb[]{
					ColorSwatches.FlatWhite,
					ColorSwatches.Red.WithAlpha(0)
				}
			);

			var multiGradient = new MultiGradient()
			{
				Gradients = new Gradient[]{
					gradient1.ToLinear(),
					gradient2.ToRadial()
				}
			};

			//var linearLayer = gradient.ToLinear(45).ToNativeLayer(gradientBox.Bounds);
			//gradientBox.Layer.InsertSublayer(linearLayer, 0);

			//var gradientView = gradient1
			//	.ToLinear()
			//	.ToNativeView(new CGRect(0, gradientBox.Frame.Height, gradientBox.Frame.Width, gradientBox.Frame.Height));



			var gradientView = multiGradient.ToNativeView(gradientBox.Bounds);

			Add(gradientView);
		}
	}
}
