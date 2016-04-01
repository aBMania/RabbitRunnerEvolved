using UnityEngine;
using System.Collections.Generic;

[SerializeField]
public class Pattern {
	[SerializeField]
	private List<Obstacle> _obstacles = new List<Obstacle>();

	[SerializeField]
	private float _length = 100f;

	public List<Obstacle> Obstacles {
		get { return _obstacles; }
	}

	public float Length {
		get { return _length; }
		set { _length = value; }
	}
}

