using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Game : Form
    {
        Player player;
        System.Drawing.Graphics graphics;
        public Game()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            player = new Player(GameScreen.Size.Width / 2, GameScreen.Size.Height / 2);
            graphics = this.CreateGraphics();
            GameScreen.Paint += new PaintEventHandler(GameScreen_Paint);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(player.getX()-50, player.getY()-50,player.getX()+50,player.getY()+50);
            //graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.White)), p.DisplayRectangle);
            Point[] points = new Point[4];
            points[0] = new Point(player.getX() - 50, player.getY() - 50);
            points[1] = new Point(player.getX() - 50, player.getY() + 50);
            points[2] = new Point(player.getX() + 50, player.getY() + 50);
            points[3] = new Point(player.getX() + 50, player.getY() - 50);
            Brush brush = new SolidBrush(Color.DarkGreen);
            g.FillPolygon(brush, points);

        }
    }
}
