using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using W20_Surname1WebAPI.Models;



namespace W20_Surname1WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Loot")]
    public class LootController : ApiController
    {


        //Para obtener el total actual del Loot
        // GET api/Loot/Total
        [HttpGet]
        public LootModels GetTotalLoot()
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = "SELECT Total FROM dbo.TotalLoot WHERE Id LIKE 1";
                //string sql2 = "SELECT Total FROM dbo.TotalLoot WHERE Id = 1";
                var totalLoot = cnn.Query<LootModels>(sql).FirstOrDefault();
                return totalLoot;

            }
        }

        // POST api/Loot/RegisterLoot
        [HttpPost]
        public System.Web.Http.IHttpActionResult RegisterPlayer(int score)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                //Obtengo el total de Loot actual
                var totalLoot = GetTotalLoot();
                //Le resto el total a la puntuación del usuario
                var finalLoot = totalLoot.Total - score;

                //Con esto lo insertariamos en una tabla para mantener un mejor control.
                //Ya k si varias personas juegan en cuanto una actualize le saldra los cambios a los demas.
                string sql = "INSERT INTO dbo.TotalLoot(Id,Total) " +
                    $"VALUES('{1}','{finalLoot}')";
                try
                {
                    cnn.Execute(sql);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error actualizando el Remaining Loot ");
                }

                return Ok();
            }
        }

        //Insertar la puntuacion de la partida....
        // POST api/Loot/FinalLoot
        [HttpPost]
        public System.Web.Http.IHttpActionResult RegisterLoot(LootModels loot)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                //Se inserta en una tabla la información necesaria para mantener el registro.
                //En este caso el Id del Player, la puntuación y la fecha...

                string sql = "INSERT INTO dbo.Loots( IdPlayer, Puntuacion, FinPartida) " +
                             $"VALUES('{loot.IdPlayer}','{loot.Puntuacion}','{loot.CloseGame}')";
                try
                {
                    cnn.Execute(sql);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error actualizando el fin de Partida");
                }

                return Ok();
            }
        }


    }
}