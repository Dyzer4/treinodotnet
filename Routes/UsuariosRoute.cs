namespace Usuarios.Routes;
using Usuarios.Model;

public static class UsuariosRoute
{
    public static void UsuariosRoutes(this WebApplication app)
    {
        var Route = app.MapGroup("Usuarios");
        Route.MapPost("", (UsuariosRequest req, UsuariosContext) =>
        {
            
        });
    }
}