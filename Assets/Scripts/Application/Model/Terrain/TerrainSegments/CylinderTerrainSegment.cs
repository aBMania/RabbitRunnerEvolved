using System;
using UnityEngine;

namespace Application.Model.Terrain.TerrainSegments
{
    public class CylinderTerrainSegment : TerrainSegment
    {
        [SerializeField, Range(1, 20)]
        private float _radius = 2.5f;

        public CylinderTerrainSegment(int index, TerrainSegmentPoint from, TerrainSegmentPoint to) : base(index, from, to)
        {
          
        }

        public float Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void GetPlayerPositionAt(float k, out Vector3 position, out Quaternion orientation)
        {
            position = Vector3.Slerp(From.Position, To.Position, k);
            orientation = Quaternion.Slerp(From.Rotation, To.Rotation, k);
        }

        public override void GetWallPositionAt(float k, Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("[CylinderTerrainSegmentModel #{0} from:{1} to:{2} radius:{3}]", Index, From, To, Radius);
        }
    }
}