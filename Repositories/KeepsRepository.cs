using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }

    public Keep GetKeepByUserId(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.QueryFirstOrDefault<Keep>(sql, new { userId });
    }

    public Keep GetKeepByKeepId(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    public int Create(Keep newKeep)
    {
      string sql = @"
        INSERT INTO keeps
        (name, description, img, isPrivate, userId)
        VALUES
        (@Name, @Description, @Img, @IsPrivate, @UserId)";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    public void Edit(Keep keep)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}