using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tic_Tac_Toe
{
    class Program
    {
        static char[,] board = {
            {'-', '-', '-' },
            {'-', '-', '-' },
            {'-', '-', '-' },
        };

        static char[,] board4x4 = {
            {'-', '-', '-' , '-'},
            {'-', '-', '-' , '-'},
            {'-', '-', '-' , '-'},
            {'-', '-', '-', '-'},
        };

        static char[,] board5x5 = {
            {'-', '-', '-' , '-', '-'},
            {'-', '-', '-' , '-', '-'},
            {'-', '-', '-' , '-', '-'},
            {'-', '-', '-', '-', '-'},
            {'-', '-', '-', '-', '-'},
        };

        static int gameMode = 0;

        static int player = 1;

        static char playerChar1 = 'X';

        static char playerChar2 = 'O';

        static int pos;

        static void Main(string[] args)
        {
start:
            Console.Clear();

            Console.WriteLine("Tic Tac Toe Ver 1.0");

            Console.WriteLine("1. 3x3");

            Console.WriteLine("2. 4x4");

            Console.WriteLine("3. 5x5");

            Console.Write("Xin chon game mode(1-3): ");

            int mode = Convert.ToInt32(Console.ReadLine());

            if (mode == 1)
            {
                gameMode = 3;
            }
            else if (mode == 2)
            {
                gameMode = 4;

                board = board4x4;
            }
            else if (mode == 3)
            {
                gameMode = 5;

                board = board5x5;
            }



            do
            {
                Console.Clear();

                Console.WriteLine("Tic Tac Toe Ver 0.0");

                Console.WriteLine("Player1({0}) vs CPU({1})", playerChar2, playerChar1);

                Board();

                if (getChar() == playerChar2)
                {
                    Console.Write("PLayer {0} turn enter (0-8): ", getChar());

                    pos = Convert.ToInt32(Console.ReadLine());

                    checkPosition();
                }
                else if (getChar() == playerChar1)
                {
                    cpu();
                }

                int flag = checkWin();

                if (flag == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Tic Tac Toe Ver 0.0");

                    Console.WriteLine("Player1({0}) vs CPU({1})", playerChar2, playerChar1);

                    Board();

                    Console.Write("Player {0} WINNN!!!, Nhan Y de choi lai: ", playerWin());

                    char y = char.Parse(Console.ReadLine());

                    if (y == 'Y' || y == 'y')
                    {
                        resetGame();

                        goto start;
                    }
                    else
                        break;

                }
                else if (flag == -1)
                {
                    Console.Clear();

                    Console.WriteLine("Tic Tac Toe Ver 0.0");

                    Console.WriteLine("Player1({0}) vs CPU({1})", playerChar2, playerChar1);

                    Board();

                    Console.Write("DRAWW !!!, Nhan Y de choi lai: ", playerWin());

                    char y = char.Parse(Console.ReadLine());

                    if (y == 'Y' || y == 'y')
                    {
                        resetGame();

                        goto start;
                    }
                    else
                        break;
                }

            } while (true);

        }

        private static void cpu()
        {
            int[] I = new int[30];

            int[] J = new int[30];

            int count = 0;

            for (int i = 0; i < gameMode; i++)
            {
                for (int j = 0; j < gameMode; j++)
                {
                    if (board[i, j] == '-')
                    {
                        I[count] = i;

                        J[count] = j;

                        count++;
                    }

                }
            }

            Random randomat = new Random();
            int randy = randomat.Next(count);

            board[I[randy], J[randy]] = playerChar1;

            player++; ;
        }

        private static char playerWin()
        {
            player = player % 2 == 0 ? 1 : 2;

            return getChar();
        }

        private static void resetGame()
        {
            for (int i = 0; i < gameMode; i++)
                for (int j = 0; j < gameMode; j++)
                    board[i, j] = '-';

            player = 1;
        }

        private static int checkWin()
        {
            int c;
            for (c = 0; c < gameMode; c++)
            {
                for (int j = 0; j < gameMode; j++)
                    if (board[c, j] == '-')
                        break;
            }

            if (checkCrossesLeftToRight() == 1 || checkCrossesLeftToRight() == 2)
                return 1;

            if (checkCrossesRightToLeft() == 1 || checkCrossesRightToLeft() == 2)
                return 1;

            for (int i = 0; i < gameMode; i++)
            {
                for (int j = 0; j < gameMode; j++)
                {
                    if (board[i, j] != '-')
                    {
                        if (j == 0)
                        {
                            int q = 0;
                            int m = board[i, j];
                            for (int k = j; k < gameMode; k++)
                            {
                                if (board[i, k] == m)
                                    q++;
                                if (q == gameMode)
                                    return 1;
                            }
                        }
                        else if (j >= 1 && j != gameMode - 1)
                        {
                            int q = 1;
                            int m = board[i, j];
                            for (int k = j + 1; k < gameMode; k++)
                            {
                                if (board[i, k] == m)
                                    q++;
                            }
                            for (int k = j - 1; k != -1; k--)
                            {
                                if (board[i, k] == m)
                                    q++;
                            }
                            if (q == gameMode)
                                return 1;
                        }
                        else if (j == gameMode - 1)
                        {
                            int q = 0;
                            int m = board[i, j];
                            for (int k = gameMode - 1; k != -1; k--)
                            {
                                if (board[i, k] == m)
                                    q++;
                                if (q == gameMode)
                                    return 1;
                            }
                        }
                        if (checkDown(i, j) == 1)
                            return 1;
                    }
                }
            }

            if (c > 9)
                return -1;

            return 0;
        }

        private static int checkCrossesLeftToRight()
        {
            int j = 0;
            int x = 0;
            int o = 0;

            for (int i = 0; i < gameMode; i++)
            {
                if (board[i, j] == playerChar1)
                    x++;
                else if (board[i, j] == playerChar2)
                    o++;
                j++;
            }

            if (x == gameMode)
                return 1;
            else if (o == gameMode)
                return 2;

            return 0;

        }

        private static int checkCrossesRightToLeft()
        {
            int j = gameMode - 1;
            int x = 0;
            int o = 0;

            for (int i = 0; i < gameMode; i++)
            {
                if (board[i, j] == playerChar1)
                    x++;
                else if (board[i, j] == playerChar2)
                    o++;
                j--;
            }

            if (x == gameMode)
                return 1;
            else if (o == gameMode)
                return 2;


            return 0;
        }

        private static int checkDown(int i, int j)
        {
            if (i == 0)
            {
                int q = 0;
                int m = board[i, j];
                for (int k = 0; k < gameMode; k++)
                {
                    if (board[k, j] == m)
                        q++;
                    if (q == gameMode)
                        return 1;
                }
            }
            else if (i >= 1 && i != gameMode - 1)
            {
                int q = 1;
                int m = board[i, j];
                for (int k = i + 1; k < gameMode; k++)
                {
                    if (board[k, j] == m)
                        q++;
                }
                for (int k = i - 1; k != -1; k--)
                {
                    if (board[k, j] == m)
                        q++;
                }
                if (q == gameMode)
                    return 1;
            }
            else if (i == gameMode - 1)
            {
                int q = 0;
                int m = board[i, j];
                for (int k = i; k != -1; k--)
                {
                    if (board[k, j] == m)
                        q++;
                    if (q == gameMode)
                        return 1;
                }

            }

            return 0;
        }

        private static char getChar()
        {
            return player % 2 == 0 ? playerChar1 : playerChar2;
        }

        private static void checkPosition()
        {
            int t = 0;
            int m = 0;
            int s = 0;
            for (int i = 0; i < gameMode; i++)
            {
                for (int j = 0; j < gameMode; j++)
                {
                    if (i * gameMode + j == pos)
                    {
                        m = i;
                        s = j;
                        t++;
                    }
                }
            }

            if (t == 0)
            {
                Console.WriteLine("So khong dung");

                Thread.Sleep(1500);

                return;
            }


            char c = board[m, s];

            if (c == playerChar1 || c == playerChar2)
            {
                Console.WriteLine("Vi tri da dung");

                Thread.Sleep(1500);

                return;
            }

            board[m, s] = getChar();

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
            if (gameMode == 3)
            {
                Console.Write("  {0}  |  {1}  |  {2}", getplayerChar(board[0, 0]), getplayerChar(board[0, 1]), getplayerChar(board[0, 2]));

                Console.Write("\t\t    Ex:");

                Console.WriteLine("\t|  0  |  1  |  2  |");

                Console.Write("-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}", getplayerChar(board[1, 0]), getplayerChar(board[1, 1]), getplayerChar(board[1, 2]));

                Console.WriteLine("\t\t\t|  3  |  4  |  5  |");

                Console.Write("-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}", getplayerChar(board[2, 0]), getplayerChar(board[2, 1]), getplayerChar(board[2, 2]));

                Console.WriteLine("\t\t\t|  6  |  7  |  8  |");

                Console.Write("-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+");
            }
            else if (gameMode == 4)
            {
                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |", getplayerChar(board[0, 0]), getplayerChar(board[0, 1]), getplayerChar(board[0, 2]), getplayerChar(board[0, 3]));

                Console.Write("\t    Ex:");

                Console.WriteLine("\t|  0  |  1  |  2  |  3  |");

                Console.Write("-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |", getplayerChar(board[1, 0]), getplayerChar(board[1, 1]), getplayerChar(board[1, 2]), getplayerChar(board[1, 3]));

                Console.WriteLine("\t\t|  4  |  5  |  6  |  7  |");

                Console.Write("-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |", getplayerChar(board[2, 0]), getplayerChar(board[2, 1]), getplayerChar(board[2, 2]), getplayerChar(board[2, 3]));

                Console.WriteLine("\t\t|  8  |  9  |  10 |  11 |");

                Console.Write("-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |", getplayerChar(board[3, 0]), getplayerChar(board[3, 1]), getplayerChar(board[3, 2]), getplayerChar(board[3, 3]));

                Console.WriteLine("\t\t|  12 |  13 |  14 |  15 |");

                Console.Write("-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+");
            }
            else if (gameMode == 5)
            {
                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", getplayerChar(board[0, 0]), getplayerChar(board[0, 1]), getplayerChar(board[0, 2]), getplayerChar(board[0, 3]), getplayerChar(board[0, 4]));

                Console.Write("\t    Ex:");

                Console.WriteLine("\t|  0  |  1  |  2  |  3  |  4  |");

                Console.Write("-----+-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", getplayerChar(board[1, 0]), getplayerChar(board[1, 1]), getplayerChar(board[1, 2]), getplayerChar(board[1, 3]), getplayerChar(board[1, 4]));

                Console.WriteLine("\t\t|  5  |  6  |  7  |  8  |  9  |");

                Console.Write("-----+-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", getplayerChar(board[2, 0]), getplayerChar(board[2, 1]), getplayerChar(board[2, 2]), getplayerChar(board[2, 3]), getplayerChar(board[2, 4]));

                Console.WriteLine("\t\t|  10 |  11 |  12 |  13 |  14 |");

                Console.Write("-----+-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", getplayerChar(board[3, 0]), getplayerChar(board[3, 1]), getplayerChar(board[3, 2]), getplayerChar(board[3, 3]), getplayerChar(board[3, 4]));

                Console.WriteLine("\t\t|  15 |  16 |  17 |  18 |  19 |");

                Console.Write("-----+-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+-----+");

                Console.Write("  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |", getplayerChar(board[4, 0]), getplayerChar(board[4, 1]), getplayerChar(board[4, 2]), getplayerChar(board[4, 3]), getplayerChar(board[4, 4]));

                Console.WriteLine("\t\t|  20 |  21 |  22 |  23 |  24 |");

                Console.Write("-----+-----+-----+-----+-----+");

                Console.WriteLine("\t\t------+-----+-----+-----+-----+");
            }

        }


    }
}
