using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OO_Practice
{
    public class player
    {
        //attributes 

        public string playerName;
        
        public  team Team;

        //constructor
        public player(string pName,team t1)
        {
            playerName = pName;
            Team = t1;

           
        }

        //operations

        public string getName()
        {
            return playerName;
        }

        public team getTeam()
        {
            return Team;
        }
           
    }
}