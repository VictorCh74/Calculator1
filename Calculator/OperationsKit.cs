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
		List<IOperation> prirityAndSignList = new List<IOperation> () ;
		List<IExecute> executeAndSignList = new List<IExecute> () ;
		
		public OperationsKit()
		{
			prirityAndSignList.Add(new Sum2()) ;
			prirityAndSignList.Add(new Subst2()) ;
			prirityAndSignList.Add(new Mult2()) ;
			prirityAndSignList.Add(new Div2()) ;
			prirityAndSignList.Add(new Pow2()) ;
			prirityAndSignList.Add(new BracketLeft()) ;

			
			executeAndSignList.Add(new Sum2()) ;
			executeAndSignList.Add(new Subst2()) ;
			executeAndSignList.Add(new Mult2()) ;
			executeAndSignList.Add(new Div2()) ;
			executeAndSignList.Add(new Pow2()) ;
		}
		
		public int GetPriorytiOf(string s) {
			var selection = from op in prirityAndSignList
					where op.signature == s
					select op ;
			
			return  selection.ToList().First().priority;
		}
		
		public 	IExecute GetOper (string item) {
				var oper =	from IExecute op in executeAndSignList
					where op.signature == item
					select op;
					
					return oper.ToList().First() ;
					
		}
		
		public List<string> GetSignatureList () {
				var _signature = from op in prirityAndSignList
								select op.signature ;
				return _signature.ToList() ;
		}
		
	}
}
