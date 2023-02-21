using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private int setNumber, randomNumber;
    [Header("Buildings")]
    [SerializeField] private List<GameObject> buildingSets = new List<GameObject>();
    [SerializeField] GameObject[] buildings;
    [SerializeField] private int numberOfSets;
    [SerializeField] private float waitingTime;
    [SerializeField] private Transform buildingSpawnPosition;
    [Header("Dangers")]
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] GameObject[] dangers;
    [SerializeField] private int numberOfDangers;
    [SerializeField] private float waitingDangerTime;
    [SerializeField] private Transform dangerSpawnPos1, dangerSpawnPos2;

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
        AddObjectsToPool(buildingSets, buildings, numberOfSets);
        AddObjectsToPool(enemiesList, dangers, numberOfDangers);
    }
    private void Update()
    { 
        if (!GameManager.IsPaused) 
        {
            StartCoroutine(WaitForSpawnBuilding(waitingTime));
            StartCoroutine(WaitForSpawnDangers(waitingDangerTime));
        }
        if (GameManager.IsPaused)
        {
            StopAllCoroutines();
        }
    }
    private void AddObjectsToPool(List<GameObject> objList, GameObject[] objsToPool, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int random = Random.Range(0, objsToPool.Length);
            GameObject bSet = Instantiate(objsToPool[random]);
            bSet.SetActive(false);
            objList.Add(bSet);
            bSet.transform.parent = transform;
        }
    }    
    private IEnumerator WaitForSpawnBuilding(float time)
    {
        for (int i = 0; i < buildingSets.Count; i++)
        {
            if (!buildingSets[i].activeSelf)
            {
                buildingSets[i].transform.position = buildingSpawnPosition.position;
                yield return new WaitForSecondsRealtime(time);
                buildingSets[i].SetActive(true);
                yield return buildingSets[i];
            }
            if (buildingSets[i].activeSelf)
            {
                yield return null;
            }
        }

        /*AddObjectsToPool(buildingSets, buildings, 1);
        buildings[buildings.Length - 1].SetActive(true);
        yield return buildings[buildings.Length - 1];*/
    }
    private IEnumerator WaitForSpawnDangers(float time)
    {
        int randomPos;
        for (int i = 0; i < enemiesList.Count; i++)
        {
            
            if (!enemiesList[i].activeSelf)
            {
                randomPos = Random.Range(0, 2);
                //Debug.Log(randomPos);
                if (randomPos == 0)
                {
                    enemiesList[i].transform.position = dangerSpawnPos1.position;  
                    yield return new WaitForSecondsRealtime(time);
                    enemiesList[i].SetActive(true);
                    yield return enemiesList[i];
                }
                if (randomPos == 1)
                {
                    enemiesList[i].transform.position = dangerSpawnPos2.position;
                    yield return new WaitForSecondsRealtime(time);
                    enemiesList[i].SetActive(true);
                    yield return enemiesList[i];  
                }        
            }
            
            
        }
    }
}
