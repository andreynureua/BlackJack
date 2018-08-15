using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Show
    {
        public static void OneMoreCard()
        {
            Console.WriteLine("Do you want one more card? y/n");
        }

        public static void YouWin()
        {
            Console.WriteLine("You win");
        }

        public static void YouLose()
        {
            Console.WriteLine("You lose");
        }

        public static void AmountPoint(int points)
        {
            Console.WriteLine($"Amount of points is {points}");
        }

        public static void ZeroBalance ()
        {
            Console.WriteLine("Your balance is 0, do you want a play new game? y/n");
        }

        public static void NewGame()
        {
            Console.WriteLine("Do you want to play a game? y/n ");
        }

        public static void Balance(int blnce)
        {
            Console.WriteLine($"Your balance is {blnce}$");
        }

        public static void Bet()
        {
            Console.WriteLine("How much would you like to bet?");
        }

        public static void ComputerCards()
        {
            Console.Write("Computer cards are : ");
        }

        public static void PrintPoints(IEnumerable<Card> list)
        {
            int count = Check.AmountPoints(list);
            AmountPoint(count);
        }

        public static void PrintCard(IEnumerable<Card> cards)
        {
            foreach (Card card in cards)
                Console.WriteLine($@"     {card.CardName.ToString()} of {card.CardSuit.ToString()}");
        }

        public static void NotANumber()
        {
            Console.WriteLine("You didn't enter a number or entered 0, you can't play to zero, please try again");
        }

        public static void BetLessThanZero()
        {
            Console.WriteLine("You can not enter a bet that is less than zero, please try again");
        }

        public static void BetMoreThanBalance()
        {
            Console.WriteLine("You can not enter a bet that exceeds your balance, please try again");
        }

        public static void UserCards()
        {
            Console.WriteLine("Your cards are: ");
        }

        public static void EmptyLine()
        {
            Console.WriteLine();
        }

        public static string ReadLine()
        {
            string s = Console.ReadLine();
            return s;
        }
    }
}
