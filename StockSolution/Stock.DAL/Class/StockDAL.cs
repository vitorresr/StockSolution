namespace Stock.DAL.Class
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Stock.DAL.Interfaces;
    using Stock.Entities.Context;
    using Stock.Entities.Dominio;
    using Stock.Entities.Transversales;

    public class StockDAL : IStockDAL
    {
        /// <summary>
        /// Variable para el manejo del DbContext 
        /// </summary>
        private readonly StockDBContext _context;

        /// <summary>
        /// Constructor para el la comunicacion con base de datos de la tabla Product
        /// </summary>
        /// <param name="context">DbContext</param>
        public StockDAL(StockDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea una nueva producto
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la creación correctamente</returns>
        public ResponseService CreateProduct(Product product)
        {
            ResponseService response = new ResponseService();

            if (ProductExists(product.ItemNo))
            {
                response = response.GetIncorrectResponse(10, "The Product Exists");
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                var productBD = _context.Products.Find(product.ItemNo);
                response = response.GetCorrectResponse(productBD, "The Product created correctly");
            }

            return response;
        }

        /// <summary>
        /// Disminuye la cantidad del producto con la cantidad informada
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la actualización correctamente</returns>
        public ResponseService UpdateAmountProdut(Product product)
        {
            ResponseService response = new ResponseService();

            if (!ProductExists(product.ItemNo))
            {
                response = response.GetIncorrectResponse(10, "The Product Exists");
            }
            else
            {
                var productoBD = _context.Products.Find(product.ItemNo);
                productoBD.Amount = productoBD.Amount - product.Amount;
                _context.Entry(productoBD).State = EntityState.Modified;
                _context.SaveChanges();
                response = response.GetCorrectResponse(null, "The Enterprise updated correctly");
            }

            return response;
        }

        /// <summary>
        /// Obtiene el listado de todas las productos en inventario
        /// </summary>
        /// <returns>Listado de productos</returns>
        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products;
            return products;
        }

        private bool ProductExists(int itemNo)
        {
            return _context.Products.Any(e => e.ItemNo == itemNo);
        }
    }
}
