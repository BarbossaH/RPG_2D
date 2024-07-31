using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Waypoint))]
public class WayPointEditor : Editor
{
  private Waypoint WaypointTarget => target as Waypoint;

  private void OnSceneGUI()
  {
    if (WaypointTarget.Points.Length == 0) return;

    Handles.color = Color.red;
    for (int i = 0; i < WaypointTarget.Points.Length; i++)
    {
      EditorGUI.BeginChangeCheck();

      Vector3 currentPoint = WaypointTarget.EntityPosition + WaypointTarget.Points[i];
      Vector3 newPosition = Handles.FreeMoveHandle(currentPoint, 0.5f, Vector3.one * 0.5f, Handles.SphereHandleCap);

      GUIStyle textStyle = new GUIStyle();
      textStyle.fontStyle = FontStyle.Bold;
      textStyle.fontSize = 16;
      textStyle.normal.textColor = Color.black;
      Vector3 textPos = new Vector3(0.2f, -0f);
      Vector3 currentEntityPos = WaypointTarget.EntityPosition + WaypointTarget.Points[i];
      Handles.Label(currentEntityPos + textPos, $"{i + 1}", textStyle);

      if (EditorGUI.EndChangeCheck())
      {
        Undo.RecordObject(target, "Free Move");//make sure the manipulation can be undone, otherwise the editor won't record the operation of the handles.
        WaypointTarget.Points[i] = newPosition - WaypointTarget.EntityPosition;
      }
    }
  }
}