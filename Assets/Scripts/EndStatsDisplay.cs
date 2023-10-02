using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndStatsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI enemiesDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        var roundedTime = Math.Round(DataStorage.instance.playTime, 2);
        time.text = roundedTime.ToString();
        enemiesDestroyed.text = DataStorage.instance.enemiesShot.ToString();
    }
}
