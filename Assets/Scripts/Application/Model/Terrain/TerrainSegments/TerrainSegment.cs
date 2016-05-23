using System;
using UnityEngine;

namespace Application.Model.Terrain.TerrainSegments
{
    public abstract class TerrainSegment
    {
        public TerrainSegmentPoint From;
        public TerrainSegmentPoint To;

        public int Index { get; set; }

        protected TerrainSegment(int index, TerrainSegmentPoint from, TerrainSegmentPoint to)
        {
            Index = index;
            From = from;
            To = to;
        }

        public abstract void GetPlayerPositionAt(float k, out Vector3 position, out Quaternion orientation);

        public abstract void GetWallPositionAt(float k, Vector3 position);

        public override string ToString()
        {
            return String.Format("[CylinderTerrainSegmentModel #{0} from:{1} to:{2}]", Index, From, To);
        }
    }
}