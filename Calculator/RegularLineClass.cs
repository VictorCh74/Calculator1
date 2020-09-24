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
	public class RegularLineClass : RegLineAbsr
	{
		
		string subjectString ;
	
		string avalabeleSymb = "0123456789+-*/^()," ;
		StringBuilder SB ;
		
		
		void Regularize() {
			
	
			SB = new StringBuilder(subjectString) ;
			SB = SB.Replace('.' , ',');
			foreach (char c in subjectString) {
				if (avalabeleSymb.IndexOf(c) == -1) {
					SB = SB.Replace( c.ToString() , "") ;
				}
			}
			
			subjectString = SB.ToString() ;
			

			
			// работа с отрицательными числами во входном выражении. Замена вида: -2  -> (0-2) или (-2 -> ((0-2)...
			Regex regExp = new Regex (@"^-\d+,?\d*|\(-\d+,?\d*") ;
			MatchCollection mColl = regExp.Matches(subjectString ) ;
			
			foreach (Match m in mColl) {
				
				if(m.Value[0] == '-' )
					subjectString = subjectString.Replace(m.Value , "(0" + m.Value +")") ;
				else	
					subjectString = subjectString.Replace(m.Value , "((0" + m.Value.Substring(1)+")" );
			}

		}
		
		override public string GetRegString(string s) {
			subjectString = s ;
			Regularize() ;
			return subjectString;
		}
		
		
	}
}
