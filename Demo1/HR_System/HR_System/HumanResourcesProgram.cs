using System;
using System.Collections.Generic;

namespace HumanResourcesSystem
{
    class HumanResourcesProgram
    {
        public static void Main()
        {
            List<Employee> employeesList = new List<Employee>();// Declare a List by using the constructor, from type Employee
            ConsoleKeyInfo cki; 
            string PressedKey = "";//save the user choosen option
            while (true)
            {
                MessageExceptions message = new MessageExceptions();// Declare a MessageException by using the constructor
                Employee employee = new Employee();// Declare a Employee by using the constructor
                Menus.MainMenuEmployee();//call MainMenuEmployee method from Class Menus
                cki = Console.ReadKey();// Read from Console
                if (cki.Key == ConsoleKey.A)// If user press "A" the code in the curly braces start executing
                {
                    cki = Add.Employees(employeesList, employee);// cki get the otuput value from method AddEmployees in Class Add
                }
                if (cki.Key == ConsoleKey.S)// If user press "S" the code in the curly braces start executing
                {
                    PressedKey = Search.Employees(employeesList, message);//pressedkey get the otuput value
                                                                          //from method AddEmployees in Class Add
                }
                if (cki.Key == ConsoleKey.P)// If user press "P" the code in the curly braces start executing
                {
                    Print.AllEmployees(employeesList);// cki get the otuput value from method PrintAllEmployees in Class Print
                }
                if (cki.Key == ConsoleKey.Q)// If user press "P" the code in the curly braces start executing
                {
                    Console.Write("Goodbye!!!");// This text appear in the console
                    Environment.Exit(0);// The console is closed
                }
                Console.ReadLine();// use console.readline to stop while looping before the upper code execute
            }
        }
    }
}
