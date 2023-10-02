using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event enemyDeathSound;
    
    [field: SerializeField]
    public float enemyHealth
    {
        private set;
        get;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float reduceBy)
    {
        enemyHealth -= reduceBy;
        if (enemyHealth <= 0)
        {
            
            enemyDeathSound.Post(gameObject);
            DataStorage.instance.IncreaseEnemyKilledCount();
            Destroy(gameObject);
        }
    }
}
