using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDataScriptableObject", menuName = "Scriptable Objects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject
{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public string name;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public string category;
    public string subCategory;
    public Sprite sprite;
}
