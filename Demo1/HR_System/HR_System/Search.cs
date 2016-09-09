using System;
using System.Collections.Generic;

namespace HumanResourcesSystem
{
    public class Search
    {
        public static string Employees(List<Employee> employeesList, MessageExceptions message)//method takes employeesList,
                                                                                               // message as parameters
        {
            string PressedKey;//declare PressedKey as string
            while (true)//
            {
                Menus.SubMenuEmployee();//invoke SubMenuEmployee from Menu class to show the submenu
                PressedKey = Console.ReadLine();//pressedkey gets value from console
                if (PressedKey == "N")//if "N" is pressed the code in curly braces executes
                {
                    SearchByName.SearchEmployeeByName(employeesList, message);//invoke SearchEmployeeByName method 
                                                                    //from classSearchByName with params employeesList message
                }
                if (PressedKey == "PO")//if "PO" is pressed the code in curly braces executes
                {
                    SearchByPosition.SearchEmployeeByPosition(employeesList, message);//invoke SearchEmployeeByPosition method 
                                                                     //from SearchByPosition with params employeesList message
                }

                if (PressedKey == "PR")//if "PR" is pressed the code in curly braces executes
                {
                    SearchByProject.SearchEmployeeByProject(employeesList, message);//invoke SearchEmployeeByProject method 
                                                                    //from SearchByProject with params employeesList message
                }
                if (PressedKey == "Q")//if "Q" is pressed the code in curly braces executes
                {
                    break;
                }
                Console.ReadLine();// use it to stop while from looping constantly
            }
            return PressedKey;
        }
    }
}
