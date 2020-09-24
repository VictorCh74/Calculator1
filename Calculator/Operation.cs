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
    public abstract class Operation_
    {
    	public string signature ;
    	public int priority;
    	abstract public double execute(double a , double b) ;
    	
    }
       public class Sum2 : Operation_ {
    	public Sum2() {
    		signature = "+";
    		priority = 2 ;
    	}
        override public double execute ( double a , double b ) {
            return a + b ;
        }
    }
    
    public class Subst2  : Operation_ {
    	public Subst2() {
    		signature = "-";
    		priority = 2 ;
    	}
        override public double execute ( double a , double b ) {
            return a - b ;
        }
    }
    
    public class Mult2  : Operation_ {
    	public Mult2() {
    		signature = "*" ;
        	 priority = 3 ;
    	}
        override public double execute ( double a , double b ) {
            return a * b ;
        }
    }
    
    public class Div2  : Operation_ {
    	public Div2(){
    		signature = "/" ;
        	priority = 3 ;
    	}
        override public double execute ( double a , double b ) {
            return a / b ;
        }
    }
    
    public class Pow2  : Operation_ {
    	public Pow2(){
    		signature = "^" ;
        	priority = 4 ;
    	}
        override public double execute ( double a , double b ) {
        	return Math.Pow ( a , b ) ;
        }
    }
    
    
	public class BracketLeft  : Operation_ {
    	public BracketLeft(){
    		signature = "(" ;
        	priority = 1 ;
    	}
        override public double execute ( double a , double b = 0.0  ) {
    		return  a;
        }
    }
    
    
    public class BracketRight  : Operation_ {
    	public BracketRight(){
    		signature = ")" ;
        	priority = 0 ;
    	}
        override public double execute ( double a , double b = 0.0  ) {
    		return  a;
        }
    }
     
}
