using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGameDemo
{
    class DiceGame
    {
        private string GameName { get; set; }
        private Random RandomGenerator { get; set; }
        private int Score { get; set; }
        private string UnknowRollGraphic = @"    +---------+
    | ?     ? |
    | ?  ?  ? |
    | ?     ? |
    +---------+";
        private string Roll1Graphic = @"    +---------+
    |         |
    |    o    |
    |         |
    +---------+";
        private string Roll2Graphic = @"    +---------+
    | o       |
    |         |
    |       o |
    +---------+";
        private string Roll3Graphic = @"    +---------+
    | o       |
    |    o    |
    |       o |
    +---------+";
        private string Roll4Graphic = @"    +---------+
    | o     o |
    |         |
    | o     o |
    +---------+";
        private string Roll5Graphic = @"    +---------+
    | o     o |
    |    o    |
    | o     o |
    +---------+";
        private string Roll6Graphic = @"    +---------+
    | o     o |
    | o     o |
    | o     o |
    +---------+";

        public DiceGame()
        {
            GameName = "Rolls R' Us";
            RandomGenerator = new Random();
            Score = 0;
        }

        public void Start()
        {
            Console.Title = GameName;
            Console.WriteLine($"===> {GameName} <===");
            Console.WriteLine(UnknowRollGraphic);
            Console.WriteLine("\nLet's play a game of chance with dice");
            Console.WriteLine("\nInstructions:");
            Console.WriteLine("\t> I will roll a die each round.");
            Console.WriteLine("\t> You will gess if it is high or low.");
            Console.WriteLine("\t> If you get it right, I'll give you a point.");
            Console.WriteLine("\nReady to play? (yes/no) ");

            string playResponse = Console.ReadLine().Trim().ToLower();
            if (playResponse == "yes")
            {
                Console.WriteLine("Great - let's play!");
                PlayRound();
            }
            else
            {
                Console.WriteLine("Ohh, okay - maybe next time.");
            }    

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private void PlayRound()
        {
            Console.Clear();
            Console.WriteLine("I'm about to roll...");
            Console.WriteLine(UnknowRollGraphic);
            Console.WriteLine("Is it going to be low (1, 2, 3) or high (4, 5, 6)?");

            string response = Console.ReadLine().Trim().ToLower();

            int roll = RandomGenerator.Next(1, 7);
            switch (roll)
            {
                case 1:
                    Console.WriteLine(Roll1Graphic);
                    break;
                case 2:
                    Console.WriteLine(Roll2Graphic);
                    break;
                case 3:
                    Console.WriteLine(Roll3Graphic);
                    break;
                case 4:
                    Console.WriteLine(Roll4Graphic);
                    break;
                case 5:
                    Console.WriteLine(Roll5Graphic);
                    break;
                case 6:
                    Console.WriteLine(Roll6Graphic);
                    break;
                default:
                    Console.WriteLine("Uh oh ... the roll broke...");
                    break;
            }

            if (response == "high")
            {
                Console.WriteLine("You guessed high...");
                if (roll <= 3)
                {
                    Lose();
                }
                else
                {
                    Win();
                }    
            }
            else if(response == "low")
            {
                Console.WriteLine("You guessed low...");
                if (roll <= 3)
                {
                    Win();
                }
                else
                {
                    Lose();
                }
            }
            else
            {
                Console.WriteLine($"You guessd '{response}'. That's not valid. Try again with 'high' or 'low'");
            }

            AskToPlayAgain();
        }

        private void Win()
        {
            Console.WriteLine("You win :)");
            Console.WriteLine($"Score: {Score}");
            Score += 1;
        }

        private void Lose()
        {
            Console.WriteLine("You loose :(");
            Console.WriteLine($"Score: {Score}");
            Score -= 1;
        }
        private void AskToPlayAgain()
        {
            Console.WriteLine("Whould you like to play another round? (y/n)");
            string playResponse = Console.ReadLine();
            if (playResponse == "y")
            {
                PlayRound();
            }
            else
            {
                Console.WriteLine("Thanks, see you later.");
                Console.WriteLine($"Your end game with score: {Score}");
            }    
        }
    }
}
