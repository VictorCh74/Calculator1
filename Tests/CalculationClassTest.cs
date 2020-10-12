/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 24.09.2020
 * Time: 15:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using Calculator ;

//"2" , "3" , "4" ,  "+" , "*" , "10" , "+"} ) ;
	

namespace Tests
{
	[TestFixture]
	public class CalculationClassTest
	{
		[Test]
		public void TestMethod()
		{
			
			ReversePolNoteClass revNote = new ReversePolNoteClass( "-2*(6+4)+10,5" , new RegularLineClass(new OperationsKit()) , new OperationsKit()) ;
			CalculationClass CC = new CalculationClass( revNote  , new OperationsKit()) ;
			
			string result = CC.Caculate() ;
			Assert.AreEqual("-9,5" , result ) ;
		}
	}
}
