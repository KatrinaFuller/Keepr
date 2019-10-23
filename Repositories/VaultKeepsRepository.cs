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

    public IEnumerable<VaultKeep> GetVaultKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"SELECT * FROM vaultkeeps vk
          INNER JOIN keeps k ON k.id = vk.keepId
          WHERE(vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<VaultKeep>(sql, new { vaultId, userId });
    }

    public int CreateVaultKeep(VaultKeep newVaultKeep)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (vaultId, userId, keepId)
      VALUES
      (@VaultId, @UserId, @KeepId)";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }

    // public void DeleteVaultKeep(int id)
    // {
    //   string sql = "DELETE FROM vaultkeeps WHERE id = @id";
    //   _db.Execute(sql, new { id });
    // }

    public VaultKeep GetVaultKeepsByVaultIdKeepIdAndUserId(int vaultId, int keepId, string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE keepId = @keepId and vaultId = @vaultId and userId = @userId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId, userId });
    }

    public void RemoveVaultKeep(int keepId, int vaultId, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE keepId = @keepId and vaultId = @vaultId and userId = @userId";
      _db.Execute(sql, new { vaultId, keepId, userId });
    }
  }
}