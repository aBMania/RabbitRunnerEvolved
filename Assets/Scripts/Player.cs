using Application;
using Application.Model.Terrain;
using UnityEngine;

public class Player : RabbitApplicationElement {

    float speed = 10f;

    private float _location = 0;

    private RabbitTerrain RabbitTerrain;

    public void Awake()
    {
        RabbitTerrain = App.Model.Terrain;
    }

    [Range(0, 1)]
    public float Height;

    [Range(-1, 1)]
    private float playerRotation = 1;

    void Update()
    {
        _location += speed * Time.deltaTime;

        Vector3 position;
        Quaternion rotation;

        RabbitTerrain.GetPlayerPositionAndOrientationAt(_location, playerRotation, out position, out rotation);
    }
}