using UnityEngine;

[SerializeField]
public class Obstacle {

	[SerializeField, Range(0, 360)]
	private float _angle = 180f;

	public float Angle {
		get { return _angle; }
		set { _angle = value; }
	}

	[SerializeField, Range(0, 10)]
	private float _centerOffset = 5f;

	public float CenterOffset {
		get { return _centerOffset; }
		set { _centerOffset = value; }
	}

	[SerializeField]
	private bool _rotating = false;

	public bool Rotating {
		get { return _rotating; }
		set { _rotating = value; }
	}

	[SerializeField, Range(1, 100)]
	private float _rotationSpeed = 20f;

	public float RotationSpeed {
		get { return _rotationSpeed; }
		set { _rotationSpeed = value; }
	}

	[SerializeField]
	private float _z = 0f;

	public float Z {
		get { return _z; }
		set { _z = value; }
	}

	[SerializeField]
	private bool _translating = false;

	public bool Translating {
		get { return _translating; }
		set { _translating = value; }
	}

	[SerializeField, Range(1, 100)]
	private float _translationSpeed = 20f;

	public float TranslationSpeed {
		get { return _translationSpeed; }
		set { _translationSpeed = value; }
	}

	[SerializeField]
	private float _translationLength = 10f;

	public float TranslationLength {
		get { return _translationLength; }
		set { _translationLength = value; }
	}

	[SerializeField]
	private Color _obstacleColor = Color.white;

	public Color ObstacleColor {
		get { return _obstacleColor; }
		set { _obstacleColor = value; }
	}

	[SerializeField]
	public Mesh obstacleMesh = null;
}

