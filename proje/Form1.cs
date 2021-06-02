using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread thread;

        int iterasyon = 0;

        int kutu = 50;
        int boyut = 18;

        int ajankonum_row = 0, ajankonum_col = 0;
        int ajanhedefkonum_row = 0, ajanhedefkonum_col = 0;

        int[,] Rmatrix;
        double[,] Qmatrix;
        int[,] tempR;
        double[,] cost;

        List<int> path = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized; // form yüklendiğinde tam ekran olsun.
            CreateBoard(kutu);
            Create_R_Q_Matrix(kutu);
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            bool iterasyoncheck = false;
            try
            {
                iterasyon = Convert.ToInt32(tbx_iterasyon.Text);
                iterasyoncheck = true;
            }
            catch
            {
                MessageBox.Show("İterasyon sayısı giriniz !!");
            }

            if (ajankonum_row == 0 && ajankonum_col == 0)
            {
                MessageBox.Show("Başlangıç konum seçiniz..!!");
            }
            else if (ajanhedefkonum_row == 0 && ajanhedefkonum_col == 0)
            {
                MessageBox.Show("Hedef konum seçiniz..!!");
            }
            else
            {
                if (iterasyoncheck)
                {
                    MessageBox.Show("İşlem Başlıyor...");
                    Set_Rmatrix(kutu);

                    thread = new Thread(SetQmatrix);
                    thread.Start();
                }
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
            Application.Exit();

        }

        private void grid1_Click(object Sender, EventArgs e)
        {
            //MessageBox.Show(grid1.ActiveCell.Row.ToString() + "," + grid1.ActiveCell.Col.ToString());
            if (ajankonum_row == 0 && ajankonum_col == 0)
            {
                ajankonum_row = grid1.ActiveCell.Row;
                ajankonum_col = grid1.ActiveCell.Col;
                tbx_ajankonum.Text = grid1.ActiveCell.Row.ToString() + "," + grid1.ActiveCell.Col.ToString();
                grid1.Cell(ajankonum_row, ajankonum_col).BackColor = Color.Blue;
                tempR[ajankonum_row - 1, ajankonum_col - 1] = 0;
            }
            else if (ajanhedefkonum_row == 0 && ajanhedefkonum_col == 0)
            {
                ajanhedefkonum_row = grid1.ActiveCell.Row;
                ajanhedefkonum_col = grid1.ActiveCell.Col;
                tbx_ajanhedefkonum.Text = grid1.ActiveCell.Row.ToString() + "," + grid1.ActiveCell.Col.ToString();
                grid1.Cell(ajanhedefkonum_row, ajanhedefkonum_col).BackColor = Color.Green;
                tempR[ajanhedefkonum_row - 1, ajanhedefkonum_col - 1] = 100;
            }
            else
            {
                MessageBox.Show("Oyun alanına tıklamayınız !!");
            }

            engeltxt(tempR);
        }

        void CreateBoard(int sayi)//sayi = kutu sayisi
        {
            int adet = sayi + 1;
            grid1.Height = (adet + 1) * boyut;
            grid1.Width = (adet + 1) * boyut;
            grid1.Rows = adet;
            grid1.Cols = adet;

            for (int i = 0; i < adet; i++)
            {
                grid1.Cell(0, i).Text = i.ToString();
                grid1.Cell(i, 0).Text = i.ToString();
                grid1.Row(i).Height = (short)boyut;
                grid1.Column(i).Width = (short)boyut;
            }
            grid1.Visible = true;

            tempR = new int[sayi, sayi];

            for (int i = 0; i < sayi; i++)
            {
                for (int j = 0; j < sayi; j++)
                {
                    tempR[i, j] = 0;
                }
            }


            cost = new double[kutu, kutu];

            int engelsayi = (sayi * sayi * 30) / 100;

            Random rastgele = new Random();

            while (engelsayi >= 0)
            {
                int row = rastgele.Next(0, sayi);
                int col = rastgele.Next(0, sayi);

                if (tempR[row, col] == 0)
                {
                    tempR[row, col] = -1;
                    engelsayi--;
                }
            }

            for (int i = 0; i < sayi; i++)
            {
                for (int j = 0; j < sayi; j++)
                {
                    if (tempR[i, j] == -1)
                    {
                        grid1.Cell(i + 1, j + 1).BackColor = Color.Red;
                    }

                    cost[i, j] = rastgele.Next(1, 10); // cost matrisi doldurma ...
                    grid1.Cell(i + 1, j + 1).Text = cost[i, j].ToString();
                }
            }

        }

        void Create_R_Q_Matrix(int sayi)//sayi = kutu sayisi
        {
            int row = sayi * sayi;
            int col = sayi * sayi;

            Rmatrix = new int[row, col];
            Qmatrix = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Rmatrix[i, j] = 0;
                    Qmatrix[i, j] = 0;
                }
            }           
        }

        void Set_Rmatrix(int sayi)//sayi = kutu sayisi
        {      
            //---- R matrix doldurma

            int Rrow = sayi * sayi;
            int Rcol = sayi * sayi;

            int durumrow = 0, durumcol = 0;
            int aksiyomrow = 0, aksiyomcol = 0;

            for (int i = 0; i < Rrow; i++)
            {
                int sayac = 0;
                int[,] aksiyom = new int[8, 2]; // Gidebileceği noktalar...

                if ((durumrow - 1) >= 0 && (durumcol - 1) >= 0)
                {
                    aksiyom[sayac, 0] = (durumrow - 1);
                    aksiyom[sayac, 1] = (durumcol - 1);
                    sayac++;
                }
                if ((durumrow - 1) >= 0)
                {
                    aksiyom[sayac, 0] = (durumrow - 1);
                    aksiyom[sayac, 1] = (durumcol);
                    sayac++;
                }
                if ((durumrow - 1) >= 0 && (durumcol + 1) < sayi)
                {
                    aksiyom[sayac, 0] = (durumrow - 1);
                    aksiyom[sayac, 1] = (durumcol + 1);
                    sayac++;
                }
                if ((durumcol - 1) >= 0)
                {
                    aksiyom[sayac, 0] = (durumrow);
                    aksiyom[sayac, 1] = (durumcol - 1);
                    sayac++;
                }
                if ((durumcol + 1) < sayi)
                {
                    aksiyom[sayac, 0] = (durumrow);
                    aksiyom[sayac, 1] = (durumcol + 1);
                    sayac++;
                }
                if ((durumrow + 1) < sayi && (durumcol - 1) >= 0)
                {
                    aksiyom[sayac, 0] = (durumrow + 1);
                    aksiyom[sayac, 1] = (durumcol - 1);
                    sayac++;
                }
                if ((durumrow + 1) < sayi)
                {
                    aksiyom[sayac, 0] = (durumrow + 1);
                    aksiyom[sayac, 1] = (durumcol);
                    sayac++;
                }
                if ((durumrow + 1) < sayi && (durumcol + 1) < sayi)
                {
                    aksiyom[sayac, 0] = (durumrow + 1);
                    aksiyom[sayac, 1] = (durumcol + 1);
                    sayac++;
                }

                aksiyomrow = 0; aksiyomcol = 0;
                for (int j = 0; j < Rcol; j++)
                {
                    bool kontrol = false;

                    if (durumrow == (ajanhedefkonum_row - 1) && durumcol == (ajanhedefkonum_col - 1))
                    {
                        if (aksiyomrow == (ajanhedefkonum_row - 1) && aksiyomcol == (ajanhedefkonum_col - 1))
                        {
                            Rmatrix[i, j] = 100;
                        }
                        else
                        {
                            Rmatrix[i, j] = -1;
                        }
                    }
                    else
                    {
                        if (tempR[durumrow, durumcol] != -1)
                        {
                            int temp = 0;
                            for (int k = 0; k < sayac; k++)
                            {
                                if (aksiyom[k, 0] == aksiyomrow && aksiyom[k, 1] == aksiyomcol)
                                {
                                    kontrol = true;
                                    temp = k;
                                }
                            }

                            if (kontrol)
                            {
                                Rmatrix[i, j] = tempR[aksiyom[temp, 0], aksiyom[temp, 1]];
                            }
                            else
                            {
                                Rmatrix[i, j] = -1;
                            }
                        }
                        else
                        {
                            Rmatrix[i, j] = -1;
                        }
                    }

                    aksiyomcol++;
                    if (aksiyomcol >= sayi)
                    {
                        aksiyomcol = 0;
                        aksiyomrow++;
                    }

                }

                durumcol++;
                if (durumcol >= sayi)
                {
                    durumrow++;
                    durumcol = 0;
                }
            }

        }        

        int coor2boxno(int row, int col)
        {
            int kutuno = (row) * kutu + col;
            return kutuno;
        }
        (int row, int col) boxno2coor(int kutuno)
        {
            return ((kutuno / kutu), (kutuno % kutu));
        }

        void SetQmatrix()
        {
            //Qmatrix[ajanhedefkonum_row - 1, ajanhedefkonum_col - 1] = 100;

            double gama = 0.9; // discount faktor (indirim faktörü)
            double alpha = 0.7;// learning rate (öğrenme katsayısı)
            int ajanrow = (ajankonum_row - 1);
            int ajancol = (ajankonum_col - 1);
            Random rastgele = new Random();
            while (iterasyon >= 0)
            {
                int sayac = 0; // grafik sayacı..

                if (sayac != 0)
                {
                    // rastgele başlangıç konumu seçilecek....

                    while (true)
                    {
                        ajanrow = rastgele.Next(0, kutu);
                        ajancol = rastgele.Next(0, kutu);
                        if (tempR[ajanrow, ajancol] != -1 && tempR[ajanrow, ajancol] != 100)
                        {
                            break;
                        }
                    }

                }

                bool hedefcheck = true;
                while (hedefcheck)
                {
                    var result = ListAksiyom(ajanrow, ajancol);
                    int[,] aksiyomlist = result.Aksiyomlar; // 11-den gidilebilecek yerlerin listesi

                    int randomaksiyom = rastgele.Next(0, result.sayac); // rastgele 11-- den gidilecek yer seçiliyor. mesela 16

                    //-- Q matrisi için durum ve aksiyom kutu nosu seçiliyor. Q(11,16) 
                    int durum = coor2boxno(ajanrow, ajancol);
                    int aksiyom = coor2boxno(aksiyomlist[randomaksiyom, 0], aksiyomlist[randomaksiyom, 1]);

                    //----- Aksiyom (16) dan gidebileceği yerlerin en yüksek değeri seçiyoruz
                    double Maxdeger = Maxdegersec(aksiyom, aksiyomlist[randomaksiyom, 0], aksiyomlist[randomaksiyom, 1]); //16 kutuno gönderdik.     

                    Qmatrix[durum, aksiyom] = Math.Round((Qmatrix[durum, aksiyom] + alpha * (Rmatrix[durum, aksiyom] + (gama * Maxdeger - Qmatrix[durum, aksiyom]))), 3, MidpointRounding.AwayFromZero);
                    //----------------

                    if (aksiyom == coor2boxno((ajanhedefkonum_row - 1), (ajanhedefkonum_col - 1)))
                    {
                        hedefcheck = false;
                    }
                    else
                    {
                        var coor = boxno2coor(aksiyom);
                        ajanrow = coor.row;
                        ajancol = coor.col;
                    }
                    sayac++;
                }


                // thread kullanımında label güncellemek için....
                this.Invoke(
                    (MethodInvoker)delegate ()
                    {
                        //chart1.Series["Series1"].Points.Add(rastgele.Next(20, 200));
                        chart1.Series["episode via steps"].Points.Add(sayac);
                        lbl_iterasyon.Text = iterasyon.ToString();
                    });
                iterasyon--;
                //Thread.Sleep(1000);
            }                    

            createpath();
            costgrafik();
        }

        double Maxdegersec(int kutuno, int kutunorow, int kutunocol)
        {
            double maxvalue = 0;
            //16'nın gidebileceği yerlerin listesi
            var Maxresult = ListAksiyom(kutunorow, kutunocol); //kutuno'nun gidebileceği kutuların listesi
            int[,] Maxaksiyom = Maxresult.Aksiyomlar;
            for (int i = 0; i < Maxresult.sayac; i++)
            {
                int gidilecekKutuno = coor2boxno(Maxaksiyom[i, 0], Maxaksiyom[i, 1]);
                if (maxvalue < Qmatrix[kutuno, gidilecekKutuno])
                {
                    maxvalue = Qmatrix[kutuno, gidilecekKutuno];
                }
            }

            return maxvalue;
        }

        (int[,] Aksiyomlar, int sayac) ListAksiyom(int row, int col)
        {
            int[,] liste = new int[8, 2];
            int sayac = 0;

            if ((row - 1) >= 0 && (col - 1) >= 0)
            {
                if (tempR[(row - 1), (col - 1)] != -1)
                {
                    liste[sayac, 0] = (row - 1);
                    liste[sayac, 1] = (col - 1);
                    sayac++;
                }
            }
            if ((row - 1) >= 0)
            {
                if (tempR[(row - 1), (col)] != -1)
                {
                    liste[sayac, 0] = (row - 1);
                    liste[sayac, 1] = (col);
                    sayac++;
                }
            }
            if ((row - 1) >= 0 && (col + 1) < kutu)
            {
                if (tempR[(row - 1), (col + 1)] != -1)
                {
                    liste[sayac, 0] = (row - 1);
                    liste[sayac, 1] = (col + 1);
                    sayac++;
                }
            }
            if ((col - 1) >= 0)
            {
                if (tempR[(row), (col - 1)] != -1)
                {
                    liste[sayac, 0] = (row);
                    liste[sayac, 1] = (col - 1);
                    sayac++;
                }
            }
            if ((col + 1) < kutu)
            {
                if (tempR[(row), (col + 1)] != -1)
                {
                    liste[sayac, 0] = (row);
                    liste[sayac, 1] = (col + 1);
                    sayac++;
                }
            }
            if ((row + 1) < kutu && (col - 1) >= 0)
            {
                if (tempR[(row + 1), (col - 1)] != -1)
                {
                    liste[sayac, 0] = (row + 1);
                    liste[sayac, 1] = (col - 1);
                    sayac++;
                }
            }
            if ((row + 1) < kutu)
            {
                if (tempR[(row + 1), (col)] != -1)
                {
                    liste[sayac, 0] = (row + 1);
                    liste[sayac, 1] = (col);
                    sayac++;
                }
            }
            if ((row + 1) < kutu && (col + 1) < kutu)
            {
                if (tempR[(row + 1), (col + 1)] != -1)
                {
                    liste[sayac, 0] = (row + 1);
                    liste[sayac, 1] = (col + 1);
                    sayac++;
                }
            }

            return (liste, sayac);
        }

        void createpath()
        {
            int ajanrow = ajankonum_row - 1;
            int ajancol = ajankonum_col - 1;

            int basKutu = coor2boxno(ajanrow, ajancol);
            path.Add(basKutu);

            int tempkutu = 0;

            while (true)
            {
                double max = 0;

                for (int i = 0; i <= Qmatrix.GetUpperBound(1); i++)
                {
                    if (max < Qmatrix[basKutu, i])
                    {
                        max = Qmatrix[basKutu, i];
                        tempkutu = i;
                    }
                }

                if (tempkutu == coor2boxno((ajanhedefkonum_row - 1), (ajanhedefkonum_col - 1)))
                {
                    path.Add(tempkutu);
                    break;
                }
                else
                {
                    path.Add(tempkutu);
                    basKutu = tempkutu;
                }
            }

            Console.WriteLine("-----------");
            for (int i = 1; i < path.Count - 1; i++)
            {
                Console.Write(path[i].ToString() + ",");
                var result = boxno2coor(path[i]);
                grid1.Cell(result.row + 1, result.col + 1).BackColor = Color.GreenYellow;
            }
            Console.WriteLine("\n-----------");
        }

        void costgrafik()
        {
            double maliyet = 1;

            for (int i = 0; i < path.Count; i++)
            {
                double gecisucret = 0.3;
                if (i == path.Count - 1)
                {
                    gecisucret = 0.5;
                }
                var result = boxno2coor(path[i]);

                //double hesap = maliyet + (gecisucret - (cost[result.row, result.col]));

                this.Invoke(
                    (MethodInvoker)delegate ()
                    {
                        chart2.Series["episode via cost"].Points.Add((cost[result.row, result.col])-gecisucret);
                    });

                //maliyet = hesap;
            }
        }

        void engeltxt(int[,] temp)
        {
            string dosya_yolu = Environment.CurrentDirectory + @"\engel.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i <= temp.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= temp.GetUpperBound(1); j++)
                {
                    if (temp[i, j] == -1)
                    {
                        sw.Write($"({i},{j},K)");
                    }
                }
                sw.WriteLine();
            }

            sw.Flush();
            sw.Close();
            fs.Close();
        }

    }
}
