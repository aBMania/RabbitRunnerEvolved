using UnityEngine;


  public class CylinderTerrainSegment : TerrainSegment
  {
    public override void Init(GameObject prefab, int index, TerrainSegmentPoint @from, TerrainSegmentPoint to)
    {
      base.Init(prefab, index, from, to);
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
