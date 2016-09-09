using System;

namespace HumanResourcesSystem
{
    public class Employee
    {
        private string name; //field is declared
        private string position;
        private string project;
        private string projectManager;
        private string teamLeader;
        private string deliveryDirector;
        private string ceo;


        public string Name  //properties
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
        public string Position//properties
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
        public string Project//properties
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
        public string ProjectManager//properties
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
        public string TeamLeader//properties
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
        public string DeliveryDirector//properties
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
        public string Ceo//properties
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
