using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CAMERA TRIGGER SCRIPT FOR FANTASIA FRENZY

public class CameraTrigger : MonoBehaviour
{
    CameraSystem _camera;

    private void Start()
    {
        _camera = Camera.main.GetComponent<CameraSystem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _camera.yMax += 10;
        }
    }
}
