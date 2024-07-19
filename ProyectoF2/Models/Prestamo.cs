using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoF2.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? Identificacion { get; set; }

    public int? IdLibro { get; set; }
    [Required]
    public DateTime? FechaDevolucion { get; set; }
    [Required]
    public DateTime? FechaConfirmacionDevolucion { get; set; }
    [Required]
    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }

    public virtual Usuario? IdentificacionNavigation { get; set; }
}
