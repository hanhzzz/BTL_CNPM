using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_CNPM.Objects
{
    public class Jobs
    {
        private String idJob;
        private String nameJob;
        private String nameComp;
        private String position;
        private String salary;
        private String address;
        private DateTime deadline;
        private int quantity;

        public Jobs(string idJob, string nameJob, string nameComp, string position, string salary, string address, DateTime deadline, int quantity)
        {
            this.IdJob = idJob;
            this.NameJob = nameJob;
            this.NameComp = nameComp;
            this.Position = position;
            this.Salary = salary;
            this.Address = address;
            this.Deadline = deadline;
            this.Quantity = quantity;
        }

        public string IdJob { get => idJob; set => idJob = value; }
        public string NameJob { get => nameJob; set => nameJob = value; }
        public string NameComp { get => nameComp; set => nameComp = value; }
        public string Position { get => position; set => position = value; }
        public string Salary { get => salary; set => salary = value; }
        public string Address { get => address; set => address = value; }
        public DateTime Deadline { get => deadline; set => deadline = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}