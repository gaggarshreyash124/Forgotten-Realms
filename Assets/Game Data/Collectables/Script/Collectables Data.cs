using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectableData", menuName = "Data/Collectable Data")]
public class CollectablesData : ScriptableObject, Icollectable
{
    [TitleGroup("Information")]
    [HorizontalGroup("Information/Split/Left", Width = 0.3f)]
    [PreviewField(height: 100, Alignment = ObjectFieldAlignment.Left)]
    [HideLabel]
    [Space(10)]
    
    public Sprite icon;

    [HorizontalGroup("Information/Split", Width = 0.65f)]
    [VerticalGroup("Information/Split/Right")]
    [Header("Name")]
    [HideLabel]
    public new string name;

    [VerticalGroup("Information/Split/Right")]
    [Header("Description")]
    [HideLabel]
    [Multiline]
    public string description;

    public void collect()
    {
        
    }
}
