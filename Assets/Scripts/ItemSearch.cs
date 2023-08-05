using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSearch : MonoBehaviour
{
    public TMP_InputField searchInput;
    private ItemFilter itemFilter; 
    [SerializeField] private Transform gridLayout;
    //private ObjectPool objectPool;

    private List<ItemDataScriptableObject> allItems;
    private List<ItemDataScriptableObject> searchResults;

    private void Awake()
    {       
       //objectPool = GetComponentInChildren<ObjectPool>();
       itemFilter = GetComponent<ItemFilter>();
    }
    private void Start()
    {
  
        searchResults = new List<ItemDataScriptableObject>();
        allItems = itemFilter.allItems;
        searchInput.onValueChanged.AddListener(OnSearchInputValueChanged);
    }

    private void OnSearchInputValueChanged(string searchQuery)
    {        
        searchResults.Clear();
        
        if (string.IsNullOrEmpty(searchQuery))
        {
            itemFilter.PopulateGrid(allItems);
            return;
        }

        foreach (var item in allItems)
        {
            if (item.name.ToLower().Contains(searchQuery.ToLower()))
            {
                searchResults.Add(item);
            }
        }
        itemFilter.PopulateGrid(searchResults);
    }
}
