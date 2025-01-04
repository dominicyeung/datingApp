using System;
using API.Entities;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController
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
