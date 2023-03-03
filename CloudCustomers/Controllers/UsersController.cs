﻿using CloudCustomers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _usersService;

    public UsersController(IUserService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        
        var users = await _usersService.GetAllUsers();
        if (users.Any()) {
            return Ok(users);
        }
        return NotFound();
    }
}

