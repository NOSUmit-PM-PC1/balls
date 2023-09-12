using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace balls
{
    public partial class FormGame : Form
    {
        FlyBall b;
        public FormGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new FlyBall(this);
            
            //Ball b = new Ball();
            //this.Controls.Add(b);

            b.Show();
        }

        private void FormGame_MouseDown(object sender, MouseEventArgs e)
        {

            FlyBall a = new FlyBall(this);    
            a.SetPosition(e.X, e.Y);
            a.SetRandomSpeed(-5, 5);
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            b.Move();
            b.Show();
        }
    }
}
