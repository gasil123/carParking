using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Carousel : MonoBehaviour
{
    List<Transform> CarList = new List<Transform>();

    ArrayList list;
    int NumberOfCars;
    // Start is called before the first frame update
    void Start()
    {
        NumberOfCars = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < NumberOfCars; i++)
        {
            CarList.Add(transform.GetChild(i));
        }
    }
}
