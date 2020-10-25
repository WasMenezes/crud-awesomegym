using AwesomeGym.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.Entidades
{
    public class Coach
    {
        protected Coach() { }
        public Coach(string name, string adress)
        {
            Name = name;
            Adress = adress;
            Status = StatusCoachEnum.Active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public StatusCoachEnum Status { get; set; }
        public List<Client> Clients { get; set; }

        public int IdUnit { get; set; }
        public Unit Unit { get; set; }

        public void ChangeToInactiveStatus()
        {
            if (Status != 0)
            {
                throw new Exception("Estado Inválido");
            }

            Status = StatusCoachEnum.Inactive;
        }
    }
}
