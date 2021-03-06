using Financas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class MovimentacaoDAO
    {
        private FinancasContext context;
        public MovimentacaoDAO(FinancasContext contextCtor)
        {
            this.context = contextCtor;
        }
        public void Adiciona(Movimentacao movimentacao)
        {
            context.Movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }
        public IList<Movimentacao> Lista()
        {
            return context.Movimentacoes.ToList();
        }

        public IList<Movimentacao> BuscaPorUsuario(int? usuarioId)
        {
            return context.Movimentacoes.Where(m => m.UsuarioId == usuarioId).ToList();
        }

        public IList<Movimentacao> BuscaPorUsuario(decimal? valorMinimo, decimal? valorMaximo,
                                                   DateTime? dataMinima, DateTime? dataMaxima,
                                                   Tipo? tipo, int? usuarioId)
        {
            IQueryable<Movimentacao> resultado = context.Movimentacoes;
            if (valorMinimo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor >= valorMinimo);
            }
            if (valorMaximo.HasValue)
            {
                resultado = resultado.Where(m => m.Valor <= valorMaximo);
            }
            if (dataMinima.HasValue)
            {
                resultado = resultado.Where(m => m.Data >= dataMinima);
            }
            if (dataMaxima.HasValue)
            {
                resultado = resultado.Where(m => m.Data <= dataMaxima);
            }
            if (tipo.HasValue)
            {
                resultado = resultado.Where(m => m.Tipo == tipo);
            }
            if (usuarioId.HasValue)
            {
                resultado = resultado.Where(m => m.UsuarioId == usuarioId);
            }
            return resultado.ToList();
        }
    }
}