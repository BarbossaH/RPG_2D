using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerStatus))]
public class PlayerStatusEditor : Editor
{
  private PlayerStatus StatusTarget => target as PlayerStatus;

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    if (GUILayout.Button("Reset Statues"))
    {
      StatusTarget.ResetPlayer();
    }
  }
}