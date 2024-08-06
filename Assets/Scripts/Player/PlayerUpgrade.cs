using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public static event Action OnPlayerUpgradeEvent;
    [Header("Config")]
    [SerializeField] private PlayerStatus playerStatus;
    [Header("Settings")]
    [SerializeField] private PlayerUpgradeSetting[] upgradeSettings;

    private void UpgradePlayer(int attributesType)
    {
        playerStatus.BaseDamage += upgradeSettings[attributesType].DamageUpgrade;
        playerStatus.TotalDamage += upgradeSettings[attributesType].DamageUpgrade;
        playerStatus.MaxHealth += upgradeSettings[attributesType].HealthUpgrade;
        playerStatus.CurrentHealth = playerStatus.MaxHealth;
        playerStatus.MaxMana += upgradeSettings[attributesType].ManaUpgrade;
        playerStatus.CurrentMana = playerStatus.MaxMana;
        playerStatus.CriticalChance += upgradeSettings[attributesType].CChanceUpgrade;
        playerStatus.CriticalDamage += upgradeSettings[attributesType].CDamageUpgrade;
    }

    private void AttributeBtnCallback(AttributesType type)
    {
        if (playerStatus.AttributesPoints <= 0) return;
        UpgradePlayer((int)type);
        playerStatus.AttributesPoints--;
        switch (type)
        {
            case AttributesType.Strength:
                playerStatus.Strength++;
                break;
            case AttributesType.Dexterity:
                playerStatus.Dexterity++;
                break;
            case AttributesType.Intelligence:
                playerStatus.Intelligence++;
                break;
        }
        OnPlayerUpgradeEvent?.Invoke();
    }
    private void OnEnable()
    {
        AttributeButton.OnAttributesAddEvent += AttributeBtnCallback;
    }
    private void OnDisable()
    {
        AttributeButton.OnAttributesAddEvent -= AttributeBtnCallback;
    }

}

[Serializable]
public class PlayerUpgradeSetting
{
    public string Name;
    [Header("Values")]
    public float DamageUpgrade;
    public float HealthUpgrade;
    public float ManaUpgrade;
    public float CChanceUpgrade;
    public float CDamageUpgrade;
}
