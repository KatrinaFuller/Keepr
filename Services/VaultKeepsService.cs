using System;
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

    public VaultKeep GetVaultKeepsByVaultId(int vaultId)
    {
      VaultKeep exists = _repo.GetVaultKeepsByVaultId(vaultId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
    {
      int id = _repo.CreateVaultKeep(newVaultKeep);
      newVaultKeep.VaultId = id;
      return newVaultKeep;
    }

    public string DeleteVaultKeep(int id)
    {
      VaultKeep exists = _repo.GetVaultKeepsByVaultId(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.DeleteVaultKeep(id);
      return "VaultKeep has been deleted";
    }
  }
}