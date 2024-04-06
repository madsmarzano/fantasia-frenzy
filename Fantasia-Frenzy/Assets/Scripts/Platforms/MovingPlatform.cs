using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    public bool atTop;
    public bool atBottom;
    public float top;
    public float bottom;
    public float position;
    [SerializeField] private float distance;

    private void Start()
    {
        bottom = transform.position.y;
        top =  transform.position.y + distance;
    }

    void Update()
    {
        position = transform.position.y;

        if (position == bottom)
        {
            atBottom = true; atTop = false;
            //transform.Translate(Vector3.up * distance * Time.deltaTime);
        }
        else if (position == top)
        {
            atTop = true; atBottom = false;
        }

        if (atBottom)
        {
            transform.Translate(Vector3.up * distance * Time.deltaTime);
        }
        else if (atTop)
        {
            transform.Translate(Vector3.down * distance * Time.deltaTime);
        }
    }

    private void MoveDown()
    {
        for (int i = 0; i < 11; i++)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        }
        atBottom = true; atTop = false;
    }

    private void MoveUp()
    {
        for (int i = 0; i < 11; i++)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
        atTop = true; atBottom = false;
    }
}
