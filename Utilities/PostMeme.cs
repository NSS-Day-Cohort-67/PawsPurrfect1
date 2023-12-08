public class PostMeme
{
  public void Post(User user, List<Meme> memes)
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
    while (string.IsNullOrEmpty(imageToPost))
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
    while (string.IsNullOrEmpty(descriptionToPost) || descriptionToPost.Length > 500)
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
}