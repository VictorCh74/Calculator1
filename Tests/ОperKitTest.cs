/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 23.09.2020
 * Time: 16:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using Calculator ;

namespace Tests
{
	[TestFixture]
	public class ОperKitTest
	{
		OperationsKit operKit =  new OperationsKit() ;
		
		[Test]
		public void TestGetPriorytiOf()
		{
			
			int priority = operKit.GetPriorytiOf("(") ;
			
			Assert.AreEqual(1 , priority) ;
			
			priority = operKit.GetPriorytiOf("^") ;
			
			Assert.AreEqual(4 , priority) ;
				
		}
		[Test]
		public void TestGetOper() {

			IExecute oper = operKit.GetOper("+") ;
			
		}
	}
}
