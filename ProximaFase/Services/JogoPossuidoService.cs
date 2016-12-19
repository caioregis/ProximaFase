using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Services
{
    public class JogoPossuidoService
    {
        private ProximaFaseContext db = new ProximaFaseContext();

        public Usuario buscarUsuarioJogoPossuido(int id)
        {
            return db.Usuarios.FirstOrDefault(u => u.id == db.JogosPossuidos.FirstOrDefault(jd => jd.id == id).usuarioID);
        }

        public List<JogoPossuido> buscarJogosPossuidosDoUsuario(int usuarioId)
        {
            return db.JogosPossuidos.Where(jp => jp.usuarioID == usuarioId).ToList();
        }
    }
}