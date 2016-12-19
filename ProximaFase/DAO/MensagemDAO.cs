using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.DAO
{
    public class MensagemDAO
    {
        private ProximaFaseContext _db;

        public MensagemDAO(ProximaFaseContext db)
        {
            _db = db;
        }

        public void CriarMensagem(Mensagem mensagem)
        {
            _db.Mensagems.Add(mensagem);
            _db.SaveChanges();
        }

        public List<Mensagem> BuscarMensagensDaCombinacao(int combinacaoId)
        {
            return _db.Mensagems.Where(m => m.CombinacaoID == combinacaoId).OrderBy(m => m.DataHora).ToList();
        }
    }
}