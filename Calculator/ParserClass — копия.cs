/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 13.09.2020
 * Time: 16:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions ;
using System.Collections.Generic ;
using System.Linq ;

namespace Calculator
{
	/// <summary>
	/// Description of ParserClass.
	/// </summary>
	public class ParserClass
	{
		string expression ;
		string[] separators = {"+" , "-" , "*" , "/" , "^"} ;
		
		
		
		Regex re = new Regex(@"\d[\+ | \* | - | / | ^]\d") ;
		Regex regExNum = new Regex(@" \d*\.\d*") ;
		OperationsKit operKit = new OperationsKit () ;
		public ParserClass(string expression)
		{
			this.expression = expression ;
			TransformString( expression )  ;
		}
		
		// преобразование в обратную полю запись
		List <string> TransformString(string expr) {
			List<string > resLine =  new List<string> () ;
			List<string> operations = new List<string> () ;
			string buffStr = "" ;
			
			buffStr = expr.Replace("+" , "s+s") ;
			buffStr = buffStr.Replace("-" , "s+s") ;
			buffStr = buffStr.Replace("*" , "s*s") ;
			buffStr = buffStr.Replace("/" , "s/s") ;
			buffStr = buffStr.Replace("^" , "s^s") ;
			buffStr = buffStr.Replace("(" , "(s") ;
			buffStr = buffStr.Replace(")" , "s)") ;
			
			
			string[] inputSequence = buffStr.Split('s') ;

			foreach( string s in inputSequence ) {
				//если s - число
				
				Match mm = regExNum.Match(s) ;
				if (regExNum.Match(s).Success){
					resLine.Add(s) ;
					continue ;
				}
						
				var _signature = from op in operKit.opList
						select op.signature ;
				
				//если S - символ арифмет. операции			
				if( _signature.Contains(s)) {
					//внести символ в стэк опреаций
					if(operations.Count == 0){
						operations.Add(s) ;
						continue ;
					}
					
					if(operations.Count != 0 || GetPriorytiOf(s) > GetPriorytiOf(operations[0] )) {
						operations.Add(s) ;
						continue ;
					}
					
					//перенести сиволы из стэка опреаций в выводную строку
					if(GetPriorytiOf(s) <= GetPriorytiOf(operations[0] )){
						foreach(string op in operations ) {
							if(GetPriorytiOf(s) > GetPriorytiOf(op) ) continue ;
							resLine.Add(op) ;							
							operations.Remove(op) ;
						}
						operations.Add(s) ;
					}
				}
				
				if( s == "(" ) {
					operations.Add(s) ;
				}
				
				if( s == ")" ) {
					foreach(string op in operations ) {		
						if(op == "(" ){ 
							operations.Remove(op) ;
							continue ; ;
						}
						resLine.Add(op) ;
						operations.Remove(op) ;
					}
				}			
			}
			
			if(operations.Count !=0) {
				foreach(string op in operations) {
					resLine.Add(op) ;
					operations.Remove(op) ;
				}
			}
			
			return resLine ;
		}
	
		int GetPriorytiOf(string s) {
			var selection = from op in operKit.opList
						where op.signature == s
						select op ;	
			return  selection.ToList().First().priority;
		}
	}
}
