using System;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
  [Header("Config")]
  [SerializeField] private GameObject selectorSprite;
  private EnemyBrain enemyBrain;

  private void Awake()
  {
    enemyBrain = GetComponent<EnemyBrain>();
  }
  private void EnemySelectedCallback(EnemyBrain brain)
  {
    if (enemyBrain == brain)
    {
      selectorSprite.SetActive(true);
    }
    else
    {
      selectorSprite.SetActive(false);
    }
  }

  private void NoSelectionCallback()
  {
    selectorSprite?.SetActive(false);
  }
  private void OnEnable()
  {
    SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
    SelectionManager.OnNoSelectionEvent += NoSelectionCallback;
  }
  private void OnDisable()
  {
    SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
    SelectionManager.OnNoSelectionEvent -= NoSelectionCallback;
  }


}