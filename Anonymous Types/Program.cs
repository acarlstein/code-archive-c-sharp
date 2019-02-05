using System;
 
namespace ConsoleApp1 {
     
    public class Program {
         
        public void Main(string[] args){            
            Console.WriteLine("Main()");
             
            displayWhichDnxIsCompilingOn();
             
            new AnonymousTypesExample.AnonymousTypesExample();
             
        }
         
        private void displayWhichDnxIsCompilingOn(){
            #if DNX451
            Console.WriteLine("Compiled on DNX451: .NET Framework");
            #endif
             
            #if DNXCORE50
            Console.WriteLine("Compiled on DNXCORE50: .NET Core 5");
            #endif                      
        }
 
    }
     
}