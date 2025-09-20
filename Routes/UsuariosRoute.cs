using Microsoft.EntityFrameworkCore;
using Usuarios.Data;

namespace Usuarios.Routes;
using Usuarios.Model;

public static class UsuariosRoute
{
    public static void UsuariosRoutes(this WebApplication app)
    {
        var route = app.MapGroup("Usuarios");
        route.MapPost("", async (UsuariosRequest req, UsuariosContext context) =>
        {
            var usuario = new Usuarios(req.Nome);
            await context.AddAsync(usuario);
            await context.SaveChangesAsync();
        });

        route.MapGet("", async (UsuariosContext context) =>
        {
            var pessoas = await context.Usuario.ToListAsync();
            return Results.Ok(pessoas);
        });

        route.MapPut("{id:int}", async (int id, UsuariosRequest req, UsuariosContext context) =>
        {
            var pessoa = await context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            if (pessoa == null) 
                return Results.NotFound();
            
            pessoa.AlterarNome(req.Nome);  
            await context.SaveChangesAsync();
            return Results.Ok(pessoa);
        });

        route.MapDelete("{id:int}", async (int id, UsuariosContext context) =>
        {
            var pessoa = await context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            if (pessoa == null) 
                return Results.NotFound();
            
            pessoa.DeletarUsuario(); 
            await context.SaveChangesAsync();
            return Results.Ok(pessoa);
        });
    }
}