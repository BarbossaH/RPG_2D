using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField] private Player player;
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      player.ResetPlayer();
    }
    if (Input.GetKeyDown(KeyCode.E))
    {
      player.AddExp(300f);
    }
  }
}