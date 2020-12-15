using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Windows.Controls;

namespace _27._11._20_Zoo
{
     public class XmlReaderWriter
    {
        
        public void ReadUsers()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("users.xml");

                // получаем корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    User newUser = new User();

                    // получаем атрибут level
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
        public void WriteUsers()
        {
            try
            {
                DeleteAllXmlNodes("users.xml");

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("users.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                foreach (var ev in UsersRepository.Users)
                {
                    XmlElement userElem;
                    // создаем новый элемент user
                    userElem = xDoc.CreateElement("user");
                    // создаем атрибут level
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
        //static public void ReadAnimals()
        //{
        //    try
        //    {
        //        XmlDocument xDoc = new XmlDocument();
        //        xDoc.Load("animals.xml");

        //        // получаем корневой элемент
        //        XmlElement xRoot = xDoc.DocumentElement;

        //        // обход всех узлов в корневом элементе
        //        foreach (XmlNode xnode in xRoot)
        //        {
        //            Animal newAnimal = new Animal();

        //            // получаем атрибут breed
        //            if (xnode.Attributes.Count > 0)
        //            {
        //                XmlNode attr = xnode.Attributes.GetNamedItem("breed");
        //                if (attr != null)
        //                {
        //                    newAnimal.Breed = attr.Value;
        //                }
        //            }
        //            // обходим все дочерние узлы элемента animal
        //            foreach (XmlNode childnode in xnode.ChildNodes)
        //            {
        //                // если узел - health
        //                if (childnode.Name == "health")
        //                {
        //                    newAnimal.Health = Int32.Parse(childnode.InnerText);
        //                }
        //                if (childnode.Name == "bellyful")
        //                {
        //                    newAnimal.Bellyful = Int32.Parse(childnode.InnerText);
        //                }
        //                if (childnode.Name == "imagePath")
        //                {
        //                    newAnimal.ImagePath = childnode.InnerText;
        //                }
        //                if (childnode.Name == "xPosition")
        //                {
        //                    newAnimal.XPos = Int32.Parse(childnode.InnerText);
        //                }
        //                if (childnode.Name == "yPosition")
        //                {
        //                    newAnimal.YPos = Int32.Parse(childnode.InnerText);
        //                }
        //            }
        //            AnimalRepository.Animals.Add(new Animal(newAnimal.Breed, newAnimal.Health, newAnimal.Bellyful,
        //                                                    newAnimal.ImagePath, newAnimal.XPos, newAnimal.YPos));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error");
        //    }
        //}
        //static public void WriteAnimals()
        //{
        //    try
        //    {
        //        DeleteAllXmlNodes("animals.xml");

        //        XmlDocument xDoc = new XmlDocument();
        //        xDoc.Load("animals.xml");
        //        XmlElement xRoot = xDoc.DocumentElement;

        //        foreach (var ev in AnimalRepository.Animals)
        //        {
        //            XmlElement animalElem;
        //            // создаем новый элемент animal
        //            animalElem = xDoc.CreateElement("animal");
        //            // создаем атрибут breed
        //            XmlAttribute breedAttr = xDoc.CreateAttribute("breed");
        //            // создаем элемент health
        //            XmlElement healthElem = xDoc.CreateElement("health");
        //            // создаем элемент bellyful
        //            XmlElement bellyfulElem = xDoc.CreateElement("bellyful");
        //            // создаем элемент imagePath
        //            XmlElement imagePathElem = xDoc.CreateElement("imagePath");
        //            // создаем элемент xPosition
        //            XmlElement xPosElem = xDoc.CreateElement("xPosition");
        //            // создаем элемент yPosition
        //            XmlElement yPosElem = xDoc.CreateElement("yPosition");
        //            // создаем текстовые значения для элементов и атрибута
        //            XmlText breedText = xDoc.CreateTextNode(ev.Breed.ToString());
        //            XmlText healthText = xDoc.CreateTextNode(ev.Health.ToString());
        //            XmlText bellyfulText = xDoc.CreateTextNode(ev.Bellyful.ToString());
        //            XmlText imagePathText = xDoc.CreateTextNode(ev.ImagePath.ToString());
        //            XmlText xPosText = xDoc.CreateTextNode(ev.XPos.ToString());
        //            XmlText yPosText = xDoc.CreateTextNode(ev.YPos.ToString());

        //            //добавляем узлы
        //            breedAttr.AppendChild(breedText);
        //            healthElem.AppendChild(healthText);
        //            bellyfulElem.AppendChild(bellyfulText);
        //            imagePathElem.AppendChild(imagePathText);
        //            xPosElem.AppendChild(xPosText);
        //            yPosElem.AppendChild(yPosText);
        //            animalElem.Attributes.Append(breedAttr);
        //            animalElem.AppendChild(healthElem);
        //            animalElem.AppendChild(bellyfulElem);
        //            animalElem.AppendChild(imagePathElem);
        //            animalElem.AppendChild(xPosElem);
        //            animalElem.AppendChild(yPosElem);
        //            xRoot.AppendChild(animalElem);
        //        }
        //        xDoc.Save("animals.xml");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error");
        //    }
        //}
        public void ReadAviaries()
        {
            try
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("aviaries.xml");

                // получаем корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    Aviary newAviary = new Aviary();

                    // обходим все дочерние узлы элемента aviary
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - userLogin
                        if (childnode.Name == "userLogin")
                        {
                            if (MainWindow.CurrentUser != childnode.InnerText)
                            {
                                break;
                            }
                        }
                        if (childnode.Name == "imagePath")
                        {
                            newAviary.ImagePath = childnode.InnerText;
                        }
                        if (childnode.Name == "xPosition")
                        {
                            newAviary.XPos = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "yPosition")
                        {
                            newAviary.YPos = Int32.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "animals")
                        {
                            foreach (XmlNode child in childnode.ChildNodes)
                            {
                                IAnimal newAnimal = null;
                                foreach (var animal in mainWindow.emptyAnimals)
                                {
                                    if (animal.GetType() == child.GetType())
                                    {
                                         newAnimal = animal.Clone();                                        
                                    }
                                }                               

                                // получаем атрибут breed
                                if (xnode.Attributes.Count > 0)
                                {
                                    XmlNode attr = xnode.Attributes.GetNamedItem("breed");
                                    if (attr != null)
                                    {
                                        newAnimal.Breed = attr.Value;
                                    }
                                }
                                // обходим все дочерние узлы элемента animal
                                foreach (XmlNode childAnimal in xnode.ChildNodes)
                                {
                                    // если узел - health
                                    if (childAnimal.Name == "health")
                                    {
                                        newAnimal.Health = Int32.Parse(childAnimal.InnerText);
                                    }
                                    if (childAnimal.Name == "bellyful")
                                    {
                                        newAnimal.Bellyful = Int32.Parse(childAnimal.InnerText);
                                    }
                                    if (childAnimal.Name == "imagePath")
                                    {
                                        newAnimal.ImagePath = childAnimal.InnerText;
                                    }
                                    if (childAnimal.Name == "xPosition")
                                    {
                                        newAnimal.XPos = Int32.Parse(childAnimal.InnerText);
                                    }
                                    if (childAnimal.Name == "yPosition")
                                    {
                                        newAnimal.YPos = Int32.Parse(childAnimal.InnerText);
                                    }
                                }
                                newAviary.Animals.Add(newAnimal);
                            }
                        }
                    }
                    AviaryRepository.Aviaries.Add(new Aviary(newAviary.ImagePath, newAviary.XPos, newAviary.YPos, newAviary.Animals));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        static public void WriteAviaries()
        {
            try
            {
                DeleteAllXmlNodes("aviaries.xml");

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("aviaries.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                foreach (var aviary in AviaryRepository.Aviaries)
                {
                    XmlElement aviaryElem;
                    // создаем новый элемент aviary
                    aviaryElem = xDoc.CreateElement("aviary");
                    // создаем элемент userlogin
                    XmlElement userLoginElem = xDoc.CreateElement("userLogin");
                    // создаем элемент imagePath
                    XmlElement imagePathElem = xDoc.CreateElement("imagePath");
                    // создаем элемент rating
                    XmlElement xPosElem = xDoc.CreateElement("xPosition");
                    // создаем элемент builders
                    XmlElement yPosElem = xDoc.CreateElement("yPosition");
                    // создаем текстовые значения для элементов
                    XmlText userLoginText = xDoc.CreateTextNode(MainWindow.CurrentUser);
                    XmlText imagePathText = xDoc.CreateTextNode(aviary.ImagePath.ToString());
                    XmlText xPosText = xDoc.CreateTextNode(aviary.XPos.ToString());
                    XmlText yPosText = xDoc.CreateTextNode(aviary.YPos.ToString());

                    //добавляем узлы
                    userLoginElem.AppendChild(userLoginText);
                    imagePathElem.AppendChild(imagePathText);
                    xPosElem.AppendChild(xPosText);
                    yPosElem.AppendChild(yPosText);
                    aviaryElem.AppendChild(userLoginElem);
                    aviaryElem.AppendChild(imagePathElem);
                    aviaryElem.AppendChild(xPosElem);
                    aviaryElem.AppendChild(yPosElem);

                    XmlElement animalsElem;
                    animalsElem = xDoc.CreateElement("animals");
                    foreach (var animal in aviary.Animals)
                    {
                        XmlElement animalElem;
                        // создаем новый элемент animal
                        animalElem = xDoc.CreateElement("animal");
                        // создаем атрибут breed
                        XmlAttribute breedAttr = xDoc.CreateAttribute("breed");
                        // создаем элемент health
                        XmlElement healthElem = xDoc.CreateElement("health");
                        // создаем элемент bellyful
                        XmlElement bellyfulElem = xDoc.CreateElement("bellyful");
                        // создаем элемент imagePath
                        XmlElement animalImagePathElem = xDoc.CreateElement("imagePath");
                        // создаем элемент xPosition
                        XmlElement animalXPosElem = xDoc.CreateElement("xPosition");
                        // создаем элемент yPosition
                        XmlElement animalYPosElem = xDoc.CreateElement("yPosition");
                        // создаем текстовые значения для элементов и атрибута
                        XmlText breedText = xDoc.CreateTextNode(animal.Breed);
                        XmlText healthText = xDoc.CreateTextNode(animal.Health.ToString());
                        XmlText bellyfulText = xDoc.CreateTextNode(animal.Bellyful.ToString());
                        XmlText animalImagePathText = xDoc.CreateTextNode(animal.ImagePath);
                        XmlText animalXPosText = xDoc.CreateTextNode(animal.XPos.ToString());
                        XmlText animalYPosText = xDoc.CreateTextNode(animal.YPos.ToString());

                        //добавляем узлы
                        breedAttr.AppendChild(breedText);
                        healthElem.AppendChild(healthText);
                        bellyfulElem.AppendChild(bellyfulText);
                        imagePathElem.AppendChild(animalImagePathText);
                        xPosElem.AppendChild(animalXPosText);
                        yPosElem.AppendChild(animalYPosText);
                        animalElem.Attributes.Append(breedAttr);
                        animalElem.AppendChild(healthElem);
                        animalElem.AppendChild(bellyfulElem);
                        animalElem.AppendChild(imagePathElem);
                        animalElem.AppendChild(xPosElem);
                        animalElem.AppendChild(yPosElem);
                        animalsElem.AppendChild(animalElem);
                    }
                    xRoot.AppendChild(aviaryElem);
                }
                xDoc.Save("aviaries.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        static private void DeleteAllXmlNodes(string path)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);

                // получаем корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                xRoot.RemoveAll();
                xDoc.Save(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
