using System;
using Application.Model.Terrain;
using Attributes;
using UnityEngine;

namespace Application.Model.Player
{
    public class Player : RabbitApplicationElement {

        [Range(0, 1)]
        public float Height;

        public delegate void PlayerUpdated();
        public event PlayerUpdated OnPlayerUpdated;

        [ShowOnly, SerializeField]
        private float _playerRotation = 0;

        [ShowOnly, SerializeField]
        private float speed = 10f;

        [ShowOnly, SerializeField]
        private float _location;

        [ShowOnly, SerializeField]
        private Vector3 _position;

        [ShowOnly, SerializeField]
        private Quaternion _rotation;
        private TerrainModel _terrainModel;

        public void Awake()
        {
            _terrainModel = App.Model.TerrainModel;
        }

        public void Update()
        {
            _location += speed * Time.deltaTime;

            try
            {
                _terrainModel.GetPlayerPositionAndOrientationAt(_location, _playerRotation, out _position, out _rotation);
            }
            catch (PlayerOutOfTerrainExeption e)
            {
                Debug.Log(String.Format("Exception {0}", e));
            }

            if (OnPlayerUpdated != null) OnPlayerUpdated();
        }


        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public float Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Quaternion Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public TerrainModel TerrainModel
        {
            get { return _terrainModel; }
            set { _terrainModel = value; }
        }
    }
}