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
        private string _btnName;
        private Image _img;
        private int _profit;
        public Button AviaryBtn { get; set; }
        public ImageSource Img { get => _img.Source; set => _img.Source = value; }
        public string Type { get; set; }
        public int Price { get; set; }

        public int Profit { 
            get
            {
                for (int i = 0; i < Animals.Count; i++)
                {
                    //_profit += Animals[i].Income;
                }

                _profit += Price;

                return _profit;
            }
        }

        public Aviary() { }
        public Aviary(Button btn, string type, int price)
        {
            _btnName = btn.Name;
            AviaryBtn = btn;
            _img = (Image)AviaryBtn.Content;
            Type = type;
            Price = price;
            Animals = new List<IAnimal>();            
        }

        
        public List<IAnimal> Animals { get; set; }    
        
        public void AddAnimal(IAnimal animal)
        {
            Animals.Add(animal);
        }

    }
}
