using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] private ItemDataScriptableObject itemData;
    [SerializeField] private string[] tags;

    private void Start()
    {
        itemData.itemName = "Meh";
        itemData.itemCategory = "Clothes";
        itemData.itemSubCategory = "Men";
        itemData.itemTags = tags;
    }

}