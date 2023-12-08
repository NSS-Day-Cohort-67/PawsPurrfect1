using System.Collections;
using System.Data.Common;

var gf = new GenericFunctions();
var filterMemesByUser = new FilterMemesByUser();
var postMeme = new PostMeme();

List<Meme> memes = new List<Meme>()
{
    new Meme
    {
        Id = 1,
        UserId = 1,
        Title = "Sleepy Cat",
        Image = @"
|\---/|
| o_o |
 \_^_/",
        Description = "A cat sleeping peacefully"
    },
    new Meme
    {
        Id = 2,
        UserId = 2,
        Title = "Curious Cat",
        Image = @"
    |\__/,|   (`\
  _.|o o  |_   ) )
-(((---(((--------",
        Description = "A cat looking curiously"
    },
    new Meme
    {
        Id = 3,
        UserId = 3,
        Title = "Grumpy Cat",
        Image = @"
 |\__/,|   (`\
 |_ _  |.--.) )
 ( T   )     /
(((^_(((/(((_/",
        Description = "A cat with a grumpy face"
    },
    new Meme
    {
        Id = 4,
        UserId = 4,
        Title = "Happy Cat",
        Image = @"
  ^~^  ,
 ('Y') )
 /   \/ 
(\|||/)",
        Description = "A happy smiling cat"
    },
    new Meme
    {
        Id = 5,
        UserId = 5,
        Title = "Surprised Cat",
        Image = @"
   |\__/,|   (`\
   |o o  |__ _)
 _.( T   )  `  /
((_ `^--' /_<  \
`` `-'(((/  (((/",
        Description = "A cat looking surprised"
    },
    new Meme
    {
        Id = 6,
        UserId = 1,
        Title = "Playful Cat",
        Image = @"
  _  ,/|
 '\`o.O'   _
  =(_*_)= (
    )U(  _)
   /   \(
  (/`-'\)",
        Description = "A playful cat in action"
    },
    new Meme
    {
        Id = 7,
        UserId = 2,
        Title = "Lazy Cat",
        Image = @"
    ,-. __ .-,
  --;`. '   `.'
   / (  ^__^  )
  ;   `(_`'_)' \
  '  ` .`--'_,  ;
~~`-..._)))(((.'",
        Description = "A cat lying lazily"
    },
    new Meme
    {
        Id = 8,
        UserId = 3,
        Title = "Adventurous Cat",
        Image = @"
 .       .
 |\_---_/|
/   o_o   \
|    U    |
\  ._I_.  /
 `-_____-'",
        Description = "A cat ready for an adventure"
    }
};
List<User> users = new List<User>()
{
    new User { Id = 1, UserName = "josh", Password = "cats" },
    new User { Id = 2, UserName = "ryan", Password = "cats" },
    new User { Id = 3, UserName = "rebecca", Password = "cats" },
    new User { Id = 4, UserName = "luc", Password = "cats" }
};


Console.Clear();

bool UserLoggedIn = false;

User LoggedInUser = null;

string loginScreen = @"Welcome to PawsPurrfect

                      /^--^\     /^--^\     /^--^\
                      \____/     \____/     \____/
                     /      \   /      \   /      \
KAT                 |        | |        | |        |
                     \__  __/   \__  __/   \__  __/
|^|^|^|^|^|^|^|^|^|^|^|^\ \^|^|^|^/ /^|^|^|^|^\ \^|^|^|^|^|^|^|^|^|^|^|^|
| | | | | | | | | | | | |\ \| | |/ /| | | | | | \ \ | | | | | | | | | | |
########################/ /######\ \###########/ /#######################
| | | | | | | | | | | | \/| | | | \/| | | | | |\/ | | | | | | | | | | | |
|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|

Please Login To Continue";

while (!UserLoggedIn)
{
    Login();
}

string greeting = @"Welcome to PawsPurrfect

   |\__/,|   (`\
   |o o  |__ _)
 _.( T   )  `  /
((_ `^--' /_<  \
`` `-'(((/  (((/";

string choice = null;

while (choice != "0")
{
    MainMenu();
}

void Login()
{
    string username = null;
    string password = null;

    Console.Clear();
    Console.WriteLine(@$"{loginScreen}");

    Console.Write("Username: ");
    username = Console.ReadLine().ToLower().Trim();
    User MatchedAccount = users.FirstOrDefault(user => user.UserName.ToLower() == username);

    if (MatchedAccount != null)
    {
        Console.Write("Password: ");
        password = Console.ReadLine().ToLower().Trim();
        if (MatchedAccount.Password == password)
        {
            LoggedInUser = MatchedAccount;
            UserLoggedIn = true;
        }
        else
        {
            Console.Write("That password is incorrect. Press any key to try again...");
            Console.ReadKey();
        }
    }
    else
    {
        Console.Write("That username can not be found. Press any key to try again...");
        Console.ReadKey();
    }
};

void MainMenu()
{
    Console.Clear();
    Console.WriteLine(@$"
{greeting}

Menu Navigation:
0. Exit
1. View All Memes
2. Post a New Meme
3. Delete A Cat
4. See a Users Memes
");

    Console.Write("Please Type Your Selection's Number: ");
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
        case "1": //VIEW ALL CATS
            Console.Clear();
            ViewAllMemes();
            break;
        case "2": // POST A CAT
            Console.Clear();
            postMeme.Post(LoggedInUser, memes);
            break;
        case "3": //DELETE A CAT
            Console.Clear();
            DeleteCat();
            gf.Continue();
            break;
        case "4": // FILTER CATS BY USER
            Console.Clear();
            filterMemesByUser.Filter(users, memes);
            Console.ReadKey();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Invalid Choice. Press any key to continue...");
            Console.ReadKey();
            break;
    }
}

void ViewAllMemes()
{

    Meme chosenMeme = null;

    while (chosenMeme == null)
    {
        Console.Clear();
        Console.WriteLine(@"All Cat Memes
        ");
        foreach (Meme meme in memes) { Console.WriteLine(@$"{memes.IndexOf(meme) + 1}. {meme.Title}"); }

        Console.Write(@$"
Choose a number to view meme...or 0 to view main menu: ");

        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            if (response == 0)
            {
                MainMenu();
                break;
            }
            foreach (Meme meme in memes)
            {
                if (response - 1 == memes.IndexOf(meme))
                {
                    chosenMeme = meme;
                    break;
                }
            }
        }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Please type a valid number with no whitespace...");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.Clear();
            Console.WriteLine("Please choose an existing meme only...");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex);
            Console.WriteLine("NOPE...");
            Console.WriteLine("Press any key to try again.");
            Console.ReadKey();
        }
    }
    Console.Clear();
    ViewMemeDetails(chosenMeme);
}

void ViewMemeDetails(Meme chosenMeme)
{

    Console.WriteLine(@$"---------MEME DETAILS--------

Id:{chosenMeme.Id}
Name: {chosenMeme.LongName}
UserId: {chosenMeme.UserId}
Title: {chosenMeme.Title}
Description: {chosenMeme.Description}
Image: 
{chosenMeme.Image}
    ");

    Console.Write("Press Any Key to Retun to Main Menu...");
    Console.ReadKey();
    MainMenu();
};

void DeleteCat()
{
    Meme chosenCat = gf.ChooseFromListOfCats("Choose a Cat to Banish!!! o:", memes); //prompt, catlist

    Console.WriteLine($"Banishing {chosenCat.Title}.....");
    memes.Remove(chosenCat);
    Console.WriteLine("Done!");
}

public class TooLongException : Exception
{
    public TooLongException(string message) : base(message)
    {

    }
}

