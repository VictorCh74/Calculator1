/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 24.09.2020
 * Time: 14:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Calculator
{
	/// <summary>
	/// Абстракция для сущности упорядоченной строки
	/// </summary>
	abstract public class AbstractRegLine
	{
		
		abstract public string GetRegString(string s) ;
	}
}
