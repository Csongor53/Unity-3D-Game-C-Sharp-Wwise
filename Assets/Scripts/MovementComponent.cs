using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private MovementType movementType;

    [SerializeField] private Animator animator;

    private float lastFootstep = 0;
    private bool footstepIsPlaying = false;
    [SerializeField] private int stepSoundFrequency = 750;

    [SerializeField] AK.Wwise.Event jumpSound;
    [SerializeField] AK.Wwise.Event footstepsSound;

    private Vector3 moveBy;
    private bool isMoving;
    private bool isJumpingOrFalling;

    // Start is called before the first frame update

    void Start()
    {
        lastFootstep = Time.time;
    }

    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        if (isJumpingOrFalling)
            return;

        jumpSound.Post(gameObject);

        GetComponent<Rigidbody>().AddForce(0, 8, 0, ForceMode.VelocityChange);
    }

    void Update()
    {
        ExecuteMovement();
    }

    void ExecuteMovement()
    {
        isJumpingOrFalling = GetComponent<Rigidbody>().velocity.y < -.035 ||
                             GetComponent<Rigidbody>().velocity.y > 0.00001;

        if (moveBy == Vector3.zero)
            isMoving = false;
        else
            isMoving = true;

        animator.SetBool("walk", isMoving);
        animator.SetBool("jump", isJumpingOrFalling);

        if (!isMoving)
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            return;
        }

        if (movementType == MovementType.TransformBased)
        {
            RotatePlayerFigure(moveBy);
            //transform.position += moveBy * (speed * Time.deltaTime);
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));


            // play footsteps if not in the air and moving
            if (!footstepIsPlaying && isMoving && !isJumpingOrFalling)
            {
                footstepsSound.Post(gameObject);
                lastFootstep = Time.time;
                footstepIsPlaying = true;
            }
            else
            {
                if ( Time.time - lastFootstep > stepSoundFrequency / speed * Time.deltaTime)
                    footstepIsPlaying = false;
            }

        }
        else if (movementType == MovementType.PhysicsBased)
        {
            var rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddForce(moveBy * 2, ForceMode.Acceleration);
        }

    }

    private void RotatePlayerFigure(Vector3 rotateVector)
    {
        rotateVector = Vector3.Normalize(rotateVector);
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        var rotationY = 90 * rotateVector.x;

        if(rotateVector.z < 0)
        {
            transform.Rotate(0, 180, 0);
            rotationY *= -1;
        }

        transform.Rotate(0, rotationY, 0);
    }

}