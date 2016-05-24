using Application.Model.Terrain.TerrainSegments;

namespace Application.View.Terrain.Segment
{
    public class TerrainSegmentView : RabbitApplicationElement
    {
        private TerrainSegment _terrainSegmentModel;

        public virtual void Init(TerrainSegment terrainSegment)
        {
            _terrainSegmentModel = terrainSegment;
        }

        public TerrainSegment TerrainSegmentModel
        {
            get { return _terrainSegmentModel; }
        }
    }
}