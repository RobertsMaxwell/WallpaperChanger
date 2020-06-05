using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopChanger
{
    public partial class Form1 : Form
    {
        private string folderPath = "";
        private float timeBetweenChanges = 15;
        private bool loop = false;
        private bool shuffle = false;

        public string FolderPath { get { return folderPath; } }
        public float TimeBetweenChanges { get { return timeBetweenChanges; } }
        public bool Loop { get { return loop; } }
        public bool Shuffle { get { return shuffle; } }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderPath = fbd.SelectedPath;
                textBox2.Text = $"{folderPath}";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                loop = true;
                checkBox1.Text = "On";
            }
            else
            {
                loop = false;
                checkBox1.Text = "Off";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                shuffle = true;
                checkBox2.Text = "On";
            }
            else
            {
                shuffle = false;
                checkBox2.Text = "Off";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alternate.SwitchImage(folderPath, timeBetweenChanges * 60, loop, shuffle);
        }

        private void UpdateTime()
        {
            timeBetweenChanges = Convert.ToInt32(Hours.Text) * 60 + Convert.ToInt32(Minutes.Text) + Convert.ToInt32(Seconds.Text) / (float)60;
        }

        private void Hours_Leave(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void Minutes_Leave(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void Seconds_Leave(object sender, EventArgs e)
        {
            UpdateTime();
        }
    }
}
