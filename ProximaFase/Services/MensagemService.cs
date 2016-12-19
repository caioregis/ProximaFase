using ProximaFase.DAO;
using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Services
{
    public class MensagemService
    {
        private MensagemDAO _mensagemDAO;
        private ProximaFaseContext _db;

        public MensagemService(ProximaFaseContext db)
        {
            _mensagemDAO = new MensagemDAO(db);
            _db = db;
        }

        public void CriarMensagemCombinacaoAberta(int combinacaoId)
        {
            Mensagem mensagem = new Mensagem()
            {
                CombinacaoID = combinacaoId,
                DeUsuarioID = _db.Usuarios.FirstOrDefault(u => u.login == "administrador").id,
                MensagemText = "Você tem uma nova combinação!!!",
                DataHora = DateTime.UtcNow,
            };

            _mensagemDAO.CriarMensagem(mensagem);
        }

        public void CriarMensagemCombinacaoConcluida(int combinacaoId)
        {
            Mensagem mensagem = new Mensagem()
            {
                CombinacaoID = combinacaoId,
                DeUsuarioID = _db.Usuarios.FirstOrDefault(u => u.login == "administrador").id,
                MensagemText = "Parabéns pela Troca!!!",
                DataHora = DateTime.UtcNow,
            };

            _mensagemDAO.CriarMensagem(mensagem);
        }

        public Mensagem CriarMensagemDeUsuarioParaConversa(int combinacaoId, int usuarioId, string mensagemText)
        {
            Mensagem mensagem = new Mensagem()
            {
                CombinacaoID = combinacaoId,
                DeUsuarioID = usuarioId,
                MensagemText = mensagemText.ToString(),
                DataHora = DateTime.UtcNow,
            };

            _mensagemDAO.CriarMensagem(mensagem);

            return mensagem;
        }
    }
}