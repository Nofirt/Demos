using System;

namespace HumanResourcesSystem
{
   public class Menus
    {
        public static void MainMenuEmployee()
        {
            Console.WriteLine(Environment.NewLine + "   -----------------HR Program-----------------" + Environment.NewLine +
                           Environment.NewLine + "   Press 'A or a' key to Add employee" +
                           Environment.NewLine + "   Press 'S or s' to Search employee or project" +
                           Environment.NewLine + "   Press 'P or p' key to print all employees" +
                           Environment.NewLine + "   Press 'Q or q' key to quit.");
        }


        public static void SubMenuEmployee()
        {
            Console.WriteLine(
                        Environment.NewLine + "   What would you like to find:" +
                        Environment.NewLine + "   Type 'N' key and press Enter to search names" +
                        Environment.NewLine + "   Type 'PO' key and press Enter to search position" +
                        Environment.NewLine + "   Type 'PR' key and press Enter to search project" +
                        Environment.NewLine + "   Type 'Q' key and press Enter to get back "
                        );
        }
    }
}
