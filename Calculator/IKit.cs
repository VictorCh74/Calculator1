/*
 * Created by SharpDevelop.
 * User: blinov.va
 * Date: 01.10.2020
 * Time: 13:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic ;
using System.Linq ;

namespace Calculator
{
	/// <summary>
	/// Description of IKit.
	/// </summary>
	public interface IKit
	{
		int GetPriorytiOf(string s) ;
		IOperation GetOper (string item) ;
		List<string> GetSignatureList () ;
		
	}
}
