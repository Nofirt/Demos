using System;
using System.Collections.Generic;

namespace HumanResourcesSystem
{
   public class Print
    {
        public static void AllEmployees(List<Employee> employeesList)
        {
            int isEmptyList = 0;
            Console.WriteLine(Environment.NewLine);//new line
            Console.WriteLine(Environment.NewLine + "List of all employees:");//outputs in the console
            foreach (var item in employeesList)//loop in List
            {
                isEmptyList = Check.CheckEmployeesFields(isEmptyList, item);//call CheckEmployeesFields method from class Check
            }
            if (isEmptyList == 0)//check if the list is empty
            {
                Console.WriteLine(Environment.NewLine + "The list of employees is empty");//return message
            }
            Console.WriteLine("Press enter to continue");
        }
    }
}
