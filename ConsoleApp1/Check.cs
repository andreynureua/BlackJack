using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace ConsoleApp1
{
    
    public static class Check
    {

        private const int WinPoints = 21;

        public static int CheckInput()
        {
            try
            {
                int a = Convert.ToInt32(Show.ReadLine());
                return a;
            }
            catch (FormatException)
            {
                
                return 0;
            }
        }

        public static void MoreCards(Player player, Deck deck)
        {
            if(!UserPlay(player, deck))
            {
                ComputerPlay(player, deck);
            }   
        }
            
        public static void CheckZeroBalance (int blnc)
        {
            if (blnc <= 0)
            {
                Show.ZeroBalance();
                bool newgame = CheckAnswer(Show.ReadLine().ToLower());
                if (newgame)
                {
                    var fileName = Assembly.GetExecutingAssembly().Location;
                    System.Diagnostics.Process.Start(fileName);
                    Environment.Exit(0);
                }
                else Environment.Exit(0);
            }   
        }

        public static bool UserPlay(Player player, Deck deck)
        {
            bool checkanswer;
            do
            {
                Show.PrintPoints(player.Cards);
                Show.OneMoreCard();
                checkanswer = CheckAnswer(Show.ReadLine().ToLower());
                if (checkanswer)
                {
                    List<Card> temp = player.GetCard(deck, 1);
                    Show.PrintCard(temp);
                    if (IsTwentyOne(AmountPoints(player.Cards)))
                    {
                        Show.PrintPoints(player.Cards);
                        Show.YouWin();
                        player.balance += player.bet;
                        return true;
                    }
                    if (IsMoreTwentyOne(AmountPoints(player.Cards)))
                    {
                        Show.PrintPoints(player.Cards);
                        Show.YouLose();
                        player.balance -= player.bet;
                        return true; 
                    }
                }
            }
            while (checkanswer);
            return false;
        }

        public static void ComputerPlay(Player player, Deck deck)
        {
            int userPoints = AmountPoints(player.Cards);
            int computerPoints = ComputerPlay(deck, userPoints);
            if (IsMoreTwentyOne(computerPoints))
            {
                Show.YouWin();
                player.balance += player.bet;
            }
            if (computerPoints > userPoints & computerPoints < (WinPoints + 1))
            {
                Show.YouLose();
                player.balance -= player.bet;
            }
        }

        public static bool PlayGame()
        {
            Show.NewGame();
            return CheckAnswer(Show.ReadLine().ToLower());
        }

        public static bool CheckAnswer(string str)
        {
            return str == "y" ? true : false;
        }
        
        public static int AmountPoints(IEnumerable<Card> list)
        { 
            return list.Sum(x => x.Value); ;
        }

        public static bool IsMoreTwentyOne(int sum)
        {
            return sum > WinPoints ? true : false;
        }

        public static bool IsTwentyOne(int sum)
        {
            return sum == WinPoints ? true : false;
        }

        public static int CheckBet(int balance)
        {
            Show.Balance(balance);
            Show.Bet();
            int bet;
            do
            {
                bet = CheckInput();
                if (bet < 0)
                {
                    Show.BetLessThanZero();
                }
                if (bet == 0)
                {
                    Show.NotANumber();
                }
                if (balance - bet < 0)
                {
                    Show.BetMoreThanBalance();
                }
            }
            while (bet <= 0 | (balance - bet < 0));
            return bet;
        }

        public static int ComputerPlay(Deck deck, int userPoints)
        {
            Player comp = new Player();
            Show.ComputerCards();
            Show.EmptyLine();
            do
            {
                List<Card> temp = comp.GetCard(deck, 1);
                Show.PrintCard(temp);
            }
            while (AmountPoints(comp.Cards) <= userPoints);
            Show.AmountPoint(AmountPoints(comp.Cards));
            return AmountPoints(comp.Cards);
        }

        public static void Start()
        {
            Player pl = new Player();
            bool playgame;
            Show.UserCards();
            do
            {
                Deck deck = new Deck();
                deck.Mix();
                playgame = PlayGame();
                if (!playgame)
                    Environment.Exit(0);
                CheckZeroBalance(pl.balance);
                pl.bet = CheckBet(pl.balance);
                List<Card> cards = pl.GetCard(deck, 2);
                Show.PrintCard(cards);
                MoreCards(pl, deck);
                pl.Cards.Clear();
            }
            while (playgame);
        }
    }
}
