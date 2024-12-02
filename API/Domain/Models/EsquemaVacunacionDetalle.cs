using API.Domain.Models.Esquema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Models;

public class EsquemaVacunacionDetalle
{
    [Key]
    public int Id { get; set; } // Identificador único del detalle

    [Required]
    public int EsquemaVacunacionId { get; set; } // Identificador del esquema al que pertenece
    [ForeignKey("EsquemaVacunacionId")]
    public EsquemaVacunacion EsquemaVacunacion { get; set; } // Relación con EsquemaVacunacion

    public int? VacunaId { get; set; } // Identificador de la vacuna utilizada (opcional)
    [ForeignKey("VacunaId")]
    public Vacuna? Vacuna { get; set; } // Relación con Vacuna

    public int? SueroId { get; set; } // Identificador del suero utilizado (opcional)
    [ForeignKey("SueroId")]
    public Suero? Suero { get; set; } // Relación con Suero

    public int? DiluyenteId { get; set; } // Identificador del diluyente utilizado (opcional)
    [ForeignKey("DiluyenteId")]
    public Diluyente? Diluyente { get; set; } // Relación con Diluyente

    public int? JeringaId { get; set; } // Identificador de la jeringa utilizada (opcional)
    [ForeignKey("JeringaId")]
    public Jeringa? Jeringa { get; set; } // Relación con Jeringa

    [Required]
    public int CantidadUtilizada { get; set; } // Cantidad utilizada del elemento
}
