using BeerService.Domain.Core.Entities;
using System;

namespace BeerService.Domain.Entities
{
    public class Cerveja : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Harmonizacao { get; private set; }
        public string Cor { get; private set; }
        public string Categoria { get; private set; }
        public string Ingredientes { get; private set; }
        public decimal TeorAlcoolico { get; private set; }
        public decimal TemperaturaInicial { get; private set; }
        public decimal TemperaturaFinal { get; private set; }
        public string Imagem { get; private set; }

        private Cerveja() { }

        public Cerveja(string nome, string descricao, string harmonizacao, 
            string cor, string categoria, string ingredientes, decimal teorAlcoolico, 
            decimal temperaturaInicial, decimal temperaturaFinal, string imagem)
        {
            Nome = nome;
            Descricao = descricao;
            Harmonizacao = harmonizacao;
            Cor = cor;
            Categoria = categoria;
            Ingredientes = ingredientes;
            TeorAlcoolico = teorAlcoolico;
            TemperaturaInicial = temperaturaInicial;
            TemperaturaFinal = temperaturaFinal;
            Imagem = imagem;
        }

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