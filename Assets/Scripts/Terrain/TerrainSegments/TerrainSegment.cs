using UnityEngine;

  public abstract class TerrainSegment : ScriptableObject
  {
    public GameObject GameObject;

    public TerrainSegmentPoint From;
    public TerrainSegmentPoint To;

    public int Index { get; set; }

    public virtual void Init(GameObject prefab, int index, TerrainSegmentPoint from, TerrainSegmentPoint to)
    {
      Index = index;
      From = from;
      To = to;

      GameObject = Instantiate(prefab);

      GameObject.transform.position = from.Position;
      GameObject.transform.rotation = from.Rotation;
    }

    public override string ToString()
    {
      return "[ CylinderSegment #" + Index + " from " + From + " to " + To + "]";
    }

    public abstract void GetPlayerPositionAt(float k, out Vector3 position, out Quaternion orientation);

    public abstract void GetWallPositionAt(float k, Vector3 position);

    public abstract void Delete();
  }