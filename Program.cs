using System.ComponentModel.DataAnnotations;
using MinimalApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();


app.MapPost("/clientes/cadastrar", async (Cliente cliente, AppDataContext dbContext) =>
{
    dbContext.Clientes.Add(cliente);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/clientes/{cliente.ClienteId}", cliente);
});

app.MapGet("/clientes/listar", async(AppDataContext dbContext)=> {
  var clientes = await dbContext.Clientes.ToListAsync();
  return Results.Ok(clientes);
});

app.MapGet("/clientes/{id}", async (int id, AppDataContext dbContext) =>
{
    var cliente = await dbContext.Clientes.FindAsync(id);
    return cliente != null ? Results.Ok(cliente) : Results.NotFound();
});

app.MapPut("/clientes/{id}", async (int id, Cliente updatedCliente, AppDataContext dbContext) =>
{
    var cliente = await dbContext.Clientes.FindAsync(id);
    if (cliente == null) return Results.NotFound();
    
    cliente.Nome = updatedCliente.Nome;
    cliente.Email = updatedCliente.Email;
    
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/clientes/{id}", async (int id, AppDataContext dbContext) =>
{
    var cliente = await dbContext.Clientes.FindAsync(id);
    if (cliente == null) return Results.NotFound();

    dbContext.Clientes.Remove(cliente);
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
