using UnityEngine;

public class CylinderTerrainSegment : TerrainSegment
{
    public CylinderTerrainSegment(int index, TerrainSegmentPoint @from, TerrainSegmentPoint @to) : base(index, @from, @to)
    {
        Debug.Log(this);
    }

    public override string ToString()
    {
        return "[ CylinderSegment #" + Index + " from " + From + " to " + To + "]";
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

    public override void Delete()
    {
        throw new System.NotImplementedException();
    }
}
