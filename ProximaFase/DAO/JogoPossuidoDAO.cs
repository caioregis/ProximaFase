using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.DAO
{
    public class JogoPossuidoDAO
    {
        private ProximaFaseContext _db;

        public JogoPossuidoDAO(ProximaFaseContext db)
        {
            _db = db;
        }

        public List<JogoPossuido> BuscarTodosJogosPossuidos()
        {
            return _db.JogosPossuidos.Where(jp => jp.Disponivel).ToList();
        }

        
        public List<JogoPossuido> BuscarJogosPossuidosDoUsuario(int usuarioId)
        {
            return _db.JogosPossuidos.Where(jp => jp.usuarioID == usuarioId).ToList();
        }
    }
}