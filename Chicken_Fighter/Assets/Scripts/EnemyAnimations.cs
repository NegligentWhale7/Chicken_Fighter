using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] string runAnim, attackingAnim, dyingAnim;
    [SerializeField] Transform rayCastOrigin;
    [SerializeField] float rayMaxDistance;
    [SerializeField] LayerMask playerMask;
    private bool isPlyrClose = false;
    public enum EnemyStates { Running, Attacking, Dying }
    public EnemyStates enemyStates;

    private void Start()
    {
        enemyStates = EnemyStates.Running;
    }
    private void Update()
    {
        switch(enemyStates)
        {
            case EnemyStates.Running:
                anim.Play(runAnim);
                if (IsPlayerClose())
                {
                    enemyStates = EnemyStates.Attacking;
                }
                break;
            case EnemyStates.Attacking:
                anim.Play(attackingAnim);
                break;
            case EnemyStates.Dying:
                anim.Play(dyingAnim);
                break;
        }
    }
    private bool IsPlayerClose()
    {
        RaycastHit hit;
        isPlyrClose = Physics.Raycast(rayCastOrigin.position, transform.forward, out hit, rayMaxDistance, playerMask);
        //Debug.DrawRay(rayCastOrigin.position, transform.forward, Color.green);
       // if(hit.collider != null) Debug.Log(hit.collider.name);
        return isPlyrClose;
    }
}
