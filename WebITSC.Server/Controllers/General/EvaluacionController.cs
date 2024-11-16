﻿using AutoMapper;
using WebITSC.Admin.Server.Repositorio;

using WebITSC.DB.Data;
using WebITSC.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using WebITSC.Shared.General.DTO;

namespace WebITSC.Server.Controllers.General
{
    [ApiController]
    [Route("api/Evaluacion")]
    public class EvaluacionController : ControllerBase
    {
        private readonly IEvaluacionRepositorio eRepositorio;
        private readonly IMapper mapper;

        public EvaluacionController(IEvaluacionRepositorio eRepositorio,
                                    IMapper mapper)
        {
            this.eRepositorio = eRepositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Evaluacion>>> GetAll()
        {
            var evaluaciones = await eRepositorio.FullGetAll();

            return Ok(evaluaciones);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Evaluacion>> GetById(int id)
        {
            var evaluacion = await eRepositorio.FullGetById(id);
            if (evaluacion == null) return NotFound();

            return Ok(evaluacion);
        }
        #region Peticiones Get

        //[HttpGet]
        //public async Task<ActionResult<List<Evaluacion>>> Get()
        //{
        //    return await repositorio.Select();
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Evaluacion>> Get(int id)
        //{
        //    Evaluacion? sel = await repositorio.SelectById(id);
        //    if (sel == null)
        //    {
        //        return NotFound();
        //    }
        //    return sel;
        //}

        //[HttpGet("existe/{id:int}")]
        //public async Task<ActionResult<bool>> Existe(int id)
        //{
        //    var existe = await repositorio.Existe(id);
        //    return existe;

        //}

        #endregion

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearEvaluacionDTO entidadDTO)
        {
            try
            {
                Evaluacion entidad = mapper.Map<Evaluacion>(entidadDTO);

                return await eRepositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Evaluacion entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var sel = await eRepositorio.SelectById(id);
            //sel = Seleccion

            if (sel == null)
            {
                return NotFound("No existe el tipo de documento buscado.");
            }


            sel = mapper.Map<Evaluacion>(entidad);

            try
            {
                await eRepositorio.Update(id, sel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await eRepositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El Evaluacion {id} no existe");
            }
            Evaluacion EntidadABorrar = new Evaluacion();
            EntidadABorrar.Id = id;

            if (await eRepositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }



    }

}




