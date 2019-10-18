namespace Keepr.Interfaces
{
  public interface IKeep
  {
    string Name { get; set; }
    string Description { get; set; }
    string Img { get; set; }
    bool IsPrivate { get; set; }
  }
}