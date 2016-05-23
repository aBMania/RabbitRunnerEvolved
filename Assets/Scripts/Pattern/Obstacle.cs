using UnityEngine;

namespace Pattern
{
    [SerializeField]
    public class Obstacle {

        [SerializeField, Range(0, 360)]
        private float _angle = 180f;

        [SerializeField, Range(0, 10)]
        private float _centerOffset = 5f;

        [SerializeField]
        private bool _rotating = false;

        [SerializeField, Range(1, 100)]
        private float _rotationSpeed = 20f;

        [SerializeField]
        private float _z = 0f;

        [SerializeField]
        private bool _translating = false;

        [SerializeField, Range(1, 100)]
        private float _translationSpeed = 20f;

        [SerializeField]
        private float _translationLength = 10f;

        [SerializeField]
        private Color _obstacleColor = Color.white;

        [SerializeField]
        public Mesh obstacleMesh = null;

        public float Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        public float CenterOffset
        {
            get { return _centerOffset; }
            set { _centerOffset = value; }
        }

        public bool Rotating
        {
            get { return _rotating; }
            set { _rotating = value; }
        }

        public float RotationSpeed
        {
            get { return _rotationSpeed; }
            set { _rotationSpeed = value; }
        }
        public float Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public bool Translating
        {
            get { return _translating; }
            set { _translating = value; }
        }

        public float TranslationSpeed
        {
            get { return _translationSpeed; }
            set { _translationSpeed = value; }
        }

        public float TranslationLength {
            get { return _translationLength; }
            set { _translationLength = value; }
        }

        public Color ObstacleColor {
            get { return _obstacleColor; }
            set { _obstacleColor = value; }
        }
    }
}

