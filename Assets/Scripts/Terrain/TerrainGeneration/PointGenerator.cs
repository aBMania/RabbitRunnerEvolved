using UnityEngine;

public abstract class PointGenerator : MonoBehaviour
{
    public abstract TerrainSegmentPoint GetNextPoint(int index);
}
