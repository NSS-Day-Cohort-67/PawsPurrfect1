﻿List<Meme> memes = new List<Meme>()
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
// User user = null;
User user = users[0];

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
    Console.Write("Password: ");
    password = Console.ReadLine().ToLower().Trim();

    UserLoggedIn = true;
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
3. Something Else
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
        case "1":
            Console.Clear();
            ViewAllMemes();
            break;
        case "2":
            Console.Clear();
            PostMeme();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("This isn't implemented yet. Press any key to continue...");
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
    Console.WriteLine(@"All Cat Memes
    ");

    foreach (Meme meme in memes)
    {
        Console.WriteLine(@$"{memes.IndexOf(meme) + 1}. {meme.Title}");
    }

    Console.WriteLine(@$"
Please press any key to continue...");
    Console.ReadKey();
};

void PostMeme()
{
    //Get Title, Image, and Description from logged in user
    Console.WriteLine("Please enter the details of the cat meme to be posted:");
    // Get Title
    Console.WriteLine("Enter the title of your meme:");
    string titleToPost = "";
    while (string.IsNullOrEmpty(titleToPost) || titleToPost.Length > 100)
    {
        try
        {
            titleToPost = Console.ReadLine();
            if (titleToPost.Length > 100)
            {
                throw new TooLongException("Title is too long. Reenter the title of your meme:");
            }
        }
        catch (TooLongException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Get Image
    Console.WriteLine("Enter the ASCII Image:");
    string imageToPost = "";
    while(string.IsNullOrEmpty(imageToPost))
    {
        try
        {
            imageToPost = Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    // Get Description
    Console.WriteLine("Enter the Meme's description:");
    string descriptionToPost = "";
    while(string.IsNullOrEmpty(descriptionToPost) || descriptionToPost.Length > 500)
    {
        try
        {
            descriptionToPost = Console.ReadLine();
            if (descriptionToPost.Length > 500)
            {
                throw new TooLongException("Description is too long. Reenter the Meme's description:");
            }
        }
        catch (TooLongException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    Meme memeToPost = new Meme
    {
        UserId = user.Id,
        Title = titleToPost,
        Image = imageToPost,
        Description = descriptionToPost
    };

    memes.Add(memeToPost);
    Console.WriteLine("Your cat meme has been added!");
}



public class TooLongException : Exception
{
  public TooLongException(string message) : base(message)
  {

  }
}