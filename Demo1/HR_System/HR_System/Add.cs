using System;
using System.Collections.Generic;

namespace HumanResourcesSystem
{
   public class Add
    {
        public static ConsoleKeyInfo Employees(List<Employee> employeesList, Employee employee)//method which take as parameters
                                                                                              // employeesList,employee
        {
            ConsoleKeyInfo cki;//cki is declared from type ConsoleKeyInfo
            Console.WriteLine(Environment.NewLine + "Important: Search is case sensitive! ");//output text in console
            Console.WriteLine(Environment.NewLine + "Please when you add new employees, search them the same way!");//output
            Console.WriteLine(Environment.NewLine + "Enter the Name of the employee");//output text in console
            employee.Name = Console.ReadLine();//give value from console to Name property of employee object

            Console.WriteLine("Enter the Position of the employee");//output text in console
            employee.Position = Console.ReadLine();//give value from console to Position property of employee object

            cki = addProject(employee);//invoke addProject method, pass employee as parameter and assign value to cki
            cki = addProjectManager(employee);//invoke addProjectManager method, pass employee as parameter and assign 
                                              //value to cki
            cki = addTeamLeader(employee);//invoke addTeamLeader method, pass employee as parameter and assign value to cki
            cki = addDeliveryDirector(employee);//invoke addTeamLeader method, pass employee as parameter and assign value 
                                                //to cki 
            cki = addCeo(employee);//invoke addCeo method, pass employee as parameter and assign value to cki
            cki = addNewEmployee(employeesList, employee);//invoke addCeo method, pass employee as parameter and 
                                                          // assign value to cki
            Console.WriteLine("Press enter to continue");
            return cki;
        }

        private static ConsoleKeyInfo addNewEmployee(List<Employee> employeesList, Employee employee)//method which take as
                                                                                        //parameters employeesList and employee
        {
            ConsoleKeyInfo cki;//cki is declared from type ConsoleKeyInfo
            Console.WriteLine("Do you want to add the new employee to the List?");//output text to console
            Console.WriteLine("If Yes press \"Y\" otherwise press Enter" + Environment.NewLine);//output text to console
            cki = Console.ReadKey();//cki gets value from input on console
            if (cki.Key == ConsoleKey.Y)//if  user press "Y" in console, the code in curly braces executes
            {
                employeesList.Add(employee);//add new employee in the employeesList
                Console.WriteLine(Environment.NewLine + "The new employee has been added to the list");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "You don't add anything");
            }

            return cki;
        }

        private static ConsoleKeyInfo addCeo(Employee employee)//method that take employee as parameter
        {
            ConsoleKeyInfo cki;//cki is declared from type ConsoleKeyInfo
            Console.WriteLine("Do you want to add CEO of the employee?");
            Console.WriteLine("If Yes press \"Y\" otherwise press Enter" + Environment.NewLine);
            cki = Console.ReadKey();//read from condole
            if (cki.Key == ConsoleKey.Y)//if  user press "Y" in console, the code in curly braces executes
            {
                Console.WriteLine(Environment.NewLine + "Enter the CEO of the employee");
                employee.Ceo = Console.ReadLine();//give value from console to Ceo property of employee object
            }

            return cki;
        }

        private static ConsoleKeyInfo addDeliveryDirector(Employee employee)//method that take employee as parameter
        {
            ConsoleKeyInfo cki;//cki is declared from type ConsoleKeyInfo
            Console.WriteLine("Do you want to add Delivery Director of the employee?");
            Console.WriteLine("If Yes press \"Y\" otherwise press Enter" + Environment.NewLine);
            cki = Console.ReadKey();//read from condole
            if (cki.Key == ConsoleKey.Y)//if  user press "Y" in console, the code in curly braces executes
            {
                Console.WriteLine(Environment.NewLine + "Enter the Delivery Director of the employee");
                employee.DeliveryDirector = Console.ReadLine();// give value from console to DeliveryDirector
                                                               //property of employee object
            }

            return cki;
        }

        private static ConsoleKeyInfo addTeamLeader(Employee employee)//method that take employee as parameter
        {
            ConsoleKeyInfo cki;//cki is declared from type ConsoleKeyInfo
            Console.WriteLine("Do you want to add Team Leader of the employee?");
            Console.WriteLine("If Yes press \"Y\" otherwise press Enter" + Environment.NewLine);
            cki = Console.ReadKey();//read from condole
            if (cki.Key == ConsoleKey.Y)//if  user press "Y" in console, the code in curly braces executes
            {
                Console.WriteLine(Environment.NewLine + "Enter the Team Leader of the employee");
                employee.TeamLeader = Console.ReadLine();//give value from console to TeamLeader property of employee object
            }

            return cki;
        }

        private static ConsoleKeyInfo addProjectManager(Employee employee)//method that take employee as parameter
        {
            ConsoleKeyInfo cki;//cki is declared from type ConsoleKeyInfo
            Console.WriteLine("Do you want to add Project Manager of the employee?");
            Console.WriteLine("If Yes press \"Y\" otherwise press Enter" + Environment.NewLine);
            cki = Console.ReadKey();//read from condole
            if (cki.Key == ConsoleKey.Y)//if  user press "Y" in console, the code in curly braces executes
            {
                Console.WriteLine(Environment.NewLine + "Enter the Project Manager of the employee");
                employee.ProjectManager = Console.ReadLine();//give value from console to ProjectManager property of
                                                             //employee object
            }

            return cki;
        }

        private static ConsoleKeyInfo addProject(Employee employee)//method that take employee as parameter
        {
            ConsoleKeyInfo cki;//cki is declared from type ConsoleKeyInfo
            Console.WriteLine("Do you want to add project of the employee?");
            Console.WriteLine("If Yes press \"Y\" otherwise press Enter" + Environment.NewLine);
            cki = Console.ReadKey();//read from condole
            if (cki.Key == ConsoleKey.Y)//if  user press "Y" in console, the code in curly braces executes
            {
                Console.WriteLine(Environment.NewLine + "Enter the Project of the employee");
                employee.Project = Console.ReadLine();//give value from console to Project property of employee object
            }

            return cki;
        }
    }
}
