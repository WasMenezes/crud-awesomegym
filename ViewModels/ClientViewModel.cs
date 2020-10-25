using AwesomeGym.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.ViewModels
{
    public class ClientViewModel {
        public ClientViewModel(string name, StatusClientEnum status)
        {
            Name = name;
            Status = status;
        }

        public string Name { get; set; }
        public StatusClientEnum Status { get; set; }

    }
}
