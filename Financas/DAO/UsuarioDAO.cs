﻿using Financas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class UsuarioDAO
    {
        private FinancasContext context;

        public UsuarioDAO(FinancasContext financasContext)
        {
            this.context = financasContext;
        }
        public void Adiciona(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }
        public IList<Usuario> Lista()
        {
            return context.Usuarios.ToList();
        }
    }
}