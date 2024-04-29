using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostWoodsEffect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform playerPos;
    
    [SerializeField] private GameObject overlay;
    private Image overlayImage;
    private Color overlayColor;

    private void Start() 
    {
        playerPos = player.GetComponent<Transform>();
        overlayColor = overlay.GetComponent<Graphic>().color;
        //overlayColor = overlayImage.color;

        overlayColor.a = 0f;
    }

    private void Update()
    {
        if (Vector3.Distance (playerPos.position, transform.position) > 0 && Vector3.Distance (playerPos.position, transform.position) <= 10)
        {
            float distance = Vector3.Distance(playerPos.position, transform.position);
            float newAlpha = 1 - (distance/10);
            overlayColor.a = newAlpha;
        }
    }

}
