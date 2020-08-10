using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MüzikPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
                
        }
        
        public void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Müzik Dosyası(*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.wmv";
            openFileDialog1.Title = "Dosya Seç";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName!="")
            {
                for (int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
                {
                    listBox1.Items.Add(openFileDialog1.FileNames[i].ToString());
                    listBox2.Items.Add(openFileDialog1.SafeFileNames[i].ToString());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar2.Minimum = 0;
            trackBar2.Maximum = 100;
            trackBar2.Value = Convert.ToInt32(axWindowsMediaPlayer1.settings.volume.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {

            int a = Convert.ToInt32(label1.Text);
            if(a%2==0)
            {
                if(listBox1.Items.Count<=0)
                {
                    openFileDialog1.Filter = "Müzik Dosyası(*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.wmv";
                    openFileDialog1.Title = "Dosya Seç";
                    openFileDialog1.FileName = "";
                    openFileDialog1.ShowDialog();
                    if(openFileDialog1.FileName!="")
                    {
                        for (int i = 0; i < openFileDialog1.SafeFileNames.Length; i++)
                        {
                            listBox1.Items.Add(openFileDialog1.FileNames[i].ToString());
                            listBox2.Items.Add(openFileDialog1.SafeFileNames[i].ToString());
                        }
                        listBox1.SelectedIndex = 0;
                        axWindowsMediaPlayer1.URL = listBox1.GetItemText(listBox1.SelectedItem);
                    }
                }
                if(listBox1.Items.Count>=1)
                {
                    if(listBox1.SelectedIndex!=-1)
                    {
                        Image myimage = new Bitmap(@"C:\Program Files (x86)\MüzikPlayer\MüzikPlayer\img\pausee.png");
                        button2.BackgroundImage = myimage;
                        button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                        timer1.Start();
                    }
                    else
                    {
                        listBox1.SelectedIndex += 1;
                    }
                }
            }
            if(a%2!=0)
            {
                Image myimage = new Bitmap(@"C:\Program Files (x86)\MüzikPlayer\MüzikPlayer\img\playy.png");
                button2.BackgroundImage = myimage;
                button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                timer1.Stop();
            }
            a++;
            label1.Text = Convert.ToString(a);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                listBox2.SelectedIndex = listBox1.SelectedIndex;
                axWindowsMediaPlayer1.URL = listBox1.GetItemText(listBox1.SelectedItem);
            int a = Convert.ToInt32(label1.Text);
            if(a%2==0)
            {
                button2.PerformClick();
            }
            else
            {
                button2.PerformClick();
                button2.PerformClick();
            }
                trackBar1.Value = 0;
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(axWindowsMediaPlayer1.URL!="")
            {
                string süre = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                double top = axWindowsMediaPlayer1.currentMedia.duration;
                int a = Convert.ToInt32(top);
                if(süre!="")
                {
                    label2.Text = süre;
                }
                else
                {
                    label2.Text = "00:00";
                }

                trackBar1.Maximum = Convert.ToInt32(a);
                trackBar1.Minimum = 0;
                
                if (trackBar1.Value>=0&&trackBar1.Value != trackBar1.Maximum&&trackBar1.Maximum>1)
                {
                    Image myimage = new Bitmap(@"C:\Program Files (x86)\MüzikPlayer\MüzikPlayer\img\pausee.png");
                    button2.BackgroundImage = myimage;
                    button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    trackBar1.Value+=1;
                }
                if(trackBar1.Value >= 0&&trackBar1.Value==trackBar1.Maximum && trackBar1.Maximum > 1)
                {
                    Image myimage = new Bitmap(@"C:\Program Files (x86)\MüzikPlayer\MüzikPlayer\img\playy.png");
                    button2.BackgroundImage = myimage;
                    button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    if (label2.Text == "00:00")
                    {
                        trackBar1.Value = 0;
                    }
                    int suan = listBox1.SelectedIndex;
                    int elemansayi = listBox1.Items.Count;
                    suan += 1;
                    if(suan<elemansayi)
                    {
                        listBox1.SelectedIndex += 1;
                        axWindowsMediaPlayer1.URL = listBox1.GetItemText(listBox1.SelectedItem);
                    }
                    else
                    {
                        listBox1.SelectedIndex = 0;
                        axWindowsMediaPlayer1.URL = listBox1.GetItemText(listBox1.SelectedItem);
                    }
                }



            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar1.Value;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            string süre = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            label2.Text = süre;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar2.Value;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sayac = Convert.ToInt32(label3.Text);
            if(sayac%2==0)
            {
                trackBar2.Visible = true;
            }
            if(sayac%2!=0)
            {
                trackBar2.Visible = false;
            }
            sayac++;
            label3.Text=Convert.ToString(sayac);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Kaydet frm = new Kaydet();
            int say;
            say = listBox1.Items.Count;
            for(int i=0; i<say;i++)
            {
                frm.listBox1.Items.Add(listBox1.Items[i]);
                frm.listBox2.Items.Add(listBox2.Items[i]);
            }
            frm.Show();
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Çalma Listesi Dosyası(*.txt)|*.txt;";
            openFileDialog2.Title = "Dosya Seç";
            openFileDialog2.FileName = "";
            openFileDialog2.ShowDialog();
            string dosya_yolu = @openFileDialog2.FileName.ToString();
            string dosya_yolu2 = @"C:\Program Files (x86)\MüzikPlayer\MüzikPlayer\data\bin\" + openFileDialog2.SafeFileName.ToString();
            //Okuma işlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            FileStream fs2 = new FileStream(dosya_yolu2, FileMode.Open, FileAccess.Read);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosyanın açılacağını,
            //3.parametre dosyaya erişimin veri okumak için olacağını gösterir.
            StreamReader sw = new StreamReader(fs);
            StreamReader sw2 = new StreamReader(fs2);
            //Okuma işlemi için bir StreamReader nesnesi oluşturduk.
            string yazi = sw.ReadLine();
            string yazi2 = sw2.ReadLine();
            while (yazi != null)
            {
                listBox1.Items.Add(yazi.ToString());
                yazi = sw.ReadLine();
                listBox2.Items.Add(yazi2.ToString());
                yazi2 = sw2.ReadLine();
            }
            //Satır satır okuma işlemini gerçekleştirdik ve ekrana yazdırdık
            //Son satır okunduktan sonra okuma işlemini bitirdik
            sw2.Close();
            sw.Close();
            fs2.Close();
            fs.Close();
            //İşimiz bitince kullandığımız nesneleri iade ettik.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sayac = listBox1.Items.Count;
            int a = listBox1.SelectedIndex;
            a += 1;
            if(a<sayac)
            {
                listBox1.SelectedIndex += 1;
            }
            else
            {
                listBox1.SelectedIndex = 0;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sayac = listBox1.Items.Count;
            int a = listBox1.SelectedIndex;
            a += 1;
            if (a > 1)
            {
                listBox1.SelectedIndex -= 1;
            }
            else
            {
                listBox1.SelectedIndex = sayac-1;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

    }
    }
