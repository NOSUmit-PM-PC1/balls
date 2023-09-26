using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace balls
{
    // неподвижные шарики
    class Ball:PictureBox
    {
        protected double x, y;
        protected int radius = 20;
        public Ball() { }
        public Ball(Form owner)
        { 
            x = 100; y = 100;
            this.Width = 2 * radius;
            this.Height = 2 * radius;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Load(Environment.CurrentDirectory +"/images/red.png");
            owner.Controls.Add(this);
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Show()
        {
            this.Top = (int)(y - radius);
            this.Left = (int)(x - radius);
        }
    }

    // летающие шарики
    class FlyBall : Ball
    {
        static public bool pause_all = true;

        protected double vx = 5, vy = 5;
        Timer t;
        bool pause = false;
        public FlyBall() { }
        public FlyBall(Form owner):base(owner)
        {
            t = new Timer();
            t.Interval = 10;
            t.Tick += T_Tick;
            t.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.MoveBall();
            this.Show();
        }

        public void SetSpeed(double vx, double vy)
        {
            this.vx = vx;
            this.vy = vy;
        }

        public void SetRandomSpeed(int min, int max)
        {
            Random rnd = new Random();
            this.vx = rnd.Next(min, max);
            this.vy = rnd.Next(min, max);
        }

        public virtual void MoveBall()
        {
            x = x + vx;
            y = y + vy;
        }

        public void Stop() { t.Enabled = false; }
        public void Start() { t.Enabled = true; }
        public void Pause()
        {
            if (pause) Start();
            else Stop();
            pause = !pause;
        }
    }

    // шарики отскакивающие от стены
    class PoolBall : FlyBall
    {
        int wight, height;
       
        public PoolBall(Form owner) : base(owner)
        {
            wight = owner.ClientSize.Width;
            height = owner.ClientSize.Height;
        }

        public override void MoveBall()
        {
            base.MoveBall();
            if (x <= radius) vx = -vx;
            if (y <= radius) vy = -vy;
            if (y >= height - radius) vy = -vy;
            if (x >= wight - radius) vx = -vx;
        }

    
    }

    // много шариков
    class IdealGas
    {
        List<FlyBall> listBalls;

        public IdealGas()
        {
            listBalls = new List<FlyBall>();
        }

        public void Add(FlyBall a)
        {
            listBalls.Add(a);
        }

        public void Stop()
        {
            foreach (var a in listBalls)
                a.Stop();

        }
        public void Start()
        {
            foreach (var a in listBalls)
                a.Start();
        }

        public void Pause()
        {
            FlyBall.pause_all = !FlyBall.pause_all;
            if (FlyBall.pause_all)
            {
                Start();
            }
            else
            {
                Stop();
            }
            
        }
    }
}
