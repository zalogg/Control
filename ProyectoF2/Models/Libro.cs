using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoF2.Models;

public partial class Libro
{
    public int IdLibro { get; set; }


    [Required(ErrorMessage = "El campo Titulo es Obligatorio")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "El campo es Obligatorio")]
    public string? NombrePortada { get; set; }
    [Required(ErrorMessage = "El campo es Obligatorio")]
    public string? Autor { get; set; }
    [Required(ErrorMessage = "El campo es Obligatorio")]
    public string? GeneroLiterario { get; set; }
    [Required(ErrorMessage = "El campo es Obligatorio")]
    public string? Editorial { get; set; }
    [Required(ErrorMessage = "El campo es Obligatorio")]
    public string? Ubicacion { get; set; }
    [Required]
    [Range(0, 120)]
    public int? Ejemplares { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}

