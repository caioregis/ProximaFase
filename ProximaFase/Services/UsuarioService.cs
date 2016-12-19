using ProximaFase.DAO;
using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProximaFase.Services
{
    public class UsuarioService
    {
        private UsuarioDAO _usuarioDAO;

        public UsuarioService(ProximaFaseContext db)
        {
            _usuarioDAO = new UsuarioDAO(db);
        }

        public Usuario BuscarUsuarioJogoPossuido(int id)
        {
            return _usuarioDAO.BuscarUsuarioJogoPossuido(id);
        }

        public Usuario BuscarUsuarioJogoDesejado(int id)
        {
            return _usuarioDAO.BuscarUsuarioJogoDesejado(id);
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return _usuarioDAO.BuscarUsuarioPorId(id);
        }
    }
}