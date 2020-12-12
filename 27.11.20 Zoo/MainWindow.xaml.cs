using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Xml;


namespace _27._11._20_Zoo
{

    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        static private Button btn;
        static private ComboBoxItem cbi;
        static private Image selectedImage = new Image();
        static private Image btnImage = new Image();
        //static public Point point = new Point();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Initialized(object sender, EventArgs e)
        {

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                timer = new DispatcherTimer();
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("users.xml");


                // получаем корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    User newUser = new User();

                    // получаем атрибут name
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("level");
                        if (attr != null)
                        {
                            newUser.Level = Int32.Parse(attr.Value);
                        }
                    }
                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - login
                        if (childnode.Name == "login")
                        {
                            newUser.Login = childnode.InnerText;
                        }
                        if (childnode.Name == "password")
                        {
                            newUser.Password = childnode.InnerText;
                        }
                        if (childnode.Name == "gold")
                        {
                            newUser.Gold = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "rating")
                        {
                            newUser.Rating = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "builders")
                        {
                            newUser.Builders = Int32.Parse(childnode.InnerText);
                        }
                    }
                    UsersRepository.Users.Add(new User(newUser.Login, newUser.Password, newUser.Gold, newUser.Level, newUser.Rating, newUser.Builders));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                DeleteAllXmlNodes();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("users.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                foreach (var ev in UsersRepository.Users)
                {
                    XmlElement userElem;
                    // создаем новый элемент event
                    userElem = xDoc.CreateElement("user");
                    // создаем атрибут name
                    XmlAttribute levelAttr = xDoc.CreateAttribute("level");
                    // создаем элемент login
                    XmlElement loginElem = xDoc.CreateElement("login");
                    // создаем элемент password
                    XmlElement passwordElem = xDoc.CreateElement("password");
                    // создаем элемент gold
                    XmlElement goldElem = xDoc.CreateElement("gold");
                    // создаем элемент rating
                    XmlElement ratingElem = xDoc.CreateElement("rating");
                    // создаем элемент builders
                    XmlElement buildersElem = xDoc.CreateElement("builders");
                    // создаем текстовые значения для элементов и атрибута
                    XmlText levelText = xDoc.CreateTextNode(ev.Level.ToString());
                    XmlText loginText = xDoc.CreateTextNode(ev.Login);
                    XmlText passwordText = xDoc.CreateTextNode(ev.Password);
                    XmlText goldText = xDoc.CreateTextNode(ev.Gold.ToString());
                    XmlText ratingText = xDoc.CreateTextNode(ev.Rating.ToString());
                    XmlText buildersText = xDoc.CreateTextNode(ev.Builders.ToString());

                    //добавляем узлы
                    levelAttr.AppendChild(levelText);
                    loginElem.AppendChild(loginText);
                    passwordElem.AppendChild(passwordText);
                    goldElem.AppendChild(goldText);
                    ratingElem.AppendChild(ratingText);
                    buildersElem.AppendChild(buildersText);
                    userElem.Attributes.Append(levelAttr);
                    userElem.AppendChild(loginElem);
                    userElem.AppendChild(passwordElem);
                    userElem.AppendChild(goldElem);
                    userElem.AppendChild(ratingElem);
                    userElem.AppendChild(buildersElem);
                    xRoot.AppendChild(userElem);
                }
                xDoc.Save("users.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void DeleteAllXmlNodes()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("users.xml");

                // получаем корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                xRoot.RemoveAll();
                xDoc.Save("users.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {

        }

        private void ButtonLoading_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainGrid.Visibility = Visibility.Visible;
                mainScroll.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                mainScroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;

                buttonLoading.Visibility = Visibility.Hidden;

                Registration registrationWindow = new Registration
                {
                    DataContext = this,
                    Owner = this
                };
                registrationWindow.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            buttonLoading.IsEnabled = true;

            timer.Stop();
        }

        private void AviaryBtn_Click(object sender, RoutedEventArgs e)
        {
            btn = (Button)sender;
            btnImage = (Image)btn.Content;


            double left = btn.Margin.Left;
            double top = btn.Margin.Top;
            double right = btn.Margin.Right;
            double bottom = btn.Margin.Bottom;
            Thickness thicknessLeft = new Thickness(left + btn.Width + 10, top, right, bottom);
            comboBoxAviaries.Margin = thicknessLeft;
            comboBoxAviaries.Visibility = Visibility.Visible;

            for (int i = 0; i < comboBoxAviaries.Items.Count; i++)
            {
                ComboBoxItem tmpItem = (ComboBoxItem)comboBoxAviaries.Items[i];
                if (btnImage == tmpItem.Content)
                {
                    tmpItem.IsEnabled = false;
                    break;
                }
            }
        }

        private void ComboBoxAviary_Click(object sender, RoutedEventArgs e)
        {
            comboBoxAviaries.Visibility = Visibility.Hidden;
            cbi = (ComboBoxItem)sender;

            selectedImage = (Image)cbi.Content;

            btnImage.Source = selectedImage.Source;
            btn.Content = btnImage;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Confirmation confirmationWindow = new Confirmation
                {
                    DataContext = this,
                    Owner = this
                };
                confirmationWindow.Show();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MainScroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            notificationLabel.Margin = new Thickness(mainScroll.HorizontalOffset, mainScroll.VerticalOffset, 0, 0);
            borderNickNameLabel.Margin = new Thickness(mainScroll.HorizontalOffset, mainScroll.VerticalOffset, 0, 0);
            borderGoldLabel.Margin = new Thickness(mainScroll.HorizontalOffset, mainScroll.VerticalOffset, 0, 0);
            goldImageLabel.Margin = new Thickness(mainScroll.HorizontalOffset, mainScroll.VerticalOffset, 0, 0);
            borderSettings.Margin = new Thickness(mainScroll.HorizontalOffset, mainScroll.VerticalOffset, 0, 0);
            levelImageLabel.Margin = new Thickness(mainScroll.HorizontalOffset, mainScroll.VerticalOffset, 0, 0);
        }


        public void DoubleClickAviary(object sender, RoutedEventArgs e)
        {
           // Button button = (Button)sender;
            AviaryWindow aviaryWindow = new AviaryWindow();
            aviaryWindow.ShowDialog();
            //point.X = button.Margin.Left;
            //point.Y = button.Margin.Top;
            
        }
    }
}
