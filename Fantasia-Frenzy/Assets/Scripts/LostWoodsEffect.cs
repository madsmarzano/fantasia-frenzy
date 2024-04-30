using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostWoodsEffect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform playerPos;
    
    [SerializeField] private Image overlay;
    private Image overlayImage;
    private Color overlayColor = new Color(1, 1, 1, 0);

    private void Start() 
    {
        playerPos = player.GetComponent<Transform>();
        overlayColor = overlay.color;
        //overlayColor = overlayImage.color;

        //overlayColor.a = 0f;
    }

    private void Update()
    {
        if (Vector2.Distance (playerPos.position, transform.position) > 0 && Vector2.Distance (playerPos.position, transform.position) <= 10)
        {
            float distance = Vector2.Distance(playerPos.position, transform.position);
            //Debug.Log("distance is " + distance);
            float newAlpha = 1 - (distance/10);
            overlayColor.a = newAlpha;
            overlay.color = overlayColor;
        }
    }

}
