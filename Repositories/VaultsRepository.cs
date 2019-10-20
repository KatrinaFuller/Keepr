using System;
using System.Data;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public object Get()
    {
      throw new NotImplementedException();
    }
    public Vault GetVaultByUserId(string userId)
    {
      throw new NotImplementedException();
    }

    public Vault GetVaultById(int id)
    {
      throw new NotImplementedException();
    }


    public int CreateVault(Vault newVault)
    {
      throw new NotImplementedException();
    }

    public void DeleteVault(int id)
    {
      throw new NotImplementedException();
    }
  }
}