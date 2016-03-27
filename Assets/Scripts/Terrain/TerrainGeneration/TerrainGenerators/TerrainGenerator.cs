using UnityEngine;

  [System.Serializable]
  public abstract class TerrainGenerator : MonoBehaviour
  {
    public GameObject TerrainSemgnetPrefab;

    public PathGenerator PathGenerator;

    public void Awake()
    {
      PathGenerator = GetComponent<PathGenerator>();
    }

    public abstract TerrainSegment GenerateNextTerrainSegment();
  }