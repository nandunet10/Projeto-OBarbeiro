﻿using Microsoft.EntityFrameworkCore;
using OBarbeiro.Infra.Contexts;

namespace OBarbeiro.Negocio.NegocioBase
{
    public class NegocioBase<T> : INegocioBase<T>, IDisposable where T : class
    {
        protected OBarbeiroDbContext _Context;
        public bool _SaveChanges = true;
        public NegocioBase(bool saveChanges = true)
        {
            _Context = new OBarbeiroDbContext();
            _SaveChanges = saveChanges;
            //_Context = context;
        }

        public async Task<T> Obter(params object[] valor) => _Context.Set<T>().Find(valor);
        public async Task<List<T>> ObterTodos() => _Context.Set<T>().ToList();
        public void SaveChages() => _Context.SaveChanges();
        public void Dispose() => _Context.Dispose();

        public async Task<T> Incluir(T objeto)
        {
            _Context.Set<T>().Add(objeto);
            if (_SaveChanges) { _Context.SaveChanges(); }
            return objeto;
        }
        public async Task<T> Alterar(T objeto)
        {
            _Context.Entry(objeto).State = EntityState.Modified;
            if (_SaveChanges) { _Context.SaveChanges(); }
            return objeto;
        }
        public void Excluir(params object[] valor)
        {
            var obj = Obter(valor);
            ExlcuirObjeto(obj.Result);
        }

        public void ExlcuirObjeto(T objeto)
        {
            _Context.Set<T>().Remove(objeto);
            if (_SaveChanges) { _Context.SaveChanges(); }

        }

    }
}
