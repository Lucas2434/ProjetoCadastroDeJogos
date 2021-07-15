using ProjetoCatalogoDeJogos.Entities;
using ProjetoCatalogoDeJogos.Exceptions;
using ProjetoCatalogoDeJogos.InputModel;
using ProjetoCatalogoDeJogos.Repositorio;
using ProjetoCatalogoDeJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCatalogoDeJogos.Service
{
    public class Jogo_Service : IJogo_Service
    {
       
            private readonly IJogoRepositorio _jogoRepositorio;

            public Jogo_Service(IJogoRepositorio jogoRepositorio)
            {
                _jogoRepositorio = jogoRepositorio;
            }

            public async Task<List<Jogo_ViewModel>> Obter(int pagina, int quantidade)
            {
                var jogos = await _jogoRepositorio.Obter(pagina, quantidade);

                return jogos.Select(jogo => new Jogo_ViewModel
                {
                    Id = jogo.Id,
                    Nome = jogo.Nome,
                    Produtora = jogo.Produtora,
                    Genero = jogo.Genero,
                    Idade = jogo.Idade,
                    Preco = jogo.Preco
                }).ToList();
            }

            public async Task<Jogo_ViewModel> Obter(Guid id)
            {
                var jogo = await _jogoRepositorio.Obter(id);

                if (jogo == null)
                    return null;

                return new Jogo_ViewModel
                {
                    Id = jogo.Id,
                    Nome = jogo.Nome,
                    Produtora = jogo.Produtora,
                    Genero = jogo.Genero,
                    Idade = jogo.Idade,
                    Preco = jogo.Preco
                };
            }

            public async Task<Jogo_ViewModel> Inserir(Jogo_InputModel jogo)
            {
                var entidadeJogo = await _jogoRepositorio.Obter(jogo.Nome, jogo.Produtora, jogo.Genero, jogo.Idade);

                if (entidadeJogo.Count > 0)
                    throw new JogoJaCadastradoException();

                var jogoInsert = new Jogo
                {
                    Id = Guid.NewGuid(),
                    Nome = jogo.Nome,
                    Produtora = jogo.Produtora,
                    Genero = jogo.Genero,
                    Idade = jogo.Idade,
                    Preco = jogo.Preco
                };

                await _jogoRepositorio.Inserir(jogoInsert);

                return new Jogo_ViewModel
                {
                    Id = jogoInsert.Id,
                    Nome = jogo.Nome,
                    Produtora = jogo.Produtora,
                    Genero = jogo.Genero,
                    Idade = jogo.Idade,
                    Preco = jogo.Preco
                };
            }

            public async Task Atualizar(Guid id, Jogo_InputModel jogo)
            {
                var entidadeJogo = await _jogoRepositorio.Obter(id);

                if (entidadeJogo == null)
                    throw new JogoNaoCadastradoException();

                entidadeJogo.Nome = jogo.Nome;
                entidadeJogo.Produtora = jogo.Produtora;
                entidadeJogo.Genero = jogo.Genero;
                entidadeJogo.Idade = jogo.Idade;
                entidadeJogo.Preco = jogo.Preco;

                await _jogoRepositorio.Atualizar(entidadeJogo);
            }

            public async Task Atualizar(Guid id, double preco)
            {
                var entidadeJogo = await _jogoRepositorio.Obter(id);

                if (entidadeJogo == null)
                    throw new JogoNaoCadastradoException();

                entidadeJogo.Preco = preco;

                await _jogoRepositorio.Atualizar(entidadeJogo);
            }

            public async Task Remover(Guid id)
            {
                var jogo = await _jogoRepositorio.Obter(id);

                if (jogo == null)
                    throw new JogoNaoCadastradoException();

                await _jogoRepositorio.Remover(id);
            }

            public void Dispose()
            {
             _jogoRepositorio?.Dispose();
            }
        
    }
}
