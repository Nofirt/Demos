using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResourcesSystem
{
    public class SearchByProject
    {
        public static void SearchEmployeeByProject(List<Employee> employeesList,  //method that takes employeesList
                                                    MessageExceptions message)    // message as params
        {
            listWithAllProjects(employeesList);//invoked method which takes employeesList as param
            Console.WriteLine("Enter the name of the Project :");
            string getInputSearch = Console.ReadLine();// Get the project to do a search
            var projectSearch = employeesList.Where(s => s.                             //Return list of objects
                                                    Project.Contains(getInputSearch)); //wich have the same project
            int countEmployeesWithSameProject;
            string foundEmployeeProject;
            processProjectInformation(projectSearch,                        //invoked method which takes projectSearch
                                      out countEmployeesWithSameProject,    //countEmployeesWithSameProject
                                      out foundEmployeeProject);            //foundEmployeeProject as params
            if (foundEmployeeProject != null)// Check if it's null to except NullReferenceException
            {
                if (getInputSearch == foundEmployeeProject)// Check if this project appear in the company
                {
                    returnedInformation(projectSearch, countEmployeesWithSameProject, //invoked method which takes projectSearch
                                        foundEmployeeProject);                        //countEmployeesWithSameProject
                }                                                                     //foundEmployeeProject as params
                else
                {
                    message.NoSuchProjectMessage();//invoked NoSuchEmployeeMessage method from object message
                }
            }
            else
            {
                message.NoSuchProjectMessage();//invoked NoSuchEmployeeMessage method from object message
            }
        }

        private static void returnedInformation(IEnumerable<Employee> projectSearch, //invoked method which takes projectSearch
                                                int countEmployeesWithSameProject,    //countEmployeesWithSameProject
                                                string foundEmployeeProject)          //foundEmployeeProject as params
        {
            Console.WriteLine(Environment.NewLine + countEmployeesWithSameProject +       //output text in console
                              " employee/s working on \"" + foundEmployeeProject + "\"");
            var loopCount = 0;//counter
            foreach (var workers in projectSearch)
            {
                loopCount++;//count employees in project 
                Console.WriteLine(" " + loopCount + "." +                       //  print how many employees,
                                  workers.Name + " -> " + workers.Position);    //  with their names and positions working
                                                                                // on same project

            }
            int isEmptyList = 0;
            foreach (var fullEmployeesInformation in projectSearch)     // loop the list to print full information about
                                                                        // all the employees related to the project search
            {
                isEmptyList = Check.CheckEmployeesFields(isEmptyList,               // invoke method CheckEmployeesFields
                                                        fullEmployeesInformation);  // from Class Check and takes isEmptyList
                                                                                    // and fullEmployeesInformation as params
            }
            Console.WriteLine("Press enter to continue searching");
        }

        private static void processProjectInformation(IEnumerable<Employee> projectSearch,  // method that takes projectSearch,
                                                      out int countEmployeesWithSameProject, //countEmployeesWithSameProject,
                                                      out string foundEmployeeProject)       //foundEmployeeProject as params
        {
            var getProjectOfEmployeeSearch = projectSearch.Select(y => y.Project);//Get the project from list 
            countEmployeesWithSameProject = 0;
            foundEmployeeProject = "";
            foreach (string name in getProjectOfEmployeeSearch)
            {
                countEmployeesWithSameProject++;
                foundEmployeeProject = name;
            }
        }

        private static void listWithAllProjects(List<Employee> employeesList)//method that takes as parameter employeesList
        {
            Console.WriteLine("List with all Projects:");
            var selected = employeesList.GroupBy(x => x.Project).                     //initialize variable selected
                                         SelectMany(x => x.OrderBy(y => y.Project).Take(1)); //and assign value using built-in 
                                                                                             // methods to group different projects and take
                                                                                             // first project of every group 
            foreach (var workers in selected)
            {
                if (workers.Project.Contains(","))
                {
                    //remove bug
                }
                else
                {
                    Console.WriteLine(" " + workers.Project);
                }

            }
        }
    }
}
