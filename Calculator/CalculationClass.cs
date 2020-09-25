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
	/// Класс вычисления. Входной параметр метода Calculate -- обратная польская запись в виде списка строк-лесем.
	/// </summary>
	public class CalculationClass
	{	
		
		Regex regExNum = new Regex(@"\d+\,?\d*") ; // шаблон для числа
		Stack<string> calcStack = new Stack<string>();
		OperationsKit operKit = new OperationsKit() ;
		IReverse reverseNote ;
		List<string> OPN ;
		
		public CalculationClass (IReverse revNote) {
			reverseNote = revNote ;
			OPN =  revNote.GetRevPolNote() ;
		}
		
		
		public string Caculate() {
			foreach(string item in OPN) {
				if(regExNum.Match(item).Success)
					calcStack.Push(item) ;
				
				else{
					double arg2 = Convert.ToDouble (calcStack.Pop()) ;
					double arg1 = Convert.ToDouble (calcStack.Pop()) ;					
					double res = operKit.GetOper(item).execute( arg1 , arg2) ;
					
					calcStack.Push(res.ToString()) ;
					
				}
			}
			
			return calcStack.Pop();
		
		}
	}
}
