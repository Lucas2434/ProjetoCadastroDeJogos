using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCatalogoDeJogos.InputModel
{
    public class Jogo_InputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Genero deve conter entre 3 e 100 caracteres")]
        public string Genero { get; set; }
        [Required]
        [Range(3, 17, ErrorMessage = "Faixa etaria deve deve ser para maiores de 18 anos")]
        public string Idade { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser de no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
