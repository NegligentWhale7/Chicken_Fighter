using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] string idleAnim, runAnim, walkAnim;
    public enum PlayerStates { Running, Walk, Paused }
    public static PlayerStates playerStates;

    //[SerializeField] GameManager gameManager;

    private void Start()
    {
        
    }
    private void Update()
    {
        States();
    }
    public void States()
    {
        switch (playerStates)
        {
            case PlayerStates.Paused:
                //playerAnimator.Play(idleAnim);
                if (!GameManager.IsPaused)
                {
                    //Debug.Log("Pausa");
                    playerStates= PlayerStates.Walk;
                }
                break;
            case PlayerStates.Walk:
                playerAnimator.Play(walkAnim);
               if (GameManager.IsPaused)
                {
                    //Debug.Log("Jugando");
                    playerStates = PlayerStates.Paused;
                }
                    break;
            default:
                playerStates = PlayerStates.Paused;
                break;
        }
    }
    
}
