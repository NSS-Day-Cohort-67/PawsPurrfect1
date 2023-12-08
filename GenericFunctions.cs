using System.Linq.Expressions;

public class GenericFunctions
{
    public void Continue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public Meme ChooseFromListOfCats(string prompt, List<Meme> memes)
    {
        Meme CatToReturn = null;

        while (CatToReturn == null)
        {
            foreach (Meme meme in memes)
            {
                Console.WriteLine(@$"{memes.IndexOf(meme) + 1}. {meme.Title}");
            }

            Console.WriteLine(prompt);
            int userInput = int.Parse(Console.ReadLine());
            CatToReturn = memes.FirstOrDefault(m => m.Id == userInput);
            Console.Clear();
            if (CatToReturn == null)
            {
                Console.WriteLine("Please Try Again...");
            }
        }
        return CatToReturn;
    }

    public Meme ChooseFromYourCats(string prompt, List<Meme> memes, User currentUser)
    {
        Meme returnCat = null;
        List<Meme> myMemes = new List<Meme>();
            Console.Clear();
            foreach (Meme meme in memes)
            {
                if (meme.UserId == currentUser.Id)
                {
                    myMemes.Add(meme);
                }
            }

            Console.WriteLine(prompt);

        while (returnCat == null)
        {

            try
            {

            foreach (Meme myMeme in myMemes)
            {
                Console.WriteLine(@$"{myMemes.IndexOf(myMeme) + 1}. {myMeme.Title}");
            }

                int userInput = int.Parse(Console.ReadLine());

                returnCat = myMemes.FirstOrDefault(mM => myMemes.IndexOf(mM) == userInput - 1);

                Console.Clear();
            }

            catch (Exception)
            {
                Console.Clear();
            }

            if (returnCat == null)
            {
                Console.Clear();
                Console.WriteLine("Please Try Again...");
            }
        }
        return returnCat;
    }
}
