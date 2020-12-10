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
    class Aviary
    {
        private Thickness _margin;
        private Image _img;

        public Button AviaryBtn { get; set; }
        public ImageSource Img { get => _img.Source; set => _img.Source = value; }
        public Thickness Margin { get => _margin;}
        public List<Animal> Animals { get; set; }

        public Aviary(Button btn)
        {
            AviaryBtn = btn;
            Animals = new List<Animal>();
            _margin = AviaryBtn.Margin;
            _img = (Image)AviaryBtn.Content;
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

    }
}
