using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    
    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab;
    public Transform collectPoint;
    int boxLimit = 3;

    private void OnEnable()
    {
        TriggerManager.onBoxCollect += TakeBox;
    }
    private void OnDisable()
    {
        TriggerManager.onBoxCollect -= TakeBox;
    }

    void TakeBox()
    {
       
    }

    

    
}
