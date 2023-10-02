using System.Collections;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private DestroyFlyingObjectMode destroyMode;
    [SerializeField] private float DestroyFlyingObjectValue;

    [SerializeField] private AK.Wwise.Event hitMarkerSound;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Fly());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator Fly()
    {
        var timePassed = 0f;
        var startPosition = transform.position;
        bool shouldFly = true;

        while (shouldFly)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            timePassed += Time.deltaTime;
            var distanceFromStartPos = Vector3.Distance(transform.position, startPosition);

            if (destroyMode == DestroyFlyingObjectMode.DistanceBased && distanceFromStartPos >= DestroyFlyingObjectValue)
                shouldFly = false;
            else if (destroyMode == DestroyFlyingObjectMode.TimeBased && timePassed >= DestroyFlyingObjectValue)
                shouldFly = false;

            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            hitMarkerSound.Post(gameObject);

            var enemyStats = other.GetComponentInParent<EnemyStats>();
            enemyStats.ReduceHealth(2);
        }
    }
}