using ProjetoCatalogoDeJogos.InputModel;
using ProjetoCatalogoDeJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ProjetoCatalogoDeJogos.Service
{
    public interface IJogo_Service : IDisposable
    {
        Task<List<Jogo_ViewModel>> Obter(int pagina, int quantidade);
        Task<Jogo_ViewModel> Obter(Guid id);
        Task<Jogo_ViewModel> Inserir(Jogo_InputModel jogo);
        Task Atualizar(Guid id, Jogo_InputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
        

    }
}
