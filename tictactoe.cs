using System;

namespace ticks_but_clear
{
    class tictactoe
    {
        class Game
        {
            public static void Initiate()
            {
                Core.Draw_First();
                Core.Start();
            }
            class Core
            {
                public class position
                {
                    public string value; //x or o
                    public int number_of_position; //1,2..9
                    public bool isFree; // true or false
                    public position(int number_of_position) { value = " "; this.number_of_position = number_of_position; isFree = true; }
                }

                public static void Start()
                {
                    position position1 = new position(1);
                    position position2 = new position(2);
                    position position3 = new position(3);
                    position position4 = new position(4);
                    position position5 = new position(5);
                    position position6 = new position(6);
                    position position7 = new position(7);
                    position position8 = new position(8);
                    position position9 = new position(9);
                    string[] position_values = { position1.value, position2.value, position3.value, position4.value, position5.value, position6.value, position7.value, position8.value, position9.value };
                    bool[] position_isFrees = { position1.isFree, position2.isFree, position3.isFree, position4.isFree, position5.isFree, position6.isFree, position7.isFree, position8.isFree, position9.isFree };
                    int position_chosen_main = 0;
                    string symbol_of_this_turn = " ";
                    int turn_counter = 0;
                    Change_the_symbol(ref turn_counter, ref position_chosen_main, ref symbol_of_this_turn, ref position_values, ref position_isFrees);
                }

                static void Draw(ref string[] position_values)
                {
                    string pos1 = position_values[0];
                    string pos2 = position_values[1];
                    string pos3 = position_values[2];
                    string pos4 = position_values[3];
                    string pos5 = position_values[4];
                    string pos6 = position_values[5];
                    string pos7 = position_values[6];
                    string pos8 = position_values[7];
                    string pos9 = position_values[8];

                    Console.WriteLine($"╔═╦═╦═╗");
                    Console.WriteLine($"║{pos7}║{pos8}║{pos9}║");
                    Console.WriteLine($"╠═╬═╬═╣");
                    Console.WriteLine($"║{pos4}║{pos5}║{pos6}║");
                    Console.WriteLine($"╠═╬═╬═╣");
                    Console.WriteLine($"║{pos1}║{pos2}║{pos3}║");
                    Console.WriteLine($"╚═╩═╩═╝");
                }

                static int Key_choosing(out int position_chosen_main)
                {
                NR: string position_chosen_key = Console.ReadLine();

                    if ((position_chosen_key == " ") | (position_chosen_key == ""))
                    {
                        Console.WriteLine("Write a number before entering it");
                        goto NR;
                    }
                    else
                    {
                        position_chosen_main = Int32.Parse(position_chosen_key);

                        return position_chosen_main;
                    }
                }

                static void Change_the_symbol(ref int turn_counter, ref int position_chosen_main, ref string symbol_of_this_turn, ref string[] position_values, ref bool[] position_isFrees)
                {
                    int i = position_chosen_main;
                PNF: Key_choosing(out i);


                    if (i - 1 > 8)
                    {
                        Console.WriteLine("There's only 9 positions. Choose carefully");
                        goto PNF;
                    }
                    else if ((position_isFrees[(i - 1)] == true))
                    {
                        Get_symbol_of_this_turn(ref turn_counter, out symbol_of_this_turn);
                        position_values[(i - 1)] = symbol_of_this_turn;
                        position_isFrees[(i - 1)] = false;
                        Draw(ref position_values);
                        Check_win(ref symbol_of_this_turn, ref turn_counter, ref position_values);
                        Change_the_symbol(ref turn_counter, ref position_chosen_main, ref symbol_of_this_turn, ref position_values, ref position_isFrees);
                    }
                    else
                    {
                        Console.WriteLine("This position isn't free. Choose another");
                        goto PNF;
                    }


                }

                static void Check_win(ref string symbol_of_this_turn, ref int turn_counter, ref string[] positions_values)
                {

                    if (((positions_values[0] == symbol_of_this_turn) & (positions_values[1] == symbol_of_this_turn) & (positions_values[2] == symbol_of_this_turn)) | ((positions_values[3] == symbol_of_this_turn) & (positions_values[4] == symbol_of_this_turn) & (positions_values[5] == symbol_of_this_turn)) | ((positions_values[6] == symbol_of_this_turn) & (positions_values[7] == symbol_of_this_turn) & (positions_values[8] == symbol_of_this_turn)) | ((positions_values[0] == symbol_of_this_turn) & (positions_values[3] == symbol_of_this_turn) & (positions_values[6] == symbol_of_this_turn)) | ((positions_values[1] == symbol_of_this_turn) & (positions_values[4] == symbol_of_this_turn) & (positions_values[7] == symbol_of_this_turn)) | ((positions_values[2] == symbol_of_this_turn) & (positions_values[5] == symbol_of_this_turn) & (positions_values[8] == symbol_of_this_turn)) | ((positions_values[0] == symbol_of_this_turn) & (positions_values[4] == symbol_of_this_turn) & (positions_values[8] == symbol_of_this_turn)) | ((positions_values[2] == symbol_of_this_turn) & (positions_values[4] == symbol_of_this_turn) & (positions_values[6] == symbol_of_this_turn)))
                    {
                        Console.WriteLine($"{symbol_of_this_turn} is winner!");
                        Console.WriteLine("");
                        Console.WriteLine("Press ESC to exit");
                        System.ConsoleKey k = Console.ReadKey().Key;
                        if ((k == ConsoleKey.Escape) | (k == ConsoleKey.Enter))
                        {
                            Environment.Exit(0);
                        }
                    }
                    else if (turn_counter == 9)
                    {
                        Console.WriteLine("It's a draw! No one loses!");
                        Console.WriteLine("");
                        Console.WriteLine("Press ESC to exit");
                        System.ConsoleKey k = Console.ReadKey().Key;
                        if ((k == ConsoleKey.Escape) | (k == ConsoleKey.Enter))
                            {
                                Environment.Exit(0);
                            }
                    }
                }
                static string Get_symbol_of_this_turn(ref int turn_counter, out string symbol_of_this_turn)
                {


                    int d = turn_counter % 2;
                    if (d == 0)
                    {
                        turn_counter++;

                        return symbol_of_this_turn = "o";

                    }
                    else
                    {
                        turn_counter++;

                        return symbol_of_this_turn = "x";
                    }
                }

                public static void Draw_First()
                {
                    Console.WriteLine("╔═╦═╦═╗");
                    Console.WriteLine("║7║8║9║");
                    Console.WriteLine("╠═╬═╬═╣");
                    Console.WriteLine("║4║5║6║");
                    Console.WriteLine("╠═╬═╬═╣");
                    Console.WriteLine("║1║2║3║");
                    Console.WriteLine("╚═╩═╩═╝");
                    Console.WriteLine("o's start first. Use keypad to play");
                }

            }
        }
        static void Main(string[] args)
        {
            Game.Initiate();
        }

    }
}
