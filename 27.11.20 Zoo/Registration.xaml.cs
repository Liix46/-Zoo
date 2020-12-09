using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _27._11._20_Zoo
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        // private UsersRepository _usersRepository = new UsersRepository();
        public Registration()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User
            {
                Login = loginTextBox.Text,
                Password = passwordTextBox.Password
            };
            foreach (var item in UsersRepository.Users)
            {
                if (item.Login == newUser.Login && item.Password == newUser.Password)
                {
                    MessageBox.Show("You logged in successfully!");
                    Close();
                    return;
                }
            }
            MessageBox.Show("Login or password is incorrect");
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User
            {
                Login = loginTextBox.Text,
                Password = passwordTextBox.Password
            };
            foreach (var item in UsersRepository.Users)
            {
                if (item.Login == newUser.Login)
                {
                    MessageBox.Show("This login already exists");
                    return;
                }
            }
            UsersRepository.Users.Add(newUser);
            MessageBox.Show("Account has been successfully added!");

            Close();
        }

        private void RegistrationWindow_Closed(object sender, EventArgs e)
        {
            //  Owner.Close();
        }
    }
}
