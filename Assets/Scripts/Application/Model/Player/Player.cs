using System;
using Application.Model.Terrain;
using Attributes;
using UnityEngine;

namespace Application.Model.Player
{
    public class Player : RabbitApplicationElement {

        public delegate void PlayerUpdated();
        public event PlayerUpdated OnPlayerUpdated;

        [ShowOnly, SerializeField]
        private float speed = 10f;

        [ShowOnly, SerializeField]
        private float _location;

        [ShowOnly, SerializeField]
        private Vector3 _position;

        [SerializeField, Range(-180, 180)]
        private float _angle;

        [ShowOnly, SerializeField]
        private Quaternion _rotation;
        private TerrainModel _terrainModel;

        [ShowOnly, SerializeField]
        private float _angularSpeed = 600;

        public void Awake()
        {
            _terrainModel = App.Model.TerrainModel;
            _location = App.View.PlayerCamera.Offset;
        }

        public void Update()
        {
            try
            {
                _terrainModel.GetPlayerPositionAndOrientationAt(_location, _angle, out _position, out _rotation);
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

        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        public float AngularSpeed
        {
            get { return _angularSpeed; }
            set { _angularSpeed = value; }
        }
    }
}