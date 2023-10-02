using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementInterpolation : MonoBehaviour
{
    [SerializeField] 
    private Vector3 movementDistance;
    [SerializeField] 
    private float timeForMovement;

    
    private Vector3 originalStartPosition;
    private Vector3 originalTargetPosition;
    private Vector3 currentStartPosition;
    private Vector3 currentTargetPosition;
    private float passedMovementTime;
    private bool moveForward = true;
    // Start is called before the first frame update
    void Start()
    {
        originalStartPosition = transform.position;
        originalTargetPosition = originalStartPosition + movementDistance;
        ChangeMovementDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (passedMovementTime >= timeForMovement)
            ChangeMovementDirection();
        transform.position =
            Vector3.Lerp(currentStartPosition, currentTargetPosition, passedMovementTime / timeForMovement);
        passedMovementTime += Time.deltaTime;
    }

    void ChangeMovementDirection()
    {
        if (moveForward)
        {
            currentStartPosition = originalStartPosition;
            currentTargetPosition = originalTargetPosition;
        }
        else
        {
            currentStartPosition = originalTargetPosition;
            currentTargetPosition = originalStartPosition;
        }
        passedMovementTime = 0;
        moveForward = !moveForward;
    }

}
