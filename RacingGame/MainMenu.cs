using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class MainMenu : Form
    {
        public bool Start = false;
        public MainMenu()
        {
            InitializeComponent();
            ClientSize = new Size(300, 600);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Create an instance of the game form
            Form1 game = new Form1();

            // Hide the main menu form
            this.Hide();

            // Show the game form
            game.ShowDialog();

            // Close the application when the game form is closed
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            // Create an instance of the game form
            HowToPlay howToPlay = new HowToPlay();

            // Hide the main menu form
            this.Hide();

            // Show the game form
            howToPlay.ShowDialog();

            // Close the application when the game form is closed
            Application.Exit();
        }
    }
}
