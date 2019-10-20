using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    public readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<Keep> GetKeepByUserId(string userId)
    {
      IEnumerable<Keep> exists = _repo.GetKeepByUserId(userId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public Keep GetKeepByKeepId(int id)
    {
      Keep exists = _repo.GetKeepByKeepId(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public Keep Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;

    }

    public Keep Edit(Keep editKeep)
    {
      Keep keep = _repo.GetKeepByKeepId(editKeep.Id);
      if (keep == null)
      {
        throw new Exception("Invalid Id");
      }
      keep.Name = editKeep.Name;
      keep.Description = editKeep.Description;
      keep.Img = editKeep.Img;
      keep.IsPrivate = editKeep.IsPrivate;
      _repo.Edit(keep);
      return keep;
    }

    public string Delete(int id)
    {
      Keep exists = _repo.GetKeepByKeepId(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return "Keep has been deleted";
    }


  }
}