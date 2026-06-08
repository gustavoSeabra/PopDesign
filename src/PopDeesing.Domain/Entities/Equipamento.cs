namespace PopDesing.Domain.Entities;

public class Equipamento
{
    public Guid IdEquipamento { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public DateTime DataCompra { get; set; }
    public int Potencia { get; set; }
}
