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
		public void TestGetRegString (){
			var lineClass = new RegularLineClass ( new OperationsKit()) ;
			
			string result = lineClass.GetRegString("2+(-(4+5.0))") ;
			
			Assert.AreEqual( "2+(-(4+5,0))" , result) ;
			
		}
	}
}
