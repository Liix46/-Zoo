using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._11._20_Zoo
{
    interface IAnimal
    {
        string Breed { get; set; }
        int Health { get; set; }
        int Bellyful { get; set; }
    }
}
