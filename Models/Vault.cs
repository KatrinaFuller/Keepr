using Keepr.Interfaces;

namespace Keepr.Models
{
  public class Vault : IVault
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}