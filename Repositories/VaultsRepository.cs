using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
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
    // public IEnumerable<Vault> Get()
    // {
    //   string sql = "SELECT * FROM  vaults";
    //   return _db.Query<Vault>(sql);
    // }
    public IEnumerable<Vault> GetVaultByUserId(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }

    public Vault GetVaultById(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }


    public int CreateVault(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults
      (name, description, userId)
      VALUES
      (@Name, @Description, @UserId)";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public void DeleteVault(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}