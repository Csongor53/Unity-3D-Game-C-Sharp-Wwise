using UnityEngine;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour
{
    public static DataStorage instance;

    [field: SerializeField]
    private int requiredKills;

    [field: SerializeField]
    public int health
    {
        get;
        private set;
    }

    public int score
    {
        get;
        private set;
    }
    public int enemiesShot
    {
        get;
        private set;
    }
    public float playTime
    {
        get;
        private set;
    }

    void Start()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        playTime += Time.deltaTime;
    }

    public void IncreaseScore(int increaseBy)
    {
        score += increaseBy;
        Debug.Log("Score: " + score);
        if (score >= 40)
            SceneManager.LoadScene("Success");
    }

    public void DecreaseHealth(int decreaseBy)
    {
        health -= decreaseBy;
        Debug.Log("Health: " + health);
        if (health <= 0)
            SceneManager.LoadScene("GameOver");
    }
    
    public void IncreaseHealth(int decreaseBy)
    {
        health += decreaseBy;
        if (health > 5)
            health = 5;
        Debug.Log("Health: " + health);
    }

    public void IncreaseEnemyKilledCount()
    {
        enemiesShot++;
        if (enemiesShot == requiredKills)
            SceneManager.LoadScene("Success");
    }
}