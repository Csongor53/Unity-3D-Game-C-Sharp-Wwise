using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthAmount;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Image healthBar;

    // Update is called once per frame
    void Update()
    {
        // health bar
        healthBar.rectTransform.sizeDelta = new Vector2(DataStorage.instance.health * 100, healthBar.rectTransform.sizeDelta.y);

        // health
        healthAmount.text = DataStorage.instance.health.ToString();

        // score
        score.text = DataStorage.instance.score.ToString();
    }
}
