using ProximaFase.Models;
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
        private ProximaFaseContext db = new ProximaFaseContext();

        //[Route("BuscaTrocaEquivalentePorUsuario")]
        [HttpGet] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public IQueryable<JogoPossuido> GetBuscaTrocaEquivalentePorUsuario(int id)
        {
            Usuario usuarioBuscador = db.Usuarios.Find(id);

            IQueryable<JogoPossuido> jogosEquivalentes = db.JogosPossuidos.Where(jp => usuarioBuscador.JogosDesejados.All(jd => jd.nome.Equals(jp.nome) && valorDeJogoEquivalente(jd, jp) && condicaoDeJogoEquivalente(jd, jp) && distanciaEquivalente(jp.usuario, usuarioBuscador)));

            //if (jogosEquivalentes == null)
            //{
            //    return NotFound();
            //}

            //return Ok(jogosEquivalentes);

            return jogosEquivalentes;
        }

        private bool valorDeJogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            int valorjogoPossuido = (int)jogoDesejado.valor;

            //cria intervalo de 10 a menos e 10 a mais no valor do jogo
            IEnumerable<int> intervaloJogoPossuido = Enumerable.Range(valorjogoPossuido - 10, valorjogoPossuido + 10);

            //verifica se o jogo desejado está dentro deste intervalo
            return intervaloJogoPossuido.Contains(valorjogoPossuido);
        }

        private bool condicaoDeJogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            return jogoDesejado.estado == jogoPossuido.estado;
        }

        private bool distanciaEquivalente(Usuario usuariosExistente, Usuario usuarioBuscador)
        {
            return usuariosExistente.endereco.cidade == usuarioBuscador.endereco.cidade;
        }
    }
}