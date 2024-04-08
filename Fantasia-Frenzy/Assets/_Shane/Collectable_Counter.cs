using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable_Counter : MonoBehaviour
{
    public static Collectable_Counter instance;

    public TMP_Text collectableText;
    public int currentcollectables = 0;

    void Awake()
    {
        instance = this;
    }

    //Start is called before the first frame update
    void Start()
    {
        collectableText.text = "COLLECTABLE" + currentcollectables.ToString();
    }

    public void Increasecollectables(int v)
    {
        currentcollectables += v;
        collectableText.text = "COLLECTABLES:" + currentcollectables;
    }
}
