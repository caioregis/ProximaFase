using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.DAO
{
    public class JogoDesejadoDAO
    {
        private ProximaFaseContext _db;

        public JogoDesejadoDAO(ProximaFaseContext db)
        {
            _db = db;
        }

  
        public List<JogoDesejado> BuscarJogosDesejadosDoUsuario(int usuarioId)
        {
            return _db.JogosDesejados.Where(jp => jp.usuarioID == usuarioId).ToList();
        }
    }
}