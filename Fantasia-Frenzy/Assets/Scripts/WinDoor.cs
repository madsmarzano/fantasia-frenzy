using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
{
    //private GameObject speechBubble;
    private bool isTouchingDoor = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isTouchingDoor )
        {
            SceneManager.LoadScene("Shane"); //CHANGE THIS LATER
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouchingDoor = true;
            transform.GetChild(0).gameObject.SetActive(true);
            //speechBubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingDoor = false;
        transform.GetChild(0).gameObject.SetActive(false);
        //speechBubble.SetActive(false);
    }
}
