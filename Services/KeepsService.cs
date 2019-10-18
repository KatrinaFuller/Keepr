using System;
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

    public object Get()
    {
      return _repo.Get();
    }

    public object GetKeepByUser(User user)
    {
      Keep exists = _repo.GetKeepByUser(user);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public object GetKeepByKeepId(int id)
    {
      Keep exists = _repo.GetKeepByKeepId(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public object Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;

    }

    public object Edit(Keep editKeep)
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

    public object Delete(int id)
    {
      throw new NotImplementedException();
    }


  }
}