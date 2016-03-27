using UnityEngine;

  public class CylinderTerrainGenerator : TerrainGenerator
  {
    [SerializeField, Range(10, 1000)]
    private int _rotationLength = 200;

    [SerializeField, Range(0, 10)]
    private float _radius = 5;

    [SerializeField, Range(3, 30)]
    private int _nDiscretePoints = 12;

    [SerializeField, Range(20, 500)]
    private int _initialLength = 200;

    private int _currentIndex = 0;

    private TerrainSegmentPoint _previousTerrainSemgnetPoint;

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
      if (_previousTerrainSemgnetPoint == null)
        _previousTerrainSemgnetPoint = PathGenerator.GetNextPoint(_currentIndex);

      var nextTerrainSegmentPoint = PathGenerator.GetNextPoint(_currentIndex);

      var cylinderTerrainSegment = (CylinderTerrainSegment) ScriptableObject.CreateInstance("CylinderTerrainSegment");
      cylinderTerrainSegment.Init(TerrainSemgnetPrefab, _currentIndex, _previousTerrainSemgnetPoint, nextTerrainSegmentPoint);
      cylinderTerrainSegment.GameObject.transform.parent = transform;

      _previousTerrainSemgnetPoint = nextTerrainSegmentPoint;

      _currentIndex++;

      return cylinderTerrainSegment;
    }
  }