using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopInventory.API.Databases.Models;

[PrimaryKey("Artigo", "Unidade", "Moeda")]
public class ArtigoMoedum
{
    [Key]
    [StringLength(48)]
    public string Artigo { get; set; } = null!;

    [Key]
    [StringLength(3)]
    public string Moeda { get; set; } = null!;

    [Column("PVP1")]
    public double? Pvp1 { get; set; }

    [Column("PVP2")]
    public double? Pvp2 { get; set; }

    [Column("PVP3")]
    public double? Pvp3 { get; set; }

    [Column("PVP4")]
    public double? Pvp4 { get; set; }

    [Column("PVP5")]
    public double? Pvp5 { get; set; }

    [Column("PVP6")]
    public double? Pvp6 { get; set; }

    public byte[]? VersaoUltAct { get; set; }

    [Key]
    [StringLength(5)]
    public string Unidade { get; set; } = null!;

    [Column("PVP1IvaIncluido")]
    public bool Pvp1ivaIncluido { get; set; }

    [Column("PVP2IvaIncluido")]
    public bool Pvp2ivaIncluido { get; set; }

    [Column("PVP3IvaIncluido")]
    public bool Pvp3ivaIncluido { get; set; }

    [Column("PVP4IvaIncluido")]
    public bool Pvp4ivaIncluido { get; set; }

    [Column("PVP5IvaIncluido")]
    public bool Pvp5ivaIncluido { get; set; }

    [Column("PVP6IvaIncluido")]
    public bool Pvp6ivaIncluido { get; set; }

    [ForeignKey("Artigo")]
    [InverseProperty("ArtigoMoeda")]
    public virtual Artigo ArtigoNavigation { get; set; } = null!;
}
