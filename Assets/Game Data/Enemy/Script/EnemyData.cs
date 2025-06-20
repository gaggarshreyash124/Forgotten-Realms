using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
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

    #region Stats

    [BoxGroup("Stats")]
    [HideLabel]
    [Header("MaxHealth")]
    public float Maxhealth;

    [BoxGroup("Stats")]
    [HideLabel]
    [Header("Speed")]
    public float speed;

    [BoxGroup("Stats")]
    [HideLabel]
    [Header("Attack Range")]
    public float attackrange;

    [BoxGroup("Stats")]
    [HideLabel]
    [Header("Attack Power")]
    public float attackdamage;
    #endregion

   
}   
