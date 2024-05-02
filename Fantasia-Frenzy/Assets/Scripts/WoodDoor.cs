using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WoodDoor : MonoBehaviour
{
    //private GameObject speechBubble;
    private bool isTouchingDoor = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isTouchingDoor )
        {
            SceneManager.LoadScene("Hood"); //CHANGE THIS LATER
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouchingDoor = true;
            
            //speechBubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingDoor = false;
        
        //speechBubble.SetActive(false);
    }
}