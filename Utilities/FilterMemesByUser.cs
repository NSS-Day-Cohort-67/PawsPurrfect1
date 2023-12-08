public class FilterMemesByUser
{
  public void Filter(List<User> users, List<Meme> memes)
  {
    Console.WriteLine("Which user's memes would you like to see? Enter a number:");
    foreach (User u in users)
    {
      Console.WriteLine($"{u.Id}. {u.UserName}");
    }

    int chosenUserId = -1;

    while (chosenUserId < 1 || chosenUserId > users.Count)
    {
      try
      {
        chosenUserId = int.Parse(Console.ReadLine());
        List<Meme> filteredMemes = memes.Where(m => m.UserId == chosenUserId).ToList();
  
        foreach(Meme m in filteredMemes)
        {
          Console.WriteLine(m.LongName);
          Console.WriteLine(m.Image);
        }


        if (chosenUserId < 1 || chosenUserId > users.Count)
        {
          throw new Exception("Please enter a valid number.");
        }
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }


    }
  }
}
