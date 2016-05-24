using Application.Model.Terrain.PathGenerator;
using Application.Model.Terrain.TerrainSegments;
using Attributes;
using UnityEngine;

namespace Application.Model.Terrain.TerrainGenerator
{
    public class CylinderTerrainGenerator : RabbitApplicationElement, ITerrainGenerator
    {
        [SerializeField, Range(0, 4)]
        private float _height = 1;

        [SerializeField, Range(0, 10)]
        private float _radius = 5;

        [SerializeField, Range(10, 1000)]
        private int _rotationLength = 200;

        [SerializeField, Range(3, 30)]
        private int _nDiscretePoints = 12;

        [SerializeField, Range(20, 500)]
        private int _initialLength = 200;

        [ShowOnly, SerializeField]
        private int _currentIndex = 0;

        [ShowOnly, SerializeField]
        private bool _autoUpdate;

        [ShowOnly, SerializeField]
        private TerrainSegmentPoint _previousTerrainSegmentPoint;

        public IPathGenerator PathGenerator;

        public void Awake()
        {
            PathGenerator = App.Model.TerrainModel.PathGenerator;
        }

        public TerrainSegment GenerateNextTerrainSegment()
        {
            if (_previousTerrainSegmentPoint == null)
                _previousTerrainSegmentPoint = PathGenerator.GetNextPoint(_currentIndex);

            var nextTerrainSegmentPoint = PathGenerator.GetNextPoint(_currentIndex);

            var cylinderTerrainSegment = new CylinderTerrainSegment(_currentIndex, _previousTerrainSegmentPoint, nextTerrainSegmentPoint, _height, _radius);

            _previousTerrainSegmentPoint = nextTerrainSegmentPoint;

            _currentIndex++;

            return cylinderTerrainSegment;
        }

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

        public bool AutoUpdate
        {
            get { return _autoUpdate; }
            set { _autoUpdate = value; }
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

        public float Height
        {
            get { return _height; }
        }
    }
}