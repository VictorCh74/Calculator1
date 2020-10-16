/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 21.09.2020
 * Time: 12:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic ;
using Calculator ;
using NUnit.Framework;
using Moq;


namespace Tests
{
	[TestFixture]
	public class RegularLineClassTest
	{
		class opKit : IKit {
			public int GetPriorytiOf(string s) {return 0 ;}
			public IOperation GetOper (string item) {
				return new MockOper() ;
			}
			public List<string> GetSignatureList () {return new List<string>() ;}
			public bool IsAvalable(string s) {return true;}
		}
		
		class MockOper : IOperation {
			public int GetArgAmmount() {return 0;}
			public string GetSignature () {return "" ;}
			public int GetPriority() {return 0;}
			public double Execute(List<double> a ) { return 0;}
			public bool Infix() {return true;}
		
		}
		
		[Test]
		public void TestGetRegString (){
			
			const string expression = "1+sin(-30)" ;
			
			var mock = new Mock<IKit> () ;
			mock.Setup(s => s.IsAvalable(It.IsAny<string>())).Returns(true) ;
			RegularLineClass regLine = new RegularLineClass ( mock.Object) ;
			
			string result = regLine.GetRegString(expression) ;
			
			Assert.AreEqual( "1+sin(um30)" , result) ;
			
		}
	}
}
