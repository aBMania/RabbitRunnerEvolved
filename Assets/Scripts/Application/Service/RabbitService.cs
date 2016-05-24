using Application.Service.PathGenerator;
using Application.Service.TerrainGenerator;

namespace Application.Service
{
    public class RabbitService : RabbitApplicationElement
    {
        private DirectionnalPathGenerator _directionnalPathGenerator;
        private CylinderTerrainGenerator _cylinderTerrainGenerator;

        public void Awake()
        {
            _directionnalPathGenerator = GetComponentInChildren<DirectionnalPathGenerator>();
            _cylinderTerrainGenerator = GetComponentInChildren<CylinderTerrainGenerator>();
        }


        public DirectionnalPathGenerator DirectionnalPathGenerator
        {
            get { return _directionnalPathGenerator; }
        }

        public CylinderTerrainGenerator CylinderTerrainGenerator
        {
            get { return _cylinderTerrainGenerator;  }
        }
    }
}