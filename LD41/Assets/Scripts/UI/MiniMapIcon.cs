// Date   : 22.04.2018 15:10
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class MiniMapIcon : MonoBehaviour {

    void Start () {
    }

    public void Initialize ()
    {
        GameManager.main.ShowIconOnDriveHud(GetComponent<SpriteRenderer>(), transform);
    }

    void Update () {
    
    }
}
