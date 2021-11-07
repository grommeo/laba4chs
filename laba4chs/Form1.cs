using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4chs
{
    public partial class Form1 : Form
    {
        List<Napitki> napitkiList = new List<Napitki>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.napitkiList.Clear();
            var rnd = new Random();
            for(var i=0;i<10;i++)
            {
                switch(rnd.Next()%3)
                {
                    case 0:
                        this.napitkiList.Add(Sok.Generate());
                        break;
                    case 1:
                        this.napitkiList.Add(Gazirovka.Generate());
                        break;
                    case 2:
                        this.napitkiList.Add(Alko.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            int sokCount = 0;
            int gazirovkaCount = 0;
            int alkoCount = 0;

            foreach(var napitki in this.napitkiList)
            {
                if (napitki is Sok)
                {
                    sokCount += 1;
                }
                else if (napitki is Gazirovka)
                {
                    gazirovkaCount += 1;
                }
                else if (napitki is Alko)
                {
                    alkoCount += 1;
                }
            }

            txtInfo.Text = "Сок\tГазировка\tАлкоголь";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t               {2}", sokCount, gazirovkaCount, alkoCount);
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.napitkiList.Count == 0)
            {
                txtOut.Text = "Пусто GGWP";
                PictureOutBox.Image = Properties.Resources.Пустота;
                return;
            }

            var napitki = this.napitkiList[0];
            this.napitkiList.RemoveAt(0);

            txtOut.Text = napitki.GetInfo();
            PictureOutBox.Image = napitki.img;

            ShowInfo();
        }
    }
}
