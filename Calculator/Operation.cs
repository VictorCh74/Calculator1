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
    
    
    public interface IExecute {
    	string signature {get ; set ;}
    	double Execute(double a , double b) ;
    }
    
    public interface IOperation
    {
    	string signature {get ; set ;}
    	int priority {get ; set ;}
    		
    }
   	
    public class Sum2 : IOperation , IExecute {
    	public string signature {get ; set ;}
    	public int priority {get ; set ;}
    	
    	public Sum2() {
    		this.signature = "+";
    		this.priority = 2 ;
    	}
        public double Execute ( double a , double b ) {
            return a + b ;
        }
    }
    
    public class Subst2  : IOperation , IExecute {
    	public string signature {get ; set ;}
    	public int priority {get ; set ;}
    	
    	public Subst2() {
    		signature = "-";
    		priority = 2 ;
    	}
        public double Execute ( double a , double b ) {
            return a - b ;
        }
    }
    
    public class Mult2  : IOperation , IExecute {
    	public string signature {get ; set ;}
    	public int priority {get ; set ;}
    	
    	public Mult2() {
    		signature = "*" ;
        	 priority = 3 ;
    	}
        public double Execute ( double a , double b ) {
            return a * b ;
        }
    }
    
    public class Div2  : IOperation , IExecute {
    	public string signature {get ; set ;}
    	public int priority {get ; set ;}
    	
    	public Div2(){
    		signature = "/" ;
        	priority = 3 ;
    	}
        public double Execute ( double a , double b ) {
            return a / b ;
        }
    }
    
    public class Pow2  : IOperation , IExecute {
    	public string signature {get ; set ;}
    	public int priority {get ; set ;}
    	
    	public Pow2(){
    		signature = "^" ;
        	priority = 4 ;
    	}
        public double Execute ( double a , double b ) {
        	return Math.Pow ( a , b ) ;
        }
    }
    
    
	public class BracketLeft  : IOperation {
    	public string signature {get ; set ;}
    	public int priority {get ; set ;}
    	
    	public BracketLeft(){
    		signature = "(" ;
        	priority = 1 ;
    	}
    }  
}
