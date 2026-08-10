using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SugarManager : MonoBehaviour
{
    public static SugarManager instance;
    public GameObject sugarPrefab;
    public Vector2 offsetToSpawn = new Vector2(-5,5);
    public float timeToSpawnSugar = 5;
    public List<Transform> sugarPosition;  
    public List<AntController> antControllers;  

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(LoopCreateSugar());
        StartCoroutine(CheckForAntAvailable());
    }
    IEnumerator LoopCreateSugar()
    {
        yield return new WaitForSeconds(timeToSpawnSugar);
        GenerateSugar();
        yield break;
    }
    public void GenerateSugar()
    {
        Vector3 posToSpawn = new Vector3(Random.Range(offsetToSpawn.x, offsetToSpawn.y), 
        1, Random.Range(offsetToSpawn.x, offsetToSpawn.y));
        GameObject sugar = Instantiate(sugarPrefab, posToSpawn, Quaternion.identity);
        sugarPosition.Add(sugar.transform);
        StartCoroutine(LoopCreateSugar());
    }
    public Transform GetFirstSugar()
    {
        Transform tempSugar = sugarPosition[0];
        sugarPosition.RemoveAt(0);
        return tempSugar;
    }
    public Transform GetRandomSugar()
    {
        return sugarPosition[Random.Range(0, sugarPosition.Count)];
    }
    IEnumerator CheckForAntAvailable()
    {
        yield return new WaitForEndOfFrame();
        CheckAnts();
        yield break;
    }
    public void CheckAnts()
    {
        if(antControllers.Count >0)
        {
            foreach(AntController antController in antControllers)
            {
                if(antController.antCurrentState == AntController.AntStates.WAITING)
                {
                    if(sugarPosition.Count>0)
                    {
                        antController.target = GetFirstSugar();  
                        antController.antCurrentState = AntController.AntStates.TO_SUGAR;                      
                    }
                }
            }
        }
        StartCoroutine(CheckForAntAvailable());
        
    }


}
