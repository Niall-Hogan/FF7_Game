using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OO_Practice
{    

    public class team
    {

        // attirbutes
        public string name;
        public List<character> characters = new List<character>();

        //constructor
        public team(string n, character c1, character c2,character c3, character c4)
        {
            name = n;
            characters.Add(c1);
            characters.Add(c2);
            characters.Add(c3);
            characters.Add(c4);

        }

        //operations 

        public string getTeamName()
        {
            return name;
        }

        public character getChar(int index)
        {
            return characters[index]; 
                        
        }

       

      
    }
}