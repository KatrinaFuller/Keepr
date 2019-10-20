using System;
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

    public VaultKeep GetVaultKeepsByVaultId(int vaultId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE vaultId = @vaultId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId });
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

    public void DeleteVaultKeep(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}