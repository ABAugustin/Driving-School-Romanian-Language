/**************************************************************************
 *                                                                        *
 *  File:        DataParserClass.cs                                       *
 *  Copyright:   (c) 2023 Ana Maria Toma, Augustin Topciu, Stefania Luca  *
 *  E-mail:      augustin.topciu@student.tuiasi.ro                        *
 *               stefania.luca@student.tuiasi.ro                          *
 *               ana-maria.toma2@student.tuiasi.ro                        *
 *                                                                        *
 *  Description: Clasa DataParserClass parseaza fisierul text             *
 *               cu intrebari.                                            *
 *                                                                        *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataPerserDLL
{
    public class DataParser
    {

        static string _textFilePath = "Users\\data for ip\\info.txt";   // calea spre fisierul cu intrebari


        private List<Intrebare> _stackDeIntrebari;                      // lista de intrebari 

        public List<Intrebare> GetStack()
        {
            return _stackDeIntrebari;
        }

        // metoda pentru popularea listei de intrebari din fisierul text
        public void fillStack()
        {
            string linie1, linie2, linie3, linie4, linie5;
            string numar = "no number", intr = "no question", a1 = "answer 1", a2 = "answer2", a3 = "answer3", path = "0";
            bool rez1 = false, rez2 = false, rez3 = false;
            _stackDeIntrebari = new List<Intrebare>();

            if (File.Exists(_textFilePath))
            {
                using (StreamReader file = new StreamReader(_textFilePath))
                {
                    int i = 0;
                    string linie;

                    while ((linie = file.ReadLine()) != null)
                    {
                        i++;

                        switch (i)
                        {
                            case 1:
                                linie1 = linie;
                                var firstSpaceIndex = linie1.IndexOf(" ");
                                numar = linie1.Substring(0, firstSpaceIndex);
                                intr = linie1.Substring(firstSpaceIndex + 1);
                                break;
                            case 2:
                                linie2 = linie;
                                if(linie2.Contains("corect"))
                                {
                                    rez1= true;
                                }
                                else
                                {
                                    rez1 = false;
                                }
                               
                                a1 = linie2.Substring(10);
                                break;
                            case 3:
                                linie3 = linie;
                                if (linie3.Contains("corect"))
                                {
                                    rez2 = true;
                                }
                                else
                                {
                                    rez2 = false;
                                }
                                a2 = linie3.Substring(10);
                                break;
                            case 4:
                                linie4 = linie;
                                if (linie4.Contains("corect"))
                                {
                                    rez3 = true;
                                }
                                else
                                {
                                    rez3 = false;
                                }
                                a3 = linie4.Substring(10);
                                break;
                            case 5:
                                linie5 = linie;
                                if (!linie5.Contains("ImagineaNU"))
                                {
                                    path = "Users\\data for ip\\" + numar + ".png";
                                }
                                else
                                {
                                    path = "nope";
                                }
                                break;
                        }

                        if (i == 5)
                        {
                            i = 0;
                            string emptyLine = file.ReadLine();
                            Intrebare intrebare = new Intrebare(numar, intr, a1, a2, a3, rez1, rez2, rez3, path);
                            _stackDeIntrebari.Add(intrebare);
                        }
                    }

                    file.Close();
                }
            }
        }

       

    }
}
