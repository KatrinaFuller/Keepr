using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetVaultKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"SELECT * FROM vaultkeeps vk
          INNER JOIN keeps k ON k.id = vk.keepId
          WHERE(vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }

    public void CreateVaultKeep(int VaultId, int KeepId, string userId)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (vaultId, userId, keepId)
      VALUES
      (@VaultId, @UserId, @KeepId)";
      _db.Execute(sql, new { VaultId, KeepId, userId });
    }

    // public void DeleteVaultKeep(int id)
    // {
    //   string sql = "DELETE FROM vaultkeeps WHERE id = @id";
    //   _db.Execute(sql, new { id });
    // }

    public VaultKeep GetVaultKeepsByVaultIdKeepIdAndUserId(VaultKeep vKeep)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE keepId = @keepId AND vaultId = @vaultId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, vKeep);
    }

    public void RemoveVaultKeep(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}