using System;
using API.Entities;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {

        var users = await context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{Id:int}")]
    public async Task<ActionResult<AppUser>> GetUser(int Id) {

        var user = await context.Users.FindAsync(Id);

        if (user==null)
        return NotFound();

        return user;
    }
}
