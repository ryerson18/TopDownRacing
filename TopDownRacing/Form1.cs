using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopDownRacing
{
    public partial class Form1 : Form
    {
        //player 1
        Rectangle Car1;
        //player 2
        Rectangle Car2;

        //colour
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        //track Pen
        Pen blackPen = new Pen(Color.Black);

        // player 1 
        bool arrowLeft = false;
        bool arrowRight = false;
        bool arrowUp = false;
        bool arrowDown = false;

        // player 2
        bool aLeft = false;
        bool dRigth = false;
        bool wUp = false;
        bool sDown = false;

        //player 1 value
        int carAngle1 = 0;
        int carSpeed1 = 10;
        int widthCar1 = 15;
        int heightCar1 = 30;

        //player 2 value
        int carAngle2 = 0;
        int carSpeed2 = 10;
        int widthCar2 = 15;
        int heightCar2 = 30;

        public Form1()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            //player 1 starting value
            int carAngle1 = 0;
            int carSpeed1 = 5;
            int widthCar1 = 15;
            int heightCar1 = 30;

            int xCar1 = this.Width / 2 - widthCar1 / 2;
            int yCar1 = this.Height - 100;

            Car1 = new Rectangle(xCar1,yCar1,widthCar1,heightCar1);

            //player 2 starting value
            int carAngle2 = 0;
            int carSpeed2 = 5;
            int widthCar2 = 15;
            int heightCar2 = 30;

            int xCar2 = this.Width / 2 - widthCar2 / 2;
            int yCar2 = this.Height - 100;

            Car2 = new Rectangle(xCar2, yCar2, widthCar2, heightCar2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    arrowUp = true;
                    break;
                case Keys.Down:
                    arrowDown = true;
                    break;
                case Keys.Left:
                    arrowLeft = true;
                    break;
                case Keys.Right:
                    arrowRight = true;
                    break;
                case Keys.W:
                    wUp = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aLeft = true;
                    break;
                case Keys.D:
                    dRigth = true;
                    break;


            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    arrowUp = false;
                    break;
                case Keys.Down:
                    arrowDown = false;
                    break;
                case Keys.Left:
                    arrowLeft = false;
                    break;
                case Keys.Right:
                    arrowRight = false;
                    break;
                case Keys.W:
                    wUp = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aLeft = false;
                    break;
                case Keys.D:
                    dRigth = false;
                    break;
            }
        }

        private void Game_Timer_Tick(object sender, EventArgs e)
        {
            //move player1
            // move up and dwon 
            if (arrowUp == true)
            {
              movecar1Forwand();
            }
            if (arrowDown == true)
            {
              movecar1Bakcwards();
            }
            //turn the car 
            if (arrowLeft == true)
            {

                carAngle1 -= 8;
            }
            if (arrowRight == true)
            {

                carAngle1 += 8;
            }

            //move player2
            // move up and dwon 
            if (wUp == true)
            {
                movecar2Forwand();
            }
            if (sDown == true)
            {
                movecar2Bakcwards();
            }
            //turn the car 
            if (aLeft == true)
            {

                carAngle2 -= 8;
            }
            if (dRigth == true)
            {

                carAngle2 += 8;
            }








            // refresh
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //player 1
            e.Graphics.TranslateTransform(widthCar1 / 2 + Car1.X, widthCar1 / 2 + Car1.Y);
            e.Graphics.RotateTransform(carAngle1);
            e.Graphics.FillRectangle(redBrush, 0 - widthCar1 / 2, 0-widthCar1 / 2, widthCar1,heightCar1);
            e.Graphics.FillRectangle(greenBrush, 0 - widthCar1 / 2, 0 - widthCar1 / 2, widthCar1, 5);
            e.Graphics.ResetTransform();

            //player 2
            e.Graphics.TranslateTransform(widthCar2 / 2 + Car2.X, widthCar2 / 2 + Car2.Y);
            e.Graphics.RotateTransform(carAngle2);
            e.Graphics.FillRectangle(blueBrush, 0 - widthCar2 / 2, 0 - widthCar2 / 2, widthCar2, heightCar2);
            e.Graphics.FillRectangle(yellowBrush, 0 - widthCar2 / 2, 0 - widthCar2 / 2, widthCar2, 5);
            e.Graphics.ResetTransform();

        }

        public void movecar1Forwand()
        {
            double angleInRadian = Math.PI * carAngle1 / 180;
            int deltaY = (int)(carSpeed1 * Math.Cos(angleInRadian));
            int deltaX = (int)(carSpeed1 * Math.Sin(angleInRadian));

            Car1.Y -= deltaY;
            Car1.X += deltaX;
        }

        public void movecar1Bakcwards()
        {
            double angleInRadian = Math.PI * carAngle1 / 180;
            int deltaY = (int)(carSpeed1 * Math.Cos(angleInRadian));
            int deltaX = (int)(carSpeed1 * Math.Sin(angleInRadian));

            Car1.Y += deltaY;
            Car1.X -= deltaX;
        }

        public void movecar2Forwand()
        {
            double angleInRadian = Math.PI * carAngle2 / 180;
            int deltaY = (int)(carSpeed2 * Math.Cos(angleInRadian));
            int deltaX = (int)(carSpeed2 * Math.Sin(angleInRadian));

            Car2.Y -= deltaY;
            Car2.X += deltaX;
        }

        public void movecar2Bakcwards()
        {
            double angleInRadian = Math.PI * carAngle2 / 180;
            int deltaY = (int)(carSpeed2 * Math.Cos(angleInRadian));
            int deltaX = (int)(carSpeed2 * Math.Sin(angleInRadian));

            Car2.Y += deltaY;
            Car2.X -= deltaX;
        }

    }
}
