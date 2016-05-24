using System;
using UnityEngine;

namespace Application.Model.Terrain.TerrainSegments
{
    public abstract class TerrainSegment
    {
        public TerrainSegmentPoint From;
        public TerrainSegmentPoint To;
        public float PlayerHeight;

        public int Index { get; set; }

        protected TerrainSegment(int index, TerrainSegmentPoint from, TerrainSegmentPoint to, float playerHeight)
        {
            Index = index;
            From = from;
            To = to;
            PlayerHeight = playerHeight;
        }

        public abstract void GetCameraPositionAndOrientationAt(float location, float playerRotation, out Vector3 position, out Quaternion orientation);

        public abstract void GetPlayerPositionAndOrientationAt(float location, float playerRotation, out Vector3 position, out Quaternion orientation);

        public abstract void GetWallPositionAt(float rotation, Vector3 position);

        public override string ToString()
        {
            return String.Format("[CylinderTerrainSegmentModel #{0} from:{1} to:{2}]", Index, From, To);
        }
    }
}