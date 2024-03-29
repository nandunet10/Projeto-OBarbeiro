﻿using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Negocio.Pesquisa;


namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        private readonly IPesquisa _pesquisar;

        public PesquisaController(IPesquisa pesquisar)
        {
            _pesquisar = pesquisar;
        }

        /// <summary>
        /// Método que retorna a lista de empresa por request
        /// </summary>
        /// <param name="pesquisar"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<List<RetornoPesquisaEmpresasViewModel>> PesquisarEmpresas([FromBody] PesquisarEmpresasViewModel pesquisar)
        {
            return await _pesquisar.PesquisarEmpresas(pesquisar);
        }

        /// <summary>
        /// Método que retorna a lista de profissionais e suas agendas por request
        /// </summary>
        /// <param name="pesquisar"></param>
        /// <returns></returns>
        [HttpPost("horario")]
        public async Task<List<RetornoPesquisaAgendamentoViewModel>> PesquisarHorariosAgendamento([FromBody] PesquisarAgendamentoViewModel pesquisar)
        {
            return await _pesquisar.PesquisarHorariosAgendamento(pesquisar);
        }
    }
}
