using Application.View.Camera;
using Application.View.Player;
using Application.View.Terrain;

namespace Application.View
{
    public class RabbitView : RabbitApplicationElement
    {
        public TerrainView TerrainView
        {
            get { return GetComponentInChildren<TerrainView>(); }
        }

        public PlayerView Player
        {
            get { return GetComponentInChildren<PlayerView>(); }
        }

        public PlayerCamera PlayerCamera
        {
            get { return GetComponentInChildren<PlayerCamera>(); }
        }


    }
}
