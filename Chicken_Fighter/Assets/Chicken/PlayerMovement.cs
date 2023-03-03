using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Transform upPosition, downPosition, rayCastOrigin;
    [SerializeField] private float speed, rayCastMaxDistance, xDistance, yDistance;
    [SerializeField] private LayerMask floorMask;
    Rigidbody rb;
    private bool isUp, onFloor = false;
    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.transform.position = upPosition.position;
        isUp = true;
    }
    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            ReturnToLastPosition();
        }
    }
    private void OnSwipe(string swipe)
    {
        //Debug.Log(swipe);
        if (GameManager.IsPaused)
        {
            return;
        }
        if (isUp && swipe == "Down")
        {
            Vector3 downPos = new Vector3(this.transform.position.x, this.transform.position.y, downPosition.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, downPos, speed);
            isUp = false;
            //Debug.Log("Bajan");
        }
        else if (!isUp && swipe == "Up") 
        {
            Vector3 upPos = new Vector3(this.transform.position.x, this.transform.position.y, upPosition.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, upPos, speed);
            isUp = true;
            //Debug.Log("Suben");
        }
        if (swipe == "Right")
        {
            //Debug.Log("Salta");
            Jump();
            
        }
    }
    private void Jump()
    {
        Vector3 parabola = new Vector3(xDistance, yDistance, 0f);
        if (IsGrounded())
        {
            rb.AddForce(parabola, ForceMode.Impulse);
          //rb.velocity += parabola;
        }        
    }
    private bool IsGrounded()
    {
        onFloor = Physics.Raycast(rayCastOrigin.position, Vector3.down, rayCastMaxDistance, floorMask);
        /*if (onFloor)        
        {
            Debug.DrawRay(rayCastOrigin.position, Vector3.down, Color.green, rayCastMaxDistance);
        }       */
        return onFloor;
    }
    private void ReturnToLastPosition()
    {
        Vector3 lastPos = new Vector3(3.39f, transform.position.y, transform.position.z);
        this.transform.position = Vector3.MoveTowards(this.transform.position, lastPos, 4f * Time.deltaTime);
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}

