public class MemeDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string LongName
    {
        get { return Title + Description; }
    }
}