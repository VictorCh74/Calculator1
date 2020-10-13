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
		[Test]
		public void GetRevPolNoteTestMethod()
		{
			ReversePolNoteClass reverseNote = new ReversePolNoteClass( "2+(-(4+5))" , new RegularLineClass(new OperationsKit()) , new OperationsKit()) ;
			
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
