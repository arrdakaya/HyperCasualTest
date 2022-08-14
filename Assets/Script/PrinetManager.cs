using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinetManager : MonoBehaviour
{
    public List<GameObject> boxList = new List<GameObject>();
    public GameObject boxPrefab;
    public Transform exitPoint;
    bool isWorking;
    int stackCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateBox());

    }
    public void RemoveLastElement()
    {
        if(boxList.Count > 0)
        {
            Destroy(boxList[boxList.Count - 1]);
            boxList.RemoveAt(boxList.Count - 1);
        }
    }
   
    IEnumerator CreateBox()
    {
      while (true)
      {
            int rowCount = (int)(boxList.Count) / stackCount;
            if(isWorking == true)
            {
                GameObject temp = Instantiate(boxPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x +((float)rowCount), exitPoint.position.y + (float)(boxList.Count % stackCount)/2, exitPoint.position.z);
                boxList.Add(temp);
                if(boxList.Count >= 15)
                {
                    isWorking = false;
                }
  
            }
            else if(boxList.Count <15)
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1);

      }
    }
}
