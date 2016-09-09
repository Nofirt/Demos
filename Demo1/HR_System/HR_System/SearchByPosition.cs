using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesSystem
{
    public class SearchByPosition
    {
        public static void SearchEmployeeByPosition(List<Employee> employeesList,     //method takes
                                                    MessageExceptions message)       //employeesList,message as params

        {
            returnlistOfPositions(employeesList);//method which takes employeesList as param
            Console.WriteLine("Enter the position :");
            string getInputSearch = Console.ReadLine();// Get the name to do a search
            var employeeSearch = employeesList.Where(s =>                               //Return list of objects
                                                s.Position.Contains(getInputSearch));   // wich have the same position

            int countEmployeesWithSamePosition;//declare integer to count how many employees are related to this position
            string foundEmployeePosition;//declare string which will store the name of the found position in the list
            proccessPositionsInformation(employeeSearch,                     //method which takes employeeSearch,
                                         out countEmployeesWithSamePosition, //countEmployeesWithSamePosition,
                                         out foundEmployeePosition);         // foundEmployeePosition as params

            if (foundEmployeePosition != null)// Check if searching is not null, to except nullreference exception and retrieve
            {
                if (getInputSearch == foundEmployeePosition)// Check if this name of employee appear in the company
                {
                    returnResults(employeeSearch,                    //method that takes
                                  countEmployeesWithSamePosition,   //employeeSearch, countEmployeesWithSamePosition,
                                  foundEmployeePosition);          // foundEmployeePosition as params
                }

                else
                {
                    message.NoSuchPositionMessage();//invoke NoSuchPositionMessage method from message object, instance of
                                                    // class MessageExceptions. This wiil execute if user input is not 
                                                    //equal to existing positions in the list 
                }
            }
            else
            {
                message.NoSuchPositionMessage();//invoke NoSuchPositionMessage method from message object, instance of
                                                // class MessageExceptions. This will execute if user not type anything
            }
        }

        private static void returnResults(IEnumerable<Employee> employeeSearch,  //method that take employeeSearch
                                          int countEmployeesWithSamePosition,    //countEmployeesWithSamePosition
                                          string foundEmployeePosition)          //foundEmployeePosition as params
        {
            if (countEmployeesWithSamePosition == 1)    //code in curly braces will execute if
                                                        // countEmployeesWithSamePositionis equal to 1
            {
                Console.WriteLine(Environment.NewLine +
                                  "There is " + countEmployeesWithSamePosition +
                                  " " + foundEmployeePosition + " in the company ");
            }
            else
            {
                Console.WriteLine(Environment.NewLine +                           //print if there are more than
                                  "There are " + countEmployeesWithSamePosition + //one employee with the same name
                                  " " + foundEmployeePosition + " positions ");
            }
            int isEmptyList = 0;//initializes isEmptyList with value of 0
            foreach (var item in employeeSearch)//loop the list to print all the employees related to the search
            {
                isEmptyList = Check.CheckEmployeesFields(isEmptyList, item);//invoke CheckEmployeesFields method from class
                                                                            //Check and take isEmptyList, item as params 
            }
            Console.WriteLine("Press enter to continue searching");
        }

        private static void proccessPositionsInformation(IEnumerable<Employee> employeeSearch,//method that takes employeeSearch
                                                         out int countEmployeesWithSamePosition,//countEmployeesWithSamePosition
                                                         out string foundEmployeePosition)    //foundEmployeePosition as params
        {
            var getPositionOfEmployeeSearch = employeeSearch.Select(y => y.Position);//Get the position from list 
            countEmployeesWithSamePosition = 0;
            foundEmployeePosition = "";
            foreach (string name in getPositionOfEmployeeSearch)
            {
                countEmployeesWithSamePosition++;
                foundEmployeePosition = name;//need this to make search of the user valid
            }
        }

        private static void returnlistOfPositions(List<Employee> employeesList)
        {
            Console.WriteLine("List with all Positions:");
            var selected = employeesList.GroupBy(x => x.Position)                // group different positions and
                           .SelectMany(x => x.OrderBy(y => y.Position).Take(1)); // select first of every group
            foreach (var positions in selected)   //loop all positions
            {
                Console.WriteLine(" " + positions.Position);//print existing positions
            }
        }
    }
}
