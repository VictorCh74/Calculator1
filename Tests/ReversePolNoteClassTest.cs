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

namespace Tests
{
	[TestFixture]
	public class ReversePolNoteClassTest
	{
		
		
		class opKit : IKit {
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
		public void GetRevPolNoteTestMethod()
		{
			ReversePolNoteClass reverseNote = new ReversePolNoteClass( "1+sin(-30)" , new RegularLineClass(new OperationsKit()) , new opKit()) ;
			
			List<string> result = reverseNote.GetRevPolNote() ;
			List<string> pat = new System.Collections.Generic.List<string>();
			pat.AddRange(new string[] { "2" ,  "4" , "5" , "+" , "-" , "+"} ) ;
	
			Assert.AreEqual( pat , result) ;
		}
		
		[Test]
		public void GetRevPolNoteTestMethodSin() {
			ReversePolNoteClass reverseNote = new ReversePolNoteClass( "2+(-(4+5)+sin(30))" , new RegularLineClass(new OperationsKit()) , new OperationsKit()) ;
			
			List<string> result = reverseNote.GetRevPolNote() ;
			List<string> pat = new System.Collections.Generic.List<string>();
			pat.AddRange(new string[] { "2" , "4","5", "+" , "-" , "30" ,  "sin" , "+" , "+"} ) ;
	
			Assert.AreEqual( pat , result) ;
		
		}
		
	}
}
