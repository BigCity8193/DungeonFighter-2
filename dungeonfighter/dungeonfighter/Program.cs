using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonfighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dungeon Adventure.");
            Console.WriteLine("Please enter your name.");
            Console.Write(">");
            string inputname = Convert.ToString(Console.ReadLine());

            playerstats player = new playerstats(inputname);
            string menuchoice = String.Empty;

            
            do
            {
                menuchoice = menu();
                switch (menuchoice)
                {
                    case "E":
                        enterdungeon(player);
                        break;
                    case "U":
                        usepotion(player);
                        break;
                    case "S":
                        gotoshop(player);
                        break;
                    case "P":
                        playerstatus(player);
                        break;
                    default:
                        break;
                }
            } while (menuchoice != "X");


            Console.WriteLine();
            Console.WriteLine("You have ended the game at level {0} with {1} XP.",player.PlayerLevel, player.PlayerTotalXP);
            Console.WriteLine("Press the any key to exit...");
            Console.ReadKey();
        
        }

        private static int monstertext()
        {
            Console.WriteLine("Which dungeon do you want to go into?");
            Console.WriteLine("1 = Easy");
            Console.WriteLine("2 = Medium");
            Console.WriteLine("3 = Hard");
            Console.Write(">");
            return Convert.ToInt16(Console.ReadLine());
           

        }

        private static void monsterdisplay(GenerateMonster currentmonster)
        {
            Console.WriteLine();
            Console.WriteLine("This Monster is a {0}", currentmonster.MonsterName);
            Console.WriteLine("The {0}'s HP is {1}",currentmonster.MonsterName, currentmonster.MonsterHP);
            Console.WriteLine("The {0}'s attack is between {1} and {2}", currentmonster.MonsterName, currentmonster.MonsterAttack[0], currentmonster.MonsterAttack[1]);
        }


        private static int fighting(playerstats player, GenerateMonster currentmonster)
        {
            char response = 'q';
            Random rand = new Random();
            Random d20 = new Random();
            int playerand;
            int monsterand;
            int deathcheck;

            do
            {
                Console.WriteLine("Do you want to attack the monster? Y/N");
                Console.Write(">");
                response = Convert.ToChar(Console.ReadLine());
                response = char.ToUpper(response);
                if (response == 'Y')
                {
                    playerand = rand.Next(player.PlayerAttack[0], (player.PlayerAttack[1] + 1));

                    if ((playerand + d20.Next(1, 21)) > (currentmonster.MonsterDefense + d20.Next(1, 21)))
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have hit the monster for {0} damage!", playerand);
                        currentmonster.MonsterHP -= playerand;
                        Console.WriteLine("The monster's HP is currently {0}.", currentmonster.MonsterHP);
                    }
                    else
                    {
                        monsterand = rand.Next(currentmonster.MonsterAttack[0], (currentmonster.MonsterAttack[1] + 1));
                        Console.WriteLine();
                        Console.WriteLine("The monster has hit you for {0} damage!", monsterand);
                        player.PlayerHP -= monsterand;
                        Console.WriteLine("Your HP is currently {0}. ", player.PlayerHP);
                    }
                    deathcheck = checkfordead(player.PlayerHP, currentmonster.MonsterHP);
                    switch (deathcheck)
                    {
                        case 1:
                            Console.WriteLine("The monster has defeated you. You are forced to head back to town. You lose {0} XP", currentmonster.MonsterXP);
                            player.PlayerHP = player.PlayerMaxHP;
                            return -currentmonster.MonsterXP;
                        case 2:
                            Console.WriteLine("The Monster is dead! {0} XP awarded!", currentmonster.MonsterXP);
                            return currentmonster.MonsterXP;
                        default:
                            break;
                    }

                }
                else
                { 
                    Console.WriteLine("Entry not recognized, please use Y or N");
                }

            } while (response != 'N');
            return 0;
        }

        private static int checkfordead(int playershp, int monstershp)
        {
            if (playershp <= 0)
            {
                return 1;
            }
            else if (monstershp <= 0)
            {
                return 2;
            }
            else
                return 0;
        }
        
        private static void checkforlevelup(playerstats player)
        {
            if (player.PlayerTotalXP >= player.XPtoLevelUP)
            {

                Console.WriteLine("***************");
                player.PlayerLevel += 1;
                Console.WriteLine("Congratulations! You leveled up! You are now level {0}!", player.PlayerLevel);
                player.XPtoLevelUP = (player.XPtoLevelUP*2) + (player.XPtoLevelUP / 2);
                Console.WriteLine("It will now take {0}XP to reach the next level.", player.XPtoLevelUP);
                player.PlayerAttack = player.setplayerattack(player.PlayerLevel);
                Console.WriteLine("Your attack is now {0} - {1}!", player.PlayerAttack[0], player.PlayerAttack[1]);
                player.PlayerMaxHP = 100 + (10 * player.PlayerLevel);
                player.PlayerHP = player.PlayerMaxHP;
                Console.WriteLine("Your HP is now {0}.", player.PlayerHP);
                player.PlayerDefense += 2;
                Console.WriteLine("Your defense is now {0}.", player.PlayerDefense);
                Console.WriteLine("***************");
                Console.WriteLine();

            }
        }

        private static void enterdungeon(playerstats player)
        {
            int monsterlevel = 0;
            char yesno = 'q';

            do
            {
                monsterlevel = monstertext();
                GenerateMonster newmonster = new GenerateMonster(monsterlevel);
                monsterdisplay(newmonster);
                player.PlayerTotalXP += fighting(player, newmonster);
                if (player.PlayerTotalXP < 0)
                    player.PlayerTotalXP = 0;
                Console.WriteLine();
                Console.WriteLine("Player's total XP is {0}", player.PlayerTotalXP);
                checkforlevelup(player);
                Console.WriteLine("Do you want to go futher in the dungeon?");
                Console.Write(">");
                yesno = Convert.ToChar(Console.ReadLine());
                yesno = char.ToUpper(yesno);

            } while (yesno != 'N');

        }

        private static void usepotion(playerstats player)
        {

            if (player.PlayerPotions != 0)
            {
                player.PlayerPotions--;
                Console.WriteLine();
                Console.WriteLine("You take a potion from your belt and drink.");
                Console.WriteLine("Your HP is restored.");
                Console.WriteLine("You now have {0} potions remaining.", player.PlayerPotions);
                player.PlayerHP = player.PlayerMaxHP;
            }
            else
                Console.WriteLine();
                Console.WriteLine("You do not have any potions.");

        }

        private static void gotoshop(playerstats player)
        {

            char response = 'q';

            Console.WriteLine();
            Console.WriteLine("Welcome to the shop.");
            Console.WriteLine("You can spend your XP for potions that will restore your health.");
            Console.WriteLine("You currently have {0}XP. Potions cost 10 XP.",player.PlayerTotalXP);
            Console.WriteLine("Would you like to buy 1 potion?");
            Console.Write(">");
            response = Convert.ToChar(Console.ReadLine());
            response = Char.ToUpper(response);
            if (response == 'Y')
            {
                if (player.PlayerTotalXP >= 10)
                {
                    player.PlayerTotalXP -= 10;
                    player.PlayerPotions += 1;

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You do not have enough XP for a potion");
                }
            }
            Console.WriteLine("Thank you for visiting the shop");

            
        }

        private static void playerstatus(playerstats player)
        {
            Console.WriteLine();
            Console.WriteLine("Stats for: {0}", player.PlayerName);
            Console.WriteLine("HP {0}/{1}", player.PlayerHP, player.PlayerMaxHP);
            Console.WriteLine("You are currently level {0} and have {1}/{2} XP to the next level.", player.PlayerLevel, player.PlayerTotalXP, player.XPtoLevelUP);
            Console.WriteLine("You currently have {0} potions.", player.PlayerPotions);
        }

        private static string menu()
        {

            string response = "q";

            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[E]nter the dungeon");
                Console.WriteLine("[U]se a potion");
                Console.WriteLine("Go to the [S]hop");
                Console.WriteLine("[P]layer Status");
                Console.WriteLine("E[x]it");
                Console.Write(">");
                response = Convert.ToString(Console.ReadLine());
                response = response.ToUpper();
                switch (response)
                {
                    case "E":
                        return "E";
                    case "U":
                        return "U";
                    case "S":
                        return "S";
                    case "X":
                        return "X";
                    case "P":
                        return "P";
                    default:
                        Console.WriteLine("Command not recognized. Try again.");
                        response = "Q";
                        break;
                }
            } while (response == "Q");
            return "0";
        }
    }
}
