using ProximaFase.DAO;
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
        private JogoPossuidoService _jogoPossuidoService;
        private JogoDesejadoService _jogoDesejadoService;
        private UsuarioService _usuarioService;
        private MensagemService _mensagemService;
        private CombinacaoDAO _combinacaoDAO;

        public CombinacaoService(ProximaFaseContext db)
        {
            _jogoPossuidoService = new JogoPossuidoService(db);
            _jogoDesejadoService = new JogoDesejadoService(db);
            _usuarioService = new UsuarioService(db);
            _mensagemService = new MensagemService(db);
            _combinacaoDAO = new CombinacaoDAO(db);
        }

        public void CriarCombinacao(int usuarioId, List<JogoPossuido> jogosEquivalentes)
        {
            List<Usuario> usuariosEnvolvidos = null;
            List<JogoPossuido> jogosEnvolvidos = null;
            JogoPossuido jogoDoBuscadorDesejadosPeloUsuarioEncontrado = null;

            Usuario usuarioBuscador = _usuarioService.BuscarUsuarioPorId(usuarioId);

            if (jogosEquivalentes != null)
            {
                usuariosEnvolvidos = new List<Usuario>();
                jogosEnvolvidos = new List<JogoPossuido>();

                decimal valorCombinacao = 0.00M;
                foreach (var jogo in jogosEquivalentes)
                {
                    usuariosEnvolvidos.Add(usuarioBuscador);
                    usuariosEnvolvidos.Add(_usuarioService.BuscarUsuarioJogoPossuido(jogo.usuario.id));

                    jogoDoBuscadorDesejadosPeloUsuarioEncontrado = JogoDesejadosPeloUsuarioEncontradoQueOUsuarioBuscadorPossua(usuarioBuscador, _usuarioService.BuscarUsuarioJogoPossuido(jogo.id));

                    jogosEnvolvidos.Add(jogoDoBuscadorDesejadosPeloUsuarioEncontrado);
                    jogosEnvolvidos.Add(jogo);

                    valorCombinacao += jogo.valor;
                }

                Combinacao combinacao = new Combinacao()
                {
                    UsuariosEnvolvidos = usuariosEnvolvidos,
                    JogosEnvolvidos = jogosEnvolvidos,
                    ValorCombinacao = valorCombinacao/2,
                    Status = Status.Aberta
                };

                _combinacaoDAO.CriarCombinacao(combinacao);

                _mensagemService.CriarMensagemCombinacaoAberta(combinacao.CombinacaoID);

            }
        }

        public Combinacao BuscarCombinacacaoPorId(int id)
        {
            return _combinacaoDAO.BuscarCombinacacaoPorId(id);
        }

        public List<Combinacao> BuscarCombinacacoesPorUsuario(int usuarioId)
        {
            return _combinacaoDAO.BuscarCombinacacoesPorUsuario(usuarioId);
        }

        public bool DescobrirJogosEquivalentesPorUsuario(int usuarioId)
        {
            List<JogoPossuido> jogosPossuidos = _jogoPossuidoService.BuscarTodosJogosPossuidos();
            List<JogoDesejado> jogosDesejados = _jogoDesejadoService.BuscarJogosDesejadosDoUsuario(usuarioId);

            List<JogoPossuido> jogosEquivalentes = jogosPossuidos.Where(jp => jogosDesejados.Any(jd => JogoEquivalente(jd, jp))).ToList();

            if (jogosEquivalentes != null)
            {
                CriarCombinacao(usuarioId, jogosEquivalentes);
                return true;
            }

            return false;
        }

        private bool JogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            Usuario usuJogoDesejado = _usuarioService.BuscarUsuarioJogoDesejado(jogoDesejado.id);
            Usuario usuJogoPossuido = _usuarioService.BuscarUsuarioJogoPossuido(jogoPossuido.id);

            return jogoDesejado.usuarioID != jogoPossuido.usuarioID &&
                jogoDesejado.nome.Equals(jogoPossuido.nome) &&
                jogoDesejado.console.Nome.Equals(jogoPossuido.console.Nome) &&
                ValorDeJogoEquivalente(jogoDesejado, jogoPossuido) &&
                CondicaoDeJogoEquivalente(jogoDesejado, jogoPossuido) &&
                DistanciaEquivalente(usuJogoDesejado, usuJogoPossuido) &&
                UsuarioEncontradoDesejaJogoDoBuscador(usuJogoDesejado, usuJogoPossuido);
        }

        private bool UsuarioEncontradoDesejaJogoDoBuscador(Usuario usuarioBuscador, Usuario usuarioEncontrado)
        {
            List<JogoPossuido> jogosPossuidos = _jogoPossuidoService.BuscarJogosPossuidosDoUsuario(usuarioBuscador.id);
            List<JogoDesejado> jogosDesejados = _jogoDesejadoService.BuscarJogosDesejadosDoUsuario(usuarioEncontrado.id);

            return jogosPossuidos.Any(jp => jogosDesejados.Any(jd => jd.nome.Equals(jp.nome) &&
            jd.console.Nome.Equals(jp.console.Nome) &&
                ValorDeJogoEquivalente(jd, jp) &&
                CondicaoDeJogoEquivalente(jd, jp)));
        }

        private JogoPossuido JogoDesejadosPeloUsuarioEncontradoQueOUsuarioBuscadorPossua(Usuario usuarioBuscador, Usuario usuarioEncontrado)
        {
            List<JogoPossuido> jogosPossuidos = _jogoPossuidoService.BuscarJogosPossuidosDoUsuario(usuarioBuscador.id);
            List<JogoDesejado> jogosDesejados = _jogoDesejadoService.BuscarJogosDesejadosDoUsuario(usuarioEncontrado.id);
            

            return jogosPossuidos.Where(jp => jogosDesejados.Any(jd => jd.nome.Equals(jp.nome) &&
            jd.console.Nome.Equals(jp.console.Nome) &&
                ValorDeJogoEquivalente(jd, jp) &&
                CondicaoDeJogoEquivalente(jd, jp))).FirstOrDefault();
        }

        private bool ValorDeJogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            int valorJogoPossuido = (int)jogoPossuido.valor;
            int valorJogoDesejado = (int)jogoDesejado.valor;

            //cria intervalo de 10 a menos e 10 a mais no valor do jogo
            IEnumerable<int> intervaloJogoPossuido = Enumerable.Range(valorJogoPossuido - 10, 21);

            //verifica se o jogo desejado está dentro deste intervalo
            return intervaloJogoPossuido.Contains(valorJogoDesejado);
        }

        private bool CondicaoDeJogoEquivalente(JogoDesejado jogoDesejado, JogoPossuido jogoPossuido)
        {
            return jogoDesejado.estado == jogoPossuido.estado;
        }

        private bool DistanciaEquivalente(Usuario usuarioBuscador, Usuario usuarioExistente)
        {
            return usuarioExistente.endereco.cidade == usuarioBuscador.endereco.cidade;
        }


        public void FinalizarCombinacaoConcluidaPorId(int id)
        {
            _combinacaoDAO.FinalizarCombinacaoPorId(id);

            _mensagemService.CriarMensagemCombinacaoConcluida(id);
        }
    }
}