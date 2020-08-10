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
    public partial class Kaydet : Form
    {
        public Kaydet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.label4.Text = textBox1.Text;

            if (textBox1.Text != "0" && textBox1.Text != "")
            {
                string dosya_yolu = @"C:\Program Files (x86)\MüzikPlayer\MüzikPlayer\data\" + textBox1.Text + ".txt";
                string dosya_yolu2 = @"C:\Program Files (x86)\MüzikPlayer\MüzikPlayer\data\bin\" + textBox1.Text + ".txt";
                //İşlem yapacağımız dosyanın yolunu belirtiyoruz.
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                FileStream fs2 = new FileStream(dosya_yolu2, FileMode.OpenOrCreate, FileAccess.Write);
                //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
                //2.parametre dosya varsa açılacağını yoksa oluşturulacağını belirtir,
                //3.parametre dosyaya erişimin veri yazmak için olacağını gösterir.
                StreamWriter sw = new StreamWriter(fs);
                StreamWriter sw2 = new StreamWriter(fs2);
                //Yazma işlemi için bir StreamWriter nesnesi oluşturduk.
                int sayac = listBox1.Items.Count;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    sw.WriteLine(listBox1.Items[i]);
                    sw2.WriteLine(listBox2.Items[i]);
               }
                //Dosyaya ekleyeceğimiz iki satırlık yazıyı WriteLine() metodu ile yazacağız.
                sw.Flush();
                sw2.Flush();
                //Veriyi tampon bölgeden dosyaya aktardık.
                sw.Close();
                sw2.Close();
                fs.Close();
                fs2.Close();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
