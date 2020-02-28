﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCFS
{
    public partial class Start : Form
    {
        int moveStart;
        int moveStartX;
        int moveStartY;
        int timeValue = 0;
           
        public Start()
        {
            InitializeComponent();
        }

   

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            progressBarFCFS.Show();
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - moveStartX, MousePosition.Y - moveStartY);
            }
        }

        private void bunifuGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            moveStart = 0;
        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            moveStart = 1;
            moveStartX = e.X;
            moveStartY = e.Y;
        }

        private void Start_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            progressBarFCFS.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeValue += 10;
            progressBarFCFS.Value = timeValue;
            if(progressBarFCFS.Value == 100)
            {
                progressBarFCFS.Value = 0;
                FCFS_Main fcsf = new FCFS_Main();
                fcsf.Show();
                this.Hide();
                timer1.Stop();
            }
        }
    }
}
