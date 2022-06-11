using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static char[] board = { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' };

        static int player = 1;

        static char playerChar1 = 'X';

        static char playerChar2 = 'O';

        static int pos;
        static void Main(string[] args)
        {
            do 
            {
                Console.WriteLine("Tic Tac Toe Ver 0.0");

                Console.WriteLine("Player1({0}) vs Player2({1})", playerChar1, playerChar2);

                Board();
                
                Console.WriteLine("PLayer{0} turn", getChar());
                
                pos = Console.ReadLine();
            }while {};
            
            
            
            //MINE

            //int[,] m1 = new int[3,3];

            int player = 1;
nhap:
            if (player % 2 == 0)
                Console.WriteLine("Player 2 turn (O)");
            else
                Console.WriteLine("Player 1 turn (X)");
            
            Console.Write("Hello! plz enter ya number: ");
            int n = Convert.ToInt32(Console.ReadLine());

            char[] array1 = new char[] { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}; ;

            if (player % 2 == 0)
                array1[n] = 'O';
            else
                array1[n] = 'X';

            Console.WriteLine(array1[n]);

            player++;

            if ((array1[1] == 'O' && array1[5] == 'O') && array1[9] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }
            
            else if ((array1[1] == 'O' && array1[2] == 'O') && array1[3] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }     
            
            else if ((array1[7] == 'O' && array1[8] == 'O') && array1[9] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }  
            
            else if ((array1[1] == 'O' && array1[4] == 'O') && array1[7] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }  
            
            else if ((array1[3] == 'O' && array1[6] == 'O') && array1[9] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }  

            else if ((array1[2] == 'O' && array1[5] == 'O') && array1[8] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }  

            else if ((array1[3] == 'O' && array1[5] == 'O') && array1[8] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }
            else if ((array1[4] == 'O' && array1[5] == 'O') && array1[6] == 'O')
            {
               Console.WriteLine("PLAYER 2 WINNNN!");
               goto end;
            }

            else if ((array1[1] == 'X' && array1[5] == 'X') && array1[9] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }
            
            else if ((array1[1] == 'X' && array1[2] == 'X') && array1[3] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }     
            
            else if ((array1[7] == 'X' && array1[8] == 'X') && array1[9] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }  
            
            else if ((array1[1] == 'X' && array1[4] == 'X') && array1[7] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }  
            
            else if ((array1[3] == 'X' && array1[6] == 'X') && array1[9] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }  

            else if ((array1[2] == 'X' && array1[5] == 'X') && array1[8] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }

            else if ((array1[3] == 'X' && array1[5] == 'X') && array1[8] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }

            else if ((array1[4] == 'X' && array1[5] == 'X') && array1[6] == 'X')
            {
               Console.WriteLine("PLAYER 1 WINNNN!");
               goto end;
            }

            else if (array1[1] == '-' || array1[2] == '-' || array1[3] == '-' || array1[4] == '-' || array1[5] == '-' || array1[6] == '-' || array1[7] == '-' || array1[8] == '-' || array1[9] == '-')
                goto nhap;

            else
            {
               Console.WriteLine("YA DRAW!!!!");
               goto end;
            }
               
            
end:
            
            return 0;
        }
        
        private static char getChar()
        {
           return player % 2 == 0 ? playerChar1 : playerChar2;
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
