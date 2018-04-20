// Date   : 20.04.2018 20:47
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName="HotKeyMap", menuName= "HotKeyMap")]
public class HotKeyMap : ScriptableObject {

    [SerializeField]
    private string objectName = "HotKeyMap";
    public string Name { get { return objectName; } }

    [SerializeField]
    private List<GameKey> keys;
    public List<GameKey> Keys { get { return keys; } }

}
