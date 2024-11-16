﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebITSC.DB.Data.Entity
{
    [Index(nameof(MateriaEnPlanEstudioId), nameof(Sede), nameof(Horario), nameof(AnnoCicloLectivo), Name = "InscripcionCarrera_UQ", IsUnique = true)]
    [Index(nameof(MateriaEnPlanEstudioId), nameof(ProfesorId), Name = "MateriasQueDaUnProfeIDX", IsUnique = false)]
    public class Turno : EntityBase
    {
        [Required(ErrorMessage = "La materia es necesaria")]
        public int MateriaEnPlanEstudioId { get; set; }
        public MateriaEnPlanEstudio MateriaEnPlanEstudio { get; set; }

        public int? ProfesorId { get; set; } //null acepable porque las materias y sus horarios de clase existen por si solas antes de que se les asigne un profe
        public Profesor? Profesor { get; set; }

        [Required(ErrorMessage = "La situacion revista es necesaria")]
        [MaxLength(45, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Sede { get; set; }

        [Required(ErrorMessage = "La situacion revista es necesaria")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Horario { get; set; } //Mañana, tarde, noche... es literalmente el Turno del turno

        [Required(ErrorMessage = "La situacion revista es necesaria")]
        public int AnnoCicloLectivo { get; set; } //Año del ciclo lectivo, el turno de modelado de sistemas actual tendra .AnnoCicloLectivo = 2024

        public List<CursadoMateria>? AlumnosCursando { get; set; } = new List<CursadoMateria>();
        public List<Clase>? Clases { get; set; } = new List<Clase>();
    }
}