using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProximaFase.Services
{
    public class CombinacaoService
    {
        private ProximaFaseContext db = new ProximaFaseContext();

        private JogoPossuidoService _jogoPossuidoService;
        private JogoDesejadoService _jogoDesejadoService;


        public CombinacaoService()
        {
            _jogoPossuidoService = new JogoPossuidoService();
            _jogoDesejadoService = new JogoDesejadoService();

        }

        public void CriarCombinacao(int usuarioId, List<JogoPossuido> jogosEquivalentes)
        {
            List<JogoPossuido> jogosEnvolvidos = null;
            JogoPossuido jogoDoBuscadorDesejadosPeloUsuarioEncontrado = null;
            Usuario usuarioBuscador = db.Usuarios.Find(usuarioId);

            if (jogosEquivalentes != null)
            {
                jogosEnvolvidos = new List<JogoPossuido>();
                decimal valorCombinacao = 0.00M;
                foreach (var jogo in jogosEquivalentes)
                {
                    jogoDoBuscadorDesejadosPeloUsuarioEncontrado = jogoDesejadosPeloUsuarioEncontradoQueOUsuarioBuscadorPossua(usuarioBuscador, _jogoPossuidoService.buscarUsuarioJogoPossuido(jogo.id));

                    jogosEnvolvidos.Add(jogoDoBuscadorDesejadosPeloUsuarioEncontrado);
                    jogosEnvolvidos.Add(jogo);

                    valorCombinacao += jogo.valor;
                }

                Combinacao combinacao = new Combinacao()
                {
                    JogosEnvolvidos = jogosEnvolvidos,
                    ValorCombinacao = valorCombinacao/2,
                    Status = Status.Aberta
                };

                db.Combinacaos.Add(combinacao);
                db.SaveChanges();
            }
        }

        public List<Combinacao> buscarCombinacacoesPorUsuario(int usuarioId)
        {
            return db.Combinacaos.Where(c => c.JogosEnvolvidos.Any(j => j.usuarioID == usuarioId) && c.Status == Status.Aberta).ToList();
        }


        public bool descobrirJogosEquivalentesPorUsuario(int usuarioId)
        {
            List<JogoPossuido> jogosPossuidos = db.JogosPossuidos.ToList();
            List<JogoDesejado> jogosDesejados = _jogoDesejadoService.buscarJogosDesejadosDoUsuario(usuarioId);

            List<JogoPossuido> jogosEquivalentes = jogosPossuidos.Where(jp => jogosDesejados.Any(jd => jogoEquivalente(jd, jp))).ToList();

            if (jogosEquivalentes != null)
            {
                CriarCombinacao(usuarioId, jogosEquivalentes);
                return true;
            }

            return false;
        }



        private bool jogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            Usuario usuJogoDesejado = _jogoDesejadoService.buscarUsuarioJogoDesejado(jogoDesejado.id);
            Usuario usuJogoPossuido = _jogoPossuidoService.buscarUsuarioJogoPossuido(jogoPossuido.id);

            return jogoDesejado.usuarioID != jogoPossuido.usuarioID &&
                jogoDesejado.nome.Equals(jogoPossuido.nome) &&
                jogoDesejado.console.Nome.Equals(jogoPossuido.console.Nome) &&
                valorDeJogoEquivalente(jogoDesejado, jogoPossuido) &&
                condicaoDeJogoEquivalente(jogoDesejado, jogoPossuido) &&
                distanciaEquivalente(usuJogoDesejado, usuJogoPossuido) &&
                usuarioEncontradoDesejaJogoDoBuscador(usuJogoDesejado, usuJogoPossuido);
        }

        private bool usuarioEncontradoDesejaJogoDoBuscador(Usuario usuarioBuscador, Usuario usuarioEncontrado)
        {
            List<JogoPossuido> jogosPossuidos = _jogoPossuidoService.buscarJogosPossuidosDoUsuario(usuarioBuscador.id);
            List<JogoDesejado> jogosDesejados = _jogoDesejadoService.buscarJogosDesejadosDoUsuario(usuarioEncontrado.id);

            return jogosPossuidos.Any(jp => jogosDesejados.Any(jd => jd.nome.Equals(jp.nome) &&
            jd.console.Nome.Equals(jp.console.Nome) &&
                valorDeJogoEquivalente(jd, jp) &&
                condicaoDeJogoEquivalente(jd, jp)));
        }

        private JogoPossuido jogoDesejadosPeloUsuarioEncontradoQueOUsuarioBuscadorPossua(Usuario usuarioBuscador, Usuario usuarioEncontrado)
        {
            List<JogoPossuido> jogosPossuidos = _jogoPossuidoService.buscarJogosPossuidosDoUsuario(usuarioBuscador.id);
            List<JogoDesejado> jogosDesejados = _jogoDesejadoService.buscarJogosDesejadosDoUsuario(usuarioEncontrado.id);
            

            return jogosPossuidos.Where(jp => jogosDesejados.Any(jd => jd.nome.Equals(jp.nome) &&
            jd.console.Nome.Equals(jp.console.Nome) &&
                valorDeJogoEquivalente(jd, jp) &&
                condicaoDeJogoEquivalente(jd, jp))).FirstOrDefault();
        }

        private bool valorDeJogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            int valorJogoPossuido = (int)jogoPossuido.valor;
            int valorJogoDesejado = (int)jogoDesejado.valor;

            //cria intervalo de 10 a menos e 10 a mais no valor do jogo
            IEnumerable<int> intervaloJogoPossuido = Enumerable.Range(valorJogoPossuido - 10, 21);

            //verifica se o jogo desejado está dentro deste intervalo
            return intervaloJogoPossuido.Contains(valorJogoDesejado);
        }

        private bool condicaoDeJogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            return jogoDesejado.estado == jogoPossuido.estado;
        }

        private bool distanciaEquivalente(Usuario usuarioBuscador, Usuario usuarioExistente)
        {
            return usuarioExistente.endereco.cidade == usuarioBuscador.endereco.cidade;
        }



    }
}