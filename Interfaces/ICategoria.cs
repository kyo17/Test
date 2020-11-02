using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface ICategoria
    {
        Task addCategoria(Categoria categoria);
        Task updateCategoria(Categoria categoria);
        Task deleteCategoria(string id);
        Task<List<Categoria>> getAll();
        Task<Categoria> getOne(string id);
    }
}
