using System;

namespace Kolko_krzyzyk
{
    class Program
    {
        static String[] board = new String[9];
        static String ponownie = "T";
        static int counter = 0;

        static void initializeVariable()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = i.ToString();
            }
        }

        static void ponownieMsg(String message)
        {
            Console.WriteLine(message + " Chcesz zagrać ponownie? T/N");
            if (Console.ReadLine().Equals("T"))
                ponownie.Equals("T");
            else
                ponownie.Equals("N");
        }

        static void Main(string[] args)
        {
            wstep();
            while (ponownie.Equals("T"))
            {
                initializeVariable();
                while (hasWon() == false && counter <= 9)
                {
                    askData("X");
                    if (hasWon() == true)
                        break;
                    askData("O");
                }
                if (hasWon() == true)
                    ponownieMsg("Brawo, wygrałeś!");
                else
                    ponownieMsg("Tym razem remis!");
            }
            dozobaczenia();
        }

        static void dozobaczenia()
        {
            Console.WriteLine("Do zobaczenia.");
            Console.ReadLine();

        }

        static void askData(String gracz)
        {
            Console.Clear();

            Console.WriteLine("Gracz: " + gracz);
            int wybor;

            while (true)
            {
                Console.WriteLine("Dokonaj wyboru.");
                drawBoard();
                wybor = Convert.ToInt32(Console.ReadLine());
                if (wybor < 0 || wybor > 8 || (board[wybor].Equals("X") || board[wybor].Equals("O")))
                    Console.WriteLine("Pole zajęte, wybierz inne!");
                else
                    break;
            }
            board[wybor] = gracz;


        }

        static void drawBoard()
        {
            for (int i = 0; i < 7; i += 3)
                Console.WriteLine(board[i] + "|" + board[i + 1] + "|" + board[i + 2]);
        }

        static Boolean hasWon()
        {
            for (int i = 0; i < 7; i += 3)
            {
                if (board[i].Equals(board[i + 1]) && board[i + 1].Equals(board[i + 2]))
                {
                    return true;
                }
            }
            if (board[0].Equals(board[3]) && board[3].Equals(board[6]))
                return true;
            if (board[1].Equals(board[4]) && board[4].Equals(board[7]))
                return true;
            if (board[2].Equals(board[5]) && board[3].Equals(board[8]))
                return true;
            if (board[2].Equals(board[4]) && board[4].Equals(board[6]))
                return true;
            if (board[0].Equals(board[4]) && board[4].Equals(board[8]))
                return true;
            return false;
        }


        static void wstep()
        {
            Console.Title = ("Kółko i krzyżyk");
            Console.WriteLine("Witaj w mojej grze.\n");
            Console.WriteLine("Wciśnij dowolny przycisk.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}