using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApplication {
    
    class Cli {

        public static void DisplayLine(string prompt = null) {
            Console.WriteLine($"{prompt}");
        }

        public static DateTime? GetDateTime(string prompt) {
            var response = Getstring(prompt);
            if(response.Length == 0) {
                return null;
            }
            return Convert.ToDateTime(response);
        }

        
        public static int GetInt(string prompt) {
            var response = Getstring(prompt);
            return Convert.ToInt32(response);
        }
        
        
        
        public static string Getstring(string prompt) {
            Console.Write($"{prompt}");
            var response = Console.ReadLine();
            return response;
        }

    }
}
