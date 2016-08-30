using System;


namespace TextBasedGame
{
    class Combat
    {
        Items i = new Items();
        Random RNG = new Random();        
        Skeleton mob = new Skeleton();
        Minotaur mino = new Minotaur();

        //player stats
        int hp = 0;
        int hpmax = 0;
        int mp = 0;
        int mpcurrent = 0;
        int att = 0;
        int wiz = 0;
        int crit = 0;
        int luck = 0;
        int wallet = 0;
        bool isAlive = true;

        //mob stats
        int mHp = 0;
        int mAtt = 0;
        int mCrit = 0;
        int mGold = 0;
        int choice = 0;
        int klass = 0;

        //stats that will be used for mob and player
        int dmg = 0;
        int lCheck = 0;
        bool cCheck = false;

        string weap = "";
        string spell = "";
        string res;
        string ans;

        //First lines of game and choosing their class. Followed by beginning room
        public void ChooseKlass()
        {
            Console.WriteLine("Greetings traveler.");
            Console.WriteLine("Tell me about yourself. What is your name?");
            string name = Console.ReadLine();

            do
            {
                Console.Clear();

                Console.WriteLine("Greatings " + name + ", what type of class are you?");
                Console.WriteLine("Wizard (1)");
                Console.WriteLine("Warrior (2)");
                Console.WriteLine("Tank (3)");
                Console.WriteLine("Rogue (4)");
                res = Console.ReadLine();

                try
                {
                    klass = Convert.ToInt32(res);
                }
                catch (Exception)
                {
                    Console.WriteLine("Press enter to try again...");
                    Console.ReadLine();
                }
            }
            while (klass > 4 || klass < 1);

            //sets klass and stats
            switch (klass)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("You have chosen a wizard. These are your stats.");
                    Wizard Mage = new Wizard();
                    Mage.show();

                    hp = Mage.GetHp();
                    hpmax = Mage.GetHp();
                    mp = Mage.GetMp();
                    mpcurrent = mp;
                    att = Mage.GetAtt();
                    wiz = Mage.GetWiz();
                    crit = Mage.GetCrit();
                    luck = Mage.GetLuck();
                    weap = " staff ";
                    spell = " firebolt ";

                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("You have chosen a warrior. These are your stats.");
                    Warrior War = new Warrior();
                    War.show();

                    hp = War.GetHp();
                    hpmax = War.GetHp();
                    mp = War.GetMp();
                    mpcurrent = mp;
                    att = War.GetAtt();
                    wiz = War.GetWiz();
                    crit = War.GetCrit();
                    luck = War.GetLuck();
                    weap = " sword ";
                    spell = " weak bolt ";

                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("You have chosen a tank. These are your stats.");
                    Tank Tank = new Tank();
                    Tank.show();

                    hp = Tank.GetHp();
                    hpmax = Tank.GetHp();
                    mp = Tank.GetMp();
                    mpcurrent = mp;
                    att = Tank.GetAtt();
                    wiz = Tank.GetWiz();
                    crit = Tank.GetCrit();
                    luck = Tank.GetLuck();
                    weap = " club ";
                    spell = " weak bolt ";

                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("You have chosen a rogue. These are your stats.");
                    Rogue Rog = new Rogue();
                    Rog.show();

                    hp = Rog.GetHp();
                    hpmax = Rog.GetHp();
                    mp = Rog.GetMp();
                    mpcurrent = mp;
                    att = Rog.GetAtt();
                    wiz = Rog.GetWiz();
                    crit = Rog.GetCrit();
                    luck = Rog.GetLuck();
                    weap = " dagger ";
                    spell = " small fireball ";

                    break;

                default:
                    Console.Write("I'm sorry, I didn't get that. Please try again.");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }

        //Combat from room 1
        public void SkeletonCombat()
        {
            mHp = mob.GetHp();
            mAtt = mob.GetAtt();
            mCrit = mob.GetCrit();
            mGold = mob.GetGold();
            bool mAlive = true;

            do
            {
                choice = 0;
                Console.WriteLine("(1) Physical Damage");
                Console.WriteLine("(2) Magical Damage");
                Console.WriteLine("Or...");
                Console.WriteLine("(3) Attack the stalactite");
                ans = Console.ReadLine();

                try
                {
                    choice = Convert.ToInt32(ans);
                }
                catch (Exception)
                {
                    Console.WriteLine("Try again...");
                }
                Console.Clear();
            }
            while (choice != 1 && choice != 2 && choice != 3);

            switch (choice)
            {
                case 1:
                    dmg = RNG.Next(att);
                    if (RNG.Next() % 5 + 5 < crit)
                        dmg *= 2;

                    Console.WriteLine("You rush towards the skeleton and smash his skull with your" + weap + "dealing " + dmg + " damage...");
                    mHp -= dmg;
                    if (mHp <= 0)
                    {
                        mAlive = false;
                        Console.WriteLine("Congratulations. You killed the skeleton in one hit.");
                    }
                    else
                    {
                        Console.WriteLine("The skeleton has " + mHp + " health remaining.");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (mpcurrent > 0)
                    {
                        dmg = RNG.Next() % wiz;
                        Console.WriteLine("You stay back at a distance and cast" + spell + "at the skeleton.");
                        Console.WriteLine("The skeleton takes " + dmg + " damage...");
                        mHp -= dmg;
                        if (mp > 10)
                        {
                            mpcurrent -= (mp / 10);
                        }
                        else
                        {
                            mpcurrent = 0;
                        }
                        Console.WriteLine("You have " + mpcurrent + " mp left.");
                        Console.ReadLine();
                        if (mHp <= 0)
                        {
                            mAlive = false;
                            Console.WriteLine("Congratulations. You killed the skeleton in one hit.");
                        }
                        else
                        {
                            Console.WriteLine("The skeleton has " + mHp + " health remaining.");
                        }
                    }
                    else
                        Console.WriteLine("You attempt to cast" + spell + "but it flickers into nonexsistance. It seems you do not have" +
                            " enough mana to cast this.");

                    break;
                case 3:
                    lCheck = RNG.Next(2, 5);
                    if (luck >= 20)
                    {
                        Console.WriteLine("You find a small rock next to you and chuck it at the stalactite above the skeleton.");
                        Console.WriteLine("It falls directly on him crushing him into a pile of bone powder.");
                        Console.WriteLine("The stalactite breaks open and huge piles of gold fall out. What are the chances...");
                        Console.WriteLine("You loot 50 gold pieces from the fallen stalactite.");
                       
                        mAlive = false;
                        wallet += 50;

                    }
                    else if (luck >= lCheck)
                    {
                        Console.WriteLine("You find a small rock next to you and chuck it at the stalactite above the skeleton.");
                        Console.WriteLine("It falls directly on him crushing him into a pile of bone powder.");
                        
                        mAlive = false;
                    }
                    else if (luck > lCheck - 3)
                    {
                        Console.WriteLine("You find a decent rock and lob it towards the closest stalactite above the skeleton.");
                        Console.WriteLine("The skeleton notices you and tries to dodge out of the way. The stalactite fell a bit too fast"
                            + " and hit the skeleton in one of its legs.");
                        mHp -= RNG.Next(10, 15);
                        Console.WriteLine("The skeleton has " + mHp + " health remaining.");
                        
                    }
                    else
                    {
                        Console.WriteLine("The only rock you find is a bit too big to throw all the way up to the ceiling.");
                        Console.WriteLine("You try anyways. The rock doesn't even come close to hitting the spike.");
                        Console.WriteLine("The rock lands in the dead center of the room with a loud BANG... The skeleton hears this and"
                            + " turns his attention directly to you.");
                    }

                    break;

                default:
                    Console.WriteLine("How did you get here you bug finder you...");
                    break;
                    
            }
            Console.ReadLine();
            Console.Clear();

            if (mAlive)
            {
                do
                {
                    dmg = RNG.Next() % mAtt;
                    if (RNG.Next() % 5 + 4 < mCrit)
                    {
                        dmg *= 2;
                    }
                    Console.WriteLine("The skeleton seizes his opportunity to retaliate. He swipes at you with his sword hitting for " + dmg + " damage...");
                    hp -= dmg;
                    Console.WriteLine("Your hp is now " + hp);
                    Console.ReadLine();
                    if (hp <= 0)
                    {
                        isAlive = false;
                        Console.WriteLine("It seems you have died. Good luck in the afterlife...");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                    do
                    {
                        choice = 0;
                        Console.WriteLine("Attack the skeleton with: ");
                        Console.WriteLine("(1) Physical Damage");
                        Console.WriteLine("(2) Magical Damage");
                        ans = Console.ReadLine();

                        try
                        {
                            choice = Convert.ToInt32(ans);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Try again...");
                        }

                    }
                    while (choice != 1 && choice != 2);

                    switch (choice)
                    {
                        case 1:
                            dmg = RNG.Next() % att;
                            if (RNG.Next() % 5 + 5 < crit)
                                dmg *= 2;

                            Console.WriteLine("You swing at the skeleton dealing " + dmg + " damage...");
                            mHp -= dmg;
                            Console.WriteLine("The skeleton has " + mHp + " health remaining.");
                            Console.ReadLine();

                            if (mHp <= 0)
                                mAlive = false;

                            break;

                        case 2:
                            if (mpcurrent > 0)
                            {

                                dmg = RNG.Next() % wiz;
                                Console.WriteLine("You cast" + spell + "at the skeleton.");
                                Console.WriteLine("The skeleton takes " + dmg + " damage...");
                                Console.ReadLine();
                                mHp -= dmg;
                                if (mp > 10)
                                    mpcurrent -= (mp / 10);

                                else
                                    mpcurrent = 0;

                                if (mHp <= 0)
                                    mAlive = false;
                                Console.WriteLine("You have " + mpcurrent + " mp left.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("You attempt to cast" + spell + "but it flickers into nonexsistance. You do not have enough " +
                                    "mana to cast this.");
                                Console.ReadLine();
                            }

                            break;
                        default:
                            Console.WriteLine("How did you get here you bug finder you...");
                            break;
                    }
                    Console.Clear();

                }
                while (isAlive && mAlive);
                
                if (isAlive == false)
                {
                    Console.WriteLine("It seems you have died. Good luck in the afterlife...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                
            }
            Console.WriteLine("You defeated the skeleton. You see " + mob.GetGold() + " gold next to the body. You put it into your wallet.");
            wallet += mob.GetGold();
            Console.ReadLine();
            Console.Clear();
        }

        //Luck check for room1
        public void Room1()
        {
            if (RNG.Next(4, 15) < luck)
            {
                Console.WriteLine("Out of the corner of your eye, you see a small shimmer.");
                Console.WriteLine("You walk over to investigate and find 20 gold!");
                wallet += 20;
                Console.WriteLine("There is nothing left for you in this room... You head back the way you came.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You search the entire room and find nothing of interest. You head back the way you came.");
                Console.ReadLine();
            }
        }

        //Luck check for fountain in room2
        public void Room2()
        {
            Console.Clear();
            Console.WriteLine("You dip your hands in the fountain and scoop the red liquid up.");
            Console.WriteLine("You lift your hands to your lips and quickly finish the liquid.");
            Console.WriteLine("As it passes down your throat, you experience a warm feeling throughout your body.");

            if (hp == hpmax)
                Console.WriteLine("You feel like this would heal you, but you already feel your best.");
            else
            {
                Console.WriteLine("You can feel your wounds closing. You feel ten years younger.");
                hp = hpmax;
            }

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("The fountain lets out a groan, and sinks into the wall. It disappears completely.");
            Console.WriteLine("You hear a mechanical clunk from your right. You turn to look at the noise.");

            if (RNG.Next(-5,5) > luck)
            {
                dmg = RNG.Next(20, 75);
                hp -= dmg;
                Console.WriteLine("An arrow flies out of the wall and lands directly in your shoulder hitting you for " + dmg +
                    " damage leaving you at " + hp + " health.");
            }
            else
                Console.WriteLine("An arrow launches out of the wall, but gets caught in the launching contraption and falls by your feet. How lucky.");
            
            Console.ReadLine();
            Console.Clear();       
        }

        public void Room3()
        {
            Console.Clear();
            Console.WriteLine("You walk into the dark room.");

            if (RNG.Next(-10, -5) > luck)
            {
                Console.WriteLine("Before you can even see it, you fall into the giant void in the middle of the room.");
                Console.WriteLine("You start falling.");
                Console.WriteLine("And falling.");
                Console.WriteLine("And falling.");
                Console.WriteLine("You realize this is the end. There is no hope for you...");
                Console.ReadLine();
                Console.WriteLine("Better luck in the afterlife...");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("Your foot slips and you fall onto your back.");
            Console.WriteLine("As you try and get back up, you realize there is a hole under your left hand.");
            Console.WriteLine("You start investigating. Soon you realize its not just a hole, but a huge pit. You don't want to be anywhere near that.");
            Console.WriteLine("You leave the room as quickly as you can.");
            Console.ReadLine();
            Console.Clear();
            
        }

        public void Room4(int x)
        {
            if (x == 1)
            {
                Console.WriteLine("You walk towards the west door in the hallway. You make it halfway there before noticing one of the tiles you step on sink down.");
                Console.WriteLine("Before you know it, a massive axe falls in a pendulum motion from the ceiling.");

                if (RNG.Next(-5, 5) > luck)
                {
                    dmg = RNG.Next(10, 70);
                    hp -= dmg;
                    Console.WriteLine("The axe cleaves into your leg for " + dmg + " damage. Leaving you with " + hp + " health.");
                    Console.ReadLine();

                    if (hp <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Your leg gets cut clean off. Without both legs, you can make it to saftey before bleeding out...");
                        Console.WriteLine("Better luck in the afterlife...");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("You manage to react fast enough to jump out of the way. The blade barely hits your foot.");
                    Console.WriteLine("It slices off a small part of your shoe, but you remain uncut.");
                }

            }
            else if (x == 2)
            {
                Console.WriteLine("The axe sits hanging in the hallway.... you slide around it carfully and make it to the otherside unharmed.");
            }
            Console.ReadLine();
            Console.Clear();
        }

        public void Room5()
        {
            mHp = mino.GetHp();
            mAtt = mino.GetAtt();
            mCrit = mino.GetCrit();
            mGold = mino.GetGold();
            bool mAlive = true;

            if (RNG.Next (-5, 4) > luck)
            {
                dmg = RNG.Next(1, 10);
                hp -= dmg;
                Console.WriteLine("The minotaur's force knocks you down. You take " + dmg + " damage. Leaving you with " + hp + " health.");
                Console.ReadLine();

                if (hp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You couldn't even handle getting knocked down...");
                    Console.WriteLine("Better luck in the afterlife...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            do
            {
                choice = 0;
                Console.WriteLine("Attack the minotaur with: ");
                Console.WriteLine("(1) Physical Damage");
                Console.WriteLine("(2) Magical Damage");
                ans = Console.ReadLine();

                try
                {
                    choice = Convert.ToInt32(ans);
                }
                catch (Exception)
                {
                    Console.WriteLine("Try again...");
                }
            }
            while (choice != 1 && choice != 2);
            {
                while (mAlive && isAlive)
                {
                    switch (choice)
                    {
                        case 1:
                            dmg = RNG.Next() % att;
                            if (RNG.Next(5, 10) < crit)
                                dmg *= 2;

                            Console.WriteLine("You swing at the Minotaur dealing " + dmg + " damage...");
                            mHp -= dmg;
                            Console.WriteLine("The minotaur has " + mHp + " health remaining.");
                            Console.ReadLine();

                            if (mHp <= 0)
                                mAlive = false;

                            break;

                        case 2:
                            if (mpcurrent > 0)
                            {

                                dmg = RNG.Next() % wiz;
                                Console.WriteLine("You cast" + spell + "at the minotaur.");
                                Console.WriteLine("The minotaur takes " + dmg + " damage leaving him with " + mHp + " health");
                                Console.ReadLine();
                                mHp -= dmg;
                                if (mp > 10)
                                    mpcurrent -= (mp / 10);

                                else
                                    mpcurrent = 0;

                                if (mHp <= 0)
                                    mAlive = false;
                                Console.WriteLine("You have " + mpcurrent + " mp left.");
                                
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("You attempt to cast" + spell + "but it flickers into nonexsistance. You do not have enough " +
                                    "mana to cast this.");
                                Console.ReadLine();
                            }

                            break;
                        default:
                            Console.WriteLine("How did you get here you bug finder you...");
                            break;
                    }
                    Console.Clear();

                    if (mAlive)
                    {
                        dmg = RNG.Next() % mAtt;
                        if (RNG.Next(5, 10) < mCrit)
                        {
                            dmg *= 2;
                        }
                        Console.WriteLine("The minotaur charges at you for " + dmg + " damage...");
                        hp -= dmg;
                        if (hp <= 0)
                            isAlive = false;
                        Console.WriteLine("Your hp is now " + hp);
                        Console.ReadLine();
                        Console.Clear();

                        choice = 0;
                        Console.WriteLine("Attack the minotaur with: ");
                        Console.WriteLine("(1) Physical Damage");
                        Console.WriteLine("(2) Magical Damage");
                        ans = Console.ReadLine();

                        try
                        {
                            choice = Convert.ToInt32(ans);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Try again...");
                        }
                    }
                    
                }
                if (isAlive == false)
                {
                    Console.WriteLine("It seems you have died. Good luck in the afterlife...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                Console.WriteLine("You defeated the minotaur. You see " + mino.GetGold() + " gold next to the body. You put it into your wallet.");
                wallet += mino.GetGold();
                Console.ReadLine();
                Console.Clear();

            }
        }

        public void Room6()
        {
            Console.WriteLine("Just warning you, I only sell one item per customer...");
            Console.WriteLine();

            do
            {
                choice = 0;

                Console.Clear();
                Console.WriteLine("Current gold: " + wallet);
                Console.WriteLine();
                Console.WriteLine("(1) Potion - 20 gold");
                Console.WriteLine("(2) Bastard Sword - (15 Att) 30 gold");
                Console.WriteLine("(3) Gandalf's Staff - (15 Wiz) 35 gold");
                Console.WriteLine("(4) Two Daggers - (15 Crit) 40 gold");
                Console.WriteLine("(5) Armor - (200 hp) 45 gold");
                Console.WriteLine("(6) Excaliber - (9999 Att) 100 gold");
                
                ans = Console.ReadLine();

                try
                {
                    choice = Convert.ToInt32(ans);
                }
                catch (Exception)
                {
                    Console.WriteLine("I'm sorry, try again....");
                }
            }
            while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5 && choice != 6);
            Console.Clear();
            switch (choice)
            {
                case 1:
                    if (wallet >= 20)
                    {
                        hp = hpmax;
                        Console.WriteLine("Your health has been fully restored. You are now at " + hp + " hp...");
                    }
                    else
                        Console.WriteLine("I'm sorry, it appears you don't have enough money to buy that...");
                    break;
                case 2:
                    if (wallet >= 30)
                    {
                        att += 15;
                        weap = "Bastard Sword";
                        Console.WriteLine("Your att is now at " + att);
                    }
                    else
                        Console.WriteLine("I'm sorry, it appears you don't have enough money to buy that...");
                    break;
                case 3:
                    if (wallet >= 35)
                    {
                        wiz += 15;
                        Console.WriteLine("Your wisdom is now at " + wiz );
                    }
                    else
                        Console.WriteLine("I'm sorry, it appears you don't have enough money to buy that...");
                    break;
                case 4:
                    if (wallet >= 40)
                    {
                        crit += 15;
                        Console.WriteLine("Your crit is now at " + crit );
                    }
                    else
                        Console.WriteLine("I'm sorry, it appears you don't have enough money to buy that...");
                    break;
                case 5:
                    if (wallet >= 45)
                    {
                        hpmax += 200;
                        hp += 200;
                        Console.WriteLine("Your current health is now " + hp);
                    }
                    else
                        Console.WriteLine("I'm sorry, it appears you don't have enough money to buy that...");
                    break;
                case 6:
                    if (wallet >= 100)
                    {
                        att += 9999;
                        weap = "excaliber";
                        Console.WriteLine("I've been holding onto this one since the 12th century... Fool...");
                    }
                    else
                        Console.WriteLine("I'm sorry, it appears you don't have enough money to buy that...");

                    break;
                default:
                    Console.WriteLine("How did you get here???");
                    break;
            }
            Console.ReadLine();
            Console.WriteLine("Now that you have browsed my wares, it is time for the final boss...");
            Console.WriteLine("The door you came through slams shut behind you.... You have no choice but to go north now...");

        }

        public void BossRoom()
        {
            RNG.Next(0, 100);

            Dragon D = new Dragon();

            mHp = D.GetHp();
            mCrit = D.GetCrit();
            string curAtt = ""; 
            
            bool mAlive = true;

            do
            {
                Console.Clear(); 
                //Choosing Dragon Attack
                mAtt = RNG.Next(0, 100);
                if (mAtt < 25)
                {
                    dmg = D.GetBite();
                    curAtt = "bite";
                }

                else if (mAtt < 50)
                {
                    dmg = D.GetClaws();
                    curAtt = "claws";
                }

                else if (mAtt < 75)
                {
                    dmg = D.GetFire();
                    curAtt = "fire breath";
                }
                else
                {
                    dmg = D.GetTail();
                    curAtt = "tail";
                }

                hp -= dmg;
                Console.WriteLine("The dragon attacks you with its " + curAtt + " hitting you for " + dmg + " damage.");
                Console.WriteLine("Your health is now at " + hp);
                Console.ReadLine();
                Console.Clear();
                if (hp <= 0)
                {
                    Console.WriteLine("You died.... Defeated by the mighty dragon Charles...");
                    Console.WriteLine("Better luck in the afterlife...");
                    Console.ReadLine();
                    Environment.Exit(0);

                    isAlive = false;
                }

                Console.WriteLine("Would you like to attack the dragon with physical damage or a magic attack?");

                do
                {
                    choice = 0;
                    Console.WriteLine("(1) Physical...");
                    Console.WriteLine("(2) Magical...");
                    ans = Console.ReadLine();

                    try
                    {
                        choice = Convert.ToInt32(ans);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("I'm sorry, try again.");
                    }
                }
                while (choice != 1 && choice != 2);

                switch (choice)
                {
                    case 1:
                        dmg = RNG.Next(att);
                        mHp -= dmg;
                        Console.WriteLine("You attack the mighty dragon with your " + weap + " hitting for " + dmg + " damage...");

                        break;
                    case 2:
                        if (mpcurrent > 0)
                        {
                            dmg = RNG.Next(wiz);
                            Console.WriteLine("You conjure up a " + spell + " and throw it at the dragon hitting it for " + dmg + " damage...");
                            if (mpcurrent > 10)
                            {
                                mpcurrent -= (mp / 10);
                                Console.WriteLine("You have " + mpcurrent + " mana remaining...");
                            }
                            else
                            {
                                mpcurrent = 0;
                                Console.WriteLine("You are now out of mana...");
                            }


                        }
                        else
                            Console.WriteLine("You attemt to cast a spell, but it sizzles out mid cast. You appear to be out of mana.");
                        break;

                    default:
                        Console.WriteLine("How did you get here?");
                        break;
                }

                if (mHp <= 0)
                    mAlive = false;

                Console.WriteLine("The dragon now has " + mHp + " health...");
                Console.ReadLine();
                Console.Clear();


            } while (mAlive && isAlive);

            if (mAlive == false)
            {
                Console.WriteLine("As you deliver the final blow, the dragon reares up on its hind legs and falls into the back of the cave.");
                Console.WriteLine("Its body destroys a wall and light poors into the once dark room.");
                Console.WriteLine("You reach for the end of the dragon's tail and pluck the largest scale. A prize for your victory....");
                Console.ReadLine();

                string win = "YOU WIN!!!";
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - win.Length, Console.WindowHeight / 2);
                Console.WriteLine(win);
                Console.ReadLine();
                Environment.Exit(0);
            }
            else if (isAlive == false)
            {
                Console.WriteLine("You died.... Defeated by the mighty dragon Charles...");
                Console.WriteLine("Better luck in the afterlife...");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
