using System;
 
namespace DynamicKeywordExample {
     
    public class DynamicKeywordExample {
     
        public DynamicKeywordExample(){
            Console.WriteLine("\nDynamicKeywordExample");
             
            var test = "This is a string";
             
            //test = 5; // This will fail because cannot implicitly convert type 'int' to 'string'
             
            Console.WriteLine("Value: {0}", test);
             
            // To be able to change to any time you want use Dynamic DynamicKeywordExample
             
            dynamic test2 = "This is another string";
             
            Console.WriteLine("Value: {0}", test2);
             
            test2 = 10;
             
            Console.WriteLine("Value: {0}", test2);
 
            // Using Dynamic is bad for performance
             
        }
         
    }
     
}