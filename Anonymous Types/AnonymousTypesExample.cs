using System;
using System.Collections.Generic;
using System.Linq;
 
namespace AnonymousTypesExample {
     
    public class AnonymousTypesExample {
     
        public AnonymousTypesExample(){
            Console.WriteLine("\nAnonymousTypesExample()");
             
            var people = new List<Person> {
                new Person { FirstName = "Alex", LastName = "Carlstein", Age = 33 },
                new Person { FirstName = "Diego", LastName = "Carlstein", Age = 32 },
                new Person { FirstName = "Alex", LastName = "Veron", Age = 40 },
                new Person { FirstName = "Vanina", LastName = "Veron", Age = 34 },
                new Person { FirstName = "Bob", LastName = "Smith", Age = 12 },
            };
             
            var result = from p in people
                         where p.LastName == "Carlstein"
                         select p;
         
            foreach (var item in result){
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
             
            Console.WriteLine("---------");
             
            var result2 = from p in people 
                          where p.LastName == "Carlstein"
                          select new { FName = p.FirstName, LName = p.LastName };
         
            foreach (var item in result2){
                Console.WriteLine(item.FName + " " + item.LName);
            }
             
            Console.WriteLine("---------");
             
            foreach (var item in result2){
                Console.WriteLine(item.FName + " " + item.LName);               
                // item.FName = "Rick"; // Cannot do this because FName is read-only                                
            }
 
        }
 
    }
 
    public class Person {
         
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Dollars { get; set; }
        public int Pesos { get; set; }
        public int Yens { get; set; }
                 
    }
 
}