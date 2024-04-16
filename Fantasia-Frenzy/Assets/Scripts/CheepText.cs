using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheepText : MonoBehaviour
{
    private TMP_Text cheepTxt;
    [SerializeField] CollectableCount cheep;

    private void Start()
    {
        cheepTxt = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        cheepTxt.SetText(cheep.count.ToString());
    }
}
