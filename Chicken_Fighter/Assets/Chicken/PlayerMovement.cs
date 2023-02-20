using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Transform upPosition, downPosition;
    [SerializeField] private float speed, xDistance, yDistance;
    Rigidbody rb;
    private bool isUp;
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
    private void OnSwipe(string swipe)
    {
        //Debug.Log(swipe);
        if (GameManager.IsPaused)
        {
            return;
        }
        if (isUp && swipe == "Down")
        {
            this.transform.position = Vector3.Lerp(this.transform.position, downPosition.position, speed);
            isUp = false;
            //Debug.Log("Bajan");
        }
        else if (!isUp && swipe == "Up") 
        {
            this.transform.position = Vector3.Lerp(this.transform.position, upPosition.position, speed);
            isUp = true;
            //Debug.Log("Suben");
        }
        if (swipe == "Right")
        {
            Debug.Log("Salta");
            Jump();
        }
    }
    private void Jump()
    {
        var lastPos = this.transform.position;
        Vector3 parabola = new Vector3(xDistance, yDistance, 0f);
        rb.AddForce(parabola, ForceMode.Impulse);
        this.transform.position = lastPos;
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}

