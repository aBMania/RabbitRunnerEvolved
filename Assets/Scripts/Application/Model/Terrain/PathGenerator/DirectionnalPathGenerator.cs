using Application.Model.Terrain.TerrainSegments;
using Attributes;
using UnityEngine;

namespace Application.Model.Terrain.PathGenerator
{
    public class DirectionnalPathGenerator : RabbitApplicationElement, IPathGenerator
    {
        [SerializeField, Range(1, 20)]
        private float _spacing = 2.5f;

        [SerializeField, Range(40, 200)]
        private int _rotationLength = 100;

        private TerrainSegmentPoint _lastSegmentPoint;

        private int _pointIndex;

        [ShowOnly, SerializeField]
        private Quaternion _globalFromRotation;

        [ShowOnly, SerializeField]
        private Quaternion _globalToRotation;

        [ShowOnly, SerializeField]
        private bool _firstPoint = true;

        private readonly Vector3 _startPosition = Vector3.zero;
        private readonly Quaternion _startDirection = Quaternion.LookRotation(Vector3.forward);


        public TerrainSegmentPoint GetNextPoint(int segmentIndex)
        {
            var point = new TerrainSegmentPoint();

            if (_firstPoint)
            {
                _firstPoint = false;
                point.Position = _startPosition;
                point.Rotation = _startDirection;

                RegenerateFromToRotations(point.Rotation, segmentIndex);

                _lastSegmentPoint = point;
                return point;
            }

            point.Rotation = Quaternion.Slerp(_globalFromRotation, _globalToRotation, (float) _pointIndex / _rotationLength);

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
}