using Application.Model.Terrain;

namespace Application.Model
{
    public class RabbitModel : RabbitApplicationElement
    {
        public TerrainModel TerrainModel
        {
            get { return GetComponentInChildren<TerrainModel>(); }
        }

        public Player.Player Player
        {
            get { return GetComponentInChildren<Player.Player>();  }
        }
    }
}
