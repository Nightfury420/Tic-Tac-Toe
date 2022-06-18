using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tic_Tac_Toe
{
   /* class Board
    {
        private int n;

        public Board() { n = 3; }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

    }*/


    class Program
    {
        static char[] board = { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' };

        static int player = 1;

        static char playerChar1 = 'X';

        static char playerChar2 = 'O';

        static int pos;
        static void Main(string[] args)
        {

          /*  Board b = new Board();
            b.N = -454;
            Console.WriteLine(b.N);*/

            do
            {
                Console.Clear();

                Console.WriteLine("Tic Tac Toe Ver 0.0");

                Console.WriteLine("Player1({0}) vs Player2({1})", playerChar1, playerChar2);

                Board();  

                Console.Write("PLayer{0} turn", getChar());

                pos = Convert.ToInt32(Console.ReadLine());

                checkPosition();

                int flag = checkWin();

                if (flag == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Tic Tac Toe Ver 0.0");

                    Console.WriteLine("Player1({0}) vs Player2({1})", playerChar1, playerChar2);

                    Board();

                    Console.Write("Player {0} WINNN!!!, Nhan phim bat ky de choi lai: ", playerWin());

                    Console.ReadLine();

                    resetGame();
                }
                else if (flag == -1)
                {
                    Console.Clear();

                    Console.WriteLine("Tic Tac Toe Ver 0.0");

                    Console.WriteLine("Player1({0}) vs Player2({1})", playerChar1, playerChar2);

                    Board();

                    Console.Write("DRAWW !!!, Nhan phim bat ky de choi lai: ", playerWin());

                    Console.ReadLine();

                    resetGame();
                }

            } while (true);



            //MINE

            //int[,] m1 = new int[3,3];

            //             int player = 1;
            // nhap:
            //             if (player % 2 == 0)
            //                 Console.WriteLine("Player 2 turn (O)");
            //             else
            //                 Console.WriteLine("Player 1 turn (X)");

            //             Console.Write("Hello! plz enter ya number: ");
            //             int n = Convert.ToInt32(Console.ReadLine());

            //             char[] array1 = new char[] { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}; ;

            //             if (player % 2 == 0)
            //                 array1[n] = 'O';
            //             else
            //                 array1[n] = 'X';

            //             Console.WriteLine(array1[n]);

            //             player++;

            //             if ((array1[1] == 'O' && array1[5] == 'O') && array1[9] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }

            //             else if ((array1[1] == 'O' && array1[2] == 'O') && array1[3] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }     

            //             else if ((array1[7] == 'O' && array1[8] == 'O') && array1[9] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }  

            //             else if ((array1[1] == 'O' && array1[4] == 'O') && array1[7] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }  

            //             else if ((array1[3] == 'O' && array1[6] == 'O') && array1[9] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }  

            //             else if ((array1[2] == 'O' && array1[5] == 'O') && array1[8] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }  

            //             else if ((array1[3] == 'O' && array1[5] == 'O') && array1[8] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }
            //             else if ((array1[4] == 'O' && array1[5] == 'O') && array1[6] == 'O')
            //             {
            //                Console.WriteLine("PLAYER 2 WINNNN!");
            //                goto end;
            //             }

            //             else if ((array1[1] == 'X' && array1[5] == 'X') && array1[9] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }

            //             else if ((array1[1] == 'X' && array1[2] == 'X') && array1[3] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }     

            //             else if ((array1[7] == 'X' && array1[8] == 'X') && array1[9] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }  

            //             else if ((array1[1] == 'X' && array1[4] == 'X') && array1[7] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }  

            //             else if ((array1[3] == 'X' && array1[6] == 'X') && array1[9] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }  

            //             else if ((array1[2] == 'X' && array1[5] == 'X') && array1[8] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }

            //             else if ((array1[3] == 'X' && array1[5] == 'X') && array1[8] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }

            //             else if ((array1[4] == 'X' && array1[5] == 'X') && array1[6] == 'X')
            //             {
            //                Console.WriteLine("PLAYER 1 WINNNN!");
            //                goto end;
            //             }

            //             else if (array1[1] == '-' || array1[2] == '-' || array1[3] == '-' || array1[4] == '-' || array1[5] == '-' || array1[6] == '-' || array1[7] == '-' || array1[8] == '-' || array1[9] == '-')
            //                 goto nhap;

            //             else
            //             {
            //                Console.WriteLine("YA DRAW!!!!");
            //                goto end;
            //             }


            // end:

            //             return ;
        }

        private static char playerWin()
        {
            player = player % 2 == 0 ? 1 : 2;

            return getChar();
        }

        private static void resetGame()
        {
            for (int i = 1; i < 9; i++)
                board[i] = '-';

            player = 1;
        }
        
        private static int checkWin()
        {
            int i;
            for ( i = 1; i <= 9; i++)
            {
                if (board[i] == '-')
                    break;
                
            }
            if (board[1] == board[2] && board[2] == board[3] && board[2] != '-')
                return 1;
            else if (board[4] == board[5] && board[5] == board[6] && board[4] != '-')
                return 1;
            else if (board[7] == board[8] && board[8] == board[9] && board[7] != '-')
                return 1;
            else if (board[1] == board[4] && board[4] == board[7] && board[4] != '-')
                return 1;
            else if (board[2] == board[5] && board[5] == board[8] && board[5] != '-')
                return 1;
            else if (board[3] == board[6] && board[6] == board[9] && board[6] != '-')
                return 1;
            else if (board[1] == board[5] && board[5] == board[9] && board[5] != '-')
                return 1;
            else if (board[3] == board[5] && board[5] == board[7] && board[5] != '-')
                return 1;

            if (i > 9)
                return -1;

            return 0;
        }

        private static char getChar()
        {
           return player % 2 == 0 ? playerChar1 : playerChar2;
        }
        
        private static void checkPosition()
        {
            char c = board[pos];
            
            if (c == playerChar1 || c == playerChar2)
            {
                Console.WriteLine("Vi tri da dung");
                
                Thread.Sleep(1500);
                
                return;
            }
            
            board[pos] = getChar();
            
            player++;
        
        }
        
        private static char getplayerChar(char c)
        {
            if (c == '-')
            {
                return ' ';
            }

            return c;
        }

        private static void Board()
        {
            //Console.WriteLine("     |     |     ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", getplayerChar(board[1]), getplayerChar(board[2]), getplayerChar(board[3]));

            Console.WriteLine("-----+-----+-----");

            Console.WriteLine("  {0}  |  {1}  |  {2}", getplayerChar(board[4]), getplayerChar(board[5]), getplayerChar(board[6]));

            Console.WriteLine("-----+-----+-----");

            Console.WriteLine("  {0}  |  {1}  |  {2}", getplayerChar(board[7]), getplayerChar(board[8]), getplayerChar(board[9]));

            Console.WriteLine("-----+-----+-----");
        }
    }
}
