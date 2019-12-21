using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectoresR3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<double> Uno = new List<double>();
        List<double> Dos = new List<double>();
        List<double> Tres = new List<double>();

        List<double> EscUno = new List<double>();

        List<double> escAB = new List<double>();

        List<double> vecUno = new List<double>();
        List<double> EscTres = new List<double>();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Visible = true;
            if (comboBox1.Text == "1")
            {
                textBox1.Visible = true;
                textBox2.Visible = false;
                label6.Visible = true;
                label7.Visible = false;
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                button2.Visible = true;
                label13.Visible = true;
                groupBox1.Size = new System.Drawing.Size(168, 110);
            }
            if (comboBox1.Text == "2")
            {
                groupBox2.Size = new System.Drawing.Size(163, 185);
                button2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                label7.Visible = true;
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                textBox4.Visible = false;
                label3.Visible = false;
                label6.Visible = true;
                label13.Visible = true;
            }
        }

        void Pasar(TextBox t, List<double> val)
        {
            string cad = t.Text;
            string[] J = cad.Split(',');
            for (int i = 0; i < 3; i++)
            {
                val.Add(double.Parse(J[i]));
            }
        }
        double AA = 0;
        double BB = 0;
        double CC = 0;

        double XX = 0;
        double YY = 0;
        double ZZ = 0;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            try
            {
                Uno.Clear();
                Dos.Clear();
                vecUno.Clear();
                EscUno.Clear();
                escAB.Clear();

                

                if (comboBox1.Text == "1")
                {
                    Pasar(textBox1, Uno);
                    AA = Uno[0];
                    BB = Uno[1];
                    CC = Uno[2];
                    panel1.Refresh();
                    panel1.Refresh();
                    if (radioButton7.Checked == true)
                    {
                        listBox1.Items.Add("Módulo de A");
                        double resM = Modulo(Uno, "A");

                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                    if (radioButton8.Checked == true)
                    {
                        listBox1.Items.Add("Producto escalar de " + int.Parse(textBox4.Text) + " por A");
                        MulEscalar(Uno, int.Parse(textBox4.Text), "A");

                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                }
                if (comboBox1.Text == "2")
                {
                    Pasar(textBox1, Uno);
                    AA = Uno[0];
                    BB = Uno[1];
                    CC = Uno[2];
                    Pasar(textBox2, Dos);
                    XX = Dos[0];
                    YY = Dos[1];
                    ZZ = Dos[2];
                    panel1.Refresh();
                    panel1.Refresh();

                    if (radioButton1.Checked == true)
                    {//producto Escalar
                        listBox1.Items.Add("Producto Escalar de A por B");
                        ProdEscalar(Uno, Dos);
                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                    if (radioButton2.Checked == true)
                    {
                        listBox1.Items.Add("Producto Vectorial de A por B");
                        prodVec(Uno, Dos);
                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                    if (radioButton3.Checked == true)
                    {
                        listBox1.Items.Add("Ángulo por Producto Escalar");
                        listBox1.Items.Add("Modulo de A");
                        double j = Math.Sqrt(Modulo(Uno, "A"));

                        listBox1.Items.Add("--------------------------------");
                        listBox1.Items.Add("Modulo de B");
                        double k = Math.Sqrt(Modulo(Dos, "B"));

                        listBox1.Items.Add("--------------------------------");
                        listBox1.Items.Add("Producto Escalar de A por B");
                        double prod = ProdEscalar(Uno, Dos);

                        listBox1.Items.Add("--------------------------------");
                        listBox1.Items.Add("|A||B| = " + (k * j).ToString("0.####"));
                        listBox1.Items.Add("Θ = ArcCos(" + prod.ToString("0.####") + "/" + (j * k).ToString("0.####") + "))");
                        double o = prod / Math.Round(j * k);
                        double w = Math.Acos((o));
                        listBox1.Items.Add("Θ = " + ConvertRadiansToDegrees(w).ToString("0.####") + "°");

                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                    if (radioButton4.Checked == true)
                    {
                        listBox1.Items.Add("Ángulo por Producto Vectorial");
                        listBox1.Items.Add("Modulo de A");
                        double j = Math.Sqrt(Modulo(Uno, "A"));
                        listBox1.Items.Add("--------------------------------");
                        listBox1.Items.Add("Modulo de B");
                        double k = Math.Sqrt(Modulo(Dos, "B"));
                        listBox1.Items.Add("--------------------------------");
                        listBox1.Items.Add("Producto Vectorial de A por B");
                        prodVec(Uno, Dos);

                        listBox1.Items.Add("--------------------------------");
                        double mod = Math.Sqrt(Modulo(vecUno, "A×B"));
                        listBox1.Items.Add("--------------------------------");

                        listBox1.Items.Add("|A||B| = " + (k * j).ToString("0.####"));
                        listBox1.Items.Add("Θ = ArcSin(" + mod.ToString("0.####") + "/" + (j * k).ToString("0.####") + "))");
                        double o = mod / Math.Round(j * k);
                        double w = Math.Asin((o));

                        listBox1.Items.Add("Θ = " +ConvertRadiansToDegrees(w).ToString("0.#####") + "°");

                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                    if (radioButton5.Checked == true)
                    {//paralelo
                        listBox1.Items.Add("A y B son Paralelos?");
                        prodVec(Uno, Dos);
                        string h = "( ";
                        bool b = true;
                        foreach (var item in vecUno)
                        {
                            if (item != 0)
                            {
                                b = false;
                            }
                            h += item + " , ";
                        }

                        h = h.Substring(0, h.Length - 2);
                        h += ")";


                        if (b)
                        {
                            h += "==";
                            listBox1.Items.Add(h+" ( 0 , 0 , 0 )");
                            listBox1.Items.Add("A y B son Paralelos");
                        }
                        else
                        {
                            h += "!=";
                            listBox1.Items.Add(h+" ( 0 , 0 , 0 ) ");
                            listBox1.Items.Add("A y B No son Paralelos");
                        }
                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                    if (radioButton6.Checked == true)
                    {//perpendicular-orton
                        listBox1.Items.Add("A y B son Perpendiculares?");
                        double res = ProdEscalar(Uno, Dos);
                        if (res == 0)
                        {

                            listBox1.Items.Add(res+"=="+0);
                            listBox1.Items.Add("A y B son Perpendiculares");
                        }
                        else
                        {
                            listBox1.Items.Add(res + "!=" + 0);
                            listBox1.Items.Add("A y B no son Perpendiculares");
                        }
                        listBox1.Items.Add("--------------------------------------------------------------------");
                    }
                    if (radioButton7.Checked == true)
                    {
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Seleccione un opción... \nVerifique los vectores...");
            }
        }

        void prodVec(List<double> a, List<double> b)
        {
            listBox1.Items.Add("           |  i    j    k  |");
            listBox1.Items.Add("A×B= |  " + a[0] + "  " + a[1] + "  " + a[2] + "  |");
            listBox1.Items.Add("           |  " + b[0] + "  " + b[1] + "  " + b[2] + "  |");
            listBox1.Items.Add("");
            //  listBox1.Items.Add("A×B= i (" + ((a[1]*b[2])-(b[1]*a[2]))+") - j ("+((a[0]*b[2]) - b[0]*a[2])+") + k("+((a[0]*b[1]) - (b[0]*a[1]))+")");
            listBox1.Items.Add("A×B= i (" + ((a[1] * b[2]) - (b[1] * a[2])) + ") - j (" + ((a[0] * b[2]) - b[0] * a[2]) + ") + k(" + ((a[0] * b[1]) - (b[0] * a[1])) + ")");
            listBox1.Items.Add("A×B=  (" + ((a[1] * b[2]) - (b[1] * a[2])) + "," + -((a[0] * b[2]) - b[0] * a[2]) + "," + +((a[0] * b[1]) - (b[0] * a[1])) + ")");

            vecUno.Add(((a[1] * b[2]) - (b[1] * a[2])));
            vecUno.Add(-((a[0] * b[2]) - b[0] * a[2]));
            vecUno.Add(+((a[0] * b[1]) - (b[0] * a[1])));
        }
        double Modulo(List<double> lis, string u)
        {
            double t = 0;
            String w = "√";
            string e = "";
            foreach (var item in lis)
            {
                t += Math.Pow((item), 2);
                e += Math.Pow((item), 2) + "+";
                w += item + "^2 + ";
            }
            listBox1.Items.Add("|" + u + "|=  " + w.Substring(0, w.Length - 2));
            listBox1.Items.Add("|" + u + "|=  " + "√" + e.Substring(0, e.Length - 1));
            listBox1.Items.Add("|" + u + "|=  " + "√" + t);
            return t;
        }
        void MulEscalar(List<double> lis, double n, string u)
        {
            string w = n + u + " =  " + n + "(";
            foreach (var item in lis)
            {
                EscUno.Add(item * n);
                w += item.ToString() + ",";
            }
            w = w.Substring(0, w.Length - 1);
            w += ")";
            listBox1.Items.Add(w);

            string e = n + u + "=  " + "(";
            foreach (var item in EscUno)
            {
                e += item.ToString() + ",";
            }
            e = e.Substring(0, e.Length - 1);
            e += ")";
            listBox1.Items.Add(e);
        }

        double ProdEscalar(List<double> a, List<double> b)
        {

            double e = 0;
            string h = "A｡B = (";
            foreach (var item in a)
            {
                h += item + ",";
            }
            h = h.Substring(0, h.Length - 1);
            h += ")｡(";
            foreach (var item in b)
            {
                h += item + ",";
            }
            h = h.Substring(0, h.Length - 1);
            listBox1.Items.Add(h + ")");
           
            string je = "A｡B =(";
            
            string j = "A｡B =";
            for (int i = 0; i < a.Count; i++)
            {
                je += a[i] + "*" + b[i] + "+";
                e += a[i] * b[i];
                j += a[i] * b[i] + "+";
            }
            je = je.Substring(0, je.Length - 1);
            listBox1.Items.Add(je + ")");
            j = j.Substring(0, j.Length - 1);
            listBox1.Items.Add(j + "");
            listBox1.Items.Add("A｡B = " + e);
            return e;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                pictureBox1.Image = global::VectoresR3.Properties.Resources.poresc;
                label3.Visible = true;
                textBox4.Visible = true;
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        { }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.Clear(this.BackColor);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen GR = new Pen(Color.FromArgb(227, 60, 25, 0), 3);
            e.Graphics.DrawLine(GR, 30, 300, 350, 80);
            int valX = 190;
            int valY = 190;
            double ree = AA;
            for (int i = 0; i < Math.Abs(AA); i++)
            {
                if (ree > 0)
                {//-4,2,5

                    if (Math.Abs(AA) != 1)
                    {
                      
                        if (i < AA - 1)
                        {
                            valX -= 20;
                            valY += 14;
                        }
                        Pen w = new Pen(Color.FromArgb(238, 242, 137, 130), 2);
                        e.Graphics.DrawLine(w, 190, 190, valX, valY);
                    }
                    else
                    {
                        valX -= 20;
                        valY += 14;
                        Pen w = new Pen(Color.FromArgb(238, 242, 137, 130), 2);

                        e.Graphics.DrawLine(w, 190, 190, valX, valY);
                    }

                }
                if (ree < 0)
                {
                   
                    if (Math.Abs(AA) != 1)
                    {
                        Pen w = new Pen(Color.FromArgb(238, 242, 137, 130), 2);
                        e.Graphics.DrawLine(w, 190, 190, valX, valY);
                        if (i < Math.Abs(AA - 1))
                        {
                            valX += 20;
                            valY -= 14;
                        }
                    }
                    else
                    {

                        valX += 20;
                        valY -= 14;

                        Pen w = new Pen(Color.FromArgb(238, 242, 137, 130), 2);
                        e.Graphics.DrawLine(w, 190, 190, valX, valY);
                    }

                }
            }


            Pen YYE = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            e.Graphics.DrawLine(YYE, 30, 190, 350, 190);


            double r = BB;
            int ux = valX;
            int uy = valY;
            for (int i = 0; i < Math.Abs(BB); i++)
            {
                if (r < 0)
                {
                    if (Math.Abs(BB) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, valX, valY, ux, uy);

                        if (i < Math.Abs(BB) - 1)
                        {
                            ux -= 23;
                        }
                    }
                    else
                    {
                        ux -= 23;

                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, valX, valY, ux, uy);
                    }


                }
                if (r > 0)
                {

                    if (Math.Abs(BB) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, valX, valY, ux, uy);
                        if (i < BB - 1)
                        {
                            ux += 23;
                        }
                    }
                    else
                    {
                        ux += 23;
                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, valX, valY, ux, uy);
                    }

                }
            }

            Pen ZZe = new Pen(Color.FromArgb(125, 0, 0, 0), 3);
            e.Graphics.DrawLine(ZZe, 190, 30, 190, 350);

            int zx = ux;
            int zy = uy;
            double oo = CC;
            for (int i = 0; i < Math.Abs(CC); i++)
            {
                if (oo < 0)
                {
                   
                    if (Math.Abs(CC) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, ux, uy, zx, zy);
                        if (i < Math.Abs(CC) - 1)
                        {
                            zy += 23;
                        }
                    }
                    else
                    {

                        zy += 23;
                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, ux, uy, zx, zy);
                    }


                }
                if (oo > 0)
                {

                    if (Math.Abs(CC) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, ux, uy, zx, zy);
                        if (i < CC - 1)
                        {
                            zy -= 23;
                        }
                    }
                    else
                    {
                        zy -= 23;
                        Pen q = new Pen(Color.FromArgb(255, 242, 137, 130), 2);
                        e.Graphics.DrawLine(q, ux, uy, zx, zy);

                    }

                }
            }

            Pen p = new Pen(Color.Red,3);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            e.Graphics.DrawLine(p, 190, 190, zx, zy);




            //segundo vector



            int valXX = 190;
            int valYY = 190;
            double ree1 = XX;
            for (int i = 0; i < Math.Abs(XX); i++)
            {
                if (ree1 > 0)
                {
                    
                    if (Math.Abs(XX) != 1)
                    {
                        Pen w = new Pen(Color.FromArgb(238, 151, 153, 243), 2);

                        e.Graphics.DrawLine(w, 190, 190, valXX, valYY);
                        if (i < XX - 1)
                        {
                            valXX -= 20;
                            valYY += 14;
                        }
                    }
                    else
                    {
                        valXX -= 20;
                        valYY += 14;
                        Pen w = new Pen(Color.FromArgb(238, 151, 153, 243),2);

                        e.Graphics.DrawLine(w, 190, 190, valXX, valYY);

                    }

                }
                if (ree1 < 0)
                {
                    

                    if (Math.Abs(XX) != 1) {
                        Pen w = new Pen(Color.FromArgb(238, 151, 153, 243), 2);
                        e.Graphics.DrawLine(w, 190, 190, valXX, valYY);
                        if (i < Math.Abs(XX) - 1)
                        {
                            valXX += 20;
                            valYY += 14;
                        }
                    } else {
                        valXX += 20;
                        valYY += 14;
                        Pen w = new Pen(Color.FromArgb(238, 151, 153, 243), 2);
                        e.Graphics.DrawLine(w, 190, 190, valXX, valYY);
                    }
                      
                }
            }



            double r1 = YY;
            int uxx = valXX;
            int uyy = valYY;
            for (int i = 0; i < Math.Abs(YY); i++)
            {
                if (r1 < 0)
                {
                  
                    if (Math.Abs(YY) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 151, 153, 243), 2);
                        e.Graphics.DrawLine(q, valXX, valYY, uxx, uyy);
                        if (i < Math.Abs(YY) - 1)
                        {
                            uxx -= 23;
                        }
                    }
                    else {
                       
                            uxx -= 23;
                        Pen q = new Pen(Color.FromArgb(255, 151, 153, 243), 2);
                        e.Graphics.DrawLine(q, valXX, valYY, uxx, uyy);

                    }
                       

                }
                if (r1 > 0)
                {
                   
                    if (Math.Abs(YY) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 151, 153, 243), 2);
                        e.Graphics.DrawLine(q, valXX, valYY, uxx, uyy);
                        if (i < YY - 1)
                        {
                            uxx += 23;
                        }
                    }
                    else {
                        uxx += 23;
                        Pen q = new Pen(Color.FromArgb(255, 151, 153, 243), 2);
                        e.Graphics.DrawLine(q, valXX, valYY, uxx, uyy);
                    }
                      
                }
            }

            int zxx = uxx;
            int zyy = uyy;
            double oo1 = ZZ;
            for (int i = 0; i < Math.Abs(ZZ); i++)
            {
                if (oo1 < 0)
                {
                    
                    if (Math.Abs(ZZ) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 151, 153, 243), 2);
                        e.Graphics.DrawLine(q, uxx, uyy, zxx, zyy);
                        if (i < Math.Abs(ZZ) - 1)
                        {
                            zyy += 23;
                        }
                    }
                    else
                    {
                        zyy += 23;
                        Pen q = new Pen(Color.FromArgb(255, 151, 153, 243), 2);
                        e.Graphics.DrawLine(q, uxx, uyy, zxx, zyy);
                    }
                      

                }
                if (oo1 > 0)
                {
                    
                    if (Math.Abs(ZZ) != 1)
                    {
                        Pen q = new Pen(Color.FromArgb(255, 151, 153, 243),2);
                        e.Graphics.DrawLine(q, uxx, uyy, zxx, zyy);
                        if (i < ZZ - 1)
                        {
                            zyy -= 23;
                        }
                    }
                    else{
                        zyy -= 23;
                        Pen q = new Pen(Color.FromArgb(20, 151, 153, 243), 2);
                        e.Graphics.DrawLine(q, uxx, uyy, zxx, zyy);
                    }
                       
                }
            }

            Pen pe = new Pen(Color.Blue,3);
            pe.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            

            e.Graphics.DrawLine(pe, 190, 190, zxx, zyy);




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                    Uno.Clear();
                    Dos.Clear();
                    vecUno.Clear();
                    EscUno.Clear();
                    escAB.Clear();
                    if (comboBox1.Text == "1")
                    {
                        Pasar(textBox1, Uno);
                        AA = Uno[0];
                        BB = Uno[1];
                        CC = Uno[2];
                        panel1.Refresh();
                        panel1.Refresh();
                    }
                    else
                    {
                        Pasar(textBox1, Uno);
                        AA = Uno[0];
                        BB = Uno[1];
                        CC = Uno[2];
                        Pasar(textBox2, Dos);
                        XX = Dos[0];
                        YY = Dos[1];
                        ZZ = Dos[2];
                        panel1.Refresh();
                        panel1.Refresh();
                    }
                
            }
            catch (Exception ex) {
                MessageBox.Show("Vectores mal Ingresados...[Formato:  0,0,0]");
            }
           
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        public static double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                pictureBox1.Image = global::VectoresR3.Properties.Resources.escalar;
            }
           
           
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {

                pictureBox1.Image = global::VectoresR3.Properties.Resources.cos;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {

                pictureBox1.Image = global::VectoresR3.Properties.Resources.sen;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                pictureBox1.Image = global::VectoresR3.Properties.Resources.per;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {


            if (radioButton6.Checked == true)
            {

                pictureBox1.Image = global::VectoresR3.Properties.Resources.paral;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {

                pictureBox1.Image = global::VectoresR3.Properties.Resources.lol;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                pictureBox1.Image = global::VectoresR3.Properties.Resources.mod;
                label3.Visible = false;
                textBox4.Visible = false;
            }
        }
    }
}
