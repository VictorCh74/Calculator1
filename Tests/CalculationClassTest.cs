/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 24.09.2020
 * Time: 15:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Calculator ;
using Moq ;

//"2" , "3" , "4" ,  "+" , "*" , "10" , "+"} ) ;
	

namespace Tests
{
	[TestFixture]
	public class CalculationClassTest
	{
		class MockNote: IReverse{
			//1+sin(-30)
			List <string> Note = new List <string> () { "1" , "30" , "um" , "sin" , "+" } ;
			public List <string> GetRevPolNote() {
				return Note ;
			}
		}
		
		class  mockOpKit : IKit {
			public int GetPriorytiOf(string s) {return 0 ;}
			public IOperation GetOper (string item) {
				if (item == "sin")
					return new Sin() ;
				if (item == "+")
					return new Sum2() ;
				if (item == "-")
					return new Subst2() ;
				return new Um() ;
			}
			
			public List<string> GetSignatureList () {return new List<string>() ;}
			public bool IsAvalable(string s) {return true;}
			
		}
		
		
		[Test]
		public void TestMethod()
		{	
			var mockRPL =  new Mock<IReverse> () ;
			mockRPL.Setup(a => a.GetRevPolNote()).
					Returns(new List <string> () { "1" , "30" , "um" , "sin" , "+" } ) ;
			
			Mock mockRevNote = new Mock <MockNote>() ;
			
			CalculationClass CC = new CalculationClass( mockRPL.Object  , new mockOpKit()) ;
					
			string result = CC.Caculate() ;
			
			Assert.AreEqual("0,5" , result ) ;
		}
	}
}
