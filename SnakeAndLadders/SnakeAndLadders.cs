using System;
using System.Collections.Generic;

namespace SnakeAndLadders
{
    class SnakeAndLadders
    {
        // assigning a constant to BoardLength to prevent this from changing and control of the length of game.
        private const int BoardLength = 100;
        //private static int token = 0;

        private static void Main(string[] args)
        {
            // initialization 
            int turn = 1;
            int token = 0;

            Console.Write("Press Return To Begin:-");
            Console.ReadLine();

            // GetPlayers gets the numbers of token taken to play and assigns  to tokens array of length = {n,+...}
            int[] tokens = GetPlayers();

            // if two tokens are at play, find the one that goes first (dice == 6) 
            if (tokens.Length == 2)
            {
                token = WhoGoesFirst();
            }

            while (true)
            {
                // for 1 to total numbers of player move token.
                for (int playerToken = token; playerToken < tokens.Length; playerToken++)
                {
                    Console.WriteLine("Turn:{0}", turn++);
                    Console.ReadLine();

                    // Logic method has the player No. , Positioning of Token, and No. Dice rolled.
                    int logicResult = Logic(playerToken + 1, tokens[playerToken], RollDice());

                    if (logicResult == BoardLength) // if reached end
                    {
                        Console.WriteLine("Token: {0} Is The Winner !!!", playerToken + 1);
                        Console.ReadLine();
                        return; // - End
                    }

                    tokens[playerToken] = logicResult;
                    Console.WriteLine();
                    token = 0; // resetting var. will need to improve this. 
                }
            }
        }

        // method takes tokens/payers, its position on the board and dice number rand generator
        // position gets changed based on the Random Class Obj and BoardUpDown Dictionary 
        private static int Logic(int tokens, int position, int dice)
        {
            while (true)
            {
                Console.Write("Token: {0} on square {1}, rolls a {2}", tokens, position, dice);

                // final stage of game
                if (position + dice > BoardLength)
                {
                    Console.WriteLine(" couldn't reach to {0}.", BoardLength);
                }
                else // normal
                {
                    position += dice;
                    Console.WriteLine(" and moves to square {0}", position);

                    if (position == BoardLength) // game end
                    {
                        return BoardLength;
                    }

                    // look at dictionary key-value keys and retrive the value if exists.
                    if (BoardUpDown.ContainsKey(position))
                    {
                        // if Tkey exist replace with Tvalue 
                        var nextPosition = BoardUpDown[position];

                        // if ladder or snake
                        if (position < nextPosition)
                        {
                            Console.WriteLine("Token: {0} Landed on a Ladder. Climbs up to square: {1}.", tokens,
                                nextPosition);
                            position = nextPosition;
                        }
                        else if (position > nextPosition)
                        {
                            Console.WriteLine("Token: {0} Landed on a Snake. Moves down to square {1}.", tokens,
                                nextPosition);
                        }

                        // Else stay on the same square 
                    }
                }

                // current position
                return position;
            }
        }

        private static int WhoGoesFirst()
        {
            Console.WriteLine("Who Goes First");
            int dice = 0;
            //int token = 0;
            do
            {
                for (int token = 0; token < 2; token++)
                {
                    dice = RollDice();
                    Console.WriteLine("Token: {0} rolls a {1}", token + 1, dice);
                    Console.ReadLine();
                    if (dice == 6)
                    {
                        Console.WriteLine("Token: {0}, Goes First!", token + 1);
                        Console.ReadLine();
                        return token;
                    }
                }
            } while (dice != 6);

            return 0;
        }

        public static int[] GetPlayers()
        {
            int numberOfPlayers;
            bool result;

            do
            {
                Console.WriteLine("Enter number of players: ");
                result = int.TryParse(Console.ReadLine(), out numberOfPlayers);
            } while (result == false);

            //int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

            int[] players = new int[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = 1;
            }

            return players;
        }

        private static int RollDice()
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            return dice;
        }

        // choose Dictionary for my board structure on how it flows.
        // with this I can control how the tokens are move when on a specific square
        //
        private static readonly Dictionary<int, int> BoardUpDown = new Dictionary<int, int>()
        {
            // there's a 2-12 ladder and snake combined
            // if you land on 2 -> move up to 12
            // if you land on 12 <- move down to 12
            // corresponding token will stay at the corresponding position
            {2, 12}, // ladder - move up from 2 to square 12
            {20, 30}, // ladder - move up from 20 square 30
            {40, 50}, // ladder - move up from 40 square 60
            {60, 70}, // ladder - move up from 40 square 60
            {80, 90}, // ladder - move up from 80 square 90
            {12, 2}, // snake - move down from 12 to square 2
            {15, 1}, // snake - move down from 15 to square 1
            {55, 45}, // snake - move down from 55 to square 45
            {75, 65}, // snake - move down from 75 to square 65
            {95, 85}, // snake - move down from 95 to square 85
        };
    }
}
