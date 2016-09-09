using System;

namespace HumanResourcesSystem
{
   public class MessageExceptions
    {
        public void NoSuchEmployeeMessage()
        {
            Console.WriteLine("There isn't employee with this name in the company");
        }
        public void NoSuchEmailMessage()
        {
            Console.WriteLine("There isn't employee with this email in the company");
        }
        public void NoSuchPositionMessage()
        {
            Console.WriteLine("There isn't position with this name in the company");
        }
        public void NoSuchPhoneMessage()
        {
            Console.WriteLine("There isn't employee with this phone number in the company");
        }
        public void NoSuchProjectMessage()
        {
            Console.WriteLine("There isn't project with this name in the company");
        }
        public void NoSuchManagerNameMessage()
        {
            Console.WriteLine("There isn't Manager in the company with this name");
        }
    }
}
