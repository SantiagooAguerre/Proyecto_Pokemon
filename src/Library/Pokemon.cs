namespace Proyecto_Pokemon;

public class Pokemon : IPokemon
{
    public string Nombre { get; }
    public int Vida { get; private set; }
    public List<IHabilidad> Habilidades { get; }
    public ITipo TipoPrincipal { get; }
    public ITipo TipoSecundario { get; }

    public Pokemon(string nombre, int vida, ITipo tipoPrincipal, ITipo tipoSecundario = null)
    {
        Nombre = nombre;
        Vida = vida;
        TipoPrincipal = tipoPrincipal;
        TipoSecundario = tipoSecundario;
        Habilidades = new List<IHabilidad>();
    }

    public void AprenderHabilidad(IHabilidad habilidad)
    {
        if (Habilidades.Count < 4)
        {
            Habilidades.Add(habilidad);
        }
        else
        {
            throw new Exception("Este Pokémon ya tiene 4 habilidades.");
        }
    }

    public void Atacar(IPokemon objetivo, int habilidadIndex)
    {
        if (habilidadIndex < 0 || habilidadIndex >= Habilidades.Count)
        {
            throw new Exception("Índice de habilidad no válido.");
        }

        IHabilidad habilidad = Habilidades[habilidadIndex];
        int daño = habilidad.Usar(objetivo);
        objetivo.RecibirDaño(daño); 
    }

    public void RecibirDaño(int cantidad)
    {
        Vida -= cantidad;
        if (Vida < 0) Vida = 0;
    }

}