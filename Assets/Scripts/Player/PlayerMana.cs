using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatus playerStatus;

    public void UseMana(float amount)
    {
        if (playerStatus.CurrentMana >= amount)
        {
            // playerStatus.CurrentMana -= amount;
            // if (playerStatus.CurrentMana <= 0f)
            // {
            //     playerStatus.CurrentMana = 0f;
            // }
            playerStatus.CurrentMana = Mathf.Max(0f, playerStatus.CurrentMana - amount);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseMana(1f);
            print("Mana Used!");
        }
    }
}
