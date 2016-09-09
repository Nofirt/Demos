using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesSystem
{
   public class SearchByName
    {
        public static void SearchEmployeeByName(List<Employee> employeesList, //method that takes employeesList
                                                MessageExceptions message)    // message as params
        {
            showListWithNamesOfEmployees(employeesList);            //invoked method which takes employeesList as param
            Console.WriteLine("Enter the name of employee :");
            string getInputSearch = Console.ReadLine();                        // Get the name to do a search
            var employeeSearch = employeesList.Where(s => s.Name.               //Return list of objects wich 
                                                     Contains(getInputSearch)); //have the same name
            int countEmployeesWithSameName;
            string foundEmployeeName;
            processEmployeeInformation(employeeSearch,                  // method that takes employeeSearch
                                       out countEmployeesWithSameName,  // countEmployeesWithSameName
                                       out foundEmployeeName);          // foundEmployeeName as params
            if (foundEmployeeName != null)// Check if it's null to except NullReferenceException
            {
                if (getInputSearch == foundEmployeeName)// Check if this name of employee appear in the company
                {
                    returnResult(employeeSearch, countEmployeesWithSameName, // invoked method takes employeeSearch
                                foundEmployeeName);              //countEmployeesWithSameName, foundEmployeeName as params
                }
                else
                {
                    message.NoSuchEmployeeMessage();//invoked NoSuchEmployeeMessage method from object message
                }
            }
            else
            {
                message.NoSuchEmployeeMessage();//invoked NoSuchEmployeeMessage method from object message
            }
        }

        private static void processEmployeeInformation(IEnumerable<Employee> employeeSearch, //method that takes employeeSearch
                                                        out int countEmployeesWithSameName,  // countEmployeesWithSameName
                                                        out string foundEmployeeName)        //foundEmployeeName as params
        {
            var getNameOfEmployeeSearch = employeeSearch.Select(y => y.Name);//Get the names from list 
            countEmployeesWithSameName = 0;//name counter
            foundEmployeeName = "";
            foreach (string name in getNameOfEmployeeSearch)//loop through names of employees
            {
                countEmployeesWithSameName++;//name counter
                foundEmployeeName = name;// used to validate the user's input
            }
        }

        private static void returnResult(IEnumerable<Employee> employeeSearch,      //method that takes employeeSearch
                                            int countEmployeesWithSameName,         //countEmployeesWithSameName
                                            string foundEmployeeName)               //foundEmployeeName as params
        {
            Console.WriteLine("There is/are " + countEmployeesWithSameName +   //print if there are more than one 
                              " employee/s with name " + foundEmployeeName);   //employee with the same name
            int isEmptyList = 0;
            foreach (var employeE in employeeSearch)//loop the list to print all the employees related to the search
            {
                Console.WriteLine(employeE.Name + " is " + employeE.Position + " in the Company");//print each object
                isEmptyList = Check.CheckEmployeesFields(isEmptyList, employeE);//invoke CheckEmployeesFields from class Check
                                                                                // and takes isEmptyList employeE as params
            }
            Console.WriteLine("Press enter to continue searching");
        }

        private static void showListWithNamesOfEmployees(List<Employee> employeesList)//method that takes employeesList as param
        {
            Console.WriteLine("List with all names of employees:");
            foreach (var workers in employeesList)//loop through list with employees to take every name and related position
            {
                Console.WriteLine(workers.Name + " - > " + workers.Position);
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
