using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    private TMP_Text healthTxt;
    [SerializeField] PlayerHealthValue health;

    private void Start()
    {
        healthTxt = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        healthTxt.SetText("Health: " + health.value.ToString() + "%");

        if (health.value <= 20) { healthTxt.color = Color.red; }
    }
}
