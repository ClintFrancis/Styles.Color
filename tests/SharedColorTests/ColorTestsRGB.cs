﻿using NUnit.Framework;
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
		public void ParseAlphaHexStringTest()
		{
			var colorHalf = ColorRGB.FromHex("#80FF0000");
			var colorEightyFive = ColorRGB.FromHex("#D9FF0000");

			Assert.AreEqual(colorHalf.A, .5d);
			Assert.AreEqual(colorEightyFive.A, .85d);
		}

		[Test()]
		public void ToAlphaHexStringTest()
		{
			var colorHalf = ColorRGB.FromHex("#7FFF0000");
			var colorEightyFive = ColorRGB.FromHex("#80FF0000");

			Assert.AreEqual(colorHalf.ToAlphaHex(), "#7FFF0000");
			Assert.AreEqual(colorEightyFive.ToAlphaHex(), "#80FF0000");
		}
	}
}
