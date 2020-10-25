using AwesomeGym.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.Entidades
{
    public class Machine
    {
        public Machine() { }
        public Machine(string name, string serialNumber, int idUnit)
        {
            Name = name;
            SerialNumber = serialNumber;
            IdUnit = idUnit;
            State = MachineEnum.Active;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public MachineEnum State { get; set; }
        public int IdUnit { get; set; }
        public Unit Unit { get; set; }

        public void ChangeToInactiveStatus()
        {
            if (State != MachineEnum.Active)
            {
                throw new Exception("Erro de Estado");
            }


        }
    }
}
