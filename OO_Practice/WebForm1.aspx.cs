using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Microsoft.VisualBasic;

namespace OO_Practice
{

    public partial class WebForm1 : System.Web.UI.Page
    {

        // Attributes
        // Static objects declared, will live the cycle of the application
        private static character cloud;
        private static character barret;
        private static character aeris;
        private static character tifa;
        private static team team1;
        private static player p1;

        private static character tseng;
        private static character reno;
        private static character rude;
        private static character don;
        private static team team2;
        private static player p2;


        private static int activePlayer1 = 4; // 4 = dead
        private static int activePlayer2 = 4;
        private static int turn = 0;

        private static int t1Count = 0; // dead count

        private static int t2Count = 0;




        //constructor
        public WebForm1()
        {

        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void addToConsole(string text)
        {
            string conCat = console.Text;
            console.Text = conCat.Insert(0, text + "\n");

        }

        protected void endGame()
        {
            Image1.Visible = false;
            Image2.Visible = false;
            Image3.Visible = false;
            Image4.Visible = false;
            Image5.Visible = false;
            Image6.Visible = false;
            Image7.Visible = false;
            Image8.Visible = false;

            

            imageP1.ImageUrl = "";
            imageP2.ImageUrl = "";

            stats1.Text = "";
            stats2.Text = "";

            p1Name.Text = "";
            p2Name.Text = "";

            lblT1.Text = "";
            lblT2.Text = "";


            

            attackp1.Enabled = false;
            changeChar1.Enabled = false;
            p1Choose.Enabled = false;

            attackP2.Enabled = false;
            changeChar2.Enabled = false;
            p2Choose.Enabled = false;

            start.Visible = true;
        }

        protected void start_Click(object sender, EventArgs e)
        {
            // creates character, team and player objects

            cloud = new character("Cloud", 50, 20, 10);
            barret = new character("Barret", 50, 20, 10);
            aeris = new character("Aeris", 50, 20, 10);
            tifa = new character("Tifa", 50, 20 ,10);


            team1 = new team("Avalanche", cloud, barret,aeris, tifa);
            p1 = new player("Niall", team1);

            tseng = new character("Tseng", 50, 20, 10);
            reno = new character("Reno", 50, 20 ,10);
            rude = new character("Rude", 50, 20 ,10);
            don = new character("Don Corneo", 50, 20, 10);

            team2 = new team("The Turks", tseng, reno,rude,don);
            p2 = new player("Girts", team2);


            t1Count = 0;
            t2Count = 0;

            // initialises Images and team names

            lblT1.Text = p1.Team.getTeamName();
            Image1.ImageUrl = "images/emptyChar.jpg";
            Image2.ImageUrl = "images/Barret.jpg";
            Image3.ImageUrl = "images/Aeris.jpg";
            Image4.ImageUrl = "images/Tifa.jpg";

            lblT2.Text = p2.Team.getTeamName();
            Image5.ImageUrl = "images/emptyChar.jpg";
            Image6.ImageUrl = "images/Reno.jpg";
            Image7.ImageUrl = "images/Rude.jpg";
            Image8.ImageUrl = "images/Don.jpg";

            // makes Character images visible
            Image1.Visible = true;
            Image2.Visible = true;
            Image3.Visible = true;
            Image4.Visible = true;
            Image5.Visible = true;
            Image6.Visible = true;
            Image7.Visible = true;
            Image8.Visible = true;
          
            start.Visible = false;
            p1Name.Visible = true;
            p2Name.Visible = true;


            imageP1.ImageUrl = "images/Cloud.jpg";
            imageP2.ImageUrl = "images/Tseng.jpg";

            activePlayer1 = 0;
            activePlayer2 = 0;


            turn = 1;

            attackp1.Enabled = true;
            p1Choose.Enabled = true;
            changeChar1.Enabled = true;

            addToConsole("Player One, your turn!");


            updateP1Stats();
            updateP2Stats();

        }

     


        protected void checkAlive()
        {

            
            if (p1.Team.getChar(activePlayer1).getStats().getHealth() <= 0)
            {
                addToConsole("Player one, " + p1.Team.getChar(activePlayer1).getName() + " has fallen in combat! Choose another fighter!");

                if(activePlayer1 == 0)
                {
                    Image1.ImageUrl = "images/Cloud.jpg";
                    imageP1.ImageUrl = "images/emptyChar.jpg";
                    activePlayer1 = 4;
                    t1Count++;

                }
                else if (activePlayer1 == 1)
                {
                    Image2.ImageUrl = "images/Barret.jpg";
                    imageP1.ImageUrl = "images/emptyChar.jpg";
                    activePlayer1 = 4;
                    t1Count++;

                }
                else if (activePlayer1 == 2)
                {
                    Image3.ImageUrl = "images/Aeris.jpg";
                    imageP1.ImageUrl = "images/emptyChar.jpg"; 
                    activePlayer1 = 4;
                    t1Count++;

                } else if (activePlayer1 == 3)
                {
                    Image4.ImageUrl = "images/Tifa.jpg";
                    imageP1.ImageUrl = "images/emptyChar.jpg";
                    activePlayer1 = 4;
                    t1Count++;
                }

                if (t1Count == 4)
                {
                    console.Text = "";
                    addToConsole("Game Over! - Player two wins!");
                    endGame();

                } else
                {


                Image1.Enabled = true;
                Image2.Enabled = true;
                Image3.Enabled = true;
                Image4.Enabled = true;
                }

            } 
            
            if (p2.Team.getChar(activePlayer2).getStats().getHealth() <= 0)
            {
                addToConsole("Player Two, " + p2.Team.getChar(activePlayer2).getName() + " has fallen in combat! Choose another fighter");
                if (activePlayer2 == 0)
                {
                    Image5.ImageUrl = "images/Tseng.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg";
                    activePlayer2 = 4;
                    t2Count++;

                }
                else if (activePlayer2 == 1)
                {
                    Image6.ImageUrl = "images/Reno.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg";
                    activePlayer2 = 4;
                    t2Count++;


                }
                else if (activePlayer2 == 2)
                {
                    Image7.ImageUrl = "images/Rude.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg";
                    activePlayer2 = 4;
                    t2Count++;


                }
                else if (activePlayer2 == 3)
                {
                    Image8.ImageUrl = "images/Don.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg";
                    activePlayer2 = 4;
                    t2Count++;

                }

                

                if (t2Count == 4)
                {
                    console.Text = "";
                    addToConsole("Game Over! - Player one wins!");
                    endGame();
                }
                else
                {
                    Image5.Enabled = true;
                    Image6.Enabled = true;
                    Image7.Enabled = true;
                    Image8.Enabled = true;
                }

            }
        }

       
        protected void updateP1Stats()
        {

           
            if (activePlayer1 == 4)
            {
                stats1.Text = "";
                p1Name.Text = "";
            } 
            else if (activePlayer1 != 4)
            {


            p1Name.Text = p1.Team.getChar(activePlayer1).getName();

            if (p1.Team.getChar(activePlayer1).getStats().getHealth() <= 0)
            {
                stats1.Text = "";
                p1Name.Text = "";
            } else
            {
            stats1.Text = "HEALTH:  " + p1.Team.getChar(activePlayer1).getStats().getHealth().ToString() + "\n" +
            "DEFENCE:  " + p1.Team.getChar(activePlayer1).getStats().getDefence().ToString() + "\n" +
            "ATTACK:  " + p1.Team.getChar(activePlayer1).getStats().getAttack().ToString();

            }
            }
        }

        protected void updateP2Stats()
        {

            if (activePlayer2 == 4)
            {
                stats2.Text = "";
                p2Name.Text = "";
            }
            else if (activePlayer2 != 4)
            {
                p2Name.Text = p2.Team.getChar(activePlayer2).getName();


                if (p2.Team.getChar(activePlayer2).getStats().getHealth() <= 0)
                {
                    stats2.Text = "";
                    p2Name.Text = "";
                }
                else
                {
                    stats2.Text = "HEALTH:  " + p2.Team.getChar(activePlayer2).getStats().getHealth().ToString() + "\n" +
                "DEFENCE:  " + p2.Team.getChar(activePlayer2).getStats().getDefence().ToString() + "\n" +
                "ATTACK:  " + p2.Team.getChar(activePlayer2).getStats().getAttack().ToString();
                }
            }
        }

   
        protected void attackp1_Click(object sender, EventArgs e)
        {

            if (activePlayer1 == 4)
            {
                addToConsole("Choose a character!");
                
            }
            else if (turn == 1 && activePlayer1 != 4)
            {


            int amount = p1.Team.getChar(activePlayer1).getStats().getAttack() -  (p2.Team.getChar(activePlayer2).getStats().getDefence() / 10);

            p2.Team.getChar(activePlayer2).getStats().takeDamage(amount);


             addToConsole("You did " + amount + " damage");

            checkAlive();
            updateP2Stats();

            attackp1.Enabled = false;
            changeChar1.Enabled = false;
            p1Choose.Enabled = false; 

            attackP2.Enabled = true;
            changeChar2.Enabled = true;
            p2Choose.Enabled = true;

            turn = 2;
            }

            if (turn == 2)
            {
                imageP2.BorderColor = System.Drawing.SystemColors.Highlight;
            }

        }

        protected void p1Choose_Click(object sender, EventArgs e)
        {


            if (activePlayer1 == 4)
            {
                addToConsole("Choose a character!"); ;

            }
            else if (turn == 1 && activePlayer1 != 4)
            {
                int num =  RandomNumber(1,5);
                int x = RandomNumber(7, 20); // health 
                int y = RandomNumber(7, 20);
                int z = RandomNumber(7, 12);



                switch (num)
                {
                    case 1: // card #1
                        if (activePlayer1 == 0)
                        {
                            p1.Team.getChar(activePlayer1).getStats().applyCards(0,0 ,20);
                            addToConsole("Buster sword equipped!");

                        }
                        else
                        {

                            p1.Team.getChar(activePlayer1).getStats().applyCards(x, 0, 0);
                            addToConsole("Health drink! " + x + " health restored");
                        }

                        break;

                    case 2:
                        p1.Team.getChar(activePlayer1).getStats().applyCards(x, y, z);
                        addToConsole("Mystery Potion! - Random stat boost");
                        break;

                    case 3:
                        p1.Team.getChar(activePlayer1).getStats().applyCards(0, y,0);
                        addToConsole("Armour boost! - You gain " + y + " Armour");
                        break;

                    case 4:
                        p1.Team.getChar(activePlayer1).getStats().applyCards(-x, 0, 0);
                        addToConsole("Health Drain! you lose " + x + " health");
                        break;

                    case 5:
                        p1.Team.getChar(activePlayer1).getStats().applyCards(0, -10, 0);
                        addToConsole("Armour drain! you lose 10 defence");
                        break;

                    default:
                        break;

                }




                updateP1Stats();
                checkAlive();
                p1Choose.Enabled = false;
            }
            
        }
        protected void changeChar1_Click(object sender, EventArgs e)
        {

            if (turn == 1 && activePlayer1 != 4)
                {
                   addToConsole("Choose a character!");

                    if (activePlayer1 == 0)
                    {
                        Image1.ImageUrl = "images/Cloud.jpg";
                        imageP1.ImageUrl = "images/emptyChar.jpg"; ;


                    }
                    else if (activePlayer1 == 1)
                    {
                        Image2.ImageUrl = "images/Barret.jpg";
                        imageP1.ImageUrl = "images/emptyChar.jpg"; ;

                    }
                    else if (activePlayer1 == 2)
                    {
                        Image3.ImageUrl = "images/Aeris.jpg";
                        imageP1.ImageUrl = "images/emptyChar.jpg"; ;


                    }
                    else if (activePlayer1 == 3)
                    {
                        Image4.ImageUrl = "images/Tifa.jpg";
                        imageP1.ImageUrl = "images/emptyChar.jpg"; ;
                    }

                    Image1.Enabled = true;
                    Image2.Enabled = true;
                    Image3.Enabled = true;
                    Image4.Enabled = true;

                    activePlayer1 = 4;
                    changeChar1.Enabled = false;
                
            }

        }

        protected void attackP2_Click(object sender, EventArgs e)
        {
            if (activePlayer2 == 4)
            {
                addToConsole("Choose a character!");

            }
            else if (turn == 2 && activePlayer2 != 4)
            {

                int amount = p2.Team.getChar(activePlayer2).getStats().getAttack() - (p1.Team.getChar(activePlayer1).getStats().getDefence() / 10);

                p1.Team.getChar(activePlayer1).getStats().takeDamage(amount);

                addToConsole("You did " + amount + " damage");
                checkAlive();
                updateP1Stats();


                if (t1Count != 4)
                {

                // disables p2 buttons
                attackP2.Enabled = false;
                p2Choose.Enabled = false;
                changeChar2.Enabled = false;

                // enables p1 buttons
                attackp1.Enabled = true;
                p1Choose.Enabled = true;
                changeChar1.Enabled = true;

                turn = 1;
                }
            }
        }
        protected void p2Choose_Click(object sender, EventArgs e)
        {

            int num = RandomNumber(1, 5);
            int x = RandomNumber(7, 20); // health 
            int y = RandomNumber(7, 20);
            int z = RandomNumber(7, 12);

            if (activePlayer2 == 4)
            {
                addToConsole("Choose a character!");
            }
            else if (turn == 2 && activePlayer2 != 4)
            {
                switch (num)
                {
                    case 1: // card #1
                        if (activePlayer2 == 0)
                        {
                            p2.Team.getChar(activePlayer2).getStats().applyCards(0, 0, 20);
                            addToConsole("Hero Drink! you gain 20 attack");

                        }
                        else
                        {

                            p2.Team.getChar(activePlayer2).getStats().applyCards(x, 0, 0);
                            addToConsole("Health drink! " + x + " health restored");
                        }

                        break;

                    case 2:
                        p2.Team.getChar(activePlayer2).getStats().applyCards(x, y, z);
                        addToConsole("Mystery Potion! - Random stat boost");
                        break;

                    case 3:
                        p2.Team.getChar(activePlayer2).getStats().applyCards(0, y, 0);
                        addToConsole("Armour boost! - You gain " + y + " Armour");
                        break;

                    case 4:
                        p2.Team.getChar(activePlayer2).getStats().applyCards(-x, 0, 0);
                        addToConsole("Health Drain! you lose " + x + " health");
                        break;

                    case 5:
                        p2.Team.getChar(activePlayer2).getStats().applyCards(0, -10, 0);
                        addToConsole("Armour drain! you lose 10 defence"); ;
                        break;

                    default:
                        break;

                }

                checkAlive();
                updateP2Stats();

                p2Choose.Enabled = false;
            }
        }
        protected void changeChar2_Click(object sender, EventArgs e)
        {

           if (turn == 2 && activePlayer2 != 4)
            {
                addToConsole("Choose a character!");

                if (activePlayer2 == 0)
                {
                    Image5.ImageUrl = "images/Tseng.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg"; ;

                }
                else if (activePlayer2 == 1)
                {
                    Image6.ImageUrl = "images/Reno.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg"; ;

                }
                else if (activePlayer2 == 2)
                {
                    Image7.ImageUrl = "images/Rude.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg"; ;

                }
                else if (activePlayer2 == 3)
                {
                    Image8.ImageUrl = "images/Don.jpg";
                    imageP2.ImageUrl = "images/emptyChar.jpg"; ;
                }

                Image5.Enabled = true;
                Image6.Enabled = true;
                Image7.Enabled = true;
                Image8.Enabled = true;


                activePlayer2 = 4;
                changeChar2.Enabled = false;
            }
        }

         
        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            if (turn == 2)
            {
                addToConsole("Its player twos turn!");

            } else if (turn == 1)
            { 
                        
                        if(p1.Team.getChar(0).getStats().getHealth() <=0)
                        {
                            addToConsole("Cloud is dead!, choose another character!");

                        } else if (p1.Team.getChar(0).getStats().getHealth() > 0)
                        {

                        activePlayer1 = 0;
                    addToConsole("You have chosen Cloud!");

                        // changes image 
                        Image1.ImageUrl = "images/emptyChar.jpg";
                        imageP1.ImageUrl = "images/Cloud.jpg";

                        // displays stats
                        updateP1Stats();

                    Image1.Enabled = false;
                    Image2.Enabled = false;
                    Image3.Enabled = false;
                    Image4.Enabled = false;

             
            }

            }
        }
        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {

            if(turn == 2)
            {
                addToConsole("Its player twos turn!");

            } else if (turn == 1)
            {
                if (p1.Team.getChar(1).getStats().getHealth() <= 0)
                {
                    addToConsole("Barret is dead!, choose another character!");

                }
                else if (p1.Team.getChar(1).getStats().getHealth() > 0)
                {
                    activePlayer1 = 1;
                    addToConsole("You have chosen Barret!");

                    // changes image 
                    Image2.ImageUrl = "images/emptyChar.jpg";
                    imageP1.ImageUrl = "images/Barret.jpg";

                    // displays stats
                    updateP1Stats();

                    // disables player 1 char select
                    Image1.Enabled = false;
                    Image2.Enabled = false;
                    Image3.Enabled = false;
                    Image4.Enabled = false;

                 
                }
            }
        }

        protected void Image3_Click(object sender, ImageClickEventArgs e)
        {

            if (turn == 2)
            {
                addToConsole("Its player twos turn!");

            }
            else if (turn == 1)
            {
                if (p1.Team.getChar(2).getStats().getHealth() <= 0)
                {
                    addToConsole("Aeris is dead!, choose another character!");

                }
                else if (p1.Team.getChar(2).getStats().getHealth() > 0)
                {
                    activePlayer1 = 2;
                    addToConsole("You have chosen Aeris!");

                    // changes image 
                    Image3.ImageUrl = "images/emptyChar.jpg";
                    imageP1.ImageUrl = "images/Aeris.jpg";

                    // displays stats
                    updateP1Stats();

                    // disables player 1 char select
                    Image1.Enabled = false;
                    Image2.Enabled = false;
                    Image3.Enabled = false;
                    Image4.Enabled = false;
                                      

                }
            }
        }
        protected void Image4_Click(object sender, ImageClickEventArgs e)
        {

            if (turn == 2)
            {
                addToConsole("Its player twos turn!");

            }
            else if (turn == 1)
            {
                if (p1.Team.getChar(3).getStats().getHealth() <= 0)
                {
                    addToConsole("Tifa is dead!, choose another character!");

                }
                else if (p1.Team.getChar(3).getStats().getHealth() > 0)
                {
                    activePlayer1 = 3;
                    addToConsole("You have chosen Tifa!");

                    // changes image 
                    Image4.ImageUrl = "images/emptyChar.jpg";
                    imageP1.ImageUrl = "images/Tifa.jpg";

                    // displays stats
                    updateP1Stats();

                    // disables player 1 char select
                    Image1.Enabled = false;
                    Image2.Enabled = false;
                    Image3.Enabled = false;
                    Image4.Enabled = false;
                               

                }
            }
        }
        protected void Image5_Click(object sender, ImageClickEventArgs e)
        {

            if (turn == 1)
            {
                addToConsole("Its player ones turn!");

            } else if (turn == 2)
            {
                if(p2.Team.getChar(0).getStats().getHealth() <=0)
                {
                    addToConsole("Tseng is dead! Choose another character");

                } else if (p2.Team.getChar(0).getStats().getHealth() > 0)
                {
                    activePlayer2 = 0;

                    addToConsole("You have chosen Tseng!");
                    // changes images
                    Image5.ImageUrl = "images/emptyChar.jpg";
                    imageP2.ImageUrl = "images/Tseng.jpg";

                    // displays stats
                    updateP2Stats();

                    // disables all character select
          
                    Image5.Enabled = false;
                    Image6.Enabled = false;
                    Image7.Enabled = false;
                    Image8.Enabled = false;

                }
            }

           
        }

        protected void Image6_Click(object sender, ImageClickEventArgs e)
        {

            if (turn == 1)
            {
                addToConsole("Its player ones turn!");
            }
            else if (turn == 2)
            {
                if (p2.Team.getChar(1).getStats().getHealth() <= 0)
                {
                    addToConsole("Reno is dead! Choose another character");

                }
                else if (p2.Team.getChar(1).getStats().getHealth() > 0)
                {
                    activePlayer2 = 1;

                    addToConsole("You have chosen Reno!");
                    // changes images
                    Image6.ImageUrl = "images/emptyChar.jpg";
                    imageP2.ImageUrl = "images/Reno.jpg";

                    // displays stats
                    updateP2Stats();

                    // disables all character select

                    Image5.Enabled = false;
                    Image6.Enabled = false;
                    Image7.Enabled = false;
                    Image8.Enabled = false;
                }
            }
        }

        protected void Image7_Click(object sender, ImageClickEventArgs e)
        {

            if (turn == 1)
            {
                addToConsole("Its player ones turn!");

            }
            else if (turn == 2)
            {
                if (p2.Team.getChar(2).getStats().getHealth() <= 0)
                {
                    addToConsole("Rude is dead! Choose another character");

                }
                else if (p2.Team.getChar(2).getStats().getHealth() > 0)
                {
                    activePlayer2 = 2;

                    addToConsole("You have chosen Rude!");
                    // changes images
                    Image7.ImageUrl = "images/emptyChar.jpg";
                    imageP2.ImageUrl = "images/Rude.jpg";

                    // displays stats
                    updateP2Stats();

                    // disables all character select

                    Image5.Enabled = false;
                    Image6.Enabled = false;
                    Image7.Enabled = false;
                    Image8.Enabled = false;
                }
            }
        }

        protected void Image8_Click(object sender, ImageClickEventArgs e)
        {

            if (turn == 1)
            {
                addToConsole("Its player ones turn!");

            }
            else if (turn == 2)
            {
                if (p2.Team.getChar(3).getStats().getHealth() <= 0)
                {
                    addToConsole("Don Corneo is dead! Choose another character");

                }
                else if (p2.Team.getChar(3).getStats().getHealth() > 0)
                {
                    activePlayer2 = 3;

                    addToConsole("You have chosen Don Corneo!");
                    // changes images
                    Image8.ImageUrl = "images/emptyChar.jpg";
                    imageP2.ImageUrl = "images/Don.jpg";

                    // displays stats
                    updateP2Stats();

                    // disables all character select

                    Image5.Enabled = false;
                    Image6.Enabled = false;
                    Image7.Enabled = false;
                    Image8.Enabled = false;

                }
            }
        }

       
    }
}