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
		
		IReverse reverseNote ;
		List<string> rpNote ;
		IKit Kit ;
		
		public CalculationClass (IReverse revNote , IKit Kit) {
			reverseNote = revNote ;
			rpNote =  revNote.GetRevPolNote() ;
			this.Kit = Kit ;
		}
		
		
		public string Caculate() {
	
			foreach(string item in rpNote) {
				//если item - число
				if(regExNum.Match(item).Success)
					calcStack.Push(item) ;
				
				else{
					
					List<double> args = new List<double>();
					args = FillArgs( item ) ;
					double res = Kit.GetOper(item).
									 Execute( args ) ;
					calcStack.Push(res.ToString()) ;				
				}
			}		
			return calcStack.Pop();
		}
		
		List<double> FillArgs (string operSign) {
			
			List<double> args = new List<double>();
			for(int i = 0 ; i < Kit.GetOper(operSign).GetArgAmmount() && calcStack.Count > 0; i++) {
				args.Add( Convert.ToDouble (calcStack.Pop())) ;
			}
			return args ;
		}
	}
}
