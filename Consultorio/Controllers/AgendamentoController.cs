using Consultorio.Models.Entities;
using Consultorio.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consultorio.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IEmailService _emailService;
        List<Agendamento> agendamentos = new List<Agendamento>();
        public AgendamentoController(IEmailService emailService)
        {
            agendamentos.Add(new Agendamento 
            { 
                Id = 1, 
                NomePaciente = "Cientista", 
                Horario = new DateTime(2022, 01, 21) 
            });
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(agendamentos);
        }


        [HttpGet("busca-agendamento/{id}")]
        public IActionResult GetById(int id)
        {
            var buscaSeleccionado = agendamentos.FirstOrDefault(x => x.Id == id);

            return buscaSeleccionado != null
                ? Ok(agendamentos)
                : BadRequest("Erro ao buscar Agendamento");
        }

        [HttpPost]
        IActionResult Post()
        {
            var pacienteAgendado = true;

            if (pacienteAgendado)
            {
                _emailService.EnviarEmail("cientista@gmail.com");
            }
            return Ok();
        }
    }
}
