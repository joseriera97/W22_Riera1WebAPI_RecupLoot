using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W20_Surname1WebAPI.Models
{
    public class LootModels
    {
        //Aprovechare loot para guardar también en TotalLoot es solo para mantener el numero en la bbdd
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _total;

        public int Total
        {
            get { return Total; }
            set { Total = value; }
        }
        //Parte para mantener le registro de puntuacion
        private string _puntuacion;
        public string Puntuacion
        {
            get { return _puntuacion; }
            set { _puntuacion = value; }
        }
        private string _idPlayer;
        public string IdPlayer
        {
            get { return _idPlayer; }
            set { _idPlayer = value; }
        }

        //La fecha de finalizar
        private DateTime _closeGame;
        public DateTime CloseGame
        {
            get { return _closeGame; }
            set { _closeGame = value; }
        }

        private DateTime _connectedSince;
        public DateTime ConnectedSince
        {
            get { return _connectedSince; }
            set { _connectedSince = value; }
        }

    }
}