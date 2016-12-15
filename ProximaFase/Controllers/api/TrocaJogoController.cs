using ProximaFase.Models;
using System;
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

        [Route("BuscarTroca")]
        [HttpPost] // There are HttpGet, HttpPost, HttpPut, HttpDelete.
        public async Task<IHttpActionResult> BuscarTroca(Usuario usuario)
        {



            List<JogoPossuido> jogosPossuidosUsuario = usuario.JogosPossuidos.ToList();


            //db.Usuarios.All(u => u.endereco.bairro == usuario.endereco.bairro && u.JogosPossuidos.Any(jp => jp.jogo.nome == usuario.JogosDesejados.Any(j => j.jogo.nome == jp.jogo.nome)));


            return Ok();
        }

    }
}
