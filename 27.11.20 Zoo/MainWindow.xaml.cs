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
        private static string _currentUser;
        private DispatcherTimer timer = new DispatcherTimer();
        private Button btn;
        private ComboBoxItem cbi;
        private Image selectedImage = new Image();
        private Image btnImage = new Image();
        private DispatcherTimer buildTimer = new DispatcherTimer();
        
        public XmlReaderWriter XmlReaderWriter = new XmlReaderWriter();
        public List<IAnimal> emptyAnimals = new List<IAnimal>()
        {
            new AnimalAntelope(),
            new AnimalBison(),
            new AnimalBuffalo(),
            new AnimalElephant(),
            new AnimalGiraffe(),
            new AnimalGorilla(),
            new AnimalGuepard(),
            new AnimalHippo(),
            new AnimalHyena(),
            new AnimalLion(),
            new AnimalMandrill(),
            new AnimalMonkey(),
            new AnimalRhinoceros(),
            new AnimalTurtle(),
            new AnimalWarthog(),
            new AnimalZebra()};

    public MainWindow()
        {
            InitializeComponent();
        }

        public static string CurrentUser
        {
            get => _currentUser;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("User login cannot be null");
                    }
                    _currentUser = value;
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void MainWindow_Initialized(object sender, EventArgs e)
        {

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                emptyAnimals.Add(new AnimalAntelope());
                emptyAnimals.Add(new AnimalBison());
                emptyAnimals.Add(new AnimalBuffalo());
                emptyAnimals.Add(new AnimalElephant());
                emptyAnimals.Add(new AnimalGiraffe());
                emptyAnimals.Add(new AnimalGorilla());
                emptyAnimals.Add(new AnimalGuepard());
                emptyAnimals.Add(new AnimalHippo());
                emptyAnimals.Add(new AnimalHyena());
                emptyAnimals.Add(new AnimalLion());
                emptyAnimals.Add(new AnimalMandrill());
                emptyAnimals.Add(new AnimalMonkey());
                emptyAnimals.Add(new AnimalRhinoceros());
                emptyAnimals.Add(new AnimalTurtle());
                emptyAnimals.Add(new AnimalWarthog());
                emptyAnimals.Add(new AnimalZebra());

                timer = new DispatcherTimer();
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();

                XmlReaderWriter.ReadUsers();
                XmlReaderWriter.ReadAviaries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            XmlReaderWriter.WriteUsers();
            XmlReaderWriter.WriteAviaries();
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
            btnImage.Opacity = 0;
            btn.Content = btnImage;

            buildTimer.Tick += new EventHandler(buildTimer_Tick);
            buildTimer.Interval = new TimeSpan(0, 0, 1);
            buildTimer.Start();
        }

        private void buildTimer_Tick(object sender, EventArgs e)
        {
            btnImage.Opacity += 0.25;

            if (btnImage.Opacity == 1)
                buildTimer.Stop();
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
            AviaryWindow aviaryWindow = new AviaryWindow();
            aviaryWindow.ShowDialog();
        }
    }
}
