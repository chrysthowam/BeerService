using BeerService.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace BeerService.Domain.Entities
{
    public class Cerveja : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Harmonizacao { get; set; }
        public string Cor { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public decimal TeorAlcoolico { get; set; }
        public decimal TemperaturaInicial { get; set; }
        public decimal TemperaturaFinal { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }

        internal void Editar(string nome, string descricao, string harmonizacao, string cor, 
            string categoria, string ingredientes, decimal teorAlcoolico, 
            decimal temperaturaInicial, decimal temperaturaFinal)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Harmonizacao = harmonizacao ?? throw new ArgumentNullException(nameof(harmonizacao));
            Cor = cor ?? throw new ArgumentNullException(nameof(cor));
            Categoria = categoria ?? throw new ArgumentNullException(nameof(categoria));
            Ingredientes = ingredientes ?? throw new ArgumentNullException(nameof(ingredientes));
            TeorAlcoolico = teorAlcoolico;
            TemperaturaInicial = temperaturaInicial;
            TemperaturaFinal = temperaturaFinal;
        }
    }
}