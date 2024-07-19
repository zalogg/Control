using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoF2.Models;

public partial class Usuario
{

    [Required]
    

    public int Identificacion { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? Apellido { get; set; }
    
    public string? Correo { get; set; }

    public string? Clave { get; set; }
    [Required]
    [Range(0, 120)]
    public int? Edad { get; set; }

    public int? IdRol { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}


