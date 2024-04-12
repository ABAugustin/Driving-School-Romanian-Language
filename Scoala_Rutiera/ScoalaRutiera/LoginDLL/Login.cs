/**************************************************************************
 *                                                                        *
 *  File:        Login.cs                                                 *
 *  Copyright:   (c) 2023 Ana Maria Toma, Augustin Topciu, Stefania Luca  *
 *  E-mail:      augustin.topciu@student.tuiasi.ro                        *
 *               stefania.luca@student.tuiasi.ro                          *
 *               ana-maria.toma2@student.tuiasi.ro                        *
 *                                                                        *
 *  Description: Clasa Login preia din fisierul utilizatori.txt           *
 *               numele de utilizatori si hash-ul parolei pentru logare.  *
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

using EncryptDLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginDLL
{
    public class Login
    {
        private List<User> _users = new List<User>();  // lista de utilizatori
        private const string Path = "Users\\";         // calea spre fisierul text in care sunt stocati utilizatorii

        public struct User
        {
            public readonly string Name;            // nume uitilizator
            public readonly string PassHash;        // codul hash al parolei utilizatorului

            public User(string name, string passHash)
            {
                Name = name;
                PassHash = passHash;
            }
        }

        //metoda care face extragerea utilizatorilor din fisierul text in lista de utilizatori
        public void ObtainUsers()
        {
            try
            {
                _users = new List<User>();
                StreamReader sr = new StreamReader(Path + "utilizatori.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] toks = line.Split('\t');
                    User user = new User(toks[0], toks[1]);
                    _users.Add(user);
                }
                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        // metoda ce verifica credentialele
        public bool LoginF(string username, string password)
        {
            bool logVar = false;
            for (int i = 0; i < _users.Count; i++)
            {
                if (username == _users[i].Name && Cryptography.HashString(password) == _users[i].PassHash)
                    logVar = true;
            }
            return logVar;
        }
    }
}
