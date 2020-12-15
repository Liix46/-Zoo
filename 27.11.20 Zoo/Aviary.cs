using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _27._11._20_Zoo
{
    public class Aviary
    {
        // private Thickness _margin;
        private Image _img;
        private string _imagePath;
        private int _xPos;
        private int _yPos;

        public Aviary() { }
        public Aviary(string imagePath, int xPos, int yPos, List<IAnimal> animals)
        {
            _imagePath = imagePath;
            _xPos = xPos;
            _yPos = yPos;
            Animals = animals;
        }
        public Button AviaryBtn { get; set; }
        public ImageSource Img { get => _img.Source; set => _img.Source = value; }
        //public Thickness Margin { get => _margin;}
        public List<IAnimal> Animals { get; set; }
        public int XPos
        {
            get => _xPos;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("X position cannot be less than 0!");
                    }
                    _xPos = value;
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
        public int YPos
        {
            get => _yPos;
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Y position cannot be less than 0!");
                    }
                    _yPos = value;
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
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Image path cannot be null!");
                    }
                    _imagePath = value;
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

        /// Очень мне это не нравится (c) Dmitry
        public Aviary(Button btn)
        {
            AviaryBtn = btn;
            Animals = new List<IAnimal>();
            //_margin = AviaryBtn.Margin;
            _img = (Image)AviaryBtn.Content;
        }

        public void AddAnimal(IAnimal animal)
        {
            Animals.Add(animal);
        }

    }
}
