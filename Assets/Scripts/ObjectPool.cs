using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;    
    [SerializeField] private int poolSize = 5;

    private List<GameObject> pooledItems = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newItem = Instantiate(itemPrefab);
            newItem.transform.SetParent(transform, false);
            newItem.SetActive(true);
            pooledItems.Add(newItem);
        }
    }

    public GameObject GetPooledItem()
    {
        foreach (var item in pooledItems)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                return item;
            }
        }
        return null;
    }

    public void ReturnItemToPool(GameObject item)
    {
        item.SetActive(false);
    }
}
