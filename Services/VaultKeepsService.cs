using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    public readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<VaultKeep> GetVaultKeepsByVaultId(int vaultId, string userId)
    {
      // Keep exists = _repo.GetVaultKeepsByVaultId(vaultId);
      // if (exists == null)
      // {
      //   throw new Exception("Invalid Id");
      // }
      return _repo.GetVaultKeepsByVaultId(vaultId, userId);
    }

    public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
    {
      int id = _repo.CreateVaultKeep(newVaultKeep);
      newVaultKeep.VaultId = id;
      return newVaultKeep;
    }

    // public string DeleteVaultKeep(int id)
    // {
    //   VaultKeep exists = _repo.GetVaultKeepsByVaultId(id);
    //   if (exists == null)
    //   {
    //     throw new Exception("Invalid Id");
    //   }
    //   _repo.DeleteVaultKeep(id);
    //   return "VaultKeep has been deleted";
    // }

    public string RemoveVaultKeep(int vaultId, int keepId, string userId)
    {
      VaultKeep vaultKeep = _repo.GetVaultKeepsByVaultIdKeepIdAndUserId(vaultId, keepId, userId);
      if (vaultKeep == null || vaultKeep.UserId != userId)
      {
        throw new Exception("Invalid Vault Id");
      }
      _repo.RemoveVaultKeep(vaultId, keepId, userId);
      return "Removed VaultKeep";
    }
  }
}