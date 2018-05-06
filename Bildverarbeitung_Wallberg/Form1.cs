using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bildverarbeitung_Wallberg
{
    public partial class Form1 : Form
    {
        Bitmap map;
        string pictureName = "KaffeefleckGross.jpg";

        public Form1()
        {
            InitializeComponent();

            map = Bildverarbeitung.Load_Image(DefaultVariables.GetProjectPath() + "Picture\\" + pictureName);

            this.pbMain.Size = new System.Drawing.Size(map.Size.Width, map.Size.Height);
            this.pbMain.Image = map;
            this.pbMain.Refresh();
        }

        private void btnGrey_Click(object sender, EventArgs e)
        {
            this.pbMain.Image = Bildverarbeitung.ImageToGrey(map);
            this.Refresh();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            map = Bildverarbeitung.Load_Image(DefaultVariables.GetProjectPath() + "\\Picture\\" + pictureName);

            this.pbMain.Image = map;
            this.Refresh();
        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            this.pbMain.Image = Bildverarbeitung.LoadHistogramInImage(map);
            this.Refresh();
        }

        private void btnHistoColor_Click(object sender, EventArgs e)
        {
            this.pbMain.Image = Bildverarbeitung.LoadHistogramInImage(map, false);
            this.Refresh();
        }

        private void btnHistoArea_Click(object sender, EventArgs e)
        {
            this.pbMain.Image = Bildverarbeitung.LoadHistogramAreaInImage(map);
            this.Refresh();
        }

        private void btn_greyscales_Click(object sender, EventArgs e)
        {
            this.pbMain.Image = Bildverarbeitung.FixGrey2RealBlackAndWhite(map);
            this.Refresh();
        }
    }
}
