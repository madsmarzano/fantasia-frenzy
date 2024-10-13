using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// By Madison Marzano
/// 
/// Used in the transition from one end of the level to the other which happens when the Player activates a trigger.
/// This script is attached to the Teleport Points and checks how close the Player is to one of them.
/// If the player is in range, the opacity of a white UI image changes from transparent to completely opaque as the player draws closer.
/// </summary>

public class LostWoodsEffect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform playerPos;
    
    [SerializeField] private Image overlay; //UI Image
    private Color overlayColor = new Color(1, 1, 1, 0); //White with opacity of 0

    private void Start() 
    {
        playerPos = player.GetComponent<Transform>();
        overlayColor = overlay.color;
    }

    private void Update()
    {
        if (Vector2.Distance (playerPos.position, transform.position) > 0 && Vector2.Distance (playerPos.position, transform.position) <= 10)
        {
            float distance = Vector2.Distance(playerPos.position, transform.position);
            float newAlpha = 1 - (distance/10); //New opacity of the UI image
            overlayColor.a = newAlpha;
            overlay.color = overlayColor;
        }
    }

}
