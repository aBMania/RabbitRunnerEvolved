using System.Collections.Generic;
using System.Linq;
using Application.Controller.GameManager;
using Application.Model.Terrain.PathGenerator;
using Application.Model.Terrain.TerrainGenerator;
using Application.Model.Terrain.TerrainSegments;
using Attributes;
using UnityEngine;

namespace Application.Model.Terrain
{
    public class TerrainModel : RabbitApplicationElement
    {
        public IPathGenerator PathGenerator
        {
            get { return GetComponentInChildren<IPathGenerator>(); }
        }

        public ITerrainGenerator TerrainGenerator
        {
            get { return GetComponentInChildren<ITerrainGenerator>(); }
        }

        public delegate void TerrainUpdated();
        public event TerrainUpdated OnTerrainUpdated;

        [ShowOnly, SerializeField]
        private int _terrainDecayToPlayer = 100;

        [ShowOnly, SerializeField]
        private int _terrainMaxSize = 200;

        [ShowOnly, SerializeField]
        private int _currentIndex;

        private readonly IDictionary<int, TerrainSegment> _terrainSegments = new SortedDictionary<int, TerrainSegment>();

        private ITerrainGenerator _terrainGenerator;
        private GameManager _gameManager;

        public void Awake()
        {
            _terrainGenerator = TerrainGenerator;
            _gameManager = App.Controller.GameManager;

            _gameManager.OnGameStart += OnGameStart;
            App.Model.Player.OnPlayerUpdated += OnPlayerUpdated;
        }

        private void OnPlayerUpdated()
        {
            UpdateTerrain();
        }

        public void OnGameStart()
        {
            UpdateTerrain();
        }

        private void UpdateTerrain()
        {
            var playerLocation = Mathf.FloorToInt(App.Model.Player.Location);

            while (playerLocation + _terrainDecayToPlayer > _currentIndex)
                AddSegment();

            while (_terrainSegments.Count > _terrainMaxSize)
                RemoveSegment();

            if (OnTerrainUpdated != null) OnTerrainUpdated();
        }

        private void RemoveSegment()
        {
            int minKey = _terrainSegments.Keys.Min();
            _terrainSegments.Remove(minKey);
        }

        private void AddSegment()
        {
            GenerateNextSegment();
        }

        public void GetCameraPositionAndOrientationAt(float location, float angle, out Vector3 position, out Quaternion orientation)
        {
            var flooredLocation = Mathf.FloorToInt(location);
            var playerLocalRatio = location - flooredLocation;
            var previousTerrainSegment = GetTerrainSegmentAt(flooredLocation);

            previousTerrainSegment.GetCameraPositionAndOrientationAt(playerLocalRatio, angle, out position, out orientation);
        }

        public void GetPlayerPositionAndOrientationAt(float location, float angle, out Vector3 position, out Quaternion orientation)
        {
            var flooredLocation = Mathf.FloorToInt(location);
            var playerLocalRatio = location - flooredLocation;
            var previousTerrainSegment = GetTerrainSegmentAt(flooredLocation);

            previousTerrainSegment.GetPlayerPositionAndOrientationAt(playerLocalRatio, angle, out position, out orientation);
        }

        public TerrainSegment GetTerrainSegmentAt(float z)
        {
            // Return the previous terrainSegment
            return GetTerrainSegmentAt(Mathf.FloorToInt(z));
        }

        public TerrainSegment GetTerrainSegmentAt(int z)
        {
            if (!_terrainSegments.ContainsKey(z))
            {
                throw new PlayerOutOfTerrainExeption();
            }

            return _terrainSegments[z];
        }

        public void GenerateNextSegment()
        {
            var terrainSegment = _terrainGenerator.GenerateNextTerrainSegment();

            _terrainSegments.Add(terrainSegment.Index, terrainSegment);
            _currentIndex = terrainSegment.Index;
        }

        public int TerrainDecayToPlayer
        {
            get { return _terrainDecayToPlayer; }
            set { _terrainDecayToPlayer = value; }
        }

        public IDictionary<int, TerrainSegment> Segments
        {
            get { return _terrainSegments; }
        }
    }
}