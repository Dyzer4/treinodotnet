namespace Usuarios.Model;

public class Usuarios
{
    public Usuarios(string nome)
    {
        Nome = nome;
    }

    public int Id { get; set; } 
    public string Nome { get; private set; }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }

    public void DeletarUsuario()
    {
        Nome = "DESATIVADO";
    }
}