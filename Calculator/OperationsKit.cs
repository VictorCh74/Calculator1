/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 13.09.2020
 * Time: 11:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic ;
using System.Linq ;
namespace Calculator
{
	/// <summary>
	/// OperationsKit -- набор методов и аттрибутов арифметических операций.
	/// </summary>
	public class OperationsKit : IKit
	{
		List<IOperation> operationList = new List<IOperation> () ;
		
		
		public OperationsKit()
		{
			operationList.Add(new Sum2()) ;
			operationList.Add(new Subst2()) ;
			operationList.Add(new Mult2()) ;
			operationList.Add(new Div2()) ;
			operationList.Add(new Pow2()) ;
			operationList.Add(new BracketLeft()) ;
			operationList.Add(new Um()) ;
			operationList.Add(new Sin()) ;			

		}
		
		public int GetPriorytiOf(string s) {
			var selection = from op in operationList
					where op.GetSignature() == s
					select op ;
			
			return  selection.ToList().First().GetPriority();
		}
		
		public 	IOperation GetOper (string item) {
				var oper =	from IOperation op in operationList
					where op.GetSignature() == item
					select op;
					
				return oper.ToList().First() ;	
		}
		
		public List<string> GetSignatureList () {
				var _signature = from op in operationList
								select op.GetSignature() ;
				return _signature.ToList() ;
		}
		
		public bool IsAvalable(string s) {
			string avalable = " " ;
			foreach (IOperation op in operationList) {
				avalable = avalable + op.GetSignature() ;
			}
			
			if (avalable.IndexOf(s) == -1) {
				return false ;
			}
			return true ;
		}
		
	}
}
