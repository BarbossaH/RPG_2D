using UnityEngine;

public class PlayerExp : MonoBehaviour
{
  [SerializeField] private PlayerStatus status;

  public void AddExp(float amount)
  {
    status.CurrentExp += amount;
    while (status.CurrentExp >= status.ExpForNextLevel)
    {
      status.CurrentExp -= status.ExpForNextLevel;
      LevelUp();
    }
  }

  private void LevelUp()
  {
    status.Level++;
    // Debug.Log(status.Level);
    //when leveling up, the experience to reach the next leven will increase. So we need to recalculate the experience demand for the level up.
    status.ExpForNextLevel = CalculateNextExpRequired();
    // Debug.Log(status.ExpForNextLevel);
  }

  private float CalculateNextExpRequired()
  {
    float newExpRequired = Mathf.Round(status.ExpForNextLevel * (1 + status.ExpMultiplier / 100f));
    return newExpRequired;
  }
}