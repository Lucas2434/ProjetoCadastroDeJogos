using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCatalogoDeJogos.Entities
{
    public class Jogo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public string Genero { get; set; }
        public string Idade { get; set; }
        public double Preco { get; set; }
    }
}
