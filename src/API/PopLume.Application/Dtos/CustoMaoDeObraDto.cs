namespace PopLume.Application.Dtos;

public class CustoMaoDeObraDto
{
    public Guid IdCustoMaoDeObra { get; set; }
    public decimal ValorHora { get; set; }
    public DateOnly InicioVigencia { get; set; }
    public DateOnly? FimVigencia { get; set; }
}

public class CreateCustoMaoDeObraDto
{
    public decimal? ValorHora { get; set; }
    public DateOnly? InicioVigencia { get; set; }
    public DateOnly? FimVigencia { get; set; }
}
