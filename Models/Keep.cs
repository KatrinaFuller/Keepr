using Keepr.Interfaces;

namespace Keepr.Models
{
  public class Keep : IKeep
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public bool IsPrivate { get; set; }
  }
}