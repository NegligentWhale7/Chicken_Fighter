using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    [SerializeField] float speed = 2.7f;
    [SerializeField] Vector3 meta = new Vector3(-16 , 0, 0);    
    private void Update()
    {
        if (!GameManager.IsPaused)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, meta, speed * Time.deltaTime);
        }
        
    }
}
