using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    // this class is for show the real amount of damage and destroy self after the animation finished

    [Header("Config")]
    [SerializeField] private TextMeshProUGUI damageTMP;

    public void SetDamageText(float damage)
    {
        damageTMP.text = damage.ToString();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
