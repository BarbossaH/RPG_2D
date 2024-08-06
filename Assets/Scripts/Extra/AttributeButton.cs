using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButton : MonoBehaviour
{
    public static event Action<AttributesType> OnAttributesAddEvent;
    [Header("Config")]
    [SerializeField] private AttributesType attributesType;

    public void AddAttribute()
    {
        OnAttributesAddEvent?.Invoke(attributesType);
    }
}
