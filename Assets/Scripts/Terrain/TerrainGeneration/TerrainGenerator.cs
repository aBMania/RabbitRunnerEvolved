
using UnityEngine;

[System.Serializable]
public abstract class TerrainGenerator : MonoBehaviour
{
    public abstract TerrainSegment GenerateNextTerrainSegment();
}