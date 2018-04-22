// Date   : 22.04.2018 15:14
// Project: LD41
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HUDCompass : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    [SerializeField]
    private CompassIcon compassIconPrefab;


    private List<CompassIcon> compassIcons = new List<CompassIcon>();
    [SerializeField]
    private RectTransform canvasRt;
    public void ShowIcon(SpriteRenderer sr, Transform target)
    {
        CompassIcon newIcon = Instantiate(compassIconPrefab);
        newIcon.Instantiate(sr, target, canvasRt);
        RectTransform rt = newIcon.GetComponent<RectTransform>();
        newIcon.transform.SetParent(transform);
        rt.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        compassIcons.Add(newIcon);
    }

    public void DestroyIcons()
    {
        foreach(CompassIcon compassIcon in compassIcons)
        {
            compassIcon.Kill();
        }

        compassIcons.Clear();
    }

}
