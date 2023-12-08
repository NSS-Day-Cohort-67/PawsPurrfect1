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

        while(CatToReturn == null)
        {
            foreach (Meme meme in memes)
            {
                Console.WriteLine(@$"{memes.IndexOf(meme) + 1}. {meme.Title}");
            }

            Console.WriteLine(prompt);
            int userInput = int.Parse(Console.ReadLine());
            CatToReturn = memes.FirstOrDefault(m => m.Id == userInput);
            Console.Clear();
            if(CatToReturn == null)
            {
                Console.WriteLine("Please Try Again...");
            }
        }
        return CatToReturn;
    }
} 
