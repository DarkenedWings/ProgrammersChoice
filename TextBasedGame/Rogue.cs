using System;
using FSPG;

namespace TextBasedGame
{
    class Rogue
    {
       
        int hp;
        int mp;
        int att;
        int wiz;
        int crit;
        int luck;

        Random RNG = new Random();
        Items weap = new Items();

        public Rogue()
        {
            hp = RNG.Next(150, 350);
            mp = RNG.Next(75, 200);
            att = RNG.Next(25, 50);
            wiz = RNG.Next(10, 30);
            crit = RNG.Next(5, 15);
            luck = RNG.Next(5, 20);
        }
        public void show()
        {
            Console.WriteLine("hp: " + hp);
            Console.WriteLine("mp: " + mp);
            Console.WriteLine("att: " + (att + weap.GetRog()));
            Console.WriteLine("wiz: " + wiz);
            Console.WriteLine("crit: " + crit);
            Console.WriteLine("luck: " + luck);

        }
        public int GetHp()
        {
            return hp;
        }
        public int GetMp()
        {
            return mp;
        }
        public int GetAtt()
        {
            return att;
        }
        public int GetWiz()
        {
            return wiz;
        }
        public int GetCrit()
        {
            return crit;
        }
        public int GetLuck()
        {
            return luck;
        }

        public void SetHp(int x)
        {
            hp += x;
        }
        public void SetMp(int x)
        {
            mp += x;
        }
    }    
}
