using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    private PlayerAnimations playerAnimations;
    private PlayerExp playerExp;
    private PlayerMana playerMana;
    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerExp = GetComponent<PlayerExp>();
        playerMana = GetComponent<PlayerMana>();
    }

    // public PlayerStatus PlayerStatus
    // {
    //     get { return playerStatus; }
    // }
    public PlayerStatus PlayerStatus => playerStatus;

    public void ResetPlayer()
    {
        //reset player status
        playerStatus.ResetPlayer();
        //reset player animation
        playerAnimations.ResetAnimation();
        playerMana.ResetMana();
    }

    public void AddExp(float amount)
    {
        playerExp.AddExp(amount);
    }
}
