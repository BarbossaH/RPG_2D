using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextManger : Singleton<DamageTextManger>
{
    //this class is to manage the floating text of damage amount, creating, showing and destroying them

    // public static DamageTextManger Instance { get; } = new DamageTextManger();

    [Header("Config")]
    [SerializeField] private DamageText damageTextPrefab;

    public void ShowDamageText(float damageAmount, Transform parent)
    {
        DamageText text = Instantiate(damageTextPrefab, parent);
        text.transform.position += Vector3.right * 0.5f;
        text.SetDamageText(damageAmount);
    }
}
