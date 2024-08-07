using UnityEngine;

public class GameManager : Singleton<GameManager>
{

  [SerializeField] private Player player;
  public Player Player => player;

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

  public void AddPLayerExp(float expAmount)
  {
    player.AddExp(expAmount);
  }
}