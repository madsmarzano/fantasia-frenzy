using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private GameObject player;
    public float xMin;
    public float xMax = 1000f;
    public float yMin;
    public float yMax;

    private void Start()
    {
        //set camera xMin and yMin based on position in editor
        xMin = transform.position.x - 50;
        yMin = transform.position.y;
        yMax = transform.position.y + 100;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        transform.position = new Vector3(x, y, transform.position.z);
    }

}
