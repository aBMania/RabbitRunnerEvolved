using Application.Model.Terrain.TerrainSegments;

namespace Application.View.Terrain.Segment
{
    public class CylinderTerrainSegmentView : TerrainSegmentView
    {
        private CylinderTerrainSegment _cylinderTerrainSegmentModel;

        public void Init(CylinderTerrainSegment cylinderTerrainSegment)
        {
            base.Init(cylinderTerrainSegment);

            _cylinderTerrainSegmentModel = cylinderTerrainSegment;
        }

        public CylinderTerrainSegment CylinderTerrainSegmentModel
        {
            get { return _cylinderTerrainSegmentModel; }
        }
    }
}