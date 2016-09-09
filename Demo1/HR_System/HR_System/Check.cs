using System;


namespace HumanResourcesSystem
{
    public class Check
    {
        public static int CheckEmployeesFields(int isEmptyList, Employee item)//method that takes isEmptyList, item as params
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
    }
}