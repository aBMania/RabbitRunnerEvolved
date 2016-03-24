using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainModel : MonoBehaviour
{
    private int _lowerBound = 0;

    private int _higherBound = 0;

    private readonly IDictionary<int, TerrainSegment> _terrainSegments = new Dictionary<int, TerrainSegment>();

    [SerializeField] private TerrainGenerator _terrainGenerator;

    public void GetPlayerPositionAndOrientationAt(float z, float k, out Vector3 position, out Quaternion orientation)
    {
        // Get the index of the previous and next segments of the player
        // if player is at z: 6.2, we get segment #6 and #7

        var previousTerrainSegmentIndex = Mathf.FloorToInt(z);
        var nextTerrainSegmentIndex = previousTerrainSegmentIndex + 1;


        // Local ratio of player position between the two segments 
        // if player is at z: 6.2, the ratio is 0.2

        var playerLocalRatio = z - previousTerrainSegmentIndex;

        // Get the terrainSegments Objects

        var previousTerrainSegment = GetTerrainSegment(previousTerrainSegmentIndex);
        var nexTerrainSegment = GetTerrainSegment(nextTerrainSegmentIndex);

        Vector3 previousTerrainSegmentPosition, nexTerrainSegmentPosition;
        Quaternion previousTerrainSegmentOrientation, nextTerrainSegmentOrientation;

        previousTerrainSegment.GetPlayerPositionAt(k, out previousTerrainSegmentPosition, out previousTerrainSegmentOrientation);
        nexTerrainSegment.GetPlayerPositionAt(k, out nexTerrainSegmentPosition, out nextTerrainSegmentOrientation);

        position = Vector3.Slerp(previousTerrainSegmentPosition, nexTerrainSegmentPosition, playerLocalRatio);
        orientation = Quaternion.Slerp(previousTerrainSegmentOrientation, nextTerrainSegmentOrientation, playerLocalRatio);
    }

    public TerrainSegment GetTerrainSegment(float z)
    {
        // Return the previous terrainSegment
        return GetTerrainSegment(Mathf.FloorToInt(z));
    }

    public TerrainSegment GetTerrainSegmentAt(int z)
    {
        return _terrainSegments[z];
    }

    public void DeleteTerrainBefore(int z)
    {
        foreach (var terrainSegment in _terrainSegments.Where(kvp => kvp.Key <= z).Select(pair => pair.Value))
        {
            terrainSegment.Delete();
        }
    }

    public void GenerateNextSegment()
    {
        _terrainGenerator.GenerateNextTerrainSegment();
    }
}