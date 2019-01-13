﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public int initialNumOfObjects = 10;
    public GameObject objectToSpawn;
    public Transform objectParent;

    private List<GameObject> objectList;

    // Start is called before the first frame update
    void Start()
    {
        objectList = new List<GameObject>();

        for(int i = 0; i < initialNumOfObjects; i++)
        {
            CreateObject();
        }
    }

    private GameObject CreateObject()
    {
        GameObject newObject = Instantiate(objectToSpawn, objectParent);
        newObject.SetActive(false);
        objectList.Add(newObject);

        return newObject;
    }

    public GameObject GetObject()
    {
        for(int i = 0; i < objectList.Count; i++)
        {
            if(objectList[i].activeSelf == false)
            {
                return objectList[i];
            }
        }

        return CreateObject();
    }



}