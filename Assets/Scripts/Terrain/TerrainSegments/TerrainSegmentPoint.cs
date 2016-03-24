using UnityEngine;

public class TerrainSegmentPoint
{
    public Vector3 Position;
    public Quaternion Rotation;

    public Vector3 Forward
    {
        get { return Rotation*Vector3.forward; }
    }

    public Vector3 Up
    {
        get { return Rotation*Vector3.up; }
    }


    public override string ToString()
    {
        return "[position : " + Position + " rotation : " + Rotation + "]";
    }
}
