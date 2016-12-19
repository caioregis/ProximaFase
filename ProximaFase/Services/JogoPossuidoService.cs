using ProximaFase.DAO;
using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProximaFase.Services
{
    public class JogoPossuidoService
    {
        private JogoPossuidoDAO _jogoPossuidoDAO;

        public JogoPossuidoService(ProximaFaseContext db)
        {
            _jogoPossuidoDAO = new JogoPossuidoDAO(db);
        }

        public List<JogoPossuido> BuscarTodosJogosPossuidos()
        {
            return _jogoPossuidoDAO.BuscarTodosJogosPossuidos();
        }

        public List<JogoPossuido> BuscarJogosPossuidosDoUsuario(int usuarioId)
        {
            return _jogoPossuidoDAO.BuscarJogosPossuidosDoUsuario(usuarioId);
        }
    }
}