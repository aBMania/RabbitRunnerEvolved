using UnityEditor;
using UnityEngine;


  [CustomEditor(typeof(TerrainModel))]
  public class TerrainModelEditor : UnityEditor.Editor
  {

    public override void OnInspectorGUI()
    {
      TerrainModel terrain = (TerrainModel) target;

      DrawDefaultInspector();

      if (GUILayout.Button("Generate next Segment"))
      {
        terrain.GenerateNextSegment();
      }

      if (GUILayout.Button("Generate next 10 Segment"))
      {
        for (var i = 0; i < 10; i++)
        {
          terrain.GenerateNextSegment();
        }
      }

      if (GUILayout.Button("Reset"))
      {

      }


    }
  }

