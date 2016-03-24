using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainModel))]
public class TerrainModelEditor : Editor
{

    public override void OnInspectorGUI()
    {
        TerrainModel terrain = (TerrainModel) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate next Segment"))
        {
            terrain.GenerateNextSegment();
        }

    }
}
