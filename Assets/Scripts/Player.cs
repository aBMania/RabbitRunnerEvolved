using System;
using Application;
using Application.Model.Terrain;
using UnityEngine;

public class Player : RabbitApplicationElement {

    float speed = 10f;

    private float _location = 0;

    private TerrainModel _terrainModel;

    public void Start()
    {
        _terrainModel = App.Model.TerrainModel;
    }

    [Range(0, 1)]
    public float Height;

    [Range(-1, 1)]
    private float playerRotation = 1;

    public void Update()
    {
        _location += speed * Time.deltaTime;

        try
        {
            Quaternion rotation;
            Vector3 position;

            _terrainModel.GetPlayerPositionAndOrientationAt(_location, playerRotation, out position, out rotation);
        }
        catch (Exception e)
        {
            //Debug.Log(String.Format("Exception {0}", e));
        }
    }
}