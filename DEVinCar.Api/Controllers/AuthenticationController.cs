using System;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]

public class AuthenticationController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthenticationController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] LoginDTO login)
    {
        var user = _userService.GetByUser(login);
        if (user == null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var token = TokenService.GenerateToken(_mapper.Map<User>(user));
        var refreshToken = RefreshTokenService.GenerateRefreshToken();
        RefreshTokenService.SaveRefreshToken(user.Name, refreshToken);

        return Ok(new
        {
            token,
            refreshToken
        });

    }

    [HttpPost]
    [Route("refresh-token")]
    [AllowAnonymous]
    public IActionResult Refresh([FromQuery] string token, string refreshToken)
    {
        var principal = RefreshTokenService.GetPrincipalFromExpiredToken(token);
        var username = principal.Identity.Name;
        var SaveRefreshToken = RefreshTokenService.GetRefreshToken(username);

        if (SaveRefreshToken != refreshToken)
            throw new SecurityTokenException("Invalid Token");

        var newToken = TokenService.GenerateToken(principal.Claims);
        var newRefreshToken = RefreshTokenService.GenerateRefreshToken();

        RefreshTokenService.DeleteRefreshToken(username, refreshToken);
        RefreshTokenService.SaveRefreshToken(username, newRefreshToken);

        return Ok(new
        {
            newToken,
            newRefreshToken
        });
    }
}