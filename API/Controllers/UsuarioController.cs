﻿using API.Domain.IServices;
using API.Domain.Models;
using API.DTO;
using API.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Usuario usuario)
    {
        try
        {
            var validateExistence = await _usuarioService.ValidateExistence(usuario);
            if (validateExistence)
            {
                return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " ya existe! " });
            }
            usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
            await _usuarioService.SavedUser(usuario);
            return Ok(new { message = "Usuario registrado con exito" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Route("GetListUsuarios")]
    [HttpGet]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetListUsuarios()
    {
        try
        {
            var listUsuarios = await _usuarioService.GetListUsuarios();
            return Ok(listUsuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var usuario = await _usuarioService.GetUsuario(id);
            return Ok(usuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // localhost:xxxx/api/Usuario/CambiarPassword
    [Route("CambiarPassword")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut]
    public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
            string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
            var usuario = await _usuarioService.ValidatePassword(idUsuario, passwordEncriptado);
            if (usuario == null)
            {
                return BadRequest(new { message = "La password es incorrecta" });
            }
            else
            {
                usuario.Password = Encriptar.EncriptarPassword(cambiarPassword.nuevaPassword);
                await _usuarioService.UpdatePassword(usuario);
                return Ok(new { message = "La password fue actualizada con exito" });
            }


        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CambiarRol(long id, Usuario item)
    {
        if (id != item.Id)
        {
            return BadRequest(new { message = "Usuario no encontrado" });
        }
        await _usuarioService.UpdateRol(item);
        return Ok(new { message = "El nuevo rol fue asignado correctamente" });
    }
}