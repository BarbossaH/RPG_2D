using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private PlayerStatus playerStatus;
    [Header("UI")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image expBar;
    [SerializeField] private TextMeshProUGUI healthAmount;
    [SerializeField] private TextMeshProUGUI manaAmount;
    [SerializeField] private TextMeshProUGUI expAmount;
    [SerializeField] private TextMeshProUGUI levelAmount;



    private void Update()
    {
        UpdatePlayerUI();
    }

    private void UpdatePlayerUI()
    {
        // healthBar.fillAmount = playerStatus.CurrentHealth / playerStatus.MaxHealth;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerStatus.CurrentHealth / playerStatus.MaxHealth, 10f * Time.deltaTime);
        healthAmount.text = playerStatus.CurrentHealth.ToString("0") + " / " + playerStatus.MaxHealth.ToString("0");

        manaBar.fillAmount = playerStatus.CurrentMana / playerStatus.MaxMana;
        manaAmount.text = playerStatus.CurrentMana.ToString("0") + " / " + playerStatus.MaxMana.ToString("0");

        expBar.fillAmount = playerStatus.CurrentExp / playerStatus.ExpForNextLevel;
        // expAmount.text = playerStatus.CurrentExp.ToString("0") + " / " + playerStatus.ExpForNextLevel.ToString("0");
        expAmount.text = $"{playerStatus.CurrentExp:0} / {playerStatus.ExpForNextLevel:0}";

        levelAmount.text = "Level:  " + playerStatus.Level.ToString();
    }
}
