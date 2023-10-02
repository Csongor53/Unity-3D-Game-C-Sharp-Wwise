using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    [SerializeField] private Image statBar;

    private EnemyStats enemyStats;
    private float maxValue;
// Start is called before the first frame update
    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        maxValue = enemyStats.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        statBar.transform.localScale = new Vector3(enemyStats.enemyHealth / maxValue , 1, 1);
    }
}
