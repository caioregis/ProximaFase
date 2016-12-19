using ProximaFase.DAO;
using ProximaFase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProximaFase.Services
{
    public class JogoDesejadoService
    {
        private JogoDesejadoDAO _jogoDesejadoDAO;

        public JogoDesejadoService(ProximaFaseContext db)
        {
            _jogoDesejadoDAO = new JogoDesejadoDAO(db);
        }


        public List<JogoDesejado> BuscarJogosDesejadosDoUsuario(int usuarioId)
        {
            return _jogoDesejadoDAO.BuscarJogosDesejadosDoUsuario(usuarioId);
        }
    }
}