using Application.View.Terrain;

namespace Application.View
{
    public class RabbitView : RabbitApplicationElement
    {
        public TerrainView TerrainView
        {
            get { return GetComponentInChildren<TerrainView>(); }
        }
    }
}
