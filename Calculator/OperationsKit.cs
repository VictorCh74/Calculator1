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
	public class OperationsKit
	{
		List<Operation_> opList = new List<Operation_> () ;
		
		
		public OperationsKit()
		{
			opList.Add(new Sum2()) ;
			opList.Add(new Subst2()) ;
			opList.Add(new Mult2()) ;
			opList.Add(new Div2()) ;
			opList.Add(new Pow2()) ;
			opList.Add(new BracketLeft()) ;
		}
		
		public int GetPriorytiOf(string s) {
			var selection = from op in opList
					where op.signature == s
					select op ;
			
			return  selection.ToList().First().priority;
		}
		
		public 	Operation_ GetOper (string item) {
				var oper =	from Operation_ op in opList
					where op.signature == item
					select op;
					
					return oper.ToList().First() ;
					
		}
		
		public List<string> GetSignatureList () {
				var _signature = from op in opList
								select op.signature ;
				return _signature.ToList() ;
		}
		
	}
}
