namespace Stock.DAL.Interfaces
{
    using System.Collections.Generic;
    using Stock.Entities.Dominio;
    using Stock.Entities.Transversales;

    public interface IStockDAL
    {
        /// <summary>
        /// Obtiene el listado de todas las productos en inventario
        /// </summary>
        /// <returns>Listado de productos</returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Crea una nueva producto
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la creación correctamente</returns>
        ResponseService CreateProduct(Product product);

        /// <summary>
        /// Disminuye la cantidad del producto con la cantidad informada
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la actualización correctamente</returns>
        ResponseService UpdateAmountProdut(Product product);
    }
}
