// Date   : 22.04.2018 15:18
// Project: LD41
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CompassIcon : MonoBehaviour
{

    [SerializeField]
    private Text txtComponent;
    [SerializeField]
    private Color colorVariable;
    [SerializeField]
    private Image imgComponent;

    private bool instantiated = false;

    private Transform target;
    private Transform player;
    private SpriteRenderer targetRenderer;
    private RectTransform rt;
    private RectTransform canvasRt;

    private Vector3 originalPosition;

    public void Instantiate(SpriteRenderer sr, Transform target, RectTransform canvasRt)
    {
        originalPosition = target.position;
        player = GameManager.main.GetPlayerTransform();
        this.canvasRt = canvasRt;
        this.target = target;
        targetRenderer = sr;
        instantiated = true;
        /*imgComponent.sprite = sr.sprite;*/
        //rt = GetComponent<RectTransform>();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        if (instantiated)
        {
            /*if (!targetRenderer.isVisible)
            {*/
            //imgComponent.enabled = true;
            float dist = 20f;
            Vector3 direction = (originalPosition - player.position);
            if (direction.magnitude < dist + 10f)
            {
                //imgComponent.enabled = false;
                target.position = originalPosition;
                //return;
            }
            else
            {
                Vector3 directedPoint = player.position + direction.normalized * dist;
                target.position = directedPoint;
                //imgComponent.enabled = true;
            }
            //Vector3 directedPoint = player.position + direction.normalized * dist;
            //Debug.Log(player.position + "->" + directedPoint);
            //Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, directedPoint);
            //target.position = directedPoint;
            //rt.anchoredPosition = screenPoint - canvasRt.sizeDelta / 2f;
            //rt.SetPositionAndRotation(screenPos, Quaternion.identity);
            /*    rt.anchorMin = screenPos;
                rt.anchorMax = screenPos;*/
            //}
            /*else
            {
                imgComponent.enabled = false;
            }*/
        }
    }

    /*
         public void Init(Transform target, Color color, SpriteRenderer renderer, Sprite icon, float ypos)
    {
        this.target = target;
        targetRenderer = renderer;
        imgComponent.color = color;
        imgComponent.sprite = icon;
        RectTransform rt = imgComponent.GetComponent<RectTransform>();
        Vector2 localPos = rt.localPosition;
        localPos.y = ypos;
        rt.localPosition = localPos;
        //txtComponent.color = color;
    }

    void Update()
    {
        if (target == null || targetRenderer == null)
        {
            Destroy(gameObject);
        }
        else if (!targetRenderer.isVisible)
        {
            if (!imgComponent.enabled)
            {
                Show();
            }
            transform.up = (Vector2)Camera.main.WorldToScreenPoint((Vector2)target.position) - (Vector2)transform.position;
        }
     
     */
}
