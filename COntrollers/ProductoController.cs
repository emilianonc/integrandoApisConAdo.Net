using Microsoft.AspNetCore.Mvc;

namespace Emiliano_Chiapponi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "TrearProductos")]
        public List<Producto> TraerProductos()
        {
            return ProductoHandler.TraerProductos();
        }
    }
}
