using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinetManager : MonoBehaviour
{
    [SerializeField] private Transform[] boxPlace = new Transform[8];
    [SerializeField] private GameObject box;
    [SerializeField] private float BoxDeliveryTime, YAxis;

    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i< boxPlace.Length; i++)
        {
            boxPlace[i] = transform.GetChild(0).GetChild(i);
        }
        StartCoroutine(BoxDelivery(BoxDeliveryTime));
    }

    public IEnumerator BoxDelivery( float Time)
    {
        var BoxCount = 0;
        var BoxPlaceIndex = 0;
        while (BoxCount < 8)
        {
            GameObject newBox = Instantiate(box, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity, transform.GetChild(1));
            newBox.transform.DOJump(new Vector3(boxPlace[BoxPlaceIndex].position.x, boxPlace[BoxPlaceIndex].position.y + YAxis,
                boxPlace[BoxPlaceIndex].position.z), 2f, 1, 0.5f).SetEase(Ease.OutQuad);
            if (BoxPlaceIndex < 3)
                BoxPlaceIndex++;
            else
            {
                BoxPlaceIndex = 0;
                YAxis += 0.45f;

            }
            BoxCount++;
            yield return new WaitForSecondsRealtime(Time);
        }
    }
}
