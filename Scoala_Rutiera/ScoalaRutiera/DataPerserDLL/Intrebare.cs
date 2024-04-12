/**************************************************************************
 *                                                                        *
 *  File:        Intrebare.cs                                             *
 *  Copyright:   (c) 2023 Ana Maria Toma, Augustin Topciu, Stefania Luca  *
 *  E-mail:      augustin.topciu@student.tuiasi.ro                        *
 *               stefania.luca@student.tuiasi.ro                          *
 *               ana-maria.toma2@student.tuiasi.ro                        *
 *                                                                        *
 *  Description: Clasa Intrebare este folosita pentru construirea         *
 *              de obiect ce stocheaza informatiile unei intrebari.       *
 *                                                                        *
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


using StateDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerserDLL
{
    public class Intrebare : IState
    {

        private String _questionNumber; //numarul intrebarii din totalitatea de intrebari
        private String _question;       // intrebarea propriu zisa
        private String _answer1;        // varianta A de raspuns
        private String _answer2;        // varianta B de raspuns
        private String _answer3;        // varianta C de raspuns
        private bool _rez1;             // valoarea de adevar a variantei A
        private bool _rez2;             // valoarea de adevar a variantei B
        private bool _rez3;             // valoarea de adevar a variantei C
        private String _pathToImage;    // calea spre imaginea intrebarii
        private int _stare = 0;         // starea intrebarii ce va fi completata in momentul rezolvarii intrebarii

        //constructor obiect Intrebare
        public Intrebare(string numar, string intrb, string a1, string a2, string a3, bool rez1, bool rez2, bool rez3, string path)
        {
            _questionNumber = numar;
            _question = intrb;
            _answer1 = a1;
            _answer2 = a2;
            _answer3 = a3;
            _rez1 = rez1;
            _rez2 = rez2;
            _rez3 = rez3;
            _pathToImage = path;
        }

        public string QuestionNumber { get => _questionNumber; set => _questionNumber = value; }
        public string Question { get => _question; set => _question = value; }
        public string Answer1 { get => _answer1; set => _answer1 = value; }
        public string Answer2 { get => _answer2; set => _answer2 = value; }
        public string Answer3 { get => _answer3; set => _answer3 = value; }
        public bool Rez1 { get => _rez1; set => _rez1 = value; }
        public bool Rez2 { get => _rez2; set => _rez2 = value; }
        public bool Rez3 { get => _rez3; set => _rez3 = value; }
        public string PathToImage { get => _pathToImage; set => _pathToImage = value; }
        public int Stare { get => _stare; set => _stare = value; }
        


        // implementarea propriu zisa a schimbarii starii intrebarilor
        public void IntrebareaDevineCorecta()
        {
            this.Stare = 1;
        }

        public void IntrebareDevineGresita()
        {
            this.Stare = 2;
        }

        // override ToString pentru afisarea elementelor unei intrebari

        public override string ToString()
        {
            return
                " Nr Intrebarea : " + this._questionNumber + "\n\r "
                + "Intrebare: " + this._question + "\n\r "
                + "Raspuns A: " + this._answer1 + "\n\r "
                + "Raspuns B: " + this._answer2 + "\n\r "
                + "Raspuns C: " + this._answer3 + "\n\r "
                + "Rezultat A: " + this._rez1 + "\n\r "
                + "Rezultat B: " + this._rez2 + "\n\r "
                + "Rezultat C: " + this._rez3 + "\n\r "
                + "Path pentru Img: " + this._pathToImage + "\n\r";


        }


    }
}
