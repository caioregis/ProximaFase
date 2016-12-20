namespace ProximaFase.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProximaFase.Models.ProximaFaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProximaFase.Models.ProximaFaseContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            //context.People.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);

            //Add ADMIN
            context.Usuarios.AddOrUpdate(
                u => u.id,
                  new Usuario
                  {
                      id = 1,
                      login = "admin",
                      email = "admin@admin.com.br",
                      senha = "admin123",
                      nome = "Administrador",
                      endereco = new Endereco
                      {
                          id = 1,
                          logradouro = "Rua São José",
                          numero = 90,
                          bairro = "Centro",
                          cidade = "Rio de Janeiro",
                          estado = "Rio de Janeiro"
                      }
                  });

            //ADD CONSOLES
            context.ConsoleGames.AddOrUpdate(
                c => c.ConsoleGameID,
                new ConsoleGame { ConsoleGameID = 1, Nome = "Console A", Ano = 2016 },
                new ConsoleGame { ConsoleGameID = 2, Nome = "Console B", Ano = 2016 },
                new ConsoleGame { ConsoleGameID = 3, Nome = "Console C", Ano = 2016 }
            );

            //ADD USUARIOS TESTERS
            context.Usuarios.AddOrUpdate(
                u => u.id,
                new Usuario
                {
                    id = 2,
                    login = "joao",
                    email = "joao@joao.com.br",
                    senha = "joao123",
                    nome = "João",
                    endereco = new Endereco
                    {
                        id = 2,
                        logradouro = "Rua São José",
                        numero = 90,
                        bairro = "Centro",
                        cidade = "Rio de Janeiro",
                        estado = "Rio de Janeiro"
                    },
                    JogosPossuidos = new List<JogoPossuido>()
                      {
                          new JogoPossuido {id = 1, nome="Jogo A", anoLancamento = 2016, dataDeCompra = DateTime.Now, estado = CondicaoJogo.PerfeitoEstado, valor = 150.00M, Disponivel = true, consoleID = 1 },
                          new JogoPossuido {id = 2, nome="Jogo B", anoLancamento = 2016, dataDeCompra = DateTime.Now, estado = CondicaoJogo.PerfeitoEstado, valor = 140.00M, Disponivel = true, consoleID = 1 },
                          new JogoPossuido {id = 3, nome="Jogo C", anoLancamento = 2016, dataDeCompra = DateTime.Now, estado = CondicaoJogo.PerfeitoEstado, valor = 160.00M, Disponivel = true, consoleID = 2 }
                      },
                    JogosDesejados = new List<JogoDesejado>()
                      {
                          new JogoDesejado { id = 1, nome = "Jogo D", anoLancamento = 2016, estado = CondicaoJogo.PerfeitoEstado, valor = 150.00M, consoleID = 2 },
                          new JogoDesejado { id = 2, nome = "Jogo E", anoLancamento = 2016, estado = CondicaoJogo.PerfeitoEstado, valor = 140.00M, consoleID = 1 },
                          new JogoDesejado { id = 3, nome = "Jogo F", anoLancamento = 2016, estado = CondicaoJogo.PerfeitoEstado, valor = 160.00M, consoleID = 3 }
                      }
                },
                new Usuario
                {
                    id = 3,
                    login = "maria",
                    email = "maria@maria.com.br",
                    senha = "maria123",
                    nome = "Maria",
                    endereco = new Endereco
                    {
                        id = 2,
                        logradouro = "Rua São José",
                        numero = 90,
                        bairro = "Centro",
                        cidade = "Rio de Janeiro",
                        estado = "Rio de Janeiro"
                    },
                    JogosPossuidos = new List<JogoPossuido>()
                      {
                          new JogoPossuido {id = 1, nome="Jogo F", anoLancamento = 2016, dataDeCompra = DateTime.Now, estado = CondicaoJogo.PerfeitoEstado, valor = 150.00M, Disponivel = true, consoleID = 1 },
                          new JogoPossuido {id = 2, nome="Jogo E", anoLancamento = 2016, dataDeCompra = DateTime.Now, estado = CondicaoJogo.PerfeitoEstado, valor = 140.00M, Disponivel = true, consoleID = 1 },
                          new JogoPossuido {id = 3, nome="Jogo C", anoLancamento = 2016, dataDeCompra = DateTime.Now, estado = CondicaoJogo.PerfeitoEstado, valor = 160.00M, Disponivel = true, consoleID = 2 }
                      },
                    JogosDesejados = new List<JogoDesejado>()
                      {
                          new JogoDesejado { id = 1, nome = "Jogo A", anoLancamento = 2016, estado = CondicaoJogo.PerfeitoEstado, valor = 150.00M, consoleID = 2 },
                          new JogoDesejado { id = 2, nome = "Jogo B", anoLancamento = 2016, estado = CondicaoJogo.PerfeitoEstado, valor = 140.00M, consoleID = 1 },
                          new JogoDesejado { id = 3, nome = "Jogo G", anoLancamento = 2016, estado = CondicaoJogo.PerfeitoEstado, valor = 160.00M, consoleID = 3 }
                      }
                }
            );

        }
    }
}
