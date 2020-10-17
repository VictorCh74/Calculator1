/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 24.09.2020
 * Time: 15:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using Calculator ;
using System.Collections.Generic ;
using Moq ;

namespace Tests
{
	[TestFixture]
	public class ReversePolNoteClassTest
	{
		class MockOper : IOperation {
			public int GetArgAmmount() {return 0;}
			public string GetSignature () {return "" ;}
			public int GetPriority() {return 0;}
			public double Execute(List<double> a ) { return 0;}
			public bool Infix() {return true;}
		
		}
		
		class mockKit : IKit {
			
			public int GetPriorytiOf(string s) {
				switch(s) {
					case "+": return  2 ;
					case "-": return 2 ;
					case "um" : return 1;
					case "(" : return 1;
					case "sin" : return 4 ;
					default : return 0 ;
				}				
			}
			
			public IOperation GetOper (string item) {
				return new MockOper() ;
			}
			public List<string> GetSignatureList () {return new List<string> 
			                               {"+" , "-" , "um" , "*" , "/" , "sin" , "^"};}
			public bool IsAvalable(string s) {return true;}
		}
		
		
		[Test]
		public void GetRevPolNoteTestMethod()
		{
			
			var kitMock = new Mock<IKit> () ;
			kitMock.Setup(a => a.GetSignatureList()).Returns(new mockKit().GetSignatureList()) ;
			kitMock.Setup(a => a.GetPriorytiOf(It.IsAny<string>())).Returns(new mockKit().GetPriorytiOf(It.IsAny<string>())) ;
			 
			var regLineMock = new Mock<AbstractRegLine> () ;
			regLineMock.Setup(a => a.GetRegString(It.IsAny<string>())).Returns("1+sin(um30)") ;
			
			ReversePolNoteClass revPN = new ReversePolNoteClass ("1+sin(-30)" , regLineMock.Object , kitMock.Object ) ;
			
			List<string> result = revPN.GetRevPolNote() ;
			List<string> pat = new List<string>();
			pat.AddRange(new string[] { "1" , "30" , "um" , "sin" , "+" } );
	
			Assert.AreEqual( pat , result) ;
		}
	}
}
