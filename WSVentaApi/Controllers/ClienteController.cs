using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSVentaApi.Models;
using WSVentaApi.Models.Response;
using WSVentaApi.Models.ViewModels;

namespace WSVentaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet] //protocolo
        public IActionResult Get()
        {
            respuesta oRespuesta = new respuesta();
            oRespuesta.Exito = 0;
            try
            {
               

                using (VentaRealContext db = new VentaRealContext()) //contexto
                {
                    var lista = db.Clientes.ToList();  //peticion en una lista
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lista;

                }

            }catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta); 
         
        }

        [HttpPost]  //Siempre que insertes DAtos tiene que ser  POST
        public IActionResult Add(ClienteRequest oModel)
        {
            respuesta oRespuesta = new respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();

                    oRespuesta.Exito = 1;
                }

                    

            }catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut] //Se usa para Editar  PUT
        public IActionResult Edit(ClienteRequest oModel)
        {
            respuesta oRespuesta = new respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Id); //Busca en la table el id where
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //indica que el registro ha pasado un status modifcado
                    db.SaveChanges();

                    oRespuesta.Exito = 1;

                }


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpDelete("{Id}")] // Se usa para Eliminar DELETE
        public IActionResult Delete(int Id)
        {
            respuesta oRespuesta = new respuesta();
            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente oCliente = db.Clientes.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }
            } 
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
