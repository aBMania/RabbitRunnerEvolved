using Application.Model.Terrain.TerrainSegments;
using Attributes;
using UnityEngine;

namespace Application.View.Terrain.Segment
{
    public class CylinderTerrainSegmentView : TerrainSegmentView
    {
        public GameObject Circle;

        [SerializeField, ShowOnly]
        private CylinderTerrainSegment _cylinderTerrainSegmentModel;

        public void Init(CylinderTerrainSegment cylinderTerrainSegment)
        {
            base.Init(cylinderTerrainSegment);

            _cylinderTerrainSegmentModel = cylinderTerrainSegment;

            GameObject instance = Instantiate(Circle);
            instance.name = "circle";
            instance.transform.parent = transform;
            instance.transform.position = _cylinderTerrainSegmentModel.To.Position;
            instance.transform.rotation = _cylinderTerrainSegmentModel.To.Rotation;
        }

        public CylinderTerrainSegment CylinderTerrainSegmentModel
        {
            get { return _cylinderTerrainSegmentModel; }
        }
    }
}