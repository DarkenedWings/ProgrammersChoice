using System;


namespace TextBasedGame
{
    class Room
    {
        Combat c = new Combat();
        
        bool[] r = new bool[9];
        string ans;
        int choice;


        //Start to the story
        public void Beginning()
        {
            for (int i = 0; i < r.Length - 1; i++)
            {
                r[i] = false;
            }
            c.ChooseKlass();

            Console.WriteLine("You find yourself at the opening of a dark and mysterious cave. You don't know how you got here.");

            do
            {
                choice = 0;
                Console.WriteLine("You can contiue forward (1), or turn around and leave (2)... ");
                ans = Console.ReadLine();

                try
                {
                    choice = Convert.ToInt32(ans);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "Press ENTER to try again...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (choice != 1 && choice != 2);
            Console.Clear();

            if (choice == 2)
            {
                Console.WriteLine("The ground beneath you starts to rumble. You hear a faint growl. As you take a step towards the opening of the cave a"
                    + " massive rock falls from above and blocks all paths leaving the cave. It appears you are stuck...");
                Console.WriteLine("You have no choice but to continue north.");
                Console.ReadLine();
            }
            Console.Clear();
        }

        //Follows directly after beginning. Leads to first combat.
        public void Room0()
        {
            
            if (r[0] == false)
            {
                Console.WriteLine("You enter into a large section of the cave. A small pond twinkles to your right. Giant stalactites hang from the ceiling"
                        + " threatening to fall down at any moment. You see a path that leads to the west as well as a small opening leading away from the"
                        + " sparkling pond. A skeleton stands with his back towards you, he does not seem to notice you yet. He blocks the path ahead.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("What would you like to do? You can attack the stalactite or attack the skeleton: ");
                Console.WriteLine("Attack the skeleton with: ");

                c.SkeletonCombat();
                r[0] = true;
            }
            Console.Clear();
            Console.WriteLine("To the west is a small opening in the cave. You see a dim light flickering from the other side of it.");
            Console.WriteLine("To the east you see a small pool of water with what appears to be a path on the wall next to it.");
            do
            {
                choice = 0;
                Console.WriteLine("(1) West...");
                Console.WriteLine("(2) East...");
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
            while (choice != 1 && choice != 2);

            switch (choice)
            {
                case 1:
                    Room1();
                    break;
                case 2:
                    Room2();
                    break;
                default:
                    Console.WriteLine("How did you get here???");
                    break;
            }
        }

        //West of Room 0
        public void Room1()
        {
            Console.WriteLine("You find yourself in a small circular room.");
            Console.WriteLine("The only noteable thing is a small lantern that is too high to touch.");
            if (r[1] == false)
            {
                c.Room1();
                r[1] = true;
            }
            else
            {
                Console.WriteLine("You have already searched this room. There is nothing for you here.");
                Console.WriteLine("You head back the way you came.");
                Console.ReadLine();
            }
            Room0();
        }

        public void Room2()
        {
            if (r[2] == false)
            {
                r[2] = true;

                Console.WriteLine("You walk into the pond to get through the archway leading out of the room.");
                Console.WriteLine("The pond gets deeper and deeper as you continue.");
                Console.WriteLine("Just as you are about to start swimming, you find the end and walk into a new room.");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("You look around the room and find that the ceiling has a massive hole where the moonlight shines" +
                    " through and lights up the area around you.");
                Console.WriteLine("There is a crubling doorway to your north, it looks like you could barely fit through it.");
                Console.WriteLine("To the south is a big doorway with no light coming from it.");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Directly ahead of you is a small fountain filled with red liquid.");
                Console.WriteLine("Ancient runes have been placed above the fountain. They claim the fountain will heal you if consumed.");

                do
                {
                    choice = 0;
                    Console.WriteLine("Would you like to drink from the fountain?");
                    Console.WriteLine("(1) Yes");
                    Console.WriteLine("(2) No");
                    ans = Console.ReadLine();

                    try
                    {
                        choice = Convert.ToInt32(ans);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Try again...");
                        Console.ReadLine();
                    }
                }
                while (choice != 1 && choice != 2);

                switch (choice)
                {
                    case 1:
                        c.Room2();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("The fountain seems to know your intentions and fades away into the wall.");
                        break;
                    default:
                        Console.WriteLine("How did you get here?");
                        break;
                }

            }
            Console.WriteLine("You can now continue north into the crumbiling door, south into the black room, or west into the pond.");

            do
            {
                choice = 0;
                Console.WriteLine("(1) North");
                Console.WriteLine("(2) South");
                Console.WriteLine("(3) West");

                ans = Console.ReadLine();
                try
                {
                    choice = Convert.ToInt32(ans);
                }
                catch (Exception)
                {
                    Console.WriteLine("Try again...");
                    Console.ReadLine();
                }
                Console.Clear();
            }
            while (choice != 1 && choice != 2 && choice != 3);

            switch (choice)
            {
                case 1:
                    Room4();
                    break;
                case 2:
                    Room3();
                    break;
                case 3:
                    Room0();
                    break;
                default:
                    Console.WriteLine("How did you get here?");
                    break;
            }
        }

        public void Room3()
        {

            if (r[3] == false)
            {
                r[3] = true;
                c.Room3();
                Room2();
            }
            Console.WriteLine("You walk in here before realizing you don't want to be anywhere near that pit. You head back the way you came.");
            Console.ReadLine();
            Console.Clear();
            Room2();
        }

        public void Room4()
        {
            if (r[4] == false)
            {
                Console.WriteLine("You find yourself in a hallway.");

                do
                {
                    choice = 0;
                    Console.WriteLine("Would you like to travel North, East, West, or South...");
                    Console.WriteLine("(1) North");
                    Console.WriteLine("(2) East");
                    Console.WriteLine("(3) West");
                    Console.WriteLine("(4) South");
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
                while (choice != 1 && choice != 2 && choice != 3 && choice != 4);

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Room5(choice);
                        break;
                    case 2:
                        Room5(choice);
                        break;
                    case 3:
                        r[4] = true;
                        c.Room4(1);
                        Room6();
                        break;
                    case 4:
                        Room2();
                        break;
                    default:
                        break;
                }
            }
            do
            {
                choice = 0;
                Console.WriteLine("Would you like to travel North, East, West, or South...");
                Console.WriteLine("(1) North");
                Console.WriteLine("(2) East");
                Console.WriteLine("(3) West");
                Console.WriteLine("(4) South");
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
            while (choice != 1 && choice != 2 && choice != 3 && choice != 4);

            Console.Clear();
            switch (choice)
            {
                case 1:
                    Room5(choice);
                    break;
                case 2:
                    Room5(choice);
                    break;
                case 3:
                    c.Room4(2);
                    Room6();
                    break;
                case 4:
                    Room2();
                    break;
                default:
                    break;
            }
        }

        public void Room5(int x)
        {
            if (r[5] == false)
            {
                r[5] = true;
                if (x == 1)
                {
                    Console.WriteLine("You enter through the north entrance. A wall is on your left.");
                    Console.WriteLine("The room continues to the east until curving out of sight.");
                    Console.WriteLine("You continue to explore the room.");
                }
                else if (x == 2)
                {
                    Console.WriteLine("You enter through the east entrance. A wall is on your right.");
                    Console.WriteLine("The room continues north until curving out of sight.");
                    Console.WriteLine("You continue to explore the room.");
                }
                else
                    Console.WriteLine("You magically apear in the room and walk toward the center.");

                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("After walking towards the curve you notice a small room in front of you. ");
                Console.WriteLine("You hear a deep grunt come from the room.");
                Console.WriteLine("A massive minotaur comes charging out...");
                Console.ReadLine();
                c.Room5();

                Console.WriteLine("You can leave this room through the north exit or the east exit.");
                do
                {
                    choice = 0;
                    Console.WriteLine("(1) North");
                    Console.WriteLine("(2) East");
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
                        Room4();
                        break;
                    case 2:
                        Room4();
                        break;
                    default:
                        Console.WriteLine("How did you get here?");
                        break;
                }

            }
            Console.WriteLine("There is nothing else for you in this room. You head back the way you came.");
            Console.ReadLine();
            Room4();
        }

        public void Room6()
        {
            Console.WriteLine("You walk into a well lit and furnished room. Sitting in a chair is a small goblin. After walking around the room, " +
                "you come to the realization that he is blind.");
            Console.WriteLine("I haven't had a visiter in years -He says in a gruff voice.");
            Console.WriteLine("Please, please, come look at my wares, I might not get visited a lot, but I always keep my shop stocked.");
            Console.WriteLine("You take a look at his wares.");
            Console.ReadLine();
            Console.Clear();
            c.Room6();
            Console.WriteLine("You take a deep breath and take a step forward into the final chamber.");
            Console.ReadLine();

            BossRoom();
        }
        
        public void BossRoom()
        {
            Console.Clear();
            Console.WriteLine("You walk into a massive cavern. The smell of old campfires fills your nose. The ground trembles beneath your feet...");
            Console.WriteLine("You scan the room. You see a massive four legged beast trampling toward you.");
            Console.WriteLine("It beats its wings and soars above you letting out a massive growl.");
            Console.WriteLine("It lands on the ground hard, shaking the ground and cause loose rocks to fall from the walls.");
            Console.WriteLine("Before you stand a mighty dragon...");
            Console.ReadLine();
            c.BossRoom();
        }

    }
}
