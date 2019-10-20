using System;
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

    [HttpGet("{id}")]
    public ActionResult<VaultKeep> GetVaultKeepsByVaultId(int id)
    {
      try
      {
        return Ok(_vks.GetVaultKeepsByVaultId(id));
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

    [HttpDelete("{id}")]
    public ActionResult<int> DeleteVaultKeep(int id)
    {
      try
      {
        return Ok(_vks.DeleteVaultKeep(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}