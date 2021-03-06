﻿//Reid Ball 
//November 30 2016
//Star Wars trench run animaton.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Windows.Forms;

namespace TrenchRun
{
    public partial class Form1 : Form
    { 
        //Declaring all variables
        Graphics graphics;
        Font titleFont, paraFont;
        SolidBrush drawBrush;
        Pen drawPen;
        int movement, fighter, bomb; 
        

        public Form1()
        {
            InitializeComponent();
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        { 
            //Assigning values to variables
            graphics = CreateGraphics();
            titleFont = new Font("Arial MS", 15.0f, FontStyle.Regular);
            paraFont = new Font("Arial MS", 12.0f, FontStyle.Regular);
            drawBrush = new SolidBrush(Color.White);
            drawPen = new Pen(Color.White);
            movement = 1;
            SoundPlayer player = new SoundPlayer(Properties.Resources.boom);

            //Clearing screen for mission briefing
            logoPictureBox.Visible = false;

            //Mission briefing
            graphics.DrawString("Death Star Attack Plan", titleFont, drawBrush, 85, 50);
            graphics.DrawString("The Death Star has a weak point on the top. \nYour assignment is" +
                " to drop a bomb down \nthis shaft and cause an explosion that will \ncause a reaction" +
                " which will result in the end \nof the Death Star and start of the revolution." +
                "\n\nGood luck, soldier.", paraFont, drawBrush, 43, 100);
            Thread.Sleep(5500);
            
            //Clearing screen for animation
            graphics.Clear(Color.Black);

            //Animation of fighter going over the Death Star until it reaches the midle of it
            for (fighter = 1; fighter <= 215; fighter++)
            {
                Thread.Sleep(3);
                graphics.Clear(Color.Black);
                graphics.DrawEllipse(drawPen, 95, 130, 200, 200);
                graphics.DrawEllipse(drawPen, 190, 225, 10, 10);
                graphics.DrawRectangle(drawPen, 185, 130, 20, 10);
                graphics.DrawLine(drawPen, 195, 140, 195, 225);
                graphics.FillRectangle(drawBrush, this.Width - movement, 30, 20, 10); 
              
                movement++;
            } 

            //Animation of bomb dropping and fighter leaving screen
            for (bomb = 40; bomb <= 230; bomb++)
            {
                Thread.Sleep(3);
                graphics.Clear(Color.Black);
                graphics.DrawEllipse(drawPen, 95, 130, 200, 200);
                graphics.DrawEllipse(drawPen, 190, 225, 10, 10);
                graphics.DrawRectangle(drawPen, 185, 130, 20, 10);
                graphics.DrawLine(drawPen, 195, 140, 195, 225);
                graphics.FillRectangle(drawBrush, this.Width - movement, 30, 20, 10);
                graphics.FillEllipse(drawBrush, 193, bomb, 4, 4);

                movement++;
            } 

            //Sound of bomb exploding
            player.Play();  
             
            //Animation of explosion
            for (int explosion = 1; explosion <= 254; explosion++)
            {
                Thread.Sleep(1);
                graphics.Clear(Color.Black);
                drawPen.Color = Color.FromArgb(255 - explosion, 255 - explosion, 255 - explosion);
                graphics.DrawEllipse(drawPen, 95, 130, 200, 200);
                graphics.DrawEllipse(drawPen, 190, 225, 10, 10);
                graphics.DrawRectangle(drawPen, 185, 130, 20, 10);
                graphics.DrawLine(drawPen, 195, 140, 195, 225);
                graphics.FillEllipse(drawBrush, 193, bomb, 4, 4);
                drawBrush.Color = Color.FromArgb(254 -explosion, 0, 0);
                graphics.FillEllipse(drawBrush, 193 - explosion / 2, 230 - explosion / 2, 1 + explosion, 1 + explosion);
            }

            //Tell user the mission has been a success
            drawBrush.Color = Color.White;
            graphics.DrawString("MISSION SUCCESS", titleFont, drawBrush, 95, 100);
        }
    }
}
