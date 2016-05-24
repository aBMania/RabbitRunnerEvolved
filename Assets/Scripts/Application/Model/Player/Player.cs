using System;
using Application.Model.Terrain;
using UnityEngine;

namespace Application.Model.Player
{
    public class Player : RabbitApplicationElement {

        private float speed = 10f;

        private float _location;

        private TerrainModel _terrainModel;

        public void Awake()
        {
            _terrainModel = App.Model.TerrainModel;
        }

        [Range(0, 1)]
        public float Height;

        [Range(-1, 1)]
        private float _playerRotation = 0;

        public void Update()
        {
            _location += speed * Time.deltaTime;

            try
            {
                Quaternion rotation;
                Vector3 position;

                _terrainModel.GetPlayerPositionAndOrientationAt(_location, _playerRotation, out position, out rotation);
            }
            catch (Exception e)
            {
                //Debug.Log(String.Format("Exception {0}", e));
            }
        }
    }
}