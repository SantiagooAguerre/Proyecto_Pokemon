namespace Proyecto_Pokemon;

public interface IPokemon
{
    string Nombre { get; }
    int Vida { get; }
    List<IHabilidad> Habilidades { get; }
    ITipo TipoPrincipal { get; }
    ITipo TipoSecundario { get; }

    void AprenderHabilidad(IHabilidad habilidad);
    void Atacar(IPokemon objetivo, int habilidadIndex);
    void RecibirDaño(int cantidad);
}