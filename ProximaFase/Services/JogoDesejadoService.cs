using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Services
{
    public class JogoDesejadoService
    {
        private ProximaFaseContext db = new ProximaFaseContext();

        public Usuario buscarUsuarioJogoDesejado(int id)
        {
            return db.Usuarios.FirstOrDefault(u => u.id == db.JogosDesejados.FirstOrDefault(jd => jd.id == id).usuarioID);
        }

        public List<JogoDesejado> buscarJogosDesejadosDoUsuario(int usuarioId)
        {
            return db.JogosDesejados.Where(jp => jp.usuarioID == usuarioId).ToList();
        }
    }
}