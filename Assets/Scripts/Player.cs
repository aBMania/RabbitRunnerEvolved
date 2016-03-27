using UnityEngine;

  public class Player : MonoBehaviour {

    float speed = 10f;

    private float location = 0;

    public TerrainModel terrain;

    [Range(0, 1)]
    public float height;

    [Range(-1, 1)]
    private float playerRotation = 1;

    void Update()
    {
      location += speed * Time.deltaTime;

      Vector3 position;
      Quaternion rotation;

      terrain.GetPlayerPositionAndOrientationAt(location, playerRotation, out position, out rotation);

      transform.position = position;
      transform.rotation = rotation;
    }
  }
