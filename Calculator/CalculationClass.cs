/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 16.09.2020
 * Time: 7:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic ;
using System.Linq;
using System.Text.RegularExpressions ;

namespace Calculator
{
	/// <summary>
	/// Description of CalculationClass.
	/// </summary>
	public class CalculationClass
	{	
		
		Regex regExNum = new Regex(@"\d+\,?\d*") ; // шаблон для числа
		Stack<string> calcStack = new Stack<string>();
		OperationsKit operKit = new OperationsKit() ;

		
		public string Caculate(List<string> OPL) {
			foreach(string item in OPL) {
				if(regExNum.Match(item).Success)
					calcStack.Push(item) ;
				
				else{
					Operation_ oper = operKit.GetOper(item) ;
					double a = Convert.ToDouble (calcStack.Pop()) ;
					double b = Convert.ToDouble (calcStack.Pop()) ;					
					double res = oper.execute( b , a) ;
					
					calcStack.Push(res.ToString()) ;
					
				}
			}
			
			return calcStack.Pop();
		
		}
	}
}
