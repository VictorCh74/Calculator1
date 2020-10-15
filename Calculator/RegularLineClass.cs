/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 21.09.2020
 * Time: 8:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;
using System.Text.RegularExpressions ;




namespace Calculator
{
	/// <summary>
	///Класс упорядочения входной строки
	/// </summary>
	public class RegularLineClass : AbstractRegLine
	{
		IKit OpKit ;
		string subjectString ;	
		
		public RegularLineClass (IKit OpKit) {
			this.OpKit = OpKit ;
		}
		
		void RplacePoints() {
		
			subjectString = subjectString.Replace('.' , ',');
			//удаление всех других неарифметических символов (опечаток)
			foreach (char c in subjectString) {
				if (!OpKit.IsAvalable(c.ToString())) {
					subjectString = subjectString.Replace( c.ToString() , "") ;
				}
			}
		}
		
		void SetUnarMinus() {
			StringBuilder SB = new StringBuilder(subjectString) ;
			
			if(SB[0] == '-') {
				SB[0] = 'u';
			}
			SB.Replace("(-" , "(u") ;
			subjectString = SB.ToString() ;
			subjectString = subjectString.Replace("u" , "um") ;
			SB=null ;
		}
		
		override public string GetRegString(string s) {
			subjectString = s ;
			 RplacePoints() ;
			 SetUnarMinus() ;
			 return subjectString;
		}
		
		
	}
}
