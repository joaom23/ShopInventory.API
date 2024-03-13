using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopInventory.API.Models;

[Table("Artigo")]
public partial class Artigo
{
    [Key]
    [Column("Artigo")]
    [StringLength(48)]
    public string Artigo1 { get; set; } = null!;

    [StringLength(50)]
    public string? Descricao { get; set; }

    [StringLength(15)]
    public string? CodBarras { get; set; }

    [StringLength(5)]
    public string? UnidadeVenda { get; set; }

    [StringLength(5)]
    public string UnidadeBase { get; set; } = null!;

    [StringLength(2)]
    public string Iva { get; set; } = null!;

    public float? Desconto { get; set; }

    [StringLength(12)]
    public string? Fornecedor { get; set; }

    [Column("STKMinimo")]
    public double? Stkminimo { get; set; }

    [Column("STKMaximo")]
    public double? Stkmaximo { get; set; }

    [Column("STKReposicao")]
    public double? Stkreposicao { get; set; }

    [Column("STKActual")]
    public double? Stkactual { get; set; }

    [Column("PCMedio")]
    public double? Pcmedio { get; set; }

    [Column("PCUltimo")]
    public double? Pcultimo { get; set; }

    [StringLength(1)]
    public string? MovStock { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataUltEntrada { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataUltSaida { get; set; }

    [StringLength(10)]
    public string? Familia { get; set; }

    [StringLength(48)]
    public string? ArtSubstituto { get; set; }

    [StringLength(48)]
    public string? ArtAssociado { get; set; }

    [StringLength(5)]
    public string? ArmazemSugestao { get; set; }

    [StringLength(3)]
    public string TipoArtigo { get; set; } = null!;

    public short? TipoComponente { get; set; }

    [Column("NecessarioRecalcPCM")]
    public bool NecessarioRecalcPcm { get; set; }

    [Column("PCPadrao")]
    public double? Pcpadrao { get; set; }

    public short? SugestaoPrComposto { get; set; }

    public double? UltDescontoComercialCompra { get; set; }

    public double? UltDespesaAdicionalCompra { get; set; }

    public short? PrazoEntrega { get; set; }

    public double? QtdEconomica { get; set; }

    [StringLength(5)]
    public string? FormulaVendas { get; set; }

    [StringLength(12)]
    public string? UltimoFornecedor { get; set; }

    [StringLength(10)]
    public string? SubFamilia { get; set; }

    [StringLength(5)]
    public string? UltimoTipoDoc { get; set; }

    public int? UltimoNumDoc { get; set; }

    public double? Peso { get; set; }

    public double? Volume { get; set; }

    [StringLength(10)]
    public string? Marca { get; set; }

    [StringLength(3)]
    public string? Garantia { get; set; }

    public bool ArtigoAnulado { get; set; }

    public bool TratamentoSeries { get; set; }

    public bool TratamentoLotes { get; set; }

    public bool LoteFormulaEntradas { get; set; }

    [StringLength(20)]
    public string? LoteEntradas { get; set; }

    public bool LoteFormulaSaidas { get; set; }

    [StringLength(20)]
    public string? LoteSaidas { get; set; }

    [StringLength(5)]
    public string? FormulaCompras { get; set; }

    [StringLength(50)]
    public string? UltimoNumSerie { get; set; }

    [StringLength(50)]
    public string? UltimoLote { get; set; }

    [StringLength(8)]
    public string? IntrastatPautal { get; set; }

    public double? IntrastatPeso { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataUltimaActualizacao { get; set; }

    public bool TestaNumSerie { get; set; }

    public bool SujeitoRetencao { get; set; }

    [Column(TypeName = "ntext")]
    public string? Observacoes { get; set; }

    [StringLength(15)]
    public string? TipoDim1 { get; set; }

    [StringLength(15)]
    public string? TipoDim2 { get; set; }

    [StringLength(15)]
    public string? TipoDim3 { get; set; }

    [StringLength(20)]
    public string? Dim1 { get; set; }

    [StringLength(20)]
    public string? Dim2 { get; set; }

    [StringLength(20)]
    public string? Dim3 { get; set; }

    public bool DimLote { get; set; }

    public short TratamentoDim { get; set; }

    [StringLength(20)]
    public string? Etiqueta { get; set; }

    public byte[]? VersaoUltAct { get; set; }

    public bool OperacaoTesouraria { get; set; }

    [Column("EntidadeOPTesouraria")]
    [StringLength(12)]
    public string? EntidadeOptesouraria { get; set; }

    [StringLength(20)]
    public string? Modelo { get; set; }

    [StringLength(5)]
    public string? UnidadeCompra { get; set; }

    [StringLength(5)]
    public string? UnidadeEntrada { get; set; }

    [StringLength(5)]
    public string? UnidadeSaida { get; set; }

    [StringLength(5)]
    public string? UltimaSerieDoc { get; set; }

    public bool DeduzIvaNoImo { get; set; }

    public bool PermiteDevolucao { get; set; }

    [StringLength(1)]
    public string? TipoEntidadeOpTesouraria { get; set; }

    public bool Imposto { get; set; }

    [StringLength(5)]
    public string? TipoDocOpTesouraria { get; set; }

    [Column("UtilizadoCCOP")]
    public bool UtilizadoCcop { get; set; }

    public bool Pesar { get; set; }

    [Column("IdGDOC")]
    public Guid? IdGdoc { get; set; }

    public bool SujeitoProRata { get; set; }

    public float? PercIvaDedutivel { get; set; }

    public bool SujeitoEcotaxa { get; set; }

    public double? Ecovalor { get; set; }

    [Column("AfectaPCM")]
    public bool AfectaPcm { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LocalizacaoSugestao { get; set; }

    [StringLength(48)]
    public string? ArtigoPai { get; set; }

    public int? OrdemDim { get; set; }

    [StringLength(10)]
    public string? RubDim1 { get; set; }

    [StringLength(10)]
    public string? RubDim2 { get; set; }

    [StringLength(10)]
    public string? RubDim3 { get; set; }

    [Column("IDTipoOrigemGPR")]
    public byte? IdtipoOrigemGpr { get; set; }

    [Column("FabCompAutoGPR")]
    public bool FabCompAutoGpr { get; set; }

    [Column("CalcNecessidadesGPR")]
    public bool CalcNecessidadesGpr { get; set; }

    [Column("QtReservadaGPR")]
    public float? QtReservadaGpr { get; set; }

    [Column("QtReceberGPR")]
    public float? QtReceberGpr { get; set; }

    [Column("IDTipoProducaoGPR")]
    public byte? IdtipoProducaoGpr { get; set; }

    [Column("DesperdicioGPR")]
    public float? DesperdicioGpr { get; set; }

    [Column("UtilizadoGPR")]
    public bool UtilizadoGpr { get; set; }

    [Column("PercIncidenciaIVA")]
    public double? PercIncidenciaIva { get; set; }

    public int? NaturezaAnalitica { get; set; }

    public Guid? IdClassificacao { get; set; }

    [Column("FormulaGPR")]
    [StringLength(5)]
    public string? FormulaGpr { get; set; }

    [Column("SequenciaGPR")]
    public int? SequenciaGpr { get; set; }

    [Column("CDU_CampoVar1")]
    [StringLength(15)]
    public string? CduCampoVar1 { get; set; }

    [Column("CDU_CampoVar2")]
    [StringLength(15)]
    public string? CduCampoVar2 { get; set; }

    [Column("CDU_CampoVar3")]
    [StringLength(15)]
    public string? CduCampoVar3 { get; set; }

    [Column("SujeitoIEC")]
    public bool? SujeitoIec { get; set; }

    [Column("CategoriaIEC")]
    [StringLength(10)]
    public string? CategoriaIec { get; set; }

    [StringLength(10)]
    public string? CodigoTaric { get; set; }

    [Column("EmbalagemIEC")]
    [StringLength(2)]
    public string? EmbalagemIec { get; set; }

    [Column("CapacidadeEmbIEC")]
    public double? CapacidadeEmbIec { get; set; }

    [StringLength(5)]
    public string? UnidadeTaric { get; set; }

    [Column("FactConvIEC")]
    public double? FactConvIec { get; set; }

    [Column("ValorIEC")]
    public double? ValorIec { get; set; }

    public double? TaxaAlcool { get; set; }

    public bool? UtilManutencao { get; set; }

    public bool SacosLeves { get; set; }

    [ForeignKey("ArtigoPai")]
    [InverseProperty("InverseArtigoPaiNavigation")]
    public virtual Artigo? ArtigoPaiNavigation { get; set; }

    [InverseProperty("ArtigoPaiNavigation")]
    public virtual ICollection<Artigo> InverseArtigoPaiNavigation { get; set; } = new List<Artigo>();
}
