using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OO_Practice
{
    public class stats
    {
        // attributes 
        private int health, defence, attack;

        // constructor
        public stats(int h, int d, int a)
        {
            health = h;
            defence = d;
            attack = a;
        }


        // operations

        public int getHealth()
        {
            return health;
        }

        public int getAttack()
        {
            return attack;
        }

        public int getDefence()
        {
            return defence;
        }

        public void takeDamage(int amount)
        {
           health -= amount;

            if(health <= 0)
            {
                health = 0;
            }

        }

        public void applyCards(int x,int y, int z)
        {

            health += x;
            defence += y;
            attack += z;
        }


    }
}