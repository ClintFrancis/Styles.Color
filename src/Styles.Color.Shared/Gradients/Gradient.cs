using System;
namespace Styles.Color.Shared
{
	//public class Gradient : NSObject
	//{
	//	public nfloat[] Locations { get; set; } = { 0.0f, 1.0f };
	//	public UIColor[] Colors { get; set; } = { UIColor.White, UIColor.LightGray };
	//	public CGPoint CenterPoint { get; set; } = new CGPoint(.5f, .5f);
	//	public CGPoint ScaleMultiplier { get; set; } = new CGPoint(1f, 1f);
	//}

	public class Gradient
	{
		public IRgb[] Colors { get; set; }

		public Gradient()
		{
		}
	}

	public class RadialGradient:Gradient{
		public RadialGradient(){
			
		}
	}
}
