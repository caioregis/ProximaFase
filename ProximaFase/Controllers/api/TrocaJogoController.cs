using ProximaFase.Models;
using ProximaFase.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProximaFase.Controllers.api
{
    public class TrocaJogoController : ApiController
    {
        private CombinacaoService _combinacaoService;

        public TrocaJogoController()
        {
            _combinacaoService = new CombinacaoService();
        }

        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public List<Combinacao> GetTrocaEquivalentePorUsuario(int id)
        {
            List<Combinacao> combinacoes = null;

                if (_combinacaoService.descobrirJogosEquivalentesPorUsuario(id))
                {
                    combinacoes = _combinacaoService.buscarCombinacacoesPorUsuario(id);
                }
            return combinacoes;
        }
    }
}