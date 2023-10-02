using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private AK.Wwise.Event shootSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShoot(InputValue inputValue)
    {
        shootSound.Post(gameObject);

        GameObject newBullet = Instantiate(bullet, Camera.main.transform.position, Quaternion.identity);
        newBullet.transform.LookAt(Camera.main.transform.position + Camera.main.transform.forward);
        newBullet.transform.Translate(Vector3.forward * Vector3.Distance(newBullet.transform.position, transform.position));
    }
}
