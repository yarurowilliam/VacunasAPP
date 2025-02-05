namespace API.Domain.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Paciente
{
    [Key]
    public int Id { get; set; } // Identificador �nico del paciente

    [Required]
    public DateTime FechaAtencion { get; set; } // Fecha de atenci�n (d�a/mes/a�o)

    [Required]
    [StringLength(20)]
    public string TipoIdentificacion { get; set; } // Tipo de identificaci�n (ej., CC, TI)

    [Required]
    [StringLength(20)]
    public string NumeroIdentificacion { get; set; } // N�mero de identificaci�n (obligatorio)

    [Required]
    [StringLength(50)]
    public string PrimerNombre { get; set; } // Primer nombre (obligatorio)

    [StringLength(50)]
    public string SegundoNombre { get; set; } // Segundo nombre (opcional)

    [Required]
    [StringLength(50)]
    public string PrimerApellido { get; set; } // Primer apellido (obligatorio)

    [StringLength(50)]
    public string SegundoApellido { get; set; } // Segundo apellido (opcional)

    [Required]
    public DateTime FechaNacimiento { get; set; } // Fecha de nacimiento (d�a/mes/a�o)

    public bool EsquemaCompleto { get; set; } // Esquema completo (booleano)

    [Required]
    [StringLength(10)]
    public string Sexo { get; set; } // Sexo (obligatorio)

    [StringLength(20)]
    public string Genero { get; set; } // G�nero (opcional)

    [StringLength(50)]
    public string OrientacionSexual { get; set; } // Orientaci�n sexual (opcional)

    public int? EdadGestacionalSemanas { get; set; } // Edad gestacional en semanas (nullable)

    [Required]
    [StringLength(50)]
    public string PaisNacimiento { get; set; } // Pa�s de nacimiento (obligatorio)

    [Required]
    [StringLength(50)]
    public string EstatusMigratorio { get; set; } // Estatus migratorio (obligatorio)

    [Required]
    [StringLength(100)]
    public string LugarAtencionParto { get; set; } // Lugar de atenci�n del parto (hospital, obligatorio)

    [Required]
    [StringLength(50)]
    public string RegimenAfiliacion { get; set; } // R�gimen de afiliaci�n (obligatorio)

    [Required]
    [StringLength(100)]
    public string Aseguradora { get; set; } // Aseguradora (obligatorio)

    [Required]
    [StringLength(50)]
    public string PertenenciaEtnica { get; set; } // Pertenencia �tnica (obligatorio)

    [Required]
    public bool Desplazado { get; set; } // Indica si es desplazado (booleano, obligatorio)

    [Required]
    public bool Discapacitado { get; set; } // Indica si es discapacitado (booleano, obligatorio)

    [Required]
    public bool Fallecido { get; set; } // Indica si ha fallecido (booleano, obligatorio)

    [Required]
    public bool VictimaConflictoArmado { get; set; } // Indica si es v�ctima del conflicto armado (booleano, obligatorio)

    [Required]
    public bool EstudiaActualmente { get; set; } // Indica si estudia actualmente (booleano, obligatorio)

    [Required]
    [StringLength(50)]
    public string PaisResidencia { get; set; } // Pa�s de residencia (obligatorio)

    [Required]
    [StringLength(50)]
    public string DepartamentoResidencia { get; set; } // Departamento de residencia (obligatorio)

    [Required]
    [StringLength(50)]
    public string MunicipioResidencia { get; set; } // Municipio de residencia (obligatorio)

    [StringLength(50)]
    public string ComunaLocalidad { get; set; } // Comuna o localidad (opcional)

    [Required]
    [StringLength(50)]
    public string Area { get; set; } // �rea (rural, urbana, obligatorio)

    [StringLength(200)]
    public string Direccion { get; set; } // Direcci�n con nomenclatura (opcional)

    [StringLength(10)]
    public string IndicativoTelefono { get; set; } // Indicativo del tel�fono fijo (opcional)

    [StringLength(15)]
    public string TelefonoFijo { get; set; } // Tel�fono fijo (opcional)

    [StringLength(15)]
    public string Celular { get; set; } // Celular (opcional)

    [EmailAddress]
    public string Email { get; set; } // Correo electr�nico (opcional)

    [Required]
    public bool AutorizaLlamadasTelefonicas { get; set; } // Autoriza llamadas telef�nicas (booleano, obligatorio)

    [Required]
    public bool AutorizaEnvioCorreo { get; set; } // Autoriza env�o de correos (booleano, obligatorio)

    // Relaci�n con Antecedentes
    public ICollection<Antecedente> Antecedentes { get; set; }

    //// Relaci�n con Madre
    [Required]
    public int MadreId { get; set; } // Identificador de la madre

    //// Relaci�n con Cuidador
    [Required]
    public int CuidadorId { get; set; } // Identificador del cuidador

    // Relaci�n 1:1 con CondicionUsuaria
    public CondicionUsuaria CondicionUsuaria { get; set; }

    // Relaci�n 1:1 con AntecedentesMedicos
    public AntecedentesMedicos AntecedentesMedicos { get; set; }

    //// Relaci�n 1:1 con EsquemaVacunacion
    //public EsquemaVacunacion EsquemaVacunacion { get; set; }
}