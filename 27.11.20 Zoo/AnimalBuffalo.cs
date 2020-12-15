using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _27._11._20_Zoo
{
    class AnimalBuffalo : IAnimal
    {
        public string _breed;// вид животного
        public int _health;
        public int _bellyful; //сытость
        private string _imagePath;
        private int _xPos;
        private int _yPos;

        public AnimalBuffalo() { }
        public AnimalBuffalo(string breed, int health, int bellyful, string imagePath, int xPos, int yPos)
        {
            _breed = breed;
            _health = health;
            _bellyful = bellyful;
            _imagePath = imagePath;
            _xPos = xPos;
            _yPos = yPos;
        }

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

        public IAnimal Clone()
        {
            return new AnimalBuffalo();
        }
    }
}

