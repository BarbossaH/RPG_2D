using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance { get; private set; }

  [SerializeField] private Player player;

  private void Awake()
  {
    Instance = this;
  }
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