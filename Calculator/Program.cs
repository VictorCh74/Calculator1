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
	
				
				ReversePolNoteClass RPNC = new ReversePolNoteClass(expStr , new RegularLineClass( new OperationsKit()) , new OperationsKit()) ;
				string result = new CalculationClass (RPNC , new OperationsKit()).Caculate() ;
				
				
				Console.WriteLine("Результат: " + result) ;
				key = Console.ReadKey(true);
				
			} while( key.KeyChar != 27) ;
		}
	}
}