using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private int damage = 5;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * speed;
        SendRay();
    }

    private void SendRay()
    {
        bool hitSomething =
            Physics.Raycast(transform.position, -transform.right, out var hitInfo);
        if (hitSomething && hitInfo.transform.CompareTag("Player"))
        {
            rb.velocity = -transform.right * speed * speedMultiplier;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CarTurnTrigger"))
            transform.Rotate(Vector3.up, 180f);

        if (collision.gameObject.CompareTag("Player"))
            DataStorage.instance.DecreaseHealth(damage);
    }
}
