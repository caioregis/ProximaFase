using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.DAO
{
    public class UsuarioDAO
    {
        private ProximaFaseContext _db;

        public UsuarioDAO(ProximaFaseContext db)
        {
            _db = db;
        }

        public Usuario BuscarUsuarioJogoPossuido(int id)
        {
            return _db.Usuarios.FirstOrDefault(u => u.id == _db.JogosPossuidos.FirstOrDefault(jd => jd.id == id).usuarioID);
        }

        public Usuario BuscarUsuarioJogoDesejado(int id)
        {
            return _db.Usuarios.FirstOrDefault(u => u.id == _db.JogosDesejados.FirstOrDefault(jd => jd.id == id).usuarioID);
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return _db.Usuarios.Find(id);
        }

        public bool UsuarioExiste(string login, string senha)
        {
            Usuario usuario = null;

            usuario = _db.Usuarios.FirstOrDefault(u => u.login == login && u.senha == senha);

            if (usuario != null)
            {
                return true;
            }

            return false;
        }
    }
}