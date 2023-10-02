using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int decreasePlayerHealthBy;
    [SerializeField] private AK.Wwise.Event playerDamageSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDamageSound.Post(gameObject);

            DataStorage.instance.DecreaseHealth(decreasePlayerHealthBy);
        }
    }
}