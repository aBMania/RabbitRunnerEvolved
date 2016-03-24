using UnityEditor;
using UnityEngine;

public class CylinderTerrainGenerator : TerrainGenerator
{
    [SerializeField, Range(1, 20)]
    private float _spacing = 2.5f;

    [SerializeField, Range(10, 1000)]
    private int _rotationLength = 200;

    [SerializeField, Range(0, 10)]
    private float _radius = 5;

    [SerializeField, Range(3, 30)]
    private int _nDiscretePoints = 12;

    [SerializeField, Range(20, 500)]
    private int _initialLength = 200;

    [SerializeField]
    private PointGenerator _pointGenerator;

    private int _currentIndex = 0;

    private TerrainSegmentPoint previousTerrainSemgnetPoint;

    public int NDiscretePoints
    {
        get { return _nDiscretePoints; }
        set { _nDiscretePoints = value; }
    }

    public int InitialLength
    {
        get { return _initialLength; }
        set { _initialLength = value; }
    }

    public bool AutoUpdate { get; set; }

    public float Spacing
    {
        get { return _spacing; }
        set { _spacing = value; }
    }

    public int RotationLength
    {
        get { return _rotationLength; }
        set { _rotationLength = value; }
    }

    public float Radius
    {
        get { return _radius; }
        set { _radius = value; }
    }

    public override TerrainSegment GenerateNextTerrainSegment()
    {
        if (previousTerrainSemgnetPoint == null)
            previousTerrainSemgnetPoint = _pointGenerator.GetNextPoint(_currentIndex);

        TerrainSegmentPoint terrainSegmentPoint = _pointGenerator.GetNextPoint(_currentIndex);

        var terrainSegment = new CylinderTerrainSegment(_currentIndex, previousTerrainSemgnetPoint, terrainSegmentPoint);

        previousTerrainSemgnetPoint = terrainSegmentPoint;

        return terrainSegment;
    }
}
