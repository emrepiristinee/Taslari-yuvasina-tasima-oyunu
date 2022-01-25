using System;

namespace CENG_Checkers
{
    class Program
    {
        public static int cursorx = 7, cursory = 7, edit_cursorx = 7, edit_cursory = 7, rand_char = 0;
        public static bool first_rnd_flag = true;
        public static int movex = 0, movey = 0, onex = 0, oney = 0, twox = 1, twoy = 0, threex = 2, threey = 0, fourx = 0, foury = 1, fivex = 1, fivey = 1, sixx = 2, sixy = 1, sevenx = 0, seveny = 2, eightx = 1, eighty = 2, ninex = 2, niney = 2;
        public static Random random = new Random();

        static void Rndm_o(bool first_rnd_of_flag)
        {
            if (first_rnd_flag) //To avoid selecting the 1st 'o' in the first round of the game
            {
                rand_char = random.Next(2, 10);
                Movex_Movey(rand_char);
                first_rnd_flag = false;
            }
            else
            {
                rand_char = random.Next(1, 10);
                Movex_Movey(rand_char);
            }
        }

        static void Move_Cursor(ConsoleKeyInfo cki, int cursor_x, int cursor_y) //move of cursor function
        {
            if (cki.Key == ConsoleKey.RightArrow && cursorx < 9)
            {   // key and boundary control
                // delete X (old position)
                cursorx++;
            }
            if (cki.Key == ConsoleKey.LeftArrow && cursorx > 2)
            {
                cursorx--;
            }
            if (cki.Key == ConsoleKey.UpArrow && cursory > 2)
            {
                cursory--;
            }
            if (cki.Key == ConsoleKey.DownArrow && cursory < 9)
            {
                cursory++;
            }
            if (cki.KeyChar >= 65 && cki.KeyChar <= 122)
            {       // keys: a-f
                Console.SetCursorPosition(20, 6);
                Console.WriteLine("Pressed Key: " + cki.KeyChar);
            }
        }

        static void Movex_Movey(int rnd_char) //assigns the positions of the stone to be moved to the variable "movex" and "movey"
        {
            switch (rnd_char)
            {
                case 1:
                    movex = onex; movey = oney;
                    break;
                case 2:
                    movex = twox; movey = twoy;
                    break;
                case 3:
                    movex = threex; movey = threey;
                    break;
                case 4:
                    movex = fourx; movey = foury;
                    break;
                case 5:
                    movex = fivex; movey = fivey;
                    break;
                case 6:
                    movex = sixx; movey = sixy;
                    break;
                case 7:
                    movex = sevenx; movey = seveny;
                    break;
                case 8:
                    movex = eightx; movey = eighty;
                    break;
                case 9:
                    movex = ninex; movey = niney;
                    break;
            }
        }

        static void Crdnt_x_y(int rnd_char) //gives new positions of the stone
        {
            switch (rnd_char)
            {
                case 1:
                    onex = movex; oney = movey;
                    break;
                case 2:
                    twox = movex; twoy = movey;
                    break;
                case 3:
                    threex = movex; threey = movey;
                    break;
                case 4:
                    fourx = movex; foury = movey;
                    break;
                case 5:
                    fivex = movex; fivey = movey;
                    break;
                case 6:
                    sixx = movex; sixy = movey;
                    break;
                case 7:
                    sevenx = movex; seveny = movey;
                    break;
                case 8:
                    eightx = movex; eighty = movey;
                    break;
                case 9:
                    ninex = movex; niney = movey;
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Please press any key to start the game");
            ConsoleKeyInfo cki;
            ConsoleKeyInfo temp_cursor_cki = Console.ReadKey(true);
            Console.Clear();
            bool z_selection_flag = true, jump_control_flag = true, round_counter_flag = true, print_info = true;
            int round_counter = 1;
            int rows_columns = 8;

            char[,] matrix = new char[rows_columns, rows_columns];
            //    {one, two, three, '.', '.', '.', '.', '.'},
            //    {four, five, six, '.', '.', '.', '.', '.'},
            //    {seven, eight, nine, '.', '.', '.', '.', '.'},
            //    {'.', '.', '.', '.', '.', '.', '.', '.'},
            //    {'.', '.', '.', '.', '.', '.', '.', '.'},
            //    {'.', '.', '.', '.', '.', 'x', 'x', 'x'},
            //    {'.', '.', '.', '.', '.', 'x', 'x', 'x'},
            //    {'.', '.', '.', '.', '.', 'x', 'x', 'x'},

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i == 0 && j == 0) || (i == 0 && j == 1) || (i == 0 && j == 2) || (i == 1 && j == 0) || (i == 1 && j == 1) || (i == 1 && j == 2) || (i == 2 && j == 0) || (i == 2 && j == 1) || (i == 2 && j == 2))
                    {
                        matrix[i, j] = 'o';
                    }
                    else if ((i == rows_columns - 3 && j == rows_columns - 3) || (i == rows_columns - 3 && j == rows_columns - 2) || (i == rows_columns - 3 && j == rows_columns - 1) || (i == rows_columns - 2 && j == rows_columns - 3) || (i == rows_columns - 2 && j == rows_columns - 2) || (i == rows_columns - 2 && j == rows_columns - 1) || (i == rows_columns - 1 && j == rows_columns - 3) || (i == rows_columns - 1 && j == rows_columns - 2) || (i == rows_columns - 1 && j == rows_columns - 1))
                    {
                        matrix[i, j] = 'x';
                    }
                    else
                    {
                        matrix[i, j] = '.';
                    }
                }
            }
            Console.WriteLine("  12345678");
            Console.WriteLine(" +--------+");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(i + 1 + "|........|");
            }
            Console.WriteLine(" +--------+");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i + 2, j + 2);
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }


            while (true)
            {
                if (round_counter_flag)
                {
                    if (print_info)
                    {
                        Console.SetCursorPosition(20, 2);
                        Console.WriteLine("Round: " + round_counter);
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine("Turn: x");
                        print_info = false;
                        Console.SetCursorPosition(edit_cursorx, edit_cursory);
                    }


                    if (Console.KeyAvailable)
                    {       // true: there is a key in keyboard buffer
                        cki = Console.ReadKey(true);       // true: do not write character

                        Move_Cursor(cki, cursorx, cursory); //move cursor function
                        Console.SetCursorPosition(cursorx, cursory);



                        if (cki.KeyChar == 122 || cki.KeyChar == 90) //Z or z
                        {
                            int temp_cursory = cursory;
                            int temp_cursorx = cursorx;
                            if (matrix[temp_cursorx - 2, temp_cursory - 2] == 'x')
                            {
                                while (true)
                                {
                                    if (Console.KeyAvailable)
                                    {       // true: there is a key in keyboard buffer
                                        cki = Console.ReadKey(true);       // true: do not write character 
                                        if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.DownArrow)
                                            temp_cursor_cki = cki;

                                        Move_Cursor(cki, cursorx, cursory);
                                        Console.SetCursorPosition(cursorx, cursory);

                                        int control_cursory = cursory;
                                        int control_cursorx = cursorx;


                                        if (cki.KeyChar == 67 || cki.KeyChar == 99) //C or c
                                        {
                                            temp_cursory = 0; temp_cursorx = 0;
                                            round_counter_flag = false;
                                            break;
                                        }
                                        else
                                        {
                                            if ((temp_cursorx != control_cursorx || temp_cursory != control_cursory) && (cki.KeyChar == 88 || cki.KeyChar == 120)) //X or x
                                            {
                                                // 1 step up
                                                if (temp_cursor_cki.Key != ConsoleKey.DownArrow && temp_cursor_cki.Key != ConsoleKey.RightArrow && temp_cursor_cki.Key != ConsoleKey.LeftArrow && temp_cursory != 2 && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 2, temp_cursory - 3] == '.')
                                                {
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write(".");
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                    temp_cursory -= 1;
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write("x");
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                    jump_control_flag = false; //if you took 1 step, you can't jump chain
                                                    round_counter_flag = false; //turn to play goes to pc
                                                    break;
                                                }
                                                //1 step right
                                                else if (temp_cursorx != 9 && temp_cursor_cki.Key == ConsoleKey.RightArrow && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 1, temp_cursory - 2] == '.')
                                                {
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write(".");
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                    temp_cursorx += 1;
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write("x");
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                    jump_control_flag = false;
                                                    round_counter_flag = false;
                                                    break;
                                                }
                                                //1 step left
                                                else if (temp_cursorx != 2 && temp_cursor_cki.Key == ConsoleKey.LeftArrow && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 3, temp_cursory - 2] == '.')
                                                {
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write(".");
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                    temp_cursorx -= 1;
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write("x");
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                    jump_control_flag = false;
                                                    round_counter_flag = false;
                                                    break;
                                                }
                                                //1 step down
                                                else if (temp_cursory != 9 && temp_cursor_cki.Key == ConsoleKey.DownArrow && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 2, temp_cursory - 1] == '.')
                                                {
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write(".");
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                    temp_cursory += 1;
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    Console.Write("x");
                                                    Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                    matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                    jump_control_flag = false;
                                                    round_counter_flag = false;
                                                    break;
                                                }


                                                if (jump_control_flag == true)
                                                {
                                                    do
                                                    {
                                                        //2 steps up jump
                                                        if (z_selection_flag == true && temp_cursor_cki.Key != ConsoleKey.RightArrow && temp_cursor_cki.Key != ConsoleKey.LeftArrow && temp_cursory != 2 && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 2, temp_cursory - 3] != '.' && matrix[temp_cursorx - 2, temp_cursory - 4] == '.')
                                                        {
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write(".");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                            temp_cursory -= 2;
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write("x");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                            Console.SetCursorPosition(20, 15);
                                                            Console.Write("Please press C after the jump chain is finished");
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                        }
                                                        //jump 2 steps to the right
                                                        else if (z_selection_flag == true && temp_cursorx != 9 && temp_cursor_cki.Key == ConsoleKey.RightArrow && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 1, temp_cursory - 2] != '.' && matrix[temp_cursorx, temp_cursory - 2] == '.')
                                                        {
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write(".");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                            temp_cursorx += 2;
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write("x");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                            Console.SetCursorPosition(20, 15);
                                                            Console.Write("Please press C after the jump chain is finished");
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                        }
                                                        //jump 2 steps to the left
                                                        else if (z_selection_flag == true && temp_cursorx != 2 && temp_cursor_cki.Key == ConsoleKey.LeftArrow && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 3, temp_cursory - 2] != '.' && matrix[temp_cursorx - 4, temp_cursory - 2] == '.')
                                                        {
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write(".");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                            temp_cursorx -= 2;
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write("x");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                            Console.SetCursorPosition(20, 15);
                                                            Console.Write("Please press C after the jump chain is finished");
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                        }
                                                        //jump 2 steps to the down
                                                        else if (z_selection_flag == true && temp_cursory != 9 && temp_cursor_cki.Key == ConsoleKey.DownArrow && matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && matrix[temp_cursorx - 2, temp_cursory - 1] != '.' && matrix[temp_cursorx - 2, temp_cursory] == '.')
                                                        {
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write(".");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = '.';
                                                            temp_cursory += 2;
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                            Console.Write("x");
                                                            matrix[temp_cursorx - 2, temp_cursory - 2] = 'x';
                                                            Console.SetCursorPosition(20, 15);
                                                            Console.Write("Please press C after the jump chain is finished");
                                                            Console.SetCursorPosition(temp_cursorx, temp_cursory);
                                                        }
                                                        //checking for possible "jump chain"
                                                        if (matrix[temp_cursorx - 2, temp_cursory - 2] == 'x' && ((temp_cursory != 3 && temp_cursory != 2 && temp_cursory != 1 && matrix[temp_cursorx - 2, temp_cursory - 4] != '.' && matrix[temp_cursorx - 2, temp_cursory - 3] == '.') || (temp_cursorx != 2 && temp_cursorx != 3 && matrix[temp_cursorx - 4, temp_cursory - 2] != '.' && matrix[temp_cursorx - 3, temp_cursory - 2] == '.') || (temp_cursorx != 8 && temp_cursorx != 9 && matrix[temp_cursorx, temp_cursory - 2] != '.' && matrix[temp_cursorx - 1, temp_cursory - 2] == '.')))
                                                        {
                                                            z_selection_flag = false;
                                                            break;
                                                        }

                                                        while (true)
                                                        {
                                                            cki = Console.ReadKey(true);       // true: do not write character 
                                                            if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.DownArrow)
                                                                temp_cursor_cki = cki;

                                                            else if (cki.KeyChar == 122 || cki.KeyChar == 90) // Z or z
                                                            {
                                                                int z_temp_cursorx = cursorx; int z_temp_cursory = cursory; //transfers the location of the selected letter to temp (for jump chain)
                                                                if (z_temp_cursorx == temp_cursorx && z_temp_cursory == temp_cursory) //checking if the last played letter is the same as the one we selected (for jump chain) 
                                                                    z_selection_flag = true;
                                                                else
                                                                    z_selection_flag = false;
                                                            }
                                                            else if (cki.KeyChar == 67 || cki.KeyChar == 99) //C or c
                                                            {
                                                                z_selection_flag = false;
                                                                Console.SetCursorPosition(20, 15);
                                                                Console.Write("                                                "); //delete the jump chain sentence
                                                                break;
                                                            }

                                                            Move_Cursor(cki, cursorx, cursory);
                                                            Console.SetCursorPosition(cursorx, cursory);

                                                            if (cki.KeyChar == 88 || cki.KeyChar == 120) // X or x
                                                                break;
                                                        }
                                                    } while (z_selection_flag);
                                                    round_counter_flag = false; //turn to play goes to pc
                                                }
                                            }
                                        }
                                    }
                                    if (z_selection_flag == false)
                                        break;
                                }
                            }
                            edit_cursorx = temp_cursorx; edit_cursory = temp_cursory;
                        }
                        jump_control_flag = true;
                        z_selection_flag = true;
                    }
                }

                //check if you win
                if (matrix[0, 0] == 'x' && matrix[0, 1] == 'x' && matrix[0, 2] == 'x' && matrix[1, 0] == 'x' && matrix[1, 1] == 'x' && matrix[1, 2] == 'x' && matrix[2, 0] == 'x' && matrix[2, 1] == 'x' && matrix[2, 2] == 'x')
                {
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("You've won the game");
                    break;
                }

                // will play on pc
                if (!round_counter_flag)
                {
                    if (!print_info)
                    {
                        Console.SetCursorPosition(20, 2);
                        Console.WriteLine("Round: " + round_counter);
                        print_info = true;
                        Console.SetCursorPosition(20, 4);
                        Console.WriteLine("Turn: o");
                        round_counter++;
                    }

                    Rndm_o(first_rnd_flag); //randomly chooses which character to play


                    if (movey != 6 && movey != 7 && matrix[movex, movey] == 'o' && matrix[movex, movey + 1] != '.' && matrix[movex, movey + 2] == '.') //2 steps down jump
                    {
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write(".");
                        matrix[movex, movey] = '.';
                        movey += 2;
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write("o");
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        matrix[movex, movey] = 'o';
                        Crdnt_x_y(rand_char);
                        round_counter_flag = true; // the turn to play passes to the player
                    }
                    else if (movey != 7 && matrix[movex, movey] == 'o' && matrix[movex, movey + 1] == '.') //1 steps to the down
                    {
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write(".");
                        matrix[movex, movey] = '.';
                        movey += 1;
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write("o");
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        matrix[movex, movey] = 'o';
                        Crdnt_x_y(rand_char);
                        round_counter_flag = true;
                    }
                    else if (movex != 6 && movex != 7 && matrix[movex, movey] == 'o' && matrix[movex + 1, movey] != '.' && matrix[movex + 2, movey] == '.') //jump 2 steps to the right
                    {
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write(".");
                        matrix[movex, movey] = '.';
                        movex += 2;
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write("o");
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        matrix[movex, movey] = 'o';
                        Crdnt_x_y(rand_char);
                        round_counter_flag = true;
                    }
                    else if (movex != 7 && matrix[movex, movey] == 'o' && matrix[movex + 1, movey] == '.') //1 steps to the right
                    {
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write(".");
                        matrix[movex, movey] = '.';
                        movex += 1;
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write("o");
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        matrix[movex, movey] = 'o';
                        Crdnt_x_y(rand_char);
                        round_counter_flag = true;
                    }
                    else if (movex != 0 && movex != 1 && matrix[movex, movey] == 'o' && matrix[movex - 1, movey] != '.' && matrix[movex - 2, movey] == '.') //jump 2 steps to the left
                    {
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write(".");
                        matrix[movex, movey] = '.';
                        movex -= 2;
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write("o");
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        matrix[movex, movey] = 'o';
                        Crdnt_x_y(rand_char);
                        round_counter_flag = true;
                    }
                    else if (movex != 0 && matrix[movex, movey] == 'o' && matrix[movex - 1, movey] == '.') //1 steps to the left
                    {
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write(".");
                        matrix[movex, movey] = '.';
                        movex -= 1;
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        Console.Write("o");
                        Console.SetCursorPosition(movex + 2, movey + 2);
                        matrix[movex, movey] = 'o';
                        Crdnt_x_y(rand_char);
                        round_counter_flag = true;
                    }
                }
                //check if pc won
                if (matrix[5, 5] == 'o' && matrix[5, 6] == 'o' && matrix[5, 7] == 'o' && matrix[6, 5] == 'o' && matrix[6, 6] == 'o' && matrix[6, 7] == 'o' && matrix[7, 5] == 'o' && matrix[7, 6] == 'o' && matrix[7, 7] == 'o')
                {
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("The Pc've won the game");
                    break;
                }
            }
        }
    }
}
