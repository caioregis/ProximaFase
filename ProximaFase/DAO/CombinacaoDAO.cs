using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.DAO
{
    public class CombinacaoDAO
    {

        private ProximaFaseContext _db;

        public CombinacaoDAO(ProximaFaseContext db)
        {
            _db = db;
        }


        public void CriarCombinacao(Combinacao combinacao)
        {
            _db.Combinacaos.Add(combinacao);
            _db.SaveChanges();
        }

        public Combinacao BuscarCombinacacaoPorId(int id)
        {
            return _db.Combinacaos.Find(id);
        }

        public List<Combinacao> BuscarCombinacacoesPorUsuario(int usuarioId)
        {
            return _db.Combinacaos.Where(c => c.JogosEnvolvidos.Any(j => j.usuarioID == usuarioId) && c.Status == Status.Aberta).ToList();
        }

        public void FinalizarCombinacaoPorId(int id)
        {
            Combinacao combinacao = _db.Combinacaos.Find(id);
            foreach (var jogo in combinacao.JogosEnvolvidos)
            {
                jogo.Disponivel = false;
            } 

            combinacao.Status = Status.Concluida;
            _db.SaveChanges();
        }
    }
}