namespace PopLume.Application.Dtos;

public class ProdutoDto
{
    public Guid IdProduto { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal PrecoCusto { get; set; }
    public int TempoImpressaoMinutos { get; set; }
    public int TempoMaoDeObraMinutos { get; set; }
    public Guid? IdEquipamento { get; set; }
    public List<ProdutoFilamentoDto> Filamentos { get; set; } = [];
    public List<ProdutoInsumoDto> Insumos { get; set; } = [];
    public List<ProdutoComponenteDto> Componentes { get; set; } = [];
}

public class CreateProdutoDto
{
    public string Nome { get; set; } = string.Empty;
    public int? TempoImpressaoMinutos { get; set; }
    public int? TempoMaoDeObraMinutos { get; set; }
    public Guid? IdEquipamento { get; set; }
    public List<ProdutoFilamentoInputDto>? Filamentos { get; set; }
    public List<ProdutoInsumoInputDto>? Insumos { get; set; }
    public List<ProdutoComponenteDto>? Componentes { get; set; }
}

public class UpdateProdutoDto : CreateProdutoDto
{
    public Guid IdProduto { get; set; }
}

public class ProdutoFilamentoInputDto
{
    public Guid IdFilamento { get; set; }
    public decimal QuantidadeGramas { get; set; }
    public decimal PercentualPerda { get; set; }
}

public class ProdutoFilamentoDto : ProdutoFilamentoInputDto
{
    public string Cor { get; set; } = string.Empty;
    public decimal Custo { get; set; }
}

public class ProdutoInsumoInputDto
{
    public Guid IdInsumo { get; set; }
    public decimal QuantidadeUtilizada { get; set; }
}

public class ProdutoInsumoDto : ProdutoInsumoInputDto
{
    public string Nome { get; set; } = string.Empty;
    public decimal Custo { get; set; }
}

public class ProdutoComponenteDto
{
    public Guid IdProdutoFilho { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoCustoUnitario { get; set; }
}
