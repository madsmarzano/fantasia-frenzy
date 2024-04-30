using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoWin : MonoBehaviour
{
    //Script is attached to --ENEMIES-- GameObject, where all enemies are children 
    //Instantiate WinnerDoor to right of Player, yPos = -0.5

    [SerializeField] private GameObject winnerDoor;
    [SerializeField] private Transform player;

    private bool doorSpawned;

    private void Update()
    {
        if (transform.childCount == 0 && !doorSpawned)
        {
            SpawnDoor();
        }
    }

    void SpawnDoor()
    {
        Instantiate(winnerDoor, new Vector2(player.position.x + 2, -0.5f), Quaternion.identity);
        doorSpawned = true;
    }
}
