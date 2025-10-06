using System;
using System.Collections.Generic;

namespace CallCenterBackend.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        // Relaciones
        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<Participacion>? Participaciones { get; set; }
        public ICollection<Evaluacion>? Evaluaciones { get; set; }
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        // Relación con Colaborador
        public int? Fk_Colaborador { get; set; }
        public Colaborador? Colaborador { get; set; }
    }
    public class Capacitador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Especialidad { get; set; }
        public string? Disponibilidad { get; set; }
        // Relación N:M con Capacitacion
        public ICollection<CapacitacionCapacitador>? CapacitacionesAsignadas { get; set; }
    }
    public class Capacitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? Objetivo { get; set; }
        public string Modalidad { get; set; } = string.Empty;  // Virtual o Presencial
        public string Estado { get; set; } = string.Empty;     // Programada, En Curso, Finalizada
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        // Relaciones
        public ICollection<Sesion>? Sesiones { get; set; }
        public ICollection<Participacion>? Participaciones { get; set; }
        public ICollection<Evaluacion>? Evaluaciones { get; set; }
        public ICollection<CapacitacionCapacitador>? CapacitadoresAsignados { get; set; }
    }
    public class Sesion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora_Inicio { get; set; }
        public TimeSpan Hora_Fin { get; set; }
        public string? Lugar { get; set; }
        // Relación con Capacitacion
        public int Fk_Capacitacion { get; set; }
        public Capacitacion? Capacitacion { get; set; }
    }
    public class Participacion
    {
        public int Id { get; set; }
        public int Fk_Colaborador { get; set; }
        public int Fk_Capacitacion { get; set; }
        public string? Estado { get; set; }
        // Relaciones
        public Colaborador? Colaborador { get; set; }
        public Capacitacion? Capacitacion { get; set; }
    }
    public class Evaluacion
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public decimal? Resultado { get; set; }
        public int Fk_Colaborador { get; set; }
        public int Fk_Capacitacion { get; set; }
        // Relaciones
        public Colaborador? Colaborador { get; set; }
        public Capacitacion? Capacitacion { get; set; }
    }
    public class CapacitacionCapacitador
    {
        public int Id { get; set; }
        public int Fk_Capacitacion { get; set; }
        public int Fk_Capacitador { get; set; }

        // Relaciones
        public Capacitacion? Capacitacion { get; set; }
        public Capacitador? Capacitador { get; set; }
    }
}
