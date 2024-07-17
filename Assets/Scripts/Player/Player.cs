using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;

    // public PlayerStatus PlayerStatus
    // {
    //     get { return playerStatus; }
    // }
    public PlayerStatus PlayerStatus => playerStatus;
}
