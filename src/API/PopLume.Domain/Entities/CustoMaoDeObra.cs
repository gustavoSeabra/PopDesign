namespace PopLume.Domain.Entities;

public class CustoMaoDeObra
{
    public Guid IdCustoMaoDeObra { get; set; }
    public decimal ValorHora { get; set; }
    public DateOnly InicioVigencia { get; set; }
    public DateOnly? FimVigencia { get; set; }

    public bool EstaVigenteEm(DateOnly data) =>
        data >= InicioVigencia && (!FimVigencia.HasValue || data <= FimVigencia.Value);
}
