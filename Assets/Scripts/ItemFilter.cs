using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemFilter : MonoBehaviour
{
    private ObjectPool objectPool;
    public Transform gridLayout;
    public List<ItemDataScriptableObject> allItems; 
    public Toggle[] subCategoryCheckboxes;
    private GameObject filterTab;
    private List<ItemDataScriptableObject> filteredItems;
    private string selectedCategory = "";

    private void Awake()
    {
        filterTab = GameObject.FindGameObjectWithTag("FilterBox");
        objectPool = GetComponentInChildren<ObjectPool>();
    }
    private void Start()
    {
        filterTab.SetActive(false);
        PopulateGrid(allItems);
    }


    public void EnableCategory(string category)
    {
        selectedCategory = category;
    }

    public void ApplyFilters()
    {
        // Create list of subcategories 
        List<string> selectedSubCategories = new List<string>();

        foreach (var checkbox in subCategoryCheckboxes)
        {
            if (checkbox.isOn)
            {
                selectedSubCategories.Add(checkbox.name);
            }
        }

        // Filter items based on selected category and sub-categories
        if (string.IsNullOrEmpty(selectedCategory) && selectedSubCategories.Count == 0)
        {
            // No category or subcategory selected, do nothing
            return;
        }
        else if (string.IsNullOrEmpty(selectedCategory))
        {
            // No category selected, filter only by sub-category
            filteredItems = FilterItems(null, selectedSubCategories);
        }
        else if (selectedSubCategories.Count == 0)
        {
            // Only subcategories selected, filter by category
            filteredItems = FilterItems(selectedCategory, null);
        }
        else
        {
            // Category and sub-categories selected, filter by both
            List<ItemDataScriptableObject> categoryFilteredItems = FilterItems(selectedCategory, null);
            filteredItems = FilterItemsBySubCategories(categoryFilteredItems, selectedSubCategories);
        }


        PopulateGrid(filteredItems);
    }

    public void ResetFilters()
    {
        selectedCategory = "";
        foreach (var checkbox in subCategoryCheckboxes)
        {
            checkbox.isOn = false;
        }

        PopulateGrid(allItems);
    }

    private List<ItemDataScriptableObject> FilterItems(string category, List<string> subCategories)
    {
        List<ItemDataScriptableObject> filtered = new List<ItemDataScriptableObject>();

        foreach (var item in allItems)
        {
            bool categoryMatch = string.IsNullOrEmpty(category) || item.category == category;
            bool subCategoryMatch = subCategories == null || subCategories.Contains(item.subCategory);

            if (categoryMatch && subCategoryMatch)
            {
                filtered.Add(item);
            }
        }

        return filtered;
    }

    public void PopulateGrid(List<ItemDataScriptableObject> items)
    {
   
        foreach (Transform child in gridLayout)
        {
            objectPool.ReturnItemToPool(child.gameObject);
        }


        foreach (var item in items)
        {
            GameObject newItemObj = objectPool.GetPooledItem();

            if (newItemObj != null)
            {
                Image itemImage = newItemObj.GetComponentInChildren<Image>();
                if (itemImage != null)
                {
                    itemImage.sprite = item.sprite;
                }

                newItemObj.transform.SetParent(gridLayout, false);
                newItemObj.SetActive(true);
            }
        }
    }


    private List<ItemDataScriptableObject> FilterItemsBySubCategories(List<ItemDataScriptableObject> items, List<string> subCategories)
    {
        List<ItemDataScriptableObject> filtered = new List<ItemDataScriptableObject>();

        foreach (var item in items)
        {
            if (subCategories.Contains(item.subCategory))
            {
                filtered.Add(item);
            }
        }

        return filtered;
    }
}
