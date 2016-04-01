using UnityEngine;
using Newtonsoft.Json;

public class PatternGenerator : MonoBehaviour {

	private Pattern pattern;

	void Awake() {
		pattern = new Pattern();
	}

	void Update() {
		Debug.Log (JsonConvert.SerializeObject(
			pattern, 
			Formatting.Indented, 
			new JsonSerializerSettings {
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			}
		));

		pattern.Length++;

		if (pattern.Length % 100 == 0) {
			Obstacle obstacle = new Obstacle ();
			pattern.Obstacles.Add(obstacle);
		}
	}
}

