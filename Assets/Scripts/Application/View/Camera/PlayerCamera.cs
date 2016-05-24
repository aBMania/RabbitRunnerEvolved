

using UnityEngine;

namespace Application.View.Camera
{
    public class PlayerCamera : RabbitApplicationElement
    {
        private int _offset = 4;
        private Model.Player.Player _playerModel;

        public void Start()
        {
            _playerModel = App.Model.Player;
        }

        public void LateUpdate()
        {
            var playerLocation = _playerModel.Location;
            var cameraLocation = playerLocation - _offset;

            Vector3 position;
            Quaternion orientation;

            App.Model.TerrainModel.GetCameraPositionAndOrientationAt(cameraLocation, _playerModel.Angle, out position, out orientation);

            transform.position = position;
            transform.rotation = orientation;
        }

        public int Offset
        {
            get { return _offset; }
        }
    }
}