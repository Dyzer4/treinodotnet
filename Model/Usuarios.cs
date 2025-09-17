namespace Usuarios.Model;

public class Usuarios
{
    public Usuarios(string nome)
    {
        Nome = nome;
    }

    public int Id { get; set; } 
    public string Nome { get; private set; }

    
}