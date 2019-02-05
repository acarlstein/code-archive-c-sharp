using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace OptionalParameterExample {
     
    public class OptionalParameterExample {
     
        public OptionalParameterExample(){
            Console.WriteLine("\nOptionalParameterExample");
             
            // DisplayInfo(); // Doesn't work
            DisplayInfo("Alex");
            DisplayInfo("Alex", "Carlstein");
            DisplayInfo("Alex", "Carlstein", age:34);
            DisplayInfo("Alex", age: 35);
            DisplayInfo(lastName: "Carlstein");
            // DisplayInfo(lastName: "Carlstein", 35); // Doesn't work
            DisplayInfo(lastName: "Carlstein", age: 36);    
 
             
        }
         
        private void DisplayInfo(string firstName = null, string lastName = null, int age = 0){
            Console.WriteLine("{0} {1} is {2} years old.", firstName, lastName, age);
        }
         
    }
     
}