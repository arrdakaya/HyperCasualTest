using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void onBoxCollectArea();
    public static event onBoxCollectArea onBoxCollect;
    bool isCollected;
    
    void Start()
    {
        StartCoroutine("CollectBoxNumerator");
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BoxCollectArea"))
        {
            isCollected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BoxCollectArea"))
        {
            isCollected = false;
        }
    }

    IEnumerator CollectBoxNumerator()
    {
        while (true)
        {
            if (isCollected == true)
            {
                onBoxCollect();
            }
            yield return new WaitForSeconds(1);

        }
    }
}
