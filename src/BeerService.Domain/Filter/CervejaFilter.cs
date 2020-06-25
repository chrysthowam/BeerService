using BeerService.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BeerService.Domain.Filter
{
    public class CervejaFilter
    {
        private IQueryable<Cerveja> _query;

        public CervejaFilter(IQueryable<Cerveja> query)
            => _query = query;

        public List<Cerveja> Listar()
            => _query.ToList();

        public CervejaFilter FiltrarNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                _query = _query.Where(x => x.Nome.ToLower()
                    .Contains(nome.ToLower()));
            return this;
        }

        public CervejaFilter FiltrarIngredientes(string ingredientes)
        {
            if (!string.IsNullOrWhiteSpace(ingredientes))
                _query = _query.Where(x => x.Ingredientes.ToLower()
                    .Contains(ingredientes.ToLower()));
            return this;
        }

        public CervejaFilter FiltrarCor(string cor)
        {
            if (!string.IsNullOrWhiteSpace(cor))
                _query = _query.Where(x => x.Cor.ToLower()
                    .Contains(cor.ToLower()));
            return this;
        }

        public CervejaFilter FiltrarTemperatura(decimal? temperatura)
        {
            if (temperatura != null)
                _query = _query.Where(x => x.TemperaturaInicial <= temperatura &&
                    x.TemperaturaFinal >= temperatura);
            return this;
        }

        public CervejaFilter FiltrarTeorAlcoolico(decimal? teorAlcoolico)
        {
            if (teorAlcoolico != null)
                _query = _query.Where(x => x.TeorAlcoolico == teorAlcoolico);
            return this;
        }
    }
}
