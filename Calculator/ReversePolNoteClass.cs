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
	
	public class ReversePolNoteClass : IReverse
	{
		string expression ;

		Regex regExNum = new Regex(@"\d+\,?\d*") ;
		IKit operKit ;
		AbstractRegLine regLIneEntity ;
		
		
		public ReversePolNoteClass(string expression , AbstractRegLine regLIneEntity , IKit operKit )
		{
			this.regLIneEntity = regLIneEntity ;	
			this.expression =  regLIneEntity.GetRegString(expression) ;
			this.operKit = operKit ;
		}
		
		// формирование обратной польской записи в формате списка строк
		public List <string> GetRevPolNote() {
			List<string > resLine =  new List<string> () ;
			Stack<string> operations = new Stack<string> () ;
	
			//сформировать входную последовательность
			string[] inputSequence = FormInputSequence(expression) ;

			foreach( string s in inputSequence ) {
				//если s - число			
				if (regExNum.Match(s).Success){
					resLine.Add(s) ;
					continue ;
				}
						
				//если s - символ арифмет. операции	-- инфиксной (+ - ...)		
				if( operKit.GetSignatureList().Contains(s) && s != "(" )
					ArithmeticOperationHandle (operations , s , ref resLine ) ;
				
					
				if( s == "(" ) 
					 operations.Push(s) ;
				
				if( s == ")" ) 	
					OperationsToResline (operations , ref resLine) ;			
			}
			//если стэк непустой то переписать все в ResLine			 
			while (operations.Count > 0) {
					resLine.Add(operations.Pop()) ;
			} 
			return resLine ;
		}
	
		
		string[] FormInputSequence(string inpitStr ) {
			string buffStr = "" ;
			// "s" -- разделитель лексем.
			buffStr = inpitStr.Replace(operKit.GetSignatureList()[0] , "#"+operKit.GetSignatureList()[0]+"#") ;
			foreach(string sig in operKit.GetSignatureList()){
				buffStr = buffStr.Replace(sig , "#"+sig+"#") ;
			}
			
			buffStr = buffStr.Replace("(" , "(#" ) ;
			buffStr = buffStr.Replace(")" , "#)" ) ;
			buffStr = buffStr.Replace("##" , "#") ;
			buffStr = buffStr.Replace("##" , "#") ;
			
			return buffStr.Split('#') ;
		}
		
		void ArithmeticOperationHandle (Stack<string> operations , string oper , ref List<string > resLine ) {
			//инфиксная операция
			
				//внести символ в стэк опреаций
           	 	if (operations.Count == 0 || operKit.GetPriorytiOf(oper) > operKit.GetPriorytiOf(operations.Peek())) {
            	    operations.Push(oper);
               		 return;
            	}				
            	//перенести сиволы из стэка опреаций в выводную строку
            	if (operKit.GetPriorytiOf(oper) <= operKit.GetPriorytiOf(operations.Peek())) {
                	while (operations.Count > 0) {
                    	if (operKit.GetPriorytiOf(oper) > operKit.GetPriorytiOf(operations.Peek()))
                        	break;
                   	 resLine.Add(operations.Pop());
                	}
                	operations.Push(oper);
            	}	
			
	
			
		}
		
		void OperationsToResline (Stack<string> operations ,  ref List<string > resLine) {
			while (operations.Count > 0) {
				if (operations.Peek() == "(") {
					break; 
				} 
				resLine.Add(operations.Pop()); 
			}
			operations.Pop();
		}
	}
}
