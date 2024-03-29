﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;
using OBarbeiro.Modelo.Modelos;
using System;
using System.Data;
using System.Net.Http.Headers;

namespace OBarbeiro.Front.Controllers;
public class AgendamentoController : Controller
{
    private string mensagem = String.Empty;

    private readonly IOptions<DadosBase> _dadosBase;
    private readonly IOptions<LoginResposta> _loginRespostaModel;
    private readonly HttpClient _httpClient;
    private readonly IApiToken _apiToken;

    public AgendamentoController(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginRespostaModel, IHttpClientFactory httpClient, IApiToken apiToken)
    {
        _dadosBase = dadosBase;
        _loginRespostaModel = loginRespostaModel;
        _apiToken = apiToken;
        _httpClient = httpClient.CreateClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // GET: AgendamentoController
    public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
    {
        if (sucesso)
            TempData["sucesso"] = mensagem;
        else
            TempData["erro"] = mensagem;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Agendamento");

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<List<Agendamento>>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");
    }

    // GET: AgendamentoController
    public async Task<IActionResult> IndexCliente(string email, string? mensagem = null, bool sucesso = true)
    {
        if (sucesso)
            TempData["sucesso"] = mensagem;
        else
            TempData["erro"] = mensagem;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Agendamento?email={email}");

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<List<Agendamento>>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");
    }

    // GET: AgendamentoController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: AgendamentoController/PesquisarAgenda
    public async Task<IActionResult> PesquisarAgenda([FromForm] string email)
    {
        ViewBag.ProfissionaisEmpresa = await this.CarregarProfissionaisPorEmpresa(email);
        ViewBag.ServicoEmpresa = await this.CarregarServicosPorEmpresa(email);
        ViewData["Email"] = email;
        return View(email);
    }

    // POST: AgendamentoController/PesquisarAgenda
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PesquisarAgenda([FromForm] PesquisarAgendamentoViewModel model)
    {
        try
        {
            model.Email = "nandunet.oliveira@gmail.com";
            if (ModelState.IsValid)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Pesquisa/horario", model);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home", new { mensagem = "Registro criado!", sucesso = true });
                else
                    throw new Exception($"Não foi possível encontrar o serviço!");

            }
            else
            {
                TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                return View();
            }
        }
        catch (Exception ex)
        {
            TempData["erro"] = "Algum erro aconteceu " + ex.Message;
            return View();
        }
    }

    // GET: AgendamentoController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: AgendamentoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: AgendamentoController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: AgendamentoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }


    #region ViewBags
    private async Task<List<SelectListItem>> CarregarPerfilUsuario(bool cadastro, int perfilUsuarioId = 0)
    {
        List<SelectListItem> lista = new();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}PerfilUsuario");

        if (response.IsSuccessStatusCode)
        {
            var perfils = JsonConvert.DeserializeObject<List<PerfilUsuario>>(await response.Content.ReadAsStringAsync());

            foreach (var linha in perfils)
            {
                if (cadastro)
                {
                    //if (linha.Perfil.ToLower() != "admin")
                    //{

                    if (linha.PerfilUsuarioId == perfilUsuarioId)
                    {
                        lista.Add(new SelectListItem()
                        {
                            Value = linha.PerfilUsuarioId.ToString(),
                            Text = $"{linha.Perfil}",
                            Selected = false,
                        });
                    }
                    //}
                }
                else
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.PerfilUsuarioId.ToString(),
                        Text = $"{linha.Perfil}",
                        Selected = false,
                    });
                }

            }

            return lista;
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    private async Task<List<SelectListItem>> CarregarStatusAgendamento()
    {
        List<SelectListItem> lista = new();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}AgendamentoStatus");

        if (response.IsSuccessStatusCode)
        {
            var status = JsonConvert.DeserializeObject<List<AgendamentoStatus>>(await response.Content.ReadAsStringAsync());
            lista.AddRange(from linha in status
                           select new SelectListItem()
                           {
                               Value = linha.AgendamentoStatusId.ToString(),
                               Text = $"{linha.Descricao}",
                               Selected = false,
                           });
            return lista;
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }


    private async Task<List<AgendaProfissional>> CarregarAgendaProfissional(string cpf)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}AgendaProfissional?cpf={cpf}");

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<List<AgendaProfissional>>(await response.Content.ReadAsStringAsync());
        else
            throw new Exception("Algo não deu certo.");
    }
    private async Task<List<SelectListItem>> CarregarProfissionaisPorEmpresa(string email)
    {
        List<SelectListItem> lista = new();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Profissional?email={email}");

        if (response.IsSuccessStatusCode)
        {
            var profissionais = JsonConvert.DeserializeObject<List<Profissional>>(await response.Content.ReadAsStringAsync());
            lista.Add(new() { Value = null, Text = "Sem preferência" });
            lista.AddRange(from linha in profissionais
                           select new SelectListItem()
                           {
                               Value = linha.Cpf.ToString(),
                               Text = $"{linha.Nome}",
                               Selected = false,
                           });

            return lista;
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }
    private async Task<List<SelectListItem>> CarregarServicosPorEmpresa(string email)
    {
        List<SelectListItem> lista = new();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Servico?email={email}");

        if (response.IsSuccessStatusCode)
        {
            var servicos = JsonConvert.DeserializeObject<List<Servico>>(await response.Content.ReadAsStringAsync());
            lista.Add(new() { Value = null, Text = "Serviços" });
            lista.AddRange(from Servico linha in servicos
                           select new SelectListItem()
                           {
                               Value = linha.ServicoId.ToString(),
                               Text = $"{linha.Descricao}",
                               Selected = false,
                           });
            return lista;
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }
    #endregion


}
