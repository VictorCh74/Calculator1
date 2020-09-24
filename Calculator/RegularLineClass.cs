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




namespace Calculator
{
	/// <summary>
	/// Description of RegularLineClass.
	/// </summary>
	public class RegularLineClass
	{
		string subjectString ;
	
		constant string avalabeleSymb = "0123456789+-*/^()," ;
		StringBuilder SB ;
		
		public RegularLineClass(string subjectString)
		{
			this.subjectString = subjectString ;		
		}
		
		void Regularize() {
			SB = new StringBuilder(subjectString) ;
			SB = SB.Replace('.' , ',');
			foreach (char c in subjectString) {
				if (avalabeleSymb.IndexOf(c) == -1) {
					SB = SB.Replace( c.ToString() , "") ;
				}
			}
		}
		
		public string GetRegString() {
			Regularize() ;
			return SB.ToString();
		}
		
		
	}
}
