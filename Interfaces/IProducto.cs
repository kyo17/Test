using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IProducto
    {
        Task addProducto(Producto producto);
        Task updateProducto(Producto producto);
        Task deleteProducto(string id);

        Task<List<Producto>> getProductos();
        Task<Producto> getProductoById(string id);
    }

}
