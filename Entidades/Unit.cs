using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.Entidades
{
    public class Unit
    {
        protected Unit() { }
        public Unit(string name, string adress)
        {
            Name = name;
            Adress = adress;
            Coachs = new List<Coach>();
            Clients = new List<Client>();
            Machines = new List<Machine>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Client> Clients { get; set; }
        public List<Coach> Coachs { get; set; }
        public List<Machine> Machines { get; set; }


    }
}
