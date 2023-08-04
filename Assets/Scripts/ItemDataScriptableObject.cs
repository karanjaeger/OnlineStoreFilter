using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemCategory;
    public string itemSubCategory;
    public string[] itemTags;
}
