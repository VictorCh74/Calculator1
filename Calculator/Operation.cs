/*
 * Created by SharpDevelop.
 * User: victor
 * Date: 13.09.2020
 * Time: 11:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;


namespace Calculator
{
    /// <summary>
    /// Description of Operation.
    /// </summary>
    
    
   /* public interface IExecute {
    	string signature {get ; set ;}
    	double Execute(double a , double b) ;
    }*/
    
    public interface IOperation
    {
    	int GetArgAmmount() ;
    	string GetSignature () ;
    	int GetPriority() ;
    	double Execute(double[] a ) ;
    	
    }
   	
    public class Sum2 : IOperation   {
   
    	public int GetArgAmmount() {return 2;}
  
   		public string GetSignature () { return "+" ;}
   		public int GetPriority() {return 2 ;}
   		
   		public double Execute ( double[] a ) {
   			if(a.Length != GetArgAmmount() )
   				throw new Exception("Неверное число операндов !!") ;
   			return a[0] + a[0] ;
        }
    }
    
    public class Subst2  : IOperation   {
    	
    	public int GetArgAmmount() {return  2 ;}
  		
    	public string GetSignature () { return "-" ;}
    	public int GetPriority() {return 2 ;}
    	
    	
        public double Execute ( double[] a ) {
    		if(a.Length != GetArgAmmount() )
   				throw new Exception("Неверное число операндов !!") ;
    		return a[0] - a[1] ;
        }
    }
    
    public class Mult2  : IOperation   {

    	public int GetArgAmmount()  {return 2 ;}
    	
    	public string GetSignature () { return "*" ;}
    	public int GetPriority() {return 2 ;}    	
    	
        public double Execute ( double[] a) {
            if(a.Length != GetArgAmmount() )
   				throw new Exception("Неверное число операндов !!") ;
            return a[0] * a[1] ;
        }
    }
    
    public class Div2  : IOperation   {
 
    	public int GetArgAmmount()  {return 2 ;}
 
    	public string GetSignature () { return "/" ;}
    	public int GetPriority() {return 2 ;}    	    	
    	
        public double Execute (  double[] a ) {
            if(a.Length != GetArgAmmount() )
   				throw new Exception("Неверное число операндов !!") ;
            return a[0] / a[1] ;
        }
    }
    
    public class Pow2  : IOperation   {
 
    	public int GetArgAmmount() {return  2 ;}
    	
    	public string GetSignature () { return "^" ;}
    	public int GetPriority() {return 4 ;}
 
        public double Execute ( double[] a ) {
            if(a.Length != GetArgAmmount() )
   				throw new Exception("Неверное число операндов !!") ;
            return Math.Pow ( a[0] , a[1] ) ;
        }
    }
    
    public class Sin : IOperation   {
 
    	public int GetArgAmmount() {return  1 ;}

    	public string GetSignature () { return "sin" ;}
    	public int GetPriority() {return 4 ;}    	
 
        public double Execute ( double[] a ) {
            if(a.Length != GetArgAmmount() )
   				throw new Exception("Неверное число операндов !!") ;
            return Math.Sin( a[0] ) ;
        }
    }
    
    //унарный минус
    public class Um : IOperation   {
 
    	public int GetArgAmmount() {return  1 ;}

    	public string GetSignature () { return "um" ;}
    	public int GetPriority() {return 1 ;}    	
 
        public double Execute ( double[] a ) {
            if(a.Length != GetArgAmmount() )
   				throw new Exception("Неверное число операндов !!") ;
            return  -a[0]  ;
        }
    }
    
    
	public class BracketLeft  : IOperation {

    	public int GetArgAmmount() { return  1 ;}
    	
    	public string GetSignature () { return "(" ;}
    	public int GetPriority() {return 1 ;}   

    	
    	 public double Execute ( double[] a ) {
    		if(a != null )
   				throw new Exception("Невернный операнд !!") ;
            return 0 ;
    	}
    }  
}
