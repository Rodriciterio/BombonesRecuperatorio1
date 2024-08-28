namespace Bombones.Entidades.Dtos
{
    public class ProveedorListDto
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Mail { get; set; } = null!;

    }
}
