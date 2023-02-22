using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Deactivator : MonoBehaviour
{
    [SerializeField] UnityEvent buildingDisabled;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        if (other.CompareTag("Building"))
        {
            LevelGenerator.Instance.WaitForSpawnBuilding();
        }
    }
}
