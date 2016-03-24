using UnityEngine;

public class DirectionnalPointGenerator : PointGenerator
{
    [SerializeField]
    private float _spacing;

    [SerializeField]
    private int rotationLength;

    private TerrainSegmentPoint _lastSegmentPoint;

    private int _pointIndex;

    private Quaternion _globalFromRotation;
    private Quaternion _globalToRotation;

    private bool _firstPoint;

    private readonly Vector3 _startPosition = Vector3.zero;
    private readonly Quaternion _startDirection = Quaternion.LookRotation(Vector3.forward);

    public override TerrainSegmentPoint GetNextPoint(int segmentIndex)
    {
        TerrainSegmentPoint point = new TerrainSegmentPoint();

        if (!_firstPoint)
        {
            _firstPoint = true;
            point.Position = _startPosition;
            point.Rotation = _startDirection;

            RegenerateFromToRotations(point.Rotation, segmentIndex);

            _lastSegmentPoint = point;
            return point;
        }

        point.Rotation = Quaternion.Slerp(_globalFromRotation, _globalToRotation, (float) _pointIndex / rotationLength);

        _pointIndex++;

        if (Quaternion.Angle(point.Rotation, _globalToRotation) <= .1f) // Arbitrary
            RegenerateFromToRotations(point.Rotation, segmentIndex);

        point.Position = _lastSegmentPoint.Position + point.Rotation * Vector3.forward * _spacing;


        _lastSegmentPoint = point;

        return point;
    }

    private void RegenerateFromToRotations(Quaternion rotation, int segmentIndex)
    {
        _globalFromRotation = rotation;

        // Let a straight start for 10 segments
        _globalToRotation = segmentIndex <= 10 ? Quaternion.LookRotation(Vector3.forward) : Random.rotation;


        _pointIndex = 0;
    }
}