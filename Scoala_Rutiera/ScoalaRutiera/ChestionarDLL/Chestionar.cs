/**************************************************************************
 *                                                                        *
 *  File:        Chestionar.cs                                            *
 *  Copyright:   (c) 2023 Ana Maria Toma, Augustin Topciu, Stefania Luca  *
 *  E-mail:      augustin.topciu@student.tuiasi.ro                        *
 *               stefania.luca@student.tuiasi.ro                          *
 *               ana-maria.toma2@student.tuiasi.ro                        *
 *                                                                        *
 *  Description: Clasa Chestionar constituie baza unei grile de test      *
 *               grila cu 26 de intrebari.                                *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DataPerserDLL;



namespace ChestionarDLL
{

    public class Chestionar
    {

        private int _timp= 1800;            // 30 de minute acordate pentru completarea unui chestionar
        private int _nrIntrebari = 26;      // numarul de intrebari dintr-un chestionar
        private int _nrIntrebariCorecte=0;  
        private int _nrIntrebariGresite=0;
        private List<Intrebare> _intrebariDinChestionar = new List<Intrebare>();  //lista de intrebari 
        public Random _rnd = new Random(); // element random folosit pentru alegerea la intamplare 26 de intrebari

        public List<Intrebare> IntrebariDinChestionar { get => _intrebariDinChestionar; set => _intrebariDinChestionar = value; }
        public int NrIntrebariCorecte { get => _nrIntrebariCorecte; set => _nrIntrebariCorecte = value; }
        public int NrIntrebariGresite { get => _nrIntrebariGresite; set => _nrIntrebariGresite = value; }
        public int NrIntrebari { get => _nrIntrebari; set => _nrIntrebari = value; }
        public int Timp { get => _timp; set => _timp = value; }

        // metoda de populare a listei de intrebari a unui chestionar
        public Chestionar(List<Intrebare> listaIntrebari)
        {
            int randomNr;

            for (int i =0;i<=26;i++)
            {
                randomNr = _rnd.Next(429);
                _intrebariDinChestionar.Add(listaIntrebari[randomNr]);
            }
            
        }


        
    }
}
