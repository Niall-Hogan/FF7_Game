using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace OO_Practice
{
    public class character
    {
        //attributes
        string name;

        public stats Stats;

        //constructor
        public character(string cName, int h, int d, int a)
        {
            this.name = cName;
            this.Stats = new stats(h,d,a);
        }

        // operations

        public stats getStats()
        {
            return Stats;
        }

        public string getName()
        {
            return name;
        }

       

      
        
    }
}