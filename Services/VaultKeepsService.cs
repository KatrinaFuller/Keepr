using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    public readonly VaultKeepsRepository _repo;
    public readonly VaultsRepository _vrepo;
    public readonly KeepsRepository _krepo;
    public VaultKeepsService(VaultKeepsRepository repo, VaultsRepository vrepo, KeepsRepository krepo)
    {
      _repo = repo;
      _vrepo = vrepo;
      _krepo = krepo;
    }

    public IEnumerable<Keep> GetVaultKeepsByVaultId(int vaultId, string userId)
    {
      // Keep exists = _repo.GetVaultKeepsByVaultId(vaultId);
      // if (exists == null)
      // {
      //   throw new Exception("Invalid Id");
      // }
      return _repo.GetVaultKeepsByVaultId(vaultId, userId);
    }

    public string CreateVaultKeep(VaultKeep newVaultKeep)
    {
      Vault vault = _vrepo.GetVaultById(newVaultKeep.VaultId);
      if (vault == null) { throw new Exception("invalid id"); }
      Keep keep = _krepo.GetKeepByKeepId(newVaultKeep.KeepId);
      if (keep == null) { throw new Exception("invalid id"); }
      _repo.CreateVaultKeep(newVaultKeep.VaultId, newVaultKeep.KeepId, newVaultKeep.UserId);

      return "success";
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

    public string RemoveVaultKeep(VaultKeep vaultKeep, string userId)
    {
      VaultKeep vKeep = _repo.GetVaultKeepsByVaultIdKeepIdAndUserId(vaultKeep);
      int id = vKeep.Id;
      if (vKeep == null || vKeep.UserId != userId)
      {
        throw new Exception("Invalid Vault Id");
      }
      _repo.RemoveVaultKeep(id);
      return "Removed VaultKeep";
    }
  }
}