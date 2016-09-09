using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace HumanResourcesApplication
{
    public class HumanResources
    {
        enum EmployeeInformation
        {
            Name,
            Position,
            Project,
            ProjectManager,
            TeamLeader,
            DeliveryDirector,
            Ceo,
        }
        public static void Main()
        {
            ///<declare>employeeList by using the constructor</declare>
            List<Employee> employeesList = new List<Employee>();
            ConsoleKeyInfo readFromConsole;//Read pressed key from console
            string pressedKey = "";//Store the user choosen option
            ///<summary>Main logic of the program is in the while loop</summary>
            while (true)
            {
                ///<declare>employee by using the constructor</declare>
                Employee employee = new Employee();
                ///<summary>Invoke the main menu</summary>
                GetMainMenu();
                readFromConsole = Console.ReadKey();
                ///<summary>If user want to add employees, press "A"</summary>
                if (readFromConsole.Key == ConsoleKey.A)
                {
                    ///<invokes>Method AddEmployee is invoked</invokes>
                    ///<param name="employeesList"></param>
                    ///<param name="employee"></param>
                    ///<returns>List with questions to add information about employee</returns>
                    AddEmployee(employeesList, employee);
                }
                ///<summary>If user want to search employees, press "S"</summary>
                if (readFromConsole.Key == ConsoleKey.S)
                {
                    ///<summary>The options to search are in while loop</summary>
                    while (true)
                    {
                        ///<summary>Invoke the Submenu</summary>
                        GetSubMenu();
                        pressedKey = Console.ReadLine();
                        ///<summary>For specific search by name user need to press "N"</summary>
                        if (pressedKey == "N")
                        {
                            ///<invokes>Method SearchName is invoked</invokes>
                            ///<param name="employeesList"></param>
                            ///<param name="employee"></param>
                            ///<returns>List with results of searching</returns>
                            SearchName(employeesList, employee);
                        }
                        ///<summary>For specific search by position user need to press "PO"</summary>
                        if (pressedKey == "PO")
                        {
                            ///<invokes>Method SearchPosition is invoked</invokes>
                            ///<param name="employeesList"></param>
                            ///<param name="employee"></param>
                            ///<returns>List with results of searching</returns>
                            SearchPosition(employeesList, employee);
                        }
                        ///<summary>For specific search by project user need to press "PR"</summary>
                        if (pressedKey == "PR")
                        {
                            ///<invokes>Method SearchProject is invoked</invokes>
                            ///<param name="employeesList"></param>
                            ///<param name="employee"></param>
                            ///<returns>List with results of searching</returns>
                            SearchProject(employeesList, employee);
                        }
                        ///<summary>To qiut the program user need to press "Q"</summary>
                        if (pressedKey == "Q")
                        {
                            break;
                        }
                        Console.ReadLine();
                    }
                }
                ///<summary>To print all employees user pressed "P"</summary>
                if (readFromConsole.Key == ConsoleKey.P)
                {
                    ///<invokes>Method PrintEmployees is invoked</invokes>
                    ///<param name="employeesList"></param>
                    ///<returns>Prints List with all employees</returns>
                    PrintEmployees(employeesList);
                }
                if (readFromConsole.Key == ConsoleKey.Q)
                {
                    Console.Write("Goodbye!!!");
                    Environment.Exit(0);
                }
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Print all employees stored in the List employeeList
        /// </summary>
        /// <param name="employeeList">List of type Employee</param>
        /// <returns>List with all employees</returns>
        public static void PrintEmployees(List<Employee> employeesList)
        {
            int isEmptyList = 0;// Initialize variable of type integer with value 0
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine + "List of all employees:");
            /// <summary>
            /// Loop in List
            /// </summary>
            foreach (var employee in employeesList)
            {
                ///<summary>Invoke CheckEmployeesFields method to make the check while looping each other fields</summary>
                isEmptyList = CheckEmployeesFields(isEmptyList, employee);
            }
            ///<summary>Check if the list is empty</summary>
            if (isEmptyList == 0)
            {
                ///<returns>Message with information</returns>
                Console.WriteLine(Environment.NewLine + "The list of employees is empty");
            }
            Console.WriteLine("Press enter to continue");
        }

        /// <summary>
        /// Search in all employees by position
        /// </summary>
        /// <param name="employeeList" type="List">List of type Employee</param>
        /// <param name="employee" type="Object"></param>
        /// <returns>List with specific information about the search</returns>
        public static void SearchPosition(List<Employee> employeesList, Employee employee)
        {
            Console.WriteLine("List with all Positions:");
            ///<summary>Group different positions and select first of every group to output the list of positions</summary>
            var selected = employeesList.GroupBy(x => x.Position).SelectMany(x => x.OrderBy(y => y.Position).Take(1));
            ///<summary>Loop throught all the positions</summary>
            foreach (var positions in selected)
            {
                ///<returns>Print existing positions</returns>
                Console.WriteLine(" " + positions.Position);
            }
            Console.WriteLine("Enter the position :");
            string getInputSearch = Console.ReadLine();// Get the name to do a search
            var positionsSearch = employeesList.Where(s => s.Position.Contains(getInputSearch));//Return list of objects which have
                                                                                                // the same position
            var getPosition = positionsSearch.Select(y => y.Position);//Get the position from list 
            var firstPosition = getPosition.First();//Get first from the list
            var countEmployeesWithSamePosition = getPosition.Count();//Count how many times the position is count
                                                                     // respectivly employees are the same count
            ///<summary>Check for null to except Nullreference, exception and check if search exists</summary>
            if (firstPosition != null && firstPosition == getInputSearch)                                                                         
            {
                Console.WriteLine("There is/are " + countEmployeesWithSamePosition + " " + firstPosition + "position/s in the company ");
                int isEmptyList = 0;//initializes isEmptyList with value of 0
                ///<summary>Loop the list to print all the employees related to the search</summary>
                foreach (var employe in positionsSearch)
                {
                    ///<summary>Invoke CheckEmployeesFields method to check if the employees fields exists </summary>
                    CheckEmployeesFields(isEmptyList, employe);
                }
                Console.WriteLine("Press enter to continue searching");
            }
            else
            {
                NoSuchPositionMessage();
            }
        }

        /// <summary>
        /// Search in all employees by project
        /// </summary>
        /// <param name="employeeList" type="List">List of type Employee</param>
        /// <param name="employee" type="Object"></param>
        /// <returns>List with specific information about the search</returns>
        public static void SearchProject(List<Employee> employeesList, Employee employee)
        {
            Console.WriteLine("List with all projects:");
            ///<summary>Group different projects and select first of every group to output the list of projects</summary>
            var selected = employeesList.GroupBy(x => x.Project).SelectMany(x => x.OrderBy(y => y.Project).Take(1));
            ///<summary>Loop throught all the projects</summary>
            foreach (var workers in selected)
            {
                ///<returns>Print existing projects</returns>
                Console.WriteLine(workers.Project);
            }
            Console.WriteLine("Enter the name of the Project :");
            string getInputSearch = Console.ReadLine();// Get the project to do a search
            var projectSearch = employeesList.Where(s => s.Project.Contains(getInputSearch));//Return list of objects which
                                                                                             // have the same project
            var getProject = projectSearch.Select(y => y.Project);//Get the project from list 
            var foundProject = getProject.First();//
            var countEmployeesWithSameProject = getProject.Count();//Count how many times the project is count
                                                                   // respectivly employees are the same count
            ///<summary>Check for null to except Nullreference, exception and check if search exists</summary>
            if (foundProject != null && foundProject == getInputSearch)
            {
                Console.WriteLine(Environment.NewLine + countEmployeesWithSameProject + " employee/s working on \"" + foundProject + "\"");
                var loopCount = 0;
                int isEmptyList = 0;//initializes isEmptyList with value of 0
                ///<summary>Loop throught the list of projects to find out who works on it and at what position</summary>
                foreach (var employ in projectSearch)
                {
                    loopCount++;
                    Console.WriteLine(" " + loopCount + "." + employ.Name + " -> " + employ.Position);
                    isEmptyList = CheckEmployeesFields(isEmptyList, employ);
                }
                Console.WriteLine("Press enter to continue searching");
            }
            else
            {
                NoSuchProjectMessage();
            }
        }
        /// <summary>
        /// Search in all employees by name
        /// </summary>
        /// <param name="employeeList" type="List">List of type Employee</param>
        /// <param name="employee" type="Object"></param>
        /// <returns>List with specific information about the search</returns>
        public static void SearchName(List<Employee> employeesList, Employee employee)
        {
            Console.WriteLine("List with all names of employees:");
            ///<summary>Loop throught employeesList to output names with positions of employees</summary>
            foreach (var workers in employeesList)
            {
                Console.WriteLine(workers.Name + " - > " + workers.Position);
                Console.WriteLine("----------------------------------");
            }
            Console.WriteLine("Enter the name of employee :");
            string getInputSearch = Console.ReadLine();// Get the name to do a search
            var employeeSearch = employeesList.Where(s => s.Name.Contains(getInputSearch));//Return list of objects wich have
                                                                                           // the same name
            var getNameOfEmployeeSearch = employeeSearch.Select(y => y.Name);//Get the names from list 
            var foundName = getNameOfEmployeeSearch.First();//get first name to make a validation
            var countSameNames = getNameOfEmployeeSearch.Count();//count employees with same name
            ///<summary>Check for null to except Nullreference, exception and check if search exists</summary>
            if (foundName != null && getInputSearch == foundName)
            {
                Console.WriteLine("There are " + countSameNames + " employees with name " + foundName);//print if there are more than one employee with the same name
                int isEmptyList = 0;//initializes isEmptyList with value of 0
                ///<summary>Loop the list to print all the employees related to the search</summary>
                foreach (var employees in employeeSearch)
                {
                    Console.WriteLine(employees.Name + " is " + employees.Position + " of the Company");
                    isEmptyList = CheckEmployeesFields(isEmptyList, employees);
                }

                Console.WriteLine("Press enter to continue searching");
            }
            else
            {
                NoSuchEmployeeMessage();
            }
        }

        /// <summary>
        /// Adding employees with taken values from user, to employeesList
        /// </summary>
        /// <param name="employeeList">List of type Employee</param>
        /// /// <param name="employee" type="Object"></param>
        /// <returns>Message about successfully adding the new employee</returns>
        public static void AddEmployee(List<Employee> employeesList, Employee employee)
        {
            Console.WriteLine(Environment.NewLine + "Important: Search is case sensitive! ");
            Console.WriteLine(Environment.NewLine + "Please when you add new employees, search them the same way!");
            string getInputValue;//declare variable from type string
            var getInfo = Enum.GetValues(typeof(EmployeeInformation)).Cast<EmployeeInformation>();// variable that takes values from enum
            /// <returns>
            /// Loop throught enum values which are same as types of fields of Employee and
            /// dynamically assign values to the questions
            /// </returns>
            foreach (var info in getInfo)
            {
                Console.WriteLine(Environment.NewLine + "Enter the " + info + " of the employee");
                getInputValue = Console.ReadLine();
                string convertInfoToString = info.ToString();
                _PropertyInfo[] properties = typeof(Employee).GetProperties();
                ///<summary>Loop throught array of properties</summary>
                foreach (_PropertyInfo property in properties)
                {
                    ///<summary>Check if the same property of the object is the same as the used item info from enum</summary>
                    if (property.Name == convertInfoToString)
                    {
                        ///<summary>After the check assign value to property of the object</summary>
                        property.SetValue(employee, getInputValue, null);
                    }
                }
            }
            ///<summary>Add new employee in the list</summary>
            employeesList.Add(employee);
            Console.WriteLine("New Employee was added");
            Console.WriteLine("Press enter to continue");
        }

        /// <summary>The Main menu in text format</summary>
        /// <returns>Output text in console</returns>
        public static void GetMainMenu()
        {
            Console.WriteLine("   ########-HR Program-#########" +
                           Environment.NewLine + "   Press 'S or s' to Search employee or project" +
                           Environment.NewLine + "   Press 'A or a' key to Add employee" +
                           Environment.NewLine + "   Press 'P or p' key to print all employees" +
                           Environment.NewLine + "   Press 'Q or q' key to quit.");
        }

        /// <summary>The Submenu in text format</summary>
        /// <returns>Output text in console</returns>
        public static void GetSubMenu()
        {
            Console.WriteLine(
                        Environment.NewLine + "What would you like to find:" +
                        Environment.NewLine + "   Type 'N' key and press Enter to search names" +
                        Environment.NewLine + "   Type 'PO' key and press Enter to search position" +
                        Environment.NewLine + "   Type 'PR' key and press Enter to search project" +
                        Environment.NewLine + "   Type 'Q' key and press Enter to get back "
                        );
        }

        /// <summary>
        /// Check all employees fields and if some field doesn't exist don't print it
        /// </summary>
        /// <param name="isEmptyList" type="integer"></param>
        /// <param name="item" type="Employee"></param>
        /// <returns>List with all employees</returns>
        public static int CheckEmployeesFields(int isEmptyList, Employee item)
        {
            isEmptyList++;//increase isEmptyList every time it has been called
            if (item.Name != null && item.Name != "")//if item.Name is null or empty the code in curly braces won't execute
            {
                Console.WriteLine(Environment.NewLine + " Name -> " + item.Name);//outputs text to console
            }
            if (item.Position != null && item.Position != "")//if item.Position is null or empty the code in curly braces
                                                             // won't execute
            {
                Console.WriteLine(" Position -> " + item.Position);//outputs text to console
            }
            if (item.Project != null && item.Project != "")//if item.Project is null or empty the code in curly braces
                                                           // won't execute
            {
                Console.WriteLine(" Project -> " + item.Project);//outputs text to console
            }
            if (item.ProjectManager != null && item.ProjectManager != "")//if item.ProjectManager is null or empty the code in 
                                                                         //curly braces won't execute
            {
                Console.WriteLine(" Project Manager -> " + item.ProjectManager);//outputs text to console
            }
            if (item.TeamLeader != null && item.TeamLeader != "")//if item.TeamLeader is null or empty the code in 
                                                                 //curly braces won't execute
            {
                Console.WriteLine(" Team Leader -> " + item.TeamLeader);//outputs text to console
            }
            if (item.DeliveryDirector != null && item.DeliveryDirector != "")//if item.DeliveryDirector is null or empty the code in 
                                                                             //curly braces won't execute
            {
                Console.WriteLine(" Delivery Director -> " + item.DeliveryDirector);//outputs text to console
            }
            if (item.Ceo != null && item.Ceo != "")//if item.Ceo is null or empty the code in 
                                                   //curly braces won't execute
            {
                Console.WriteLine(" Ceo -> " + item.Ceo);//outputs text to console
            }
            Console.WriteLine(Environment.NewLine);
            return isEmptyList;
        }

        public static void NoSuchEmployeeMessage()
        {
            Console.WriteLine("There isn't employee with this name in the company");
        }
        public static void NoSuchPositionMessage()
        {
            Console.WriteLine("There isn't position with this name in the company");
        }
        public static void NoSuchProjectMessage()
        {
            Console.WriteLine("There isn't project with this name in the company");
        }
    }
}
