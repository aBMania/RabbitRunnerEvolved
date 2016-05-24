using Application.View.Terrain;

namespace Application.View
{
    public class RabbitView : RabbitApplicationElement
    {
        private TerrainView _terrainView;

        public void Awake()
        {
            _terrainView = GetComponentInChildren<TerrainView>();
        }


        public TerrainView TerrainView
        {
            get { return _terrainView; }
        }
    }
}
