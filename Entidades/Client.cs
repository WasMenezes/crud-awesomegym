using AwesomeGym.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.Entidades
{
    public class Client
    {
        protected Client() { }
        public Client(string name, string adress, DateTime dateBirth)
        {
            Name = name;
            Adress = adress;
            DateBirth = dateBirth;
            Status = StatusClientEnum.Active;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Adress { get; set; }
        public DateTime DateBirth { get; private set; }
        public StatusClientEnum Status { get; private set; }

        public int IdUnit { get; private set; }
        public Unit Unit { get; private set; }

        public int IdCoach { get; private set; }
        public Coach Coach { get; private set; }

        public void ChangeToInactiveStatus()
        {
            if (Status != StatusClientEnum.Active)
            {
                throw new Exception("Estado inválido");
            }

            Status = StatusClientEnum.Inactive;
        }
    }
}
