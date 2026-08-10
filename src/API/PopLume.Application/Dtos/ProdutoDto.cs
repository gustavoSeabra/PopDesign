namespace PopLume.Application.Dtos;

public class ProdutoDto
{
    public Guid IdProduto { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int TempoImpressaoMinutos { get; set; }
    public int TempoMaoDeObraMinutos { get; set; }
    public Guid? IdEquipamento { get; set; }
    public List<ProdutoVariacaoDto> Variacoes { get; set; } = [];
    public List<ProdutoInsumoDto> Insumos { get; set; } = [];
    public List<ProdutoComponenteDto> Componentes { get; set; } = [];
}

public class CreateProdutoDto
{
    public string Nome { get; set; } = string.Empty;
    public int? TempoImpressaoMinutos { get; set; }
    public int? TempoMaoDeObraMinutos { get; set; }
    public Guid? IdEquipamento { get; set; }
    public List<ProdutoVariacaoInputDto>? Variacoes { get; set; }
    public List<ProdutoInsumoInputDto>? Insumos { get; set; }
    public List<ProdutoComponenteDto>? Componentes { get; set; }
}

public class UpdateProdutoDto : CreateProdutoDto
{
    public Guid IdProduto { get; set; }
}

public class ProdutoVariacaoInputDto
{
    public Guid IdProdutoVariacao { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? CodigoInterno { get; set; }
    public bool Ativa { get; set; } = true;
    public List<ProdutoVariacaoFilamentoInputDto> Filamentos { get; set; } = [];
}

public class ProdutoVariacaoDto
{
    public Guid IdProdutoVariacao { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? CodigoInterno { get; set; }
    public bool Ativa { get; set; }
    public decimal PrecoCusto { get; set; }
    public List<ProdutoVariacaoFilamentoDto> Filamentos { get; set; } = [];
}

public class ProdutoVariacaoFilamentoInputDto
{
    public Guid IdFilamento { get; set; }
    public decimal QuantidadeGramas { get; set; }
    public decimal PercentualPerda { get; set; }
}

public class ProdutoVariacaoFilamentoDto : ProdutoVariacaoFilamentoInputDto
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
    public Guid IdProdutoVariacaoFilho { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoCustoUnitario { get; set; }
}
