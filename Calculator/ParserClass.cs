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
	
	public class ParserClass
	{
		string expression ;

		Regex regExNum = new Regex(@"\d+\,?\d*") ;
		OperationsKit operKit = new OperationsKit () ;
		
		public ParserClass(string expression)
		{
			RegularLineClass regLine = new RegularLineClass(expression) ;
			this.expression =  regLine.GetRegString() ;
		}
		
		// формирование обратной польской записи в формате списка строк
		public List <string> TransformString(string expr) {
			List<string > resLine =  new List<string> () ;
			Stack<string> operations = new Stack<string> () ;
	
			//сформировать входную последовательность
			string[] inputSequence = ForminputSequence(expr) ;

			foreach( string s in inputSequence ) {
				//если s - число			
				if (regExNum.Match(s).Success){
					resLine.Add(s) ;
					continue ;
				}
						
				//если s - символ арифмет. операции			
				if( operKit.GetSignatureList().Contains(s)) {
					
					//внести символ в стэк опреаций
					if(operations.Count == 0 || operKit.GetPriorytiOf(s) > operKit.GetPriorytiOf(operations.Peek() )) {
						operations.Push(s) ;
						continue ;
					}
					
					//перенести сиволы из стэка опреаций в выводную строку
					if(operKit.GetPriorytiOf(s) <= operKit.GetPriorytiOf(operations.Peek() )){
						
						
						while(operations.Count > 0){
							if(	operKit.GetPriorytiOf(s) > operKit.GetPriorytiOf(operations.Peek() ))
							   break;
							resLine.Add(operations.Pop()) ;
						}
						
						operations.Push(s) ;
					}
				}
				
				if( s == "(" ) {
					operations.Push(s) ;
				}
				
				if( s == ")" ) {
					
					int removeCount = operations.Count-1 ;
					for(;; removeCount--) {
						if(operations.Peek() == "(" ){
							break ; 
						} ;
						resLine.Add(operations.Pop()) ; 
					}
					operations.Pop() ;
				}			
			}
			
			if(operations.Count !=0) {
				 
				int removeCount = operations.Count ;
					for(;removeCount > 0; removeCount--) {
					resLine.Add(operations.Pop()) ;
				}
			}
			
			return resLine ;
		}
	
		
		string[] ForminputSequence(string inpitStr ) {
			string buffStr = "" ;
			// "s" -- разделитель лексем.
			buffStr = inpitStr.Replace(operKit.GetSignatureList()[0] , "s"+operKit.GetSignatureList()[0]+"s") ;
			foreach(string sig in operKit.GetSignatureList()){
				buffStr = buffStr.Replace(sig , "s"+sig+"s") ;
			}
			
			buffStr = buffStr.Replace("(" , "(s" ) ;
			buffStr = buffStr.Replace(")" , "s)" ) ;
			buffStr = buffStr.Replace("ss" , "s") ;
			buffStr = buffStr.Replace("ss" , "s") ;
			
			string[] sequence = buffStr.Split('s') ;
			
			return sequence;
		}
	}
}
