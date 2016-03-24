using System;
using UnityEngine;

public abstract class TerrainSegment
{
    public TerrainSegmentPoint From;
    public TerrainSegmentPoint To;
    public int Index { get; set; }

    public TerrainSegment(int index, TerrainSegmentPoint from, TerrainSegmentPoint to)
    {
        Index = index;
        From = from;
        To = to;
    }

    public override string ToString()
    {
        return "[ CylinderSegment #" + Index + " from " + From + " to " + To + "]";
    }

    public abstract void GetPlayerPositionAt(float k, out Vector3 position, out Quaternion orientation);

    public abstract void GetWallPositionAt(float k, Vector3 position);

    public abstract void Delete();
}