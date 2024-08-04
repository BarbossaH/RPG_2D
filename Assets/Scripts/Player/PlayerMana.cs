using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStatus playerStatus;
    public float CurrentMana { get; private set; }

    private void Start()
    {
        ResetMana();
    }
    public void UseMana(float amount)
    {
        playerStatus.CurrentMana = Mathf.Max(0f, playerStatus.CurrentMana - amount);
        CurrentMana = playerStatus.CurrentMana;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseMana(1f);
        }
    }

    public void ResetMana()
    {
        CurrentMana = playerStatus.CurrentMana;

    }
}
