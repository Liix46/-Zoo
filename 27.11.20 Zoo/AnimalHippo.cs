using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _27._11._20_Zoo
{
    class AnimalHippo : IAnimal
    {
        public string _breed;// вид животного
        public int _health;
        public int _bellyful; //сытость

        public string Breed
        {
            get => _breed;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Breed cannot be null");
                    }
                    else if (value.Trim().Length == 0)
                    {
                        throw new ArgumentException("Breed length cannot be 0");
                    }
                    _breed = value;
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
        public int Health
        {
            get => _health;
            set
            {
                try
                {
                    if (value < 0 && value > 100)
                    {
                        throw new ArgumentException("Health cannot be less than 0 and cannot be bigger than 100");
                    }
                    _health = value;
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
        public int Bellyful
        {
            get => _bellyful;
            set
            {
                try
                {
                    if (value < 0 && value > 100)
                    {
                        throw new ArgumentException("Health cannot be less than 0 and cannot be bigger than 100");
                    }
                    _bellyful = value;
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
    }
}
