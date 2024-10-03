//Roulett:
//You have $1 000,00 to start with in demo the thing is always in demo.
//The Gambler can choose between "$1 - all in" to bet.
//When the gambler made an bet the balance go down with how much u bet.
//You can bet on either, Red, Black, Green, Odd or Even or a Specific number. 
//If you hit you get the money back instantly and it tells you how much you got and have, but if you miss the money goes away. 
//2x if you hit on: Odd/Even, Red/Black.
//35x if you hit on green or a specific number.
//If your balance goes to 0,00 you lose the game and need to start all over again.
//When you reach $1 000 000, the game ends and you win.

int wallet = 1000;
int bet = 0;
int mult = 1;
int single = -1;
int[] red = { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };
int[] black = { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };
int rouletteNum = -1;
int betAmount = 0;
string rouletteColor = "0";
string choice = "";
bool Leave = false;
bool win = false;

Random rand = new Random();

Console.WriteLine(wallet.ToString("N"));
Console.WriteLine();

//Game
while(wallet < 1000000 && wallet > 0)
{
    Console.WriteLine("Hello and welcome to the Casino!");
    Console.WriteLine();
    Console.WriteLine("You have $" +  wallet.ToString("N"));
    Console.WriteLine();
    Console.WriteLine("1: Go to the Roulette table");
    Console.WriteLine("2: Go to the Bar");
    choice = Console.ReadLine();
    //Roulette table
    if (choice == "1")
    {
        choice = "0";
        Console.WriteLine("Welcome to the table!");
        while (!Leave)
        {
            Console.WriteLine("1: Play");
            Console.WriteLine("2: Go back");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Where do you want to place?");
                while (!Leave)
                {
                    Console.WriteLine("1. Red");
                    Console.WriteLine("2. Black");
                    Console.WriteLine("3. Green");
                    Console.WriteLine("4. Odd Numbers");
                    Console.WriteLine("5. Even Numbers");
                    Console.WriteLine("6. Specific Number");
                    Console.WriteLine("7. Go back");
                    choice = Console.ReadLine();
                    if (choice == "7")
                    {
                        Console.WriteLine("You're back to the lobby");
                        choice = "0";
                        Leave = true;
                        continue;
                    }
                    while (true)
                    {
                        Console.WriteLine("Please place a bet ammount");
                        betAmount = Convert.ToInt32(Console.ReadLine());
                        if (betAmount < 0 || betAmount > wallet)
                        {
                            Console.WriteLine("You can't bet this amount");
                        }
                        else
                        {
                            Console.WriteLine("You have successfully placed a bet of $" + betAmount);
                            break;
                        }
                    }
                    //slumpar
                    if (choice == "1")
                    {
                        mult = 2;

                    }
                    else if (choice == "2")
                    {
                        mult = 2;

                    }
                    else if (choice == "3")
                    {
                        mult = 35;

                    }
                    else if (choice == "4")
                    {
                        mult = 2;

                    }
                    else if (choice == "5")
                    {
                        mult = 2;

                    }
                    else if (choice == "6")
                    {
                        mult = 35;
                        while (true)
                        {
                            Console.WriteLine("Which number?");
                            try
                            {
                                single = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Invalid");
                            }
                            if (single > 36 || single < 0)
                            {
                                Console.WriteLine("Please place an existing number");
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine("Start Spin (press enter 2x times)");
                    Console.ReadKey();
                    Console.WriteLine("Spinning...");
                    Console.ReadKey();
                    rouletteNum = rand.Next(0, 37);
                    if (red.Contains(rouletteNum))
                    {
                        rouletteColor = "red";
                    }
                    else if (rouletteNum == 0)
                    {
                        rouletteColor = "green";
                    }
                    else
                    {
                        rouletteColor = "black";
                    }
                    Console.WriteLine();
                    Console.WriteLine(rouletteNum);
                    Console.WriteLine(rouletteColor);
                    Console.WriteLine();
                    if (choice == "1")
                    {
                        if (rouletteColor == "red")
                        {
                            win = true;
                        }
                    }
                    else if (choice == "2")
                    {
                        if (rouletteColor == "black")
                        {
                            win = true;
                        }
                    }
                    else if (choice == "3")
                    {
                        if (rouletteColor == "green")
                        {
                            win = true;
                        }
                    }
                    else if (choice == "4")
                    {
                        if (rouletteNum % 2 != 0)
                        {
                            win = true;
                        }
                    }
                    else if (choice == "5")
                    {
                        if (rouletteNum % 2 == 0)
                        {
                            win = true;
                        }
                    }
                    else if (choice == "6")
                    {
                        if (rouletteNum == single)
                        {
                            win = true;
                        }
                    }
                    if (win)
                    {
                        wallet += betAmount * mult - betAmount;
                        Console.WriteLine("You won $" + (betAmount * mult - betAmount));
                    }
                    else
                    {
                        wallet -= betAmount;
                        Console.WriteLine("You lose $" + (betAmount));
                    }
                    win = false;
                    rouletteNum = -1;
                    betAmount = 0;
                    rouletteColor = "0";
                    Leave = true;
                }
            }
            if (choice == "2")
            {
                Console.WriteLine("You're back to the Lobby");
                choice = "0";
                Leave = true;
            }
        }
    }
    Leave = false;
    //The bar
    if(choice == "2")
    {
        Console.WriteLine("Welcome to The Bar");
        while (!Leave)
        {
            Console.WriteLine("1: Drink");
            Console.WriteLine("2: Go back");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("What would you like to drink?");
                while (!Leave)
                {
                    Console.WriteLine("1: Whiskey $20");
                    Console.WriteLine("2: Jägermeister $25");
                    Console.WriteLine("3: Champagne $30");
                    Console.WriteLine("4: Go back");
                    choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("You bought whiskey");
                        wallet -= 20;
                    }
                    if (choice == "2")
                    {
                        Console.WriteLine("You bought Jäger");
                        wallet -= 25;
                    } 
                    if (choice == "3")
                    {
                        Console.WriteLine("You bought champagne");
                        wallet -= 30;
                    }
                    if (choice == "4")
                    {
                        Console.WriteLine("You're back to the lobby");
                        choice = "0";
                        Leave = true;
                    }
                }
            }
        }
    }
    Leave = false;
}
if (wallet > 1000000)
{
    Console.WriteLine("You Win");
}
else
{
    Console.WriteLine("You Lose, Game over");
}