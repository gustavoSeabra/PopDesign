﻿namespace PopLume.Domain.Entities;

public class ProdutoComposicao
{
    public Guid IdProdutoComposicao { get; set; }
    public Guid IdProdutoPai { get; set; }
    public Guid IdProdutoFilho { get; set; }
    public Guid IdProdutoVariacaoFilho { get; set; }
    public int Quantidade { get; set; }

    // Propriedades de Navegação
    public virtual Produto ProdutoPai { get; set; } = null!;
    public virtual Produto ProdutoFilho { get; set; } = null!;
    public virtual ProdutoVariacao ProdutoVariacaoFilho { get; set; } = null!;
}
