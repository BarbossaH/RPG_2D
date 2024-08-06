using System;
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

    [Header("Status Panel")]
    [SerializeField] private GameObject statesPanel;
    [SerializeField] private TextMeshProUGUI statLevelTMP;
    [SerializeField] private TextMeshProUGUI statDamageTMP;
    [SerializeField] private TextMeshProUGUI statCriticalChanceTMP;
    [SerializeField] private TextMeshProUGUI statCriticalDamageTMP;
    [SerializeField] private TextMeshProUGUI statTotalExpTMP;
    [SerializeField] private TextMeshProUGUI statCurrentExpTMP;
    [SerializeField] private TextMeshProUGUI statRequiredExpTMP;

    [Header("Attributes")]
    [SerializeField] private TextMeshProUGUI statPointsTMP;
    [SerializeField] private TextMeshProUGUI statStrengthTMP;
    [SerializeField] private TextMeshProUGUI statDexterityTMP;
    [SerializeField] private TextMeshProUGUI statIntelligenceTMP;

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
    public void ToggleStatPanel()
    {
        statesPanel.SetActive(!statesPanel.activeSelf);
        if (statesPanel.activeSelf)
        {
            UpdateStatePanel();
        }
    }
    private void UpdateStatePanel()
    {
        statLevelTMP.text = playerStatus.Level.ToString();
        statDamageTMP.text = playerStatus.TotalDamage.ToString();
        statCriticalChanceTMP.text = playerStatus.CriticalChance.ToString();
        statCriticalDamageTMP.text = playerStatus.CriticalDamage.ToString();
        statTotalExpTMP.text = playerStatus.TotalExp.ToString();
        statCurrentExpTMP.text = playerStatus.CurrentExp.ToString();
        statRequiredExpTMP.text = playerStatus.ExpForNextLevel.ToString();
        statPointsTMP.text = playerStatus.AttributesPoints.ToString();
        statStrengthTMP.text = playerStatus.Strength.ToString();
        statDexterityTMP.text = playerStatus.Dexterity.ToString();
        statIntelligenceTMP.text = playerStatus.Intelligence.ToString();
    }
    private void OnUpgradeCallback()
    {
        UpdateStatePanel();
        UpdatePlayerUI();
    }
    private void OnEnable()
    {
        PlayerUpgrade.OnPlayerUpgradeEvent += OnUpgradeCallback;
    }

    private void OnDisable()
    {
        PlayerUpgrade.OnPlayerUpgradeEvent -= OnUpgradeCallback;

    }
}
