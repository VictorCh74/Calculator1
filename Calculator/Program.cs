/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 13.09.2020
 * Time: 11:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic ;


namespace Calculator
{
	class Program
	{	
		
		public static void Main(string[] args)
		{	ConsoleKeyInfo key ;
			Console.Write("[Выход -- ESC\n");
			do{
				
				Console.Write("Ввод выражения: ");
				string expStr = Console.ReadLine();
	
				
				ParserClass PC = new ParserClass(expStr , new RegularLineClass()) ;
				List<string> revPolNot = PC.GetRevPolNote() ;
				/*CalculationClass CalcCl = new CalculationClass () ;
				string result = CalcCl.Caculate(revPolNot) ;
				Console.WriteLine("Результат: " + result) ;*/
				key = Console.ReadKey(true);
			} while( key.KeyChar != 27) ;
		}
	}
}