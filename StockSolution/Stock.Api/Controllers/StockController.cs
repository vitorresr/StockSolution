/// <summary>
/// Clase para el controlador de la entidad Products
/// </summary>

namespace Stock.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Stock.BLL;
    using Stock.DAL.Class;
    using Stock.Entities.Context;
    using Stock.Entities.Dominio;
    using Stock.Entities.Transversales;

    /// <summary>
    /// Controlador de la entidad Products
    /// </summary>
    [Route("api/Stock")]
    [ApiController]
    public class StockController : Controller
    {
        /// <summary>
        /// Variable para el manejo del DbContext 
        /// </summary>
        private readonly StockDBContext _context;

        /// <summary>
        /// Variable para el negocio de la entidad Product
        /// </summary>
        private StockBLL _negocioBLL;

        /// <summary>
        /// Constructor para el controlador de la entidad Product
        /// </summary>
        /// <param name="context">DbContext</param>
        public StockController(StockDBContext context)
        {
            this._context = context;
            this._negocioBLL = new StockBLL(new StockDAL(this._context));
        }

        /// <summary>
        /// Obtiene el listado de todas las productos en inventario
        /// </summary>
        /// <returns>Listado de productos</returns>
        // GET: api/Stock
        [HttpGet]
        public ActionResult<ResponseService> GetProducts()
        {
            ResponseService response = new ResponseService();

            try
            {
                var products = this._negocioBLL.GetProducts();
                response = response.GetCorrectResponse(products, string.Empty);
            }
            catch (Exception ex)
            {
                response = response.GetIncorrectResponse(ex.GetHashCode(), ex.Message);
            }

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return Ok(JsonConvert.SerializeObject(response, jsonSerializerSettings));
        }

        /// <summary>
        /// Crea una nueva producto
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la creación correctamente</returns>
        //// POST: api/Stock
        [HttpPost]
        public ActionResult<ResponseService> CreateProduct(Product product)
        {
            ResponseService response = new ResponseService();
            try
            { 
                response = this._negocioBLL.CreateProduct(product);
            }
            catch (Exception ex)
            {
                response = response.GetIncorrectResponse(ex.GetHashCode(), ex.Message);
            }

            return Ok(response);
        }

        /// <summary>
        /// Disminuye la cantidad del producto con la cantidad informada
        /// </summary>
        /// <param name="product">Información del producto</param>
        /// <returns>Respuesta que información si se realizo la actualización correctamente</returns>
        /// POST: api/Stock/UpdateAmount
        [HttpPost("UpdateAmount")]
        public ActionResult<ResponseService> UpdateAmountProdut(Product product)
        {
            ResponseService response = new ResponseService();
            try
            {
                response = this._negocioBLL.UpdateAmountProdut(product);
            }
            catch (Exception ex)
            {
                response = response.GetIncorrectResponse(ex.GetHashCode(), ex.Message);
            }

            return Ok(response);
        }
    }
}