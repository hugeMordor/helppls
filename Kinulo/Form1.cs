using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//using System.Drawing
using System.Windows.Forms;
 
namespace Kinulo
{
    
    public partial class Form1 : Form
    {
        double _vx, _vy, _v0, _agile, _h0, _dev = 50; int _setka = 0;
        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _v0 = Convert.ToDouble(textBox2.Text)*_dev;
            }
            catch { 
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _setka = Convert.ToInt32(textBox5.Text) * Convert.ToInt32(_dev);
            }
            catch{
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _agile = Convert.ToDouble(textBox3.Text);
            }
            catch { }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _dev = Convert.ToDouble(textBox4.Text);
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _h0 = Convert.ToDouble(textBox1.Text)*_dev;
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 0), new Point(0, 500));
            g.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 500), new Point(900, 500));

            if (_setka !=0) {

                for (int i = _setka; i < 500; i = i + _setka) {
                    g.DrawLine(new Pen(Brushes.Gray, 1), new Point(0, 500-i), new Point(900, 500-i));
                   
                }
                for (int i = _setka; i < 900; i = i + _setka)
                {
                   
                    g.DrawLine(new Pen(Brushes.Gray, 1), new Point(i, 0), new Point(i, 500));
                }

            }


            // Create pen.
        //    Pen blackPen = new Pen(Color.Black, 2);

            // Create rectangle for ellipse.
         //   Rectangle rect = new Rectangle(100, 100, 1, 1);

            // Draw ellipse to screen.
         //   g.DrawRectangle(blackPen, rect);
/*
            for (int i = 0; i < 50; i++) {
                Pen blackPen1 = new Pen(Color.Black, 2);

                Rectangle rect1 = new Rectangle(100, i, 1, 1);

                
                g.DrawRectangle(blackPen1, rect1);

            }
*/



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;

            if (_agile == 0 || _v0 == 0)
            {
                textBox2.BackColor = Color.Red;
                textBox3.BackColor = Color.Red;
            }
            else
            {
                

                double rad = _agile * (Math.PI / 180.0);

                _vy = (Math.Sin(rad)) * _v0;
                _vx = (Math.Cos(rad)) * _v0;
                int vy = Convert.ToInt32(_vy);
                int vx = Convert.ToInt32(_vx);

                double time;
                time = ((_vy + (Math.Sqrt((_vy * _vy) + 2 * 10 * _h0)))) / 10;
                textBox6.Text = Convert.ToString((((_vy) * (_vy) / 20) + _h0) / _dev);
                textBox7.Text = Convert.ToString(time); // время, не работает
                textBox8.Text = Convert.ToString(time*_vx); // по формуле вроде так, но надо починить время
                Graphics g = pictureBox1.CreateGraphics();
                Pen blackPen1 = new Pen(Color.Black, 2);
                double x = 0, y = 0;
                int i = 0;
                while (0 == 0)
                {
                    Rectangle rect1 = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(500 - y), 1, 1);
                    Console.Write(x);
                    x = _vx * i;
                    y = (_vy * i) - ((10 * i * i) / 2) + _h0;

                    if (x > 900)
                    {  /// было бы неплохо пофиксить, ибо тут должен отключаться цикл если значение переходят в отрицательный у
                        break;
                    }

                    try
                    {
                        g.DrawRectangle(blackPen1, rect1);
                    }
                    catch { }
                    i++;
                }
            }
        }
    }
}
