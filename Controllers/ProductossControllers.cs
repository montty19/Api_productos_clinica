using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks; 
using api_farmacia.Models;

namespace api_farmacia.Controllers{

    [Route("api/[controller]")]

    public class ProductossController : Controller{
    
    private Conexion dbConexion;
    public ProductossController(){dbConexion = Conectar.Create(); }
        //LISTAR
        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.Productoss.ToArray());
        }

        //BUSCAR
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id){
            var productoss = await dbConexion.Productoss.FindAsync(id);
            if (productoss != null){
                return Ok (productoss);
            }else{
                return NotFound();
            }
            
        }
        //AGREGAR
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Productoss productoss){
            if(ModelState.IsValid){
                dbConexion.Productoss.Add(productoss);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else{
                return BadRequest();
            }
        }
        //UPDATE
        public async Task<ActionResult> Put([FromBody] Productoss productoss){
            var v_productoss = dbConexion.Productoss.SingleOrDefault(a => a.id == productoss.id);
            if(v_productoss!=null && ModelState.IsValid){
                dbConexion.Entry(v_productoss).CurrentValues.SetValues(productoss);
                await dbConexion.SaveChangesAsync();
                return Ok();

            }else{
                return BadRequest();
            }
        }
        //ELIMINAR
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
           var productoss = dbConexion.Productoss.SingleOrDefault(a => a.id == id);
           if(productoss!=null){
               dbConexion.Productoss.Remove(productoss);
               await dbConexion.SaveChangesAsync();
               return Ok();
           }else{
               return NotFound();
           }
        }

    }
}