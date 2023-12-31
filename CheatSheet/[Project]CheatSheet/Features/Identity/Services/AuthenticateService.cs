﻿namespace _Project_CheatSheet.Features.Identity.Services;

using AutoMapper;
using Common.Exceptions;
using Constants.GlobalConstants.Authentication;
using Infrastructure.Data.SQL.Models;
using Infrastructure.Data.SQL.Models.Enums;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthenticateService : IAuthenticateService
{
    private const int IdentityTokenHoursExpiration = 48;

    private readonly IConfiguration configuration;
    private readonly IMapper mapper;
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;

    public AuthenticateService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration configuration,
        IMapper mapper)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
        this.mapper = mapper;
    }

    public async Task<Response> AuthenticateLogin(IdentityLoginModel identityLoginModel)
    {
        var user = await userManager.FindByNameAsync(identityLoginModel.Username);
        if (user == null)
        {
            throw new ServiceException(AuthenticationMessages.WrongCredentials);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, identityLoginModel.Password, false);
        if (!result.Succeeded)
        {
            throw new ServiceException(AuthenticationMessages.WrongCredentials);
        }

        var userRoles = await userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = GetToken(authClaims);

        var response = await GetResponse(token, user);
        return response;
    }

    public async Task<Response> AuthenticateRegister(IdentityRegisterModel identityRegisterModel)
    {
        var userNameExists = await userManager.FindByNameAsync(identityRegisterModel.UserName);
        if (userNameExists != null)
        {
            throw new ServiceException(AuthenticationMessages.UserNameOrEmailExist);
        }

        var emailExists = await userManager.FindByEmailAsync(identityRegisterModel.Email);
        if (emailExists != null)
        {
            throw new ServiceException(AuthenticationMessages.UserNameOrEmailExist);
        }

        var user = mapper.Map<User>(identityRegisterModel);
        var result = await userManager.CreateAsync(user, identityRegisterModel.Password);

        if (!result.Succeeded)
        {
            throw new ServiceException(AuthenticationMessages.IssueWithRegister);
        }

        await userManager.AddToRoleAsync(user, ApplicationRolesEnum.User.ToString());

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, ApplicationRolesEnum.User.ToString())
        };

        var token = GetToken(authClaims);
        var response = await GetResponse(token, user);
        return response;
    }

    private async Task<Response> GetResponse(JwtSecurityToken token, User user)
    {
        var response = new Response();

        response.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
        response.Roles = await userManager.GetRolesAsync(user);
        response.UserId = user.Id;
        return response;
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            configuration["JWT:ValidIssuer"],
            configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(IdentityTokenHoursExpiration),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}