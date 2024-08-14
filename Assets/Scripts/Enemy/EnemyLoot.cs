using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyLoot : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float expDrop;
    [SerializeField] private DropItem[] dropItems;
    public float ExpDrop => expDrop;
    public List<DropItem> DropItems { get; private set; }
    private void Start()
    {
        LoadDropItems();
    }
    private void LoadDropItems()
    {
        DropItems = new List<DropItem>();
        foreach (DropItem item in dropItems)
        {
            float prob = Random.Range(0, 100);
            if (prob < item.DropChance)
            {
                DropItems.Add(item);
            }
        }
    }
}
[Serializable]
public class DropItem
{
    [Header("Config")]
    public string Name;
    public InventoryItem item;
    public int Quantity;

    [Header("Drop Chance")]
    public float DropChance;
    public bool PickedItem { get; set; }

}