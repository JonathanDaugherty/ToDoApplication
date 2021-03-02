using System;
using System.Threading.Tasks;
using ToDoLib.Controllers;
using ToDoLib.Models;

namespace ToDoApplication {
    class Program {

        TodoController todoctrl = null;
        CategoriesController catctrl = null;

        async Task ListAllTodos() {
            Cli.DisplayLine("Called ListAllTodos()");
            var todos = await todoctrl.GetAll(); 
            foreach(var todo in todos) {
                Console.WriteLine($"{todo}");
            }
        }
        async Task CreateTodo() {
            Cli.DisplayLine("Called CreateTodo()");
            Cli.DisplayLine();
            var categories = await catctrl.GetAll();
            var todo = new Todo();
            todo.Id = 0;
            todo.Description = Cli.Getstring("Enter Description: ");
            todo.Due = Cli.GetDateTime("Enter valid date: ");
            todo.Note = Cli.Getstring("Enter Note: ");
            Cli.DisplayLine("Categories: ");
            foreach(var c in categories) {
                Cli.DisplayLine($"{c.Id} : {c.Name}");
            }

            todo.CategoryId = Cli.GetInt("Select category: ");
            var newTodo = await todoctrl.Create(todo);
            Cli.DisplayLine();
            Cli.DisplayLine("Added . . . ");
            Cli.DisplayLine();
        }
            

        
        async Task Run() {
            todoctrl = new TodoController();
            catctrl = new CategoriesController();
            Cli.DisplayLine("Todo Application");
            var option = DisplayMenu();
            while (option != 0) {
                switch (option) {
                    case 1:
                        await ListAllTodos();
                        break;
                    case 2:
                        await CreateTodo();
                        break;
                    case 0:
                        return;
                    default:
                        Cli.DisplayLine("Invalid Menu Option");
                        break;
                }
                option = DisplayMenu();
            }
        }
        int DisplayMenu() {
            Cli.DisplayLine("Menu:");
            Cli.DisplayLine("1 : List all todos");
            Cli.DisplayLine("2 : Add Todo");
            Cli.DisplayLine("0 : Exit");
            var option = Cli.GetInt("Enter menu number: ");
            return option;
        }

        static async Task Main(string[] args) {
            
            var pgm = new Program();
            await pgm.Run();

            
            


            //var aStr = Cli.Getstring("Enter a string: ");
            //var anInt = Cli.GetInt("Enter an Int: ");
            //var aDate = Cli.GetDateTime("Enter a valid Date: ");
            //var aDate2 = Cli.GetDateTime("Just Press Enter");
            //Console.WriteLine($"{aStr}");
            //Console.WriteLine($"{anInt}");
            //Console.WriteLine($"{aDate} [{aDate2}]");

            
            
            
            //var answer = Cli.Getstring("Enter a string:");
            //Console.WriteLine($"The answer is {answer}");
        }
    }
}
