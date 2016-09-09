
namespace HumanResourcesApplication
{
    public class Employee
    {
        private string name;              //    declare name field of the employee
        private string position;          //    declare position field of the employee
        private string project;           //    declare project field of the employee
        private string projectManager;    //    declare projectManager field of the employee
        private string teamLeader;        //    declare teamLeader field of the employee
        private string deliveryDirector;  //    declare deliveryDirector field of the employee
        private string ceo;               //    declare ceo field of the employee


        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;

            }
        }
        public string Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        public string Project
        {
            get
            {
                return this.project;
            }
            set
            {
                this.project = value;
            }
        }
        public string ProjectManager
        {
            get
            {
                return this.projectManager;
            }
            set
            {
                this.projectManager = value;
            }
        }
        public string TeamLeader
        {
            get
            {
                return this.teamLeader;
            }
            set
            {
                this.teamLeader = value;
            }
        }
        public string DeliveryDirector
        {
            get
            {
                return this.deliveryDirector;
            }
            set
            {
                this.deliveryDirector = value;
            }
        }
        public string Ceo
        {
            get
            {
                return this.ceo;
            }
            set
            {
                this.ceo = value;
            }
        }
    }
}