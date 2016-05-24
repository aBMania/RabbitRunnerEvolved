using Application.Model.Terrain;
using Application.View;

namespace Application.Model
{
    public class RabbitModel : RabbitApplicationElement
    {
        private TerrainModel _terrainModel;

        public void Awake()
        {
            _terrainModel = GetComponent<TerrainModel>();
        }

        public TerrainModel TerrainModel
        {
            get { return _terrainModel; }
        }
    }
}
