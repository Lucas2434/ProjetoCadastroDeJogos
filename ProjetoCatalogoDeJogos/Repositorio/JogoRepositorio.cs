using ProjetoCatalogoDeJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCatalogoDeJogos.Repositorio
{
    public class JogoRepositorio : IJogoRepositorio
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Jogo{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Fifa 21", Produtora = "EA", Genero = "Esporte", Idade = "Livre para todos os publicos", Preco = 200} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Jogo{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Fifa 20", Produtora = "EA", Genero = "Esporte", Idade = "Livre para todos os publicos", Preco = 190} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Jogo{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "Fifa 19", Produtora = "EA", Genero = "Esporte", Idade = "Livre para todos os publicos", Preco = 180} },
            {Guid.Parse("da033439-f352-4539-879f-515759312d53"), new Jogo{ Id = Guid.Parse("da033439-f352-4539-879f-515759312d53"), Nome = "Fifa 18", Produtora = "EA", Genero = "Esporte", Idade = "Livre para todos os publicos", Preco = 170} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Jogo{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Nome = "Street Fighter V", Produtora = "Capcom", Genero = "Jogo De Luta", Idade = "Indicado Para Maiores de 12 Anos", Preco = 80} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Jogo{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Nome = "Grand Theft Auto V", Produtora = "Rockstar", Genero = "Ação", Idade = "Indicado Para Maiores de 18 Anos", Preco = 190} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return Task.FromResult<Jogo>(null);

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora, string Genero, string Idade)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora) && jogo.Genero.Equals(Genero) && jogo.Idade.Equals(Idade)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora, string Genero, string Idade)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora) && jogo.Genero.Equals(Genero) && jogo.Idade.Equals(Idade))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
