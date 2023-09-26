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
        IdealGas gas = new IdealGas();
        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FlyBall a = new FlyBall(this);
                a.SetPosition(e.X, e.Y);
                a.SetRandomSpeed(-5, 5);
                a.Show();
                gas.Add(a);
            }
            else
            {
                PoolBall a = new PoolBall(this);
                a.SetPosition(e.X, e.Y);
                a.SetRandomSpeed(-5, 5);
                a.Show();
                gas.Add(a);
            }
            
        }
               
        private void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                //foreach(var a in listBalls)
                //    a.Pause();
            }
            catch
            {
                MessageBox.Show("Нажми правую кнопку мыши для создания шарика");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gas.Pause();
        }
    }
}
