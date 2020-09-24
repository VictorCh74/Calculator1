/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 21.09.2020
 * Time: 12:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Calculator ;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class RegularLineClassTest
	{
		[Test]
		public void TestRegularize()
		{
			var lineClass = new RegularLineClass ("1+2.4 -8p *(5+7) ") ;
			
			string result = lineClass.GetRegString() ;
			
			Assert.AreEqual( "1+2,4-8*(5+7)" , result) ;
		}
	}
}
