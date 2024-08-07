using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatus playerStatus;
    [Header("Test")]
    public ItemHealthPotion HealthPotion;
    public ItemManaPotion ManaPotion;

    private PlayerAnimations playerAnimations;
    private PlayerExp playerExp;
    public PlayerMana PlayerMana { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerExp = GetComponent<PlayerExp>();
        PlayerMana = GetComponent<PlayerMana>();
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    // public PlayerStatus PlayerStatus
    // {
    //     get { return playerStatus; }
    // }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (HealthPotion.UseItem())
            {
                Debug.Log("Use Heath potion Item");
            }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (ManaPotion.UseItem())
            {
                Debug.Log("Use Mana Potion");
            }
        }
    }
    public PlayerStatus PlayerStatus => playerStatus;

    public void ResetPlayer()
    {
        //reset player status
        playerStatus.ResetPlayer();
        //reset player animation
        playerAnimations.ResetAnimation();
        PlayerMana.ResetMana();
    }

    public void AddExp(float amount)
    {
        playerExp.AddExp(amount);
    }
}
