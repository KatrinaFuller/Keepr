using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet("{vaultId}")]
    public ActionResult<VaultKeep> GetVaultKeepsByVaultId(int vaultId)
    {
      try
      {
        // var id = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.GetVaultKeepsByVaultId(vaultId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<VaultKeep> CreateVaultKeep([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        newVaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.CreateVaultKeep(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpDelete("{id}")]
    // public ActionResult<int> DeleteVaultKeep(int id)
    // {
    //   try
    //   {
    //     return Ok(_vks.DeleteVaultKeep(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPut]
    public ActionResult<string> RemoveVaultKeep([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.RemoveVaultKeep(vaultKeep.VaultId, vaultKeep.KeepId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}