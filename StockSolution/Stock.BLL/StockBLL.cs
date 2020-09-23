namespace Stock.BLL
{
    using System.Collections.Generic;
    using Stock.DAL.Interfaces;
    using Stock.Entities.Dominio;
    using Stock.Entities.Transversales;

    public class StockBLL
    {
        /// <summary>
        /// Define la interfaz para el acceso con comunicacion de datos
        /// </summary>
        private IStockDAL _repositorioDAL;

        /// <summary>
        /// Constructor de la clase de negocio para la entidad Products
        /// </summary>
        /// <param name="repositorioDAL">interfaz para el acceso con comunicacion de datos</param>
        public StockBLL(IStockDAL repositorioDAL)
        {
            this._repositorioDAL = repositorioDAL;
        }

        /// <summary>
        /// Obtiene el listado de todas las productos en inventario
        /// </summary>
        /// <returns>Listado de productos</returns>
        public IEnumerable<Product> GetProducts()
        {
            return _repositorioDAL.GetProducts();
        }

        /// <summary>
        /// Crea una nueva producto
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la creación correctamente</returns>
        public ResponseService CreateProduct(Product product)
        {
            return _repositorioDAL.CreateProduct(product);
        }

        /// <summary>
        /// Disminuye la cantidad del producto con la cantidad informada
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la actualización correctamente</returns>
        public ResponseService UpdateAmountProdut(Product product)
        {
            return _repositorioDAL.UpdateAmountProdut(product);
        }
    }
}
