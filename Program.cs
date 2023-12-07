List<Meme> memes = new List<Meme>()
{
};

Console.Clear();

string greeting = @"Welcome to PawsPurrfect";

string choice = null;

while (choice != "0")
{
    MainMenu();
}

void MainMenu()
{
    Console.WriteLine(@$"
{greeting}

Please Select An Option To Navigate To:
0. Exit
1. Something
2. Something Else
3. Something Else
");

    choice = Console.ReadLine().Trim();

    switch (choice)
    {
        case "0":
            Console.Clear();
            Console.WriteLine(@"Thank you for visiting PawsPurrfect! We hope to see you again.
Goodbye :)

Please press any key to close the application");
            Console.ReadKey();
            Console.Clear();
            break;
        case "1":
            Console.Clear();
            Console.WriteLine("This isn't implemented yet. Press any key to continue...");
            Console.ReadKey();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("This isn't implemented yet. Press any key to continue...");
            Console.ReadKey();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("This isn't implemented yet. Press any key to continue...");
            Console.ReadKey();
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}