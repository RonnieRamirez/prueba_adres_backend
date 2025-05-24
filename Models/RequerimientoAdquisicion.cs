namespace AdquisicionesBackend.Models
{
  public class RequerimientoAdquisicion
  {
    public int Id { get; set; }
    public decimal Presupuesto { get; set; }
    public string Unidad { get; set; }
    public string TipoBien { get; set; }
    public int Cantidad { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime FechaAdquisicion { get; set; }
    public string Proveedor { get; set; }
    public bool Activo { get; set; }
  }
}
