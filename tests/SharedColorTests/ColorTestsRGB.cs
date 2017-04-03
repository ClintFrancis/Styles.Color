using NUnit.Framework;
using System;
using Styles;

namespace SharedColorTests
{
	[TestFixture()]
	public class ColorTestsRGB
	{
		[Test()]
		public void FromHexTest()
		{
			var colorRed = new ColorRGB(1d,0d,0d);
			var colorRedHex = ColorRGB.FromHex("#FF0000");

			Assert.AreEqual(colorRed.R, colorRedHex.R);
			Assert.AreEqual(colorRed.G, colorRedHex.G);
			Assert.AreEqual(colorRed.B, colorRedHex.B);
		}

		[Test()]
		public void ToHexStringTest()
		{
			var colorRed = new ColorRGB(1d, 0d, 0d);
			Assert.AreEqual(colorRed.ToHex(), "#FF0000");
		}

		[Test()]
		public void ParseARGBHexStringTest()
		{
			var colorHalf = ColorRGB.FromHex("#80FF0000");
			var colorEightyFive = ColorRGB.FromHex("#D9FF0000");

			Assert.AreEqual(colorHalf.A, .5d);
			Assert.AreEqual(colorEightyFive.A, .85d);
		}

		[Test()]
		public void ToARGBHexStringTest()
		{
			var colorHalf = ColorRGB.FromHex("#7FFF0000");
			var colorEightyFive = ColorRGB.FromHex("#80FF0000");

			Assert.AreEqual(colorHalf.ToAlphaHex(), "#7FFF0000");
			Assert.AreEqual(colorEightyFive.ToAlphaHex(), "#80FF0000");
		}

		[Test()]
		public void ToRGBColorValueTest()
		{
			var colorRed = ColorRGB.FromHex("#FF0000");
			Assert.AreEqual(colorRed.ValueRGB, 16711680);
		}

		[Test()]
		public void FromRGBToColorTest()
		{
			var colorRed = new ColorRGB(){ ValueRGB = 16711680 };
			Assert.AreEqual(colorRed.ToHex(), "#FF0000");
		}

		[Test()]
		public void ToRGBAColorValueTest()
		{
			var colorRed = new ColorRGB() { ValueARGB = 4294901760 };
			Assert.AreEqual(colorRed.ToAlphaHex(), "#FFFF0000");
		}

		[Test()]
		public void AdjustHueTest(){
			//var color1 = ColorRGB.FromRGB(0x881111).AdjustHue(45);
			//var color2 = ColorRGB.FromRGB(0xc0392b).AdjustHue(90);
			//var color3 = ColorRGB.FromRGB(0xc0392b).AdjustHue(-60);
			var same1 = ColorRGB.FromRGB(0xc0392b).AdjustHue(0);
			var same2 = ColorRGB.FromRGB(0xc0392b).AdjustHue(360);

			//Assert.AreEqual(color1.ToHex(), "#886A11");
			//Assert.AreEqual(color2.ToHex(), "#68c02b");
			//Assert.AreEqual(color3.ToHex(), "#c02bb2");
			Assert.AreEqual(same1.ToHex(), "#C0392B");
			Assert.AreEqual(same2.ToHex(), "#C0392B");
		}
	}
}
