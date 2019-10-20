using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    public readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }

    public object GetVaultByUserId(string userId)
    {
      Vault exists = _repo.GetVaultByUserId(userId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public object GetVaultById(int id)
    {
      Vault exists = _repo.GetVaultById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public object CreateVault(Vault newVault)
    {
      int id = _repo.CreateVault(newVault);
      newVault.Id = id;
      return newVault;
    }

    public string DeleteVault(int id)
    {
      Vault exists = _repo.GetVaultById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.DeleteVault(id);
      return "Vault has been deleted";
    }
  }
}