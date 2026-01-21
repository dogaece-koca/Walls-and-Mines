using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp7
{
    internal class Program
    {
        static void stats()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(59, 2);
            Console.Write("Score:        ");
            Console.SetCursorPosition(59, 4);
            Console.Write("Mines:        ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(59, 1);
            Console.Write("Time:         ");
            Console.SetCursorPosition(59, 3);
            Console.Write("Energy:       ");
            Console.SetCursorPosition(59, 6);
            Console.Write("Highest Score (level 1):");
            Console.SetCursorPosition(59, 7);
            Console.Write("Highest Score (level 2):");
            Console.SetCursorPosition(59, 8);
            Console.Write("Highest Score (level 3):");
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            int n, level, highest1 = 0, highest2 = 0, highest3 = 0;
            bool check = true;

            stats();

            void all()
            {
                stats();

                Random random = new Random();

                string[,] walls = new string[23, 53];

                void wallFunction(int k, int t)
                {
                    int up, down, left, right;
                    do
                    {
                        up = random.Next(0, 2);
                        down = random.Next(0, 2);
                        left = random.Next(0, 2);
                        right = random.Next(0, 2);
                    }
                    while (up + down + left + right == 4 || up + down + left + right == 0);

                    if (up == 0)
                    {
                        walls[k + 2, t + 2] = "#";
                        walls[k + 2, t + 3] = "#";
                        walls[k + 2, t + 4] = "#";
                        walls[k + 2, t + 5] = "#";
                    }
                    if (down == 0)
                    {
                        walls[k + 5, t + 2] = "#";
                        walls[k + 5, t + 3] = "#";
                        walls[k + 5, t + 4] = "#";
                        walls[k + 5, t + 5] = "#";
                    }
                    if (left == 0)
                    {
                        walls[k + 2, t + 2] = "#";
                        walls[k + 3, t + 2] = "#";
                        walls[k + 4, t + 2] = "#";
                        walls[k + 5, t + 2] = "#";
                    }
                    if (right == 0)
                    {
                        walls[k + 2, t + 5] = "#";
                        walls[k + 3, t + 5] = "#";
                        walls[k + 4, t + 5] = "#";
                        walls[k + 5, t + 5] = "#";
                    }
                }

                for (int k = 0; k < walls.GetLength(0) - 5; k += 5)
                {
                    for (int t = 0; t < walls.GetLength(1) - 5; t += 5)
                    {
                        wallFunction(k, t);
                    }
                }

                for (int i = 0; i < walls.GetLength(0); i++)
                {
                    for (int j = 0; j < walls.GetLength(1); j++)
                    {
                        if (i == 0 || j == 0 || i == walls.GetLength(0) - 1 || j == walls.GetLength(1) - 1) walls[i, j] = "#";
                        if (walls[i, j] == null) walls[i, j] = " ";

                        Console.SetCursorPosition(j, i);
                        Console.Write(walls[i, j]);
                    }
                }

                int time = -1, score = 0, energy = 200, mine = 0;

                int playerx = random.Next(1, 52), playery = random.Next(1, 22);
                while (walls[playery, playerx] != " ")
                {
                    playerx = random.Next(1, 52);
                    playery = random.Next(1, 22);
                }

                void enemy(string c)
                {
                    int x = random.Next(1, 52), y = random.Next(1, 22);
                    while (walls[y, x] != " " || (y == playery && x == playerx))
                    {
                        x = random.Next(1, 52);
                        y = random.Next(1, 22);
                    }
                    walls[y, x] = c;
                }
                enemy("X"); enemy("X"); enemy("Y"); enemy("Y");

                void numFunction(int a)
                {
                    for (int i = 0; i < a; i++)
                    {
                        int Number, num = random.Next(1, 11);
                        if (num >= 1 && num < 7)
                        {
                            Number = 1;
                        }
                        else if (num >= 7 && num <= 9)
                        {
                            Number = 2;
                        }
                        else
                        {
                            Number = 3;
                        }

                        int Numx = random.Next(1, 52), Numy = random.Next(1, 22);
                        while (walls[Numy, Numx] != " " || (Numy == playery && Numx == playerx))
                        {
                            Numx = random.Next(1, 52);
                            Numy = random.Next(1, 22);
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(Numx, Numy);
                        Console.Write(Number);
                        walls[Numy, Numx] = Convert.ToString(Number);
                    }
                }
                numFunction(20);

                void playerFunction()
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(playerx, playery);
                    Console.Write("P");
                }
                playerFunction();

                void scoreFunction()
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(66, 2);
                    Console.Write(score);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                scoreFunction();

                void scoreMineFunction(int fi, int fj, int si, int sj)
                {
                    walls[fi, fj] = " ";
                    Console.SetCursorPosition(fj, fi);
                    Console.Write(" ");
                    walls[si, sj] = " ";
                    Console.SetCursorPosition(sj, si);
                    Console.Write(" ");
                    score += 300;
                    scoreFunction();
                }

                void energyFunction()
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(67, 3);
                    Console.Write(energy + " ");
                }
                energyFunction();

                void mineFunction()
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.SetCursorPosition(66, 4);
                    Console.Write(mine + " ");
                }
                mineFunction();

                void Wallchanges()
                {
                    string op = random.Next(0, 2) == 0 ? "#" : " ";

                    int xx = (random.Next(0, 10) * 5) + 1, yy = (random.Next(0, 4) * 5) + 1, choosedir = random.Next(0, 4);
                    int up = 0, down = 0, left = 0, right = 0;

                    if (walls[yy + 2, xx + 1] == "#") left++;
                    if (walls[yy + 1, xx + 2] == "#") up++;
                    if (walls[yy + 4, xx + 2] == "#") down++;
                    if (walls[yy + 2, xx + 4] == "#") right++;

                    do
                    {
                        op = random.Next(0, 2) == 0 ? "#" : " ";

                        xx = random.Next(0, 10) * 5 + 1;
                        yy = random.Next(0, 4) * 5 + 1;

                        up = 0; down = 0; left = 0; right = 0;

                        if (walls[yy + 2, xx + 1] == "#") left++;
                        if (walls[yy + 1, xx + 2] == "#") up++;
                        if (walls[yy + 4, xx + 2] == "#") down++;
                        if (walls[yy + 2, xx + 4] == "#") right++;
                    }
                    while ((choosedir == 0 && (walls[yy + 2, xx + 1] == op || (left == 1 && up == 0 && down == 0 && right == 0) || (left == 0 && up == 1 && down == 1 && right == 1) || (op == "#" && (walls[yy + 2, xx + 1] != " " || walls[yy + 3, xx + 1] != " " || (walls[yy + 1, xx + 1] != " " && walls[yy + 1, xx + 1] != "#") || (walls[yy + 4, xx + 1] != " " && walls[yy + 4, xx + 1] != "#") || (yy + 1 == playery && xx + 1 == playerx) || (yy + 2 == playery && xx + 1 == playerx) || (yy + 3 == playery && xx + 1 == playerx) || (yy + 4 == playery && xx + 1 == playerx)))))
                        || (choosedir == 1 && (walls[yy + 1, xx + 2] == op || (left == 0 && up == 1 && down == 0 && right == 0) || (left == 1 && up == 0 && down == 1 && right == 1) || (op == "#" && (walls[yy + 1, xx + 2] != " " || walls[yy + 1, xx + 3] != " " || (walls[yy + 1, xx + 1] != " " && walls[yy + 1, xx + 1] != "#") || (walls[yy + 1, xx + 4] != " " && walls[yy + 1, xx + 4] != "#") || (yy + 1 == playery && xx + 1 == playerx) || (yy + 1 == playery && xx + 2 == playerx) || (yy + 1 == playery && xx + 3 == playerx) || (yy + 1 == playery && xx + 4 == playerx)))))
                        || (choosedir == 2 && (walls[yy + 4, xx + 2] == op || (left == 0 && up == 0 && down == 1 && right == 0) || (left == 1 && up == 1 && down == 0 && right == 1) || (op == "#" && (walls[yy + 4, xx + 2] != " " || walls[yy + 4, xx + 3] != " " || (walls[yy + 4, xx + 1] != " " && walls[yy + 4, xx + 1] != "#") || (walls[yy + 4, xx + 4] != " " && walls[yy + 4, xx + 4] != "#") || (yy + 4 == playery && xx + 1 == playerx) || (yy + 4 == playery && xx + 2 == playerx) || (yy + 4 == playery && xx + 3 == playerx) || (yy + 4 == playery && xx + 4 == playerx)))))
                        || (choosedir == 3 && (walls[yy + 2, xx + 4] == op || (left == 0 && up == 0 && down == 0 && right == 1) || (left == 1 && up == 1 && down == 1 && right == 0) || (op == "#" && (walls[yy + 2, xx + 4] != " " || walls[yy + 3, xx + 4] != " " || (walls[yy + 1, xx + 4] != " " && walls[yy + 1, xx + 4] != "#") || (walls[yy + 4, xx + 4] != " " && walls[yy + 4, xx + 4] != "#") || (yy + 1 == playery && xx + 4 == playerx) || (yy + 2 == playery && xx + 4 == playerx) || (yy + 3 == playery && xx + 4 == playerx) || (yy + 4 == playery && xx + 4 == playerx))))));

                    if (choosedir == 0)
                    {
                        walls[yy + 1, xx + 1] = op;
                        walls[yy + 2, xx + 1] = op;
                        walls[yy + 3, xx + 1] = op;
                        walls[yy + 4, xx + 1] = op;
                    }
                    if (choosedir == 1)
                    {
                        walls[yy + 1, xx + 1] = op;
                        walls[yy + 1, xx + 2] = op;
                        walls[yy + 1, xx + 3] = op;
                        walls[yy + 1, xx + 4] = op;
                    }
                    if (choosedir == 2)
                    {
                        walls[yy + 4, xx + 1] = op;
                        walls[yy + 4, xx + 2] = op;
                        walls[yy + 4, xx + 3] = op;
                        walls[yy + 4, xx + 4] = op;
                    }
                    if (choosedir == 3)
                    {
                        walls[yy + 1, xx + 4] = op;
                        walls[yy + 2, xx + 4] = op;
                        walls[yy + 3, xx + 4] = op;
                        walls[yy + 4, xx + 4] = op;
                    }

                    if (walls[yy + 1, xx + 1] == " ")
                    {
                        if (walls[yy + 1, xx + 2] == "#" || walls[yy + 2, xx + 1] == "#")
                            walls[yy + 1, xx + 1] = "#";
                    }
                    if (walls[yy + 1, xx + 4] == " ")
                    {
                        if (walls[yy + 1, xx + 3] == "#" || walls[yy + 2, xx + 4] == "#")
                            walls[yy + 1, xx + 4] = "#";
                    }
                    if (walls[yy + 4, xx + 1] == " ")
                    {
                        if (walls[yy + 4, xx + 2] == "#" || walls[yy + 3, xx + 1] == "#")
                            walls[yy + 4, xx + 1] = "#";
                    }
                    if (walls[yy + 4, xx + 4] == " ")
                    {
                        if (walls[yy + 4, xx + 3] == "#" || walls[yy + 3, xx + 4] == "#")
                            walls[yy + 4, xx + 4] = "#";
                    }

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    for (int i = 0; i < 4; i++)
                    {
                        switch (choosedir)
                        {
                            case 0:
                                Console.SetCursorPosition(xx + 1, yy + 1 + i);
                                Console.Write(walls[yy + 1 + i, xx + 1]);
                                break;
                            case 1:
                                Console.SetCursorPosition(xx + 1 + i, yy + 1);
                                Console.Write(walls[yy + 1, xx + 1 + i]);
                                break;
                            case 2:
                                Console.SetCursorPosition(xx + 1 + i, yy + 4);
                                Console.Write(walls[yy + 4, xx + 1 + i]);
                                break;
                            case 3:
                                Console.SetCursorPosition(xx + 4, yy + 1 + i);
                                Console.Write(walls[yy + 1 + i, xx + 4]);
                                break;
                        }
                    }
                }

                Console.SetCursorPosition(59, 15);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Press Esc to exit");

                int count = 0, speed = 32, slow = 1;

                while (true)
                {
                    if (count % slow == 0)
                    {
                        if (Console.KeyAvailable)
                        {
                            cki = Console.ReadKey(true);

                            if (walls[playery, playerx] != "+" && walls[playery, playerx] != "#")
                            {
                                Console.SetCursorPosition(playerx, playery);
                                Console.Write(" ");
                            }

                            if (cki.Key == ConsoleKey.RightArrow && walls[playery, playerx + 1] != "#" && walls[playery, playerx + 1] != "X" && walls[playery, playerx + 1] != "Y")
                            {
                                playerx++;
                                energy--;
                            }
                            if (cki.Key == ConsoleKey.LeftArrow && walls[playery, playerx - 1] != "#" && walls[playery, playerx - 1] != "X" && walls[playery, playerx - 1] != "Y")
                            {
                                playerx--;
                                energy--;
                            }
                            if (cki.Key == ConsoleKey.UpArrow && walls[playery - 1, playerx] != "#" && walls[playery - 1, playerx] != "X" && walls[playery - 1, playerx] != "Y")
                            {
                                playery--;
                                energy--;
                            }
                            if (cki.Key == ConsoleKey.DownArrow && walls[playery + 1, playerx] != "#" && walls[playery + 1, playerx] != "X" && walls[playery + 1, playerx] != "Y")
                            {
                                playery++;
                                energy--;
                            }
                            if (cki.KeyChar >= 97 && cki.KeyChar <= 102)
                            {
                                Console.SetCursorPosition(59, 21);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("pressed Key: " + cki.KeyChar);
                            }
                            if (cki.Key == ConsoleKey.Escape) break;

                            playerFunction();

                            if (walls[playery, playerx] == "+")
                            {
                                Console.SetCursorPosition(59, 15);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("GAME OVER        ");
                                break;
                            }

                            if (walls[playery, playerx] == "1")
                            {
                                score += 10;
                            }
                            if (walls[playery, playerx] == "2")
                            {
                                score += 30;
                                energy += 51;
                            }
                            if (walls[playery, playerx] == "3")
                            {
                                score += 90;
                                energy += 201;
                                mine++;
                            }
                            walls[playery, playerx] = " ";
                            scoreFunction();

                            if (cki.Key == ConsoleKey.Spacebar && mine > 0)
                            {
                                mine--;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(playerx, playery);
                                Console.Write("+");
                                walls[playery, playerx] = "+";
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            mineFunction();

                            if (energy <= 0)
                            {
                                energy = 0;
                                slow = 2;
                            }
                            else
                            {
                                slow = 1;
                            }
                            energyFunction();
                        }
                    }

                    if (count == (speed * 5))
                    {
                        Console.SetCursorPosition(59, 15);
                        Console.Write("                   ");
                    }

                    if ((count + 1) % (speed * 10) == 0)
                    {
                        string e = random.Next(0, 2) == 0 ? "X" : "Y";
                        enemy(e);
                    }

                    if (count % speed == 0)
                    {
                        Wallchanges();

                        numFunction(1);

                        time++;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.SetCursorPosition(65, 1);
                        Console.Write(time);
                    }

                    if (count % (speed / level) == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        for (int i = 0; i < walls.GetLength(0); i++)
                        {
                            for (int j = 0; j < walls.GetLength(1); j++)
                            {
                                if (walls[i, j] == "X")
                                {
                                    if (walls[i - 1, j] == ".")
                                    {
                                        walls[i - 1, j] = " ";
                                    }
                                    else if (walls[i, j - 1] == ".")
                                    {
                                        walls[i, j - 1] = " ";
                                    }
                                    else
                                    {
                                        if (j > playerx && walls[i, j - 1] != "X" && walls[i, j - 1] != "Y" && walls[i, j - 1] != "#")
                                        {
                                            if (walls[i, j - 1] == "+")
                                            {
                                                scoreMineFunction(i, j - 1, i, j);
                                            }
                                            else
                                            {
                                                walls[i, j] = " ";
                                                Console.SetCursorPosition(j, i);
                                                Console.Write(" ");
                                                walls[i, j - 1] = "X";
                                                Console.SetCursorPosition(j - 1, i);
                                                Console.Write("X");
                                            }
                                        }
                                        else if (j < playerx && walls[i, j + 1] != "X" && walls[i, j + 1] != "Y" && walls[i, j + 1] != "#")
                                        {
                                            if (walls[i, j + 1] == "+")
                                            {
                                                scoreMineFunction(i, j + 1, i, j);
                                            }
                                            else
                                            {
                                                walls[i, j] = ".";
                                                Console.SetCursorPosition(j, i);
                                                Console.Write(" ");
                                                walls[i, j + 1] = "X";
                                                Console.SetCursorPosition(j + 1, i);
                                                Console.Write("X");
                                            }
                                        }
                                        else
                                        {
                                            if (i > playery && walls[i - 1, j] != "X" && walls[i - 1, j] != "Y" && walls[i - 1, j] != "#")
                                            {
                                                if (walls[i - 1, j] == "+")
                                                {
                                                    scoreMineFunction(i - 1, j, i, j);
                                                }
                                                else
                                                {
                                                    walls[i, j] = " ";
                                                    Console.SetCursorPosition(j, i);
                                                    Console.Write(" ");
                                                    walls[i - 1, j] = "X";
                                                    Console.SetCursorPosition(j, i - 1);
                                                    Console.Write("X");
                                                }
                                            }
                                            else if (i < playery && walls[i + 1, j] != "X" && walls[i + 1, j] != "Y" && walls[i + 1, j] != "#")
                                            {
                                                if (walls[i + 1, j] == "+")
                                                {
                                                    scoreMineFunction(i + 1, j, i, j);
                                                }
                                                else
                                                {
                                                    walls[i, j] = ".";
                                                    Console.SetCursorPosition(j, i);
                                                    Console.Write(" ");
                                                    walls[i + 1, j] = "X";
                                                    Console.SetCursorPosition(j, i + 1);
                                                    Console.Write("X");
                                                }
                                            }
                                        }
                                    }
                                }
                                if (walls[i, j] == "Y")
                                {
                                    if (walls[i - 1, j] == ",")
                                    {
                                        walls[i - 1, j] = " ";
                                    }
                                    else if (walls[i, j - 1] == ",")
                                    {
                                        walls[i, j - 1] = " ";
                                    }
                                    else
                                    {
                                        if (i > playery && walls[i - 1, j] != "X" && walls[i - 1, j] != "Y" && walls[i - 1, j] != "#")
                                        {
                                            if (walls[i - 1, j] == "+")
                                            {
                                                scoreMineFunction(i - 1, j, i, j);
                                            }
                                            else
                                            {
                                                walls[i, j] = " ";
                                                Console.SetCursorPosition(j, i);
                                                Console.Write(" ");
                                                walls[i - 1, j] = "Y";
                                                Console.SetCursorPosition(j, i - 1);
                                                Console.Write("Y");
                                            }
                                        }
                                        else if (i < playery && walls[i + 1, j] != "X" && walls[i + 1, j] != "Y" && walls[i + 1, j] != "#")
                                        {
                                            if (walls[i + 1, j] == "+")
                                            {
                                                scoreMineFunction(i + 1, j, i, j);
                                            }
                                            else
                                            {
                                                walls[i, j] = ",";
                                                Console.SetCursorPosition(j, i);
                                                Console.Write(" ");
                                                walls[i + 1, j] = "Y";
                                                Console.SetCursorPosition(j, i + 1);
                                                Console.Write("Y");
                                            }
                                        }
                                        else
                                        {
                                            if (j > playerx && walls[i, j - 1] != "X" && walls[i, j - 1] != "Y" && walls[i, j - 1] != "#")
                                            {
                                                if (walls[i, j - 1] == "+")
                                                {
                                                    scoreMineFunction(i, j - 1, i, j);
                                                }
                                                else
                                                {
                                                    walls[i, j] = " ";
                                                    Console.SetCursorPosition(j, i);
                                                    Console.Write(" ");
                                                    walls[i, j - 1] = "Y";
                                                    Console.SetCursorPosition(j - 1, i);
                                                    Console.Write("Y");
                                                }
                                            }
                                            else if (j < playerx && walls[i, j + 1] != "X" && walls[i, j + 1] != "Y" && walls[i, j + 1] != "#")
                                            {
                                                if (walls[i, j + 1] == "+")
                                                {
                                                    scoreMineFunction(i, j + 1, i, j);
                                                }
                                                else
                                                {
                                                    walls[i, j] = ",";
                                                    Console.SetCursorPosition(j, i);
                                                    Console.Write(" ");
                                                    walls[i, j + 1] = "Y";
                                                    Console.SetCursorPosition(j + 1, i);
                                                    Console.Write("Y");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (walls[playery, playerx] == "X" || walls[playery, playerx] == "Y")
                        {
                            Console.SetCursorPosition(59, 15);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("GAME OVER        ");
                            break;
                        }
                    }

                    count++;
                    Thread.Sleep(speed);
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                switch (level)
                {
                    case 5:
                        if (score >= highest1) highest1 = score;
                        Console.SetCursorPosition(84, 6);
                        Console.Write(highest1);
                        break;
                    case 7:
                        if (score >= highest2) highest2 = score;
                        Console.SetCursorPosition(84, 7);
                        Console.Write(highest2);
                        break;
                    case 9:
                        if (score >= highest3) highest3 = score;
                        Console.SetCursorPosition(84, 8);
                        Console.Write(highest3);
                        break;
                }
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Enter)
                    {
                        level = 1;

                        Console.Write("\nChoose difficulty level (1, 2, or 3): ");

                        while (level != 5 && level != 7 && level != 9)
                        {
                            string choose = Console.ReadLine();

                            if (int.TryParse(choose, out n) && (Convert.ToInt32(choose) == 1 || Convert.ToInt32(choose) == 2 || Convert.ToInt32(choose) == 3))
                            {
                                switch (Convert.ToInt32(choose))
                                {
                                    case 1:
                                        level = 5;
                                        break;
                                    case 2:
                                        level = 7;
                                        break;
                                    case 3:
                                        level = 9;
                                        break;
                                }
                            }
                            else
                            {
                                Console.Write("invalid level");
                                Console.SetCursorPosition(37, 26);
                                Console.Write("             ");
                                Console.SetCursorPosition(37, 26);
                            }
                        }

                        Console.SetCursorPosition(0, 24);
                        Console.Write("                                                   ");
                        Console.SetCursorPosition(0, 26);
                        Console.Write("                                                   ");
                        Console.SetCursorPosition(0, 27);
                        Console.Write("               ");

                        all();

                        check = true;
                    }

                    if (cki.Key == ConsoleKey.Spacebar) break;
                }

                if (check)
                {
                    Console.SetCursorPosition(0, 24);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press Enter to start New Game or Spacebar to finish");
                    check = false;
                }
            }

            Console.SetCursorPosition(0, 26);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
