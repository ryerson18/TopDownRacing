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

        string state = "waiting";


        //player 1
        Rectangle Car1;
        //player 2
        Rectangle Car2;

        //colour
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        //track Pen
        Pen WhitePen = new Pen(Color.WhiteSmoke,5);

        // list of track limits
        List<Rectangle> tracklimitsList = new List<Rectangle>();

        // check ponits 
        Rectangle check1 = new Rectangle(490, 88, 5, 190);
        Rectangle check2 = new Rectangle(760, 390, 210, 5);
        Rectangle check3 = new Rectangle(500, 525, 5, 175);
        Rectangle check4 = new Rectangle(7, 390, 210, 5);
        Rectangle redCheck = new Rectangle(540, 88, 5, 190);

        bool car1Check1 = false;
        bool car1Check2 = false;
        bool car1Check3 = false;
        bool car1Check4 = false;
        bool car1redCheck = false;

        bool car2Check1 = false;
        bool car2Check2 = false;
        bool car2Check3 = false;
        bool car2Check4 = false;
        bool car2redCheck = false;

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
        int carlap1 = 0;

        //player 2 value
        int carAngle2 = 90;
        int carSpeed2 = 10;
        int widthCar2 = 15;
        int heightCar2 = 30;
        int carlap2 = 0;

      
        public Form1()
        {
            InitializeComponent();
        }

        public void OnStart()
        {
            // track 1 
            tracklimitsList.Add(new Rectangle(0, 45, 1000, 40));
            tracklimitsList.Add(new Rectangle(0, 705, 1000, 40));
            tracklimitsList.Add(new Rectangle(0, 50, 5, 700));
            tracklimitsList.Add(new Rectangle(5, 86, 50, 140)); 
            tracklimitsList.Add(new Rectangle(56, 86, 50, 80));
            tracklimitsList.Add(new Rectangle(54, 170, 20, 30));
            tracklimitsList.Add(new Rectangle(70, 162, 20, 20));
            tracklimitsList.Add(new Rectangle(105, 80, 50, 50));
            tracklimitsList.Add(new Rectangle(105, 130, 20, 20));
            tracklimitsList.Add(new Rectangle(0, 705, 1000, 40));
            tracklimitsList.Add(new Rectangle(0, 50, 5, 700));
            tracklimitsList.Add(new Rectangle(5, 86, 50, 140));
            tracklimitsList.Add(new Rectangle(56, 86, 50, 80));
            tracklimitsList.Add(new Rectangle(54, 170, 20, 30));
            tracklimitsList.Add(new Rectangle(70, 162, 20, 20));
            tracklimitsList.Add(new Rectangle(105, 80, 50, 50));
            tracklimitsList.Add(new Rectangle(145, 74, 40, 40));
            tracklimitsList.Add(new Rectangle(180, 65, 60, 30));
            tracklimitsList.Add(new Rectangle(0, 50, 5, 700));
            tracklimitsList.Add(new Rectangle(5, 86, 50, 140));
            tracklimitsList.Add(new Rectangle(56, 86, 50, 80));
            tracklimitsList.Add(new Rectangle(54, 170, 20, 30));
            tracklimitsList.Add(new Rectangle(70, 162, 20, 20));
            tracklimitsList.Add(new Rectangle(105, 80, 50, 50));
            tracklimitsList.Add(new Rectangle(1, 200, 35, 60));
            tracklimitsList.Add(new Rectangle(1, 230, 20, 60));
            tracklimitsList.Add(new Rectangle(5, 565, 50, 150));
            tracklimitsList.Add(new Rectangle(56, 86, 50, 80));
            tracklimitsList.Add(new Rectangle(30, 600, 50, 150));
            tracklimitsList.Add(new Rectangle(80, 620, 20, 100));
            tracklimitsList.Add(new Rectangle(100, 640, 20, 100));
            tracklimitsList.Add(new Rectangle(120, 650, 20, 100));
            tracklimitsList.Add(new Rectangle(140, 665, 20, 100));
            tracklimitsList.Add(new Rectangle(160, 682, 40, 100));
            tracklimitsList.Add(new Rectangle(180, 694, 60, 30));
            tracklimitsList.Add(new Rectangle(1, 530, 35, 60));
            tracklimitsList.Add(new Rectangle(1, 500, 20, 60));
            tracklimitsList.Add(new Rectangle(960, 80, 50, 20));
            tracklimitsList.Add(new Rectangle(940, 80, 50, 157));
            tracklimitsList.Add(new Rectangle(920, 80, 20, 127));
            tracklimitsList.Add(new Rectangle(900, 80, 20, 106));
            tracklimitsList.Add(new Rectangle(880, 80, 50, 87));
            tracklimitsList.Add(new Rectangle(860, 80, 20, 66));
            tracklimitsList.Add(new Rectangle(830, 80, 60, 50));
            tracklimitsList.Add(new Rectangle(780, 80, 50, 25));
            tracklimitsList.Add(new Rectangle(740, 80, 40, 15));
            tracklimitsList.Add(new Rectangle(980, 80, 20, 1000));
            tracklimitsList.Add(new Rectangle(328, 279, 320, 243));

           

            //player 1 starting value
            carAngle1 = 90;
            carSpeed1 = 5;
            widthCar1 = 15;
            heightCar1 = 30;
            carlap1 = 0;

            int xCar1 = 400;
            int yCar1 = 120;

            Car1 = new Rectangle(xCar1,yCar1, widthCar1,heightCar1);

            //player 2 starting value
            carAngle2 = 90;
            carSpeed2 = 5;
            widthCar2 = 15;
            heightCar2 = 30;
            carlap2 = 0;

            int xCar2 = 400;
            int yCar2 = 210;

            Car2 = new Rectangle(xCar2, yCar2, widthCar2, heightCar2);

            //display score text
            car1Lap.Visible = true;
            car2Lap.Visible = true;

            Winlabel.Text = "";
            car1Lap.Text = "";
            car2Lap.Text = "";

            state = "playing";
            Game_Timer.Enabled = true;
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
                case Keys.Space:
                    if (state == "waiting" || state == "over")
                    {
                        OnStart();
                    }
                    break;
                case Keys.Escape:
                    if (state == "waiting" || state == "over")
                    {
                        Application.Exit();
                    }
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

            // check to see if players go off the track 
            bool offTrack1 = false;
            bool offTrack2 = false;
            for (int i = 0; i < tracklimitsList.Count; i++)
            {

                if (tracklimitsList[i].IntersectsWith(Car1))
                {
                    carSpeed1 = 3;
                    offTrack1 = true;
                    break;
                }
            }
            if (offTrack1 == false)
            {
                carSpeed1= 8;
            }

            for (int i = 0; i < tracklimitsList.Count; i++)
            {

               if (tracklimitsList[i].IntersectsWith(Car2))
                {
                   carSpeed2 = 3;
                   offTrack2 = true;
                   break;
                }
            }
            if (offTrack2 == false)
            {
               carSpeed2 = 8;
            }

            // check to see if players go around the whole track
            // car 1
            if (check1.IntersectsWith(Car1))
            {
                car1Check1 = true;
            }
            if (check2.IntersectsWith(Car1))
            {
                car1Check2 = true;
            }
            if (check3.IntersectsWith(Car1))
            {
                car1Check3 = true;
            }
            if (check4.IntersectsWith(Car1))
            {
                car1Check4 = true;
            }
            if(redCheck.IntersectsWith(Car1))
            {
                car1redCheck = true;
                car1Check1 = false;
                car1Check2 = false;
                car1Check3 = false;
                car1Check4 = false;
            }


            if (car1Check1 == true && car1Check2 == true && car1Check3 == true && car1Check4 == true)
            {
                carlap1++;
                car1Lap.Text = $"{carlap1}";

                car1Check1 = false;
                car1Check2 = false;
                car1Check3 = false;
                car1Check4 = false;
                car1redCheck = false;      
            }
            //car 2
            if (check1.IntersectsWith(Car2))
            {
                car2Check1 = true;
            }
            if (check2.IntersectsWith(Car2))
            {
                car2Check2 = true;
            }
            if (check3.IntersectsWith(Car2))
            {
                car2Check3 = true;
            }
            if (check4.IntersectsWith(Car2))
            {
                car2Check4 = true;
            }
            if (redCheck.IntersectsWith(Car2))
            {
                car2redCheck = true;
                car2Check1 = false;
                car2Check2 = false;
                car2Check3 = false;
                car2Check4 = false;
            }
            if (car2Check1 == true && car2Check2 == true && car2Check3 == true && car2Check4 == true)
            {
                carlap2++;
                car2Lap.Text = $"{carlap2}";

                car2Check1 = false;
                car2Check2 = false;
                car2Check3 = false;
                car2Check4 = false;
                car2redCheck = false;
            }



            //check to see if players have doen all the laps
            if (carlap1 == 1)
            {
                Game_Timer.Stop();
                Winlabel.Visible = true;
                titleLabel.Visible = false;
                car1Lap.Visible = false;
                car2Lap.Visible = false;
                state = "over";

                

            }
            
            if(carlap2 == 1)
            {
                Game_Timer.Stop();
                Winlabel.Visible = true;
                car1Lap.Visible = false;
                car2Lap.Visible = false;
                state = "over";

                Winlabel.Text = "Player two is the race winner";
            }





            // refresh
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (state == "waiting")
            {
                titleLabel.Text = "TopDownRacing";
                SubtitleLabel.Text = "Press Space to Play and Esc to Exit";
            }

            if (state == "playing")
            {
                titleLabel.Text = "";
                SubtitleLabel.Text = "";

                //start line
                //side one
                e.Graphics.FillRectangle(blackBrush, 490, 92, 20, 20); 
                e.Graphics.FillRectangle(whiteBrush, 490, 112, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 490, 132, 20, 20);
                e.Graphics.FillRectangle(whiteBrush, 490, 152, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 490, 172, 20, 20);
                e.Graphics.FillRectangle(whiteBrush, 490, 192, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 490, 212, 20, 20);
                e.Graphics.FillRectangle(whiteBrush, 490, 232, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 490, 212, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 490, 252, 20, 20);

                //side two
                e.Graphics.FillRectangle(whiteBrush, 510, 92, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 510, 112, 20, 20);
                e.Graphics.FillRectangle(whiteBrush, 510, 132, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 510, 152, 20, 20);
                e.Graphics.FillRectangle(whiteBrush, 510, 172, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 510, 192, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 510, 192, 20, 20);
                e.Graphics.FillRectangle(whiteBrush, 510, 212, 20, 20);
                e.Graphics.FillRectangle(blackBrush, 510, 232, 20, 20);
                e.Graphics.FillRectangle(whiteBrush, 510, 252, 20, 20);

                //player 1
                e.Graphics.TranslateTransform(widthCar1 / 2 + Car1.X, widthCar1 / 2 + Car1.Y);
                e.Graphics.RotateTransform(carAngle1);
                e.Graphics.FillRectangle(redBrush, 0 - widthCar1 / 2, 0 - widthCar1 / 2, widthCar1, heightCar1);
                e.Graphics.FillRectangle(greenBrush, 0 - widthCar1 / 2, 0 - widthCar1 / 2, widthCar1,5);
                e.Graphics.ResetTransform();

                //player 2
                e.Graphics.TranslateTransform(widthCar2 / 2 + Car2.X, widthCar2 / 2 + Car2.Y);
                e.Graphics.RotateTransform(carAngle2);
                e.Graphics.FillRectangle(blueBrush, 0 - widthCar2 / 2, 0 - widthCar2 / 2, widthCar2, heightCar2);
                e.Graphics.FillRectangle(yellowBrush, 0 - widthCar2 / 2, 0 - widthCar2 / 2, widthCar2, 5);
                e.Graphics.ResetTransform();

                //tracl
                //inside
                e.Graphics.DrawLine(WhitePen, 350, 525, 650, 525);
                e.Graphics.DrawLine(WhitePen, 350, 275, 650, 275);
                e.Graphics.DrawArc(WhitePen, 225, 275, 250, 250, 90, 180);
                e.Graphics.DrawArc(WhitePen, 510, 275, 250, 250, -90, 180);

                // outside
                e.Graphics.DrawLine(WhitePen, 288, 700, 700, 700);
                e.Graphics.DrawLine(WhitePen, 285, 88, 700, 88);
                e.Graphics.DrawArc(WhitePen, 5, 88, 612, 612, 90, 180);
                e.Graphics.DrawArc(WhitePen, 365, 88, 612, 612, -90, 180);               
            }

            if(state == "over")
            {
                if(carlap1 ==1)
                {
                 Winlabel.Text = "Player one is the race winner";
                 Winlabel.Text += "\n\nPress Space to Play or Esc to Exit";
                }

                if(carlap2 == 1)
                {
                 Winlabel.Text = "Player two is the race winner";
                 Winlabel.Text += "\n\nPress Space to Play or Esc to Exit";

                }

                
            }


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
