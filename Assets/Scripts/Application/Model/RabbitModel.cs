using Application.Model.Terrain;

namespace Application.Model
{
    public class RabbitModel : RabbitApplicationElement
    {
        private readonly RabbitTerrain _terrain = new RabbitTerrain();

        public RabbitTerrain Terrain
        {
            get { return _terrain; }
        }
    }
}
