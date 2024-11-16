﻿using WebITSC.DB.Data.Entity;
using WebITSC.DB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebITSC.Shared.General.DTO.InscripcionCarrera
{
    public class CrearInscripcionCarreraDTO
    {
        [Required(ErrorMessage = "El alumno es necesario")]
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "La carrera es necesario")]
        public int CarreraId { get; set; }
        //public Carrera Carrera { get; set; }

        [Required(ErrorMessage = "El cohorte de la carrera es necesario")]
        public int Cohorte { get; set; }

        //[Required(ErrorMessage = "El legajo es necesario")]
        //[MaxLength(12, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Legajo { get; set; }

        [Required(ErrorMessage = "El Estado del alumno es necesario")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string EstadoAlumno { get; set; }

           [Required(ErrorMessage = "El libro matriz del alumno es necesario")]
           [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
         public string LibroMatriz { get; set; }

           [Required(ErrorMessage = "El número de orden del alumno es necesario")]
           [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
           public string NroOrdenAlumno { get; set; }
        }
    }

