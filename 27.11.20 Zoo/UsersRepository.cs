using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _27._11._20_Zoo
{
    static public class UsersRepository
    {
        static readonly List<User> _users = new List<User>();

        static public List<User> Users
        {
            get => _users;
        }
    }
}
