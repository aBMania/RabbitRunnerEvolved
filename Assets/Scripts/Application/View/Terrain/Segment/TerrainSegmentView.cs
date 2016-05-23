using Application.Model.Terrain.TerrainSegments;

namespace Application.View.Terrain.Segment
{
    public class TerrainSegmentView : RabbitApplicationElement
    {
        private TerrainSegment _terrainSegmentModel;

        protected void Init(TerrainSegment terrainSegment)
        {
            _terrainSegmentModel = terrainSegment;
        }

        public TerrainSegment TerrainSegmentModel
        {
            get { return _terrainSegmentModel; }
        }
    }
}