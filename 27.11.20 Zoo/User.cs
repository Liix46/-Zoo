using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _27._11._20_Zoo
{
    public class User
    {
        private string _login;
        private string _password;
        private int _gold = 500;
        private int _level = 1;
        private int _rating = 0;
        private int _builders = 1;

        public User()
        {

        }
        public User(string login, string password, int gold, int level, int rating, int builders)
        {
            _login = login;
            _password = password;
            _gold = gold;
            _level = level;
            _rating = rating;
            _builders = builders;
        }
        public string Login
        {
            get => _login;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Login cannot be null");
                    }
                    else if (value.Trim().Length == 0)
                    {
                        throw new ArgumentException("Login length cannot be 0");
                    }
                    _login = value;
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Login cannot be null");
                    }
                    else if (value.Trim().Length == 0)
                    {
                        throw new ArgumentException("Login length cannot be 0");
                    }
                    _password = value;
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public int Gold
        {
            get => _gold;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Login cannot be null");
                    }
                    _gold = value;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Login cannot be null");
                    }
                    _level = value;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public int Rating
        {
            get => _rating;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Login cannot be null");
                    }
                    _rating = value;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public int Builders
        {
            get => _builders;
            set
            {
                try
                {
                    if (value < 0 && value > 2)
                    {
                        throw new ArgumentException("Login cannot be null");
                    }
                    _builders = value;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}
