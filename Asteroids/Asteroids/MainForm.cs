using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asteroids.GameLibrary;
using Asteroids.Time;

namespace Asteroids
{
    public partial class MainForm : Form
    {
        KeyManager km;
        Keys key = new Keys();
        BufferedGraphics buff;
        Game game;
        public MainForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            
        }
        Asteroids.Time.Timer timer, frameTimer, eventTimer;
        public void GameLoop()
        {
            timer = new Asteroids.Time.Timer();
            frameTimer = new Asteroids.Time.Timer();
            eventTimer = new Asteroids.Time.Timer();
            game.ResetTime();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            km.KeyReleased(e.KeyCode);
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            km.KeyPressed(e.KeyCode);
        }
 
    }
}
