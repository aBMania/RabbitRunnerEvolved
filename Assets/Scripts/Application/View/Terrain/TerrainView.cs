using System.Collections.Generic;
using Application.Model.Terrain;
using Application.Model.Terrain.TerrainSegments;
using Application.View.Terrain.Segment;
using UnityEngine;

namespace Application.View.Terrain
{
    public class TerrainView : RabbitApplicationElement
    {
        public CylinderTerrainSegmentView CylinderPrefab;

        private TerrainModel _terrainModel;

        private IDictionary<int, TerrainSegmentView> _terrainSegmentViews = new SortedDictionary<int, TerrainSegmentView>();

        public void Awake()
        {
            _terrainModel = App.Model.TerrainModel;

            App.Model.TerrainModel.OnTerrainUpdated += OnTerrainUpdated;
        }

        private void OnTerrainUpdated()
        {
            // Add missing views
            foreach (var entry in _terrainModel.Segments)
            {
                if(_terrainSegmentViews.ContainsKey(entry.Key)) continue;
                
                if (entry.Value is CylinderTerrainSegment)
                {
                    var instance = Instantiate(CylinderPrefab);

                    instance.name = "Cylinder Segment Instance id:" + entry.Key;
                    instance.transform.parent = transform;

                    instance.Init((CylinderTerrainSegment) entry.Value);

                    _terrainSegmentViews.Add(entry.Key, instance);
                }                
            }

            // Remove unnecessary views
            IList<int> toRemoveKeys = new List<int>();

            foreach (var entry in _terrainSegmentViews)
            {
                if (_terrainModel.Segments.ContainsKey(entry.Key)) continue;

                Destroy(entry.Value.gameObject);
                toRemoveKeys.Add(entry.Key);
            }

            foreach (var key in toRemoveKeys)
            {
                _terrainSegmentViews.Remove(key);
            }
        }

    }
}