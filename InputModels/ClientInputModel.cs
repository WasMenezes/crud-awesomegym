using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.InputModels
{
    public class ClientInputModel
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime DateBirth { get; set; }
        public int idCoach { get; set; }
        public int idUnit { get; set; }

    }
}
