using System;
using UnityEngine;

namespace Application.Model.Terrain.TerrainSegments
{
    public class CylinderTerrainSegment : TerrainSegment
    {
        private float _radius;

        public CylinderTerrainSegment(int index, TerrainSegmentPoint from, TerrainSegmentPoint to, float playerHeight, float radius) : base(index, from, to, playerHeight)
        {
            _radius = radius;
        }

        // location in range [0,1]
        // angle in range [-180, 180]
        public override void GetCameraPositionAndOrientationAt(float location, float angle, out Vector3 position, out Quaternion orientation)
        {
            position = Vector3.Slerp(From.Position, To.Position, location);
            orientation = Quaternion.Slerp(From.Rotation, To.Rotation, location);
        }

        // location in range [0,1]
        // angle in range [-180, 180]
        public override void GetPlayerPositionAndOrientationAt(float location, float angle, out Vector3 position, out Quaternion orientation)
        {
            position = Vector3.Slerp(From.Position, To.Position, location);
            orientation = Quaternion.Slerp(From.Rotation, To.Rotation, location);

            orientation = orientation*Quaternion.AngleAxis(angle, Vector3.forward);
            position = position + orientation*Vector3.down*(Radius - PlayerHeight);
        }

        public override void GetWallPositionAt(float rotation, Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public float Radius
        {
            get { return _radius; }
        }

        public override string ToString()
        {
            return String.Format("[CylinderTerrainSegmentModel #{0} from:{1} to:{2} radius:{3}]", Index, From, To, Radius);
        }
    }
}