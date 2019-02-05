using System;
using System.Collections.Generic;
using System.Linq;
 
namespace LINQExample {
     
    public class LINQExample {
     
        public LINQExample(){
            Console.WriteLine("\nLINQExample()");
             
            var sample = "This is a text example to show how LINQ works";
             
            var result = from s in sample 
                         select s;
                          
            foreach (var item in result){
                Console.Write(item + "-");
            }
             
            Console.WriteLine("\n------");
             
            result = from s in sample
                     where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                     select s;
                      
            foreach (var item in result){
                Console.Write(item + "-");
            }
             
            Console.WriteLine("\n------");
             
            result = from s in sample.ToLower()
                     where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                     select s;
                      
            foreach (var item in result){
                Console.Write(item + "-");
            }
             
            Console.WriteLine("\n------");
             
            result = from s in sample.ToLower()
                     where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                     orderby s // ascending by default
                     select s;
                      
            foreach (var item in result){
                Console.Write(item + "-");
            }
             
            Console.WriteLine("\n------");
 
            result = from s in sample.ToLower()
                     where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                     orderby s descending
                     select s;
                      
            foreach (var item in result){
                Console.Write(item + "-");
            }
             
            Console.WriteLine("\n------");
 
            var result2 = from s in sample.ToLower()
                          where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                          group s by s;                  
                      
            foreach (var item in result2){
                Console.WriteLine(item);
            }
             
            Console.WriteLine("\n------");
 
            result2 = from s in sample.ToLower()
                      where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                      group s by s;                  
                      
            foreach (var item in result2){
                Console.Write(item.Key + "-");
            }
             
            Console.WriteLine("\n------");
 
            result2 = from s in sample.ToLower()
                      where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                      orderby s descending
                      group s by s;                  
                      
            foreach (var item in result2){
                Console.Write(item.Key + "-");
            }
             
            Console.WriteLine("\n------");
 
            result2 = from s in sample.ToLower()
                      where s == 'a' || s == 'e' || s == 'i' || s == 'o' || s == 'u'
                      orderby s 
                      group s by s;                  
                      
            foreach (var item in result2){
                Console.WriteLine(item.Key + ":" + item.Count());
            }
             
            Console.WriteLine("\n------");
             
            var people = new List<Person>{
                new Person { FirstName = "Alex", LastName = "Carlstein", Age = 33 },
                new Person { FirstName = "Diego", LastName = "Carlstein", Age = 32 },
                new Person { FirstName = "Alex", LastName = "Veron", Age = 40 },
                new Person { FirstName = "Vanina", LastName = "Veron", Age = 34 },
                new Person { FirstName = "Bob", LastName = "Smith", Age = 12 },
            };
             
            var result3 = from p in people
                          select p;
             
            foreach (var item in result3){
                Console.WriteLine("{0} {1}: {2}", item.FirstName, item.LastName, item.Age);
            }
 
            Console.WriteLine("\n------");
             
            result3 = from p in people
                          where p.Age < 35
                          select p;
             
            foreach (var item in result3){
                Console.WriteLine("{0} {1}: {2}", item.FirstName, item.LastName, item.Age);
            }
 
            Console.WriteLine("\n------");
             
            result3 = from p in people
                          where p.Age < 35 && p.LastName == "Carlstein"
                          select p;
             
            foreach (var item in result3){
                Console.WriteLine("{0} {1}: {2}", item.FirstName, item.LastName, item.Age);
            }
 
            Console.WriteLine("\n------");
 
            result3 = from p in people
                          orderby p.LastName
                          select p;
             
            foreach (var item in result3){
                Console.WriteLine("{0}, {1}: {2}", item.LastName, item.FirstName, item.Age);
            }
 
            Console.WriteLine("\n------");
 
            var result4 = from p in people
                          orderby p.LastName descending
                          group p by p.LastName;
             
            foreach (var item in result4){
                 
                Console.WriteLine(item.Key + ": " + item.Count());
                foreach (var p in item){
                    Console.WriteLine("\t{0}, {1}", p.LastName, p.FirstName);
                }
                 
            }
 
            Console.WriteLine("\n------");
             
        }
         
        public class Person {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
         
    }
         
}