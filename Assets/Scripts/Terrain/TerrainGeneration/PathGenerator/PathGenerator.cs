using UnityEngine;

public abstract class PathGenerator : MonoBehaviour
{
    public abstract TerrainSegmentPoint GetNextPoint(int index);
}
