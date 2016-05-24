using System.Collections.Generic;
using Application.Controller.GameManager;
using Application.Model.Terrain.PathGenerator;
using Application.Model.Terrain.TerrainGenerator;
using Application.Model.Terrain.TerrainSegments;
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

        private readonly IDictionary<int, TerrainSegment> _terrainSegments = new Dictionary<int, TerrainSegment>();

        private ITerrainGenerator _terrainGenerator;
        private GameManager _gameManager;

        public void Awake()
        {
            _terrainGenerator = TerrainGenerator;
            _gameManager = App.Controller.GameManager;
            _gameManager.OnGameStart += OnGameStart;
        }


        public void OnGameStart()
        {
            for (var i = 0; i < 100; i++)
            {
                GenerateNextSegment();
            }
            
        }


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

            var previousTerrainSegment = GetTerrainSegmentAt(previousTerrainSegmentIndex);
            var nexTerrainSegment = GetTerrainSegmentAt(nextTerrainSegmentIndex);

            Vector3 previousTerrainSegmentPosition, nexTerrainSegmentPosition;
            Quaternion previousTerrainSegmentOrientation, nextTerrainSegmentOrientation;

            previousTerrainSegment.GetPlayerPositionAt(k, out previousTerrainSegmentPosition, out previousTerrainSegmentOrientation);
            nexTerrainSegment.GetPlayerPositionAt(k, out nexTerrainSegmentPosition, out nextTerrainSegmentOrientation);

            position = Vector3.Slerp(previousTerrainSegmentPosition, nexTerrainSegmentPosition, playerLocalRatio);
            orientation = Quaternion.Slerp(previousTerrainSegmentOrientation, nextTerrainSegmentOrientation, playerLocalRatio);
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

        public void DeleteTerrainBefore(int z)
        {
            /*
            foreach (var terrainSegment in _terrainSegments.Where(kvp => kvp.Key <= z).Select(pair => pair.Value))
            {
                // terrainSegment.Delete();
            }
            */
        }

        public void GenerateNextSegment()
        {
            var terrainSegment = _terrainGenerator.GenerateNextTerrainSegment();

            _terrainSegments.Add(terrainSegment.Index, terrainSegment);
        }
    }
}