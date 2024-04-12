/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2023 Ana Maria Toma, Augustin Topciu, Stefania Luca  *
 *  E-mail:      augustin.topciu@student.tuiasi.ro                        *
 *               stefania.luca@student.tuiasi.ro                          *
 *               ana-maria.toma2@student.tuiasi.ro                        *
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

using ChestionarDLL;
using DataPerserDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoalaRutiera
{
    public partial class Form1 : Form
    {

        LoginDLL.Login l = new LoginDLL.Login();
        
        List<Intrebare> listaIntrebari;
        List<Intrebare> intrebariGresite = new List<Intrebare>();
        Chestionar ch;
        bool raspunsA=false, raspunsB=false,raspunsC=false;
        bool wrongAans = false, wrongBans = false,wrongCans=false;
        bool chestAans = false, chestBans = false, chestCans = false;
        int intrebareCurenta = 0;
        int currentWrongQuestion = 0;
        int chIntrebare = 0;
        int IntrebariCorecteQQ=0;
        int IntrebariGresiteQQ=0;
        int MedieIntrebariQQ = 0;
        int TesteEsuateCount = 0;
        int TesteLuateCount = 0;



        public Form1()
        {
            DataParser data = new DataParser();
            data.fillStack();
            listaIntrebari = data.GetStack();
            InitializeComponent();
            
             
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mediuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            l.ObtainUsers();
            loginPanel.Visible = true;
            loginPanel.BringToFront();
            meniuPanel.Visible = false;
            mediuPanel.Visible = false;
            grilePanel.Visible = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            if (l.LoginF(username, password) == true)
            {
                loginPanel.Visible = false;
                meniuPanel.Visible = true;
                meniuPanel.BringToFront();
                mediuPanel.Visible = false;
                grilePanel.Visible = false;
            }
            else
            {
                MessageBox.Show("Nume de utilizator sau parolă greșite");
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            meniuPanel.Visible = false;
            loginPanel.BringToFront();
            loginPanel.Visible = true;
            mediuPanel.Visible = false;
            grilePanel.Visible = false;
        }

        private void mediuButton_Click(object sender, EventArgs e)
        {
            mediuPanel.Visible = true;
            mediuPanel.BringToFront();
            loginPanel.Visible = false;
            meniuPanel.Visible = false;
            grilePanel.Visible = false;
            RaspunsA.BackColor = Color.Gray;
            RaspunsB.BackColor = Color.Gray;
            RaspunsC.BackColor = Color.Gray;
            Intrebare.Text = listaIntrebari[intrebareCurenta].Question;
            RaspunsA.Text = listaIntrebari[intrebareCurenta].Answer1;
            RaspunsB.Text = listaIntrebari[intrebareCurenta].Answer2;
            RaspunsC.Text = listaIntrebari[intrebareCurenta].Answer3;

            if (listaIntrebari[intrebareCurenta].PathToImage != "nope")
            {
                poza.Image = new Bitmap(listaIntrebari[intrebareCurenta].PathToImage);
            }
            else
            {
                poza.BackColor = Color.Gray;
                poza.Image = null;
            }
        }

        private void mediuMenuButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            meniuPanel.Visible = true;
            meniuPanel.BringToFront();
            mediuPanel.Visible = false;
            grilePanel.Visible = false;
        }
        private void grileButton_Click(object sender, EventArgs e)
        {
            
            grilePanel.Visible = false;
            loginPanel.Visible = false;
            meniuPanel.Visible = false;
            mediuPanel.Visible = false;
            SelectieChestionar.Visible = true;
            SelectieChestionar.BringToFront();
            ch = new Chestionar(listaIntrebari);
        }

        private void grileMediuButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            meniuPanel.Visible = false;
            mediuPanel.Visible = false;
            grilePanel.Visible = false;
            meniuPanel.BringToFront();
            TesteTrecute.Text = TesteLuateCount.ToString();
            TesteEsuate.Text = TesteEsuateCount.ToString();
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void despreButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Școală auto\n\nProiect Ingineria Programării     \n\nLuca Ștefania\nToma Ana-Maria\nTopciu Augustin");
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

       

        

        private void TrimiteRaspuns_Click(object sender, EventArgs e)
        {
            countOfWrongQuestions.Text = intrebariGresite.Count.ToString();
            if (raspunsA == listaIntrebari[intrebareCurenta].Rez1 && raspunsB == listaIntrebari[intrebareCurenta].Rez2 && raspunsC == listaIntrebari[intrebareCurenta].Rez3)
            {
                listaIntrebari[intrebareCurenta].IntrebareaDevineCorecta();
                intrebareCurenta++;
                raspunsA = raspunsB = raspunsC = false;
                IntrebareaCurentMediu.Text = (intrebareCurenta+1).ToString();
                mediuButton_Click(this,null);

            }
            else
            {
                listaIntrebari[intrebareCurenta].IntrebareDevineGresita();
                if (!intrebariGresite.Contains(listaIntrebari[intrebareCurenta]) && listaIntrebari[intrebareCurenta].Stare == 2)
                {
                    intrebariGresite.Add(listaIntrebari[intrebareCurenta]);
                    currentWrongQuestion++;
                }
                countOfWrongQuestions.Text = currentWrongQuestion.ToString();
            }
        }

        private void RaspunsA_Click(object sender, EventArgs e)
        {
            if (RaspunsA.BackColor==Color.Yellow)
            {
                RaspunsA.BackColor = Color.White;
                raspunsA = false;
                
            }
            else
            {
                RaspunsA.BackColor = Color.Yellow;
                raspunsA = true;
            }
        }

        private void BackToMediuInvatareDinIntrGresite_Click(object sender, EventArgs e)
        {
            countOfWrongQuestions.Text = intrebariGresite.Count.ToString();
            mediuButton_Click(this, null);
        }

        private void mediuWrongButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            meniuPanel.Visible = true;
            intrGresite.BringToFront();
            meniuPanel.Visible = false;
            mediuPanel.Visible = false;
            grilePanel.Visible = false;
            try
            {
                if(intrebariGresite.Count==0)
                {
                    MessageBox.Show("Nu mai sunt intrebari gresite");
                    mediuButton_Click(this, null);

                }
                if (intrebariGresite.Count > 0)
                {
                    intrebareGresita.Text = intrebariGresite[currentWrongQuestion - 1].Question;
                    wrongA.Text = intrebariGresite[currentWrongQuestion - 1].Answer1;
                    wrongB.Text = intrebariGresite[currentWrongQuestion - 1].Answer2;
                    wrongC.Text = intrebariGresite[currentWrongQuestion - 1].Answer3;
                    try
                    {
                        if (intrebariGresite[currentWrongQuestion - 1].PathToImage != "nope")
                        {
                            wrongPhoto.Image = new Bitmap(intrebariGresite[currentWrongQuestion - 1].PathToImage);
                        }
                    }
                    catch (Exception EroareImagineIntrGresita)
                    {
                        MessageBox.Show("Nu mai sunt intrebari gresite");
                        mediuButton_Click(this, null);
                    }
                }
            }catch(Exception NuSuntIntrebariGresite)
            {
                
                mediuButton_Click(this, null);

            }
        }

        private void wrongA_Click(object sender, EventArgs e)
        {
            if (wrongA.BackColor == Color.Yellow)
            {
                wrongA.BackColor = Color.White;
                wrongAans = false;
            }
            else
            {
                wrongA.BackColor = Color.Yellow;
                wrongAans = true;

            }
        }

        private void sendWrongQuestion_Click(object sender, EventArgs e)
        {
            
                if (wrongAans == intrebariGresite[currentWrongQuestion - 1].Rez1 && wrongBans == intrebariGresite[currentWrongQuestion - 1].Rez2 && wrongCans == intrebariGresite[currentWrongQuestion - 1].Rez3)
                {
                     intrebariGresite[currentWrongQuestion - 1].IntrebareaDevineCorecta();
                    intrebariGresite.Remove(intrebariGresite[currentWrongQuestion - 1]);
                    currentWrongQuestion--;
                    countOfWrongQuestions.Text = intrebariGresite.Count.ToString();
                     mediuWrongButton_Click(this, e);
                     wrongAans = wrongBans = wrongCans = false;
                 }
                else
                {
                intrebariGresite[currentWrongQuestion - 1].IntrebareDevineGresita();
                if (!intrebariGresite.Contains(listaIntrebari[intrebareCurenta]))
                        intrebariGresite.Add(listaIntrebari[intrebareCurenta]);
                }

            
            if (intrebariGresite.Count == 0)
            {
                MessageBox.Show("Nu mai sunt intrebari gresite");
                mediuButton_Click(this, null);

            }
        }

        // teste trecute nr
        private void TesteTrecute_Click(object sender, EventArgs e)
        {

        }
        // teste esuate numar
        private void TesteEsuate_Click(object sender, EventArgs e)
        {

        }

        //rata de succes numar
        private void RataDeSucces_Click(object sender, EventArgs e)
        {
            
        }
        //genereaza chestionar button on click
        

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            meniuPanel.Visible = true;
            meniuPanel.BringToFront();
            mediuPanel.Visible = false;
            grilePanel.Visible = false;
        }


        private void wrongB_Click(object sender, EventArgs e)
        {
            if (wrongB.BackColor == Color.Yellow)
            {
                wrongB.BackColor = Color.White;
                wrongBans = false;
            }
            else
            {
                wrongB.BackColor = Color.Yellow;
                wrongBans = true;
            }
        }


        private void wrongC_Click(object sender, EventArgs e)
        {
            if (wrongC.BackColor == Color.Yellow)
            {
                wrongC.BackColor = Color.White;
                wrongCans = false;
            }
            else
            {
                wrongC.BackColor = Color.Yellow;
                wrongCans = true;
            }
        }

        private void IntrebareChestionar_Click(object sender, EventArgs e)
        {

        }

        private void RaspunsB_Click(object sender, EventArgs e)
        {
            if (RaspunsB.BackColor == Color.Yellow)
            {
                RaspunsB.BackColor = Color.White;
                raspunsB = false;
            }
            else
            {
                RaspunsB.BackColor = Color.Yellow;
                raspunsB = true;
                
            }
        }

      

        private void RaspunsC_Click(object sender, EventArgs e)
        {
            if (RaspunsC.BackColor == Color.Yellow)
            {
                RaspunsC.BackColor = Color.White;
                raspunsC = false;
            }
            else
            {
                RaspunsC.BackColor = Color.Yellow;
                raspunsC = true;
            }
            
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"Users\\ScoalaRutieraHelp.chm");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        ///                     SECTIUN CHESTIONAR
        /////////////////////////////////////////////////////////////////////////////////////////////////
       
        // metoda de countdown
        private void TimerChestionar_Tick(object sender, EventArgs e)
        {
            if (ch.Timp > 0)        //daca timpul nu s-a terminat scadem din el cate o secunda
            {
                ch.Timp--;
                int minutes = ch.Timp / 60;
                int seconds = ch.Timp - (minutes * 60);
                TimpRamas.Text = minutes.ToString() + ":" + seconds.ToString(); //afisam timpul ramas
            }
            else
            {                                                   // in cazul in care timpul s-a scurs, este verificat
                this.TimerChestionar.Stop();                    // daca s-au completat corect minim 22 de intrebari pentru 
                MessageBox.Show("Timpul s-a scurs!");           // promovarea testului sau esuarea acestuia
                if (ch.NrIntrebariCorecte >= 22)
                {
                    MessageBox.Show("Examen Trecut cu Succes!");    
                    TesteLuateCount++;                                      // se incrementeaza numarul de teste promovate
                    TesteTrecute.Text = TesteLuateCount.ToString();
                    ch = null;
                    grileButton_Click(this, null);                          //redirectionare spre meniul anterior
                    grileMediuButton_Click(this, null);

                }
                else
                {
                    MessageBox.Show("Examen Esuat!");
                    IntrebariCorecteQQ = 0;
                    IntrebariGresiteQQ = 0;
                    TesteEsuateCount++;                                 // se incrementeaza numarul de teste esuate
                    TesteEsuate.Text = TesteEsuateCount.ToString();
                    ch = null;  
                    grileButton_Click(this, null);                      //redirectionare spre meniul anterior
                    grileMediuButton_Click(this, null);

                }
            }
        }

        // metoda de verificare a raspunului
        private void TrimiteRaspunsChestionar_Click(object sender, EventArgs e)
        {
            
            //in cazul in care raspunsul este corect, se va incrementa numaru de intrebari corecte si se va trece la urmatoarea intrebare
            if (chestAans == ch.IntrebariDinChestionar[chIntrebare].Rez1 && chestBans == ch.IntrebariDinChestionar[chIntrebare].Rez2 && chestCans == ch.IntrebariDinChestionar[chIntrebare].Rez3)
            {   
                
                ch.IntrebariDinChestionar[chIntrebare].IntrebareaDevineCorecta();
                chIntrebare++;
                IntrebariCorecteQQ++;
                ch.NrIntrebariCorecte++;
                chestAans = chestBans = chestCans = false;
                IntrebariCorecteQ.Text = IntrebariCorecteQQ.ToString();
                
                GenereazaChestionarButton_Click(this, null);
                
            }
            else
            {
                //in cazul in care raspunul este gresit, se va incrementa numarul de intrebari gresite si se va trece la urmatoarea intrebare

                ch.IntrebariDinChestionar[chIntrebare].IntrebareDevineGresita();
                chIntrebare++;
                IntrebariGresiteQQ++;
                ch.NrIntrebariGresite++;

                if (IntrebariGresiteQQ == 5)    // daca numarul de intrebari gresite ajunge la 5 se va opri testul si se va reintoarce la meniul anterior
                {
                    MessageBox.Show("Examen Esuat!");
                    IntrebariCorecteQQ = 0;
                    IntrebariGresiteQQ = 0;
                    TesteEsuateCount++;
                    TesteEsuate.Text = TesteEsuateCount.ToString();
                    ch = null;
                    grileButton_Click(this, null);
                    grileMediuButton_Click(this, null);
                    
                    
                }
                else
                {
                    chestAans = chestBans = chestCans = false;
                    GenereazaChestionarButton_Click(this, null);
                }
                                            // daca numarul adunat de intrebari gresite si intrebari corecte ajunge la 26 examenul este luat cu succes 
                if(IntrebariCorecteQQ+IntrebariGresiteQQ==26 &&IntrebariCorecteQQ >= 22)
                {
                    MessageBox.Show("Examen Trecut cu Succes");
                    TesteLuateCount++;
                    TesteTrecute.Text = TesteLuateCount.ToString();
                    ch = null;
                    grileButton_Click(this, null);
                    grileMediuButton_Click(this, null);

                }

            }
        }
        // metoda de generare a intrebarilor din chestionar
        private void GenereazaChestionarButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            meniuPanel.Visible = false;
            mediuPanel.Visible = false;
            grilePanel.Visible = false;
            Chestionar.Visible = true;
            Chestionar.BringToFront();
            TimerChestionar.Enabled = true;

            IntrebariCorecteQ.Text = IntrebariCorecteQQ.ToString();
            IntrebariGresiteQ.Text = IntrebariGresiteQQ.ToString();

            RaspunsChestionarA.BackColor = Color.Gray;
            RaspunsChestionarB.BackColor = Color.Gray;
            RaspunsChestionarC.BackColor = Color.Gray;

            IntrebareChestionar.Text = ch.IntrebariDinChestionar[chIntrebare].Question;
            RaspunsChestionarA.Text = ch.IntrebariDinChestionar[chIntrebare].Answer1;
            RaspunsChestionarB.Text = ch.IntrebariDinChestionar[chIntrebare].Answer2;
            RaspunsChestionarC.Text = ch.IntrebariDinChestionar[chIntrebare].Answer3;

            if (ch.IntrebariDinChestionar[chIntrebare].PathToImage != "nope")
            {
                PozaChestionar.Image = new Bitmap(ch.IntrebariDinChestionar[chIntrebare].PathToImage);
            }
            else
            {
                PozaChestionar.Image = null;
                PozaChestionar.BackColor = Color.Gray;
            }

        }

        // metode de schimbare a culorii raspunsurilor si valorii de adevar

        private void RaspunsChestionarA_Click(object sender, EventArgs e)
        {
            if (RaspunsChestionarA.BackColor == Color.Yellow)
            {
                RaspunsChestionarA.BackColor = Color.White;
                chestAans = false;
            }
            else
            {
                RaspunsChestionarA.BackColor = Color.Yellow;
                chestAans = true;
            }
        }

        private void RaspunsChestionarB_Click(object sender, EventArgs e)
        {
            if (RaspunsChestionarB.BackColor == Color.Yellow)
            {
                RaspunsChestionarB.BackColor = Color.White;
                chestBans = false;
            }
            else
            {
                RaspunsChestionarB.BackColor = Color.Yellow;
                chestBans = true;
            }
        }

        private void RaspunsChestionarC_Click(object sender, EventArgs e)
        {
            if (RaspunsChestionarC.BackColor == Color.Yellow)
            {
                RaspunsChestionarC.BackColor = Color.White;
                chestCans = false;
            }
            else
            {
                RaspunsChestionarC.BackColor = Color.Yellow;
                chestCans = true;
            }
        }
    }
}
