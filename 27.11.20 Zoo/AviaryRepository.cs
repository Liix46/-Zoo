using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._11._20_Zoo
{
    static public class AviaryRepository
    {
        static readonly List<Aviary> _aviaries = new List<Aviary>();

        static public List<Aviary> Aviaries
        {
            get => _aviaries;
        }
    }
}
