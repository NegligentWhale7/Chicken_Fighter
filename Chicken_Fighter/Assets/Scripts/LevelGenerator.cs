using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int setNumber, randomNumber;
    [Header("Buildings")]
    [SerializeField] private List<GameObject> buildingSets = new List<GameObject>();
    [SerializeField] GameObject[] buildings;
    [SerializeField] private int numberOfSets, waitingTime;
    [SerializeField] private Transform buildingSpawnPosition;
    private static LevelGenerator instance;
    public static LevelGenerator Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        AddScenariesToPool(numberOfSets);
    }
    private void Update()
    { 
        if (!GameManager.IsPaused) StartCoroutine(WaitForIt(waitingTime));
    }
    private void AddScenariesToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int random = Random.Range(0, buildings.Length);
            GameObject bSet = Instantiate(buildings[random]);
            bSet.SetActive(false);
            buildingSets.Add(bSet);
            bSet.transform.parent = transform;
        }
    }    
    private IEnumerator WaitForIt(float time)
    {
        for (int i = 0; i < buildingSets.Count; i++)
        {
            if (!buildingSets[i].activeSelf)
            {
                yield return new WaitForSecondsRealtime(time);
                buildingSets[i].transform.position = buildingSpawnPosition.position;
                buildingSets[i].SetActive(true);
                yield return buildingSets[i];
            }
        }
    }
}
