using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{user}")]
    public ActionResult<Keep> GetKeepByUser(User user)
    {
      try
      {
        return Ok(_ks.GetKeepByUser(user));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetKeepByKeepId(int id)
    {
      try
      {
        return Ok(_ks.GetKeepByKeepId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Keep> Edit([FromBody] Keep editKeep, int id)
    {
      try
      {
        editKeep.Id = id;
        return Ok(_ks.Edit(editKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<int> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}