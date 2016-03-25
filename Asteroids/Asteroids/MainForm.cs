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
using System.Threading;

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
            game = new Game();
        }
        Asteroids.Time.Timer timer, frameTimer, eventTimer;
        public void GameLoop()
        {
            timer = new Asteroids.Time.Timer();
            frameTimer = new Asteroids.Time.Timer();
            eventTimer = new Asteroids.Time.Timer();
            game.ResetTime();
            Thread renderThread = new Thread(this.ASynchGameLoop);
            renderThread.Start();
            while(this.Created)
            {
                eventTimer.Reset();
                while(eventTimer.Time <= 30)
                {
                    Thread.Yield();
                }
            }
        }
        private void RenderScene()
        {

        }
        private void GameLogic()
        {

        }
        public void ASynchGameLoop()
        {
            int count = 0, FRAMES = 30;
            while(this.Created)
            {
                if(++count == FRAMES)
                {

                }
                timer.Reset();
                while(timer.Time < 10)
                {
                    Thread.Yield();
                }
            }
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
