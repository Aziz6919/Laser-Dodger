using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] Transform[] lasersPositions;
    float lasermovespeed = 5f;
    void Start()
    {
        for(int i=0; i<lasers.Length; i++)
        {
            lasers[i].SetActive(false);
            
        }
        InvokeRepeating("activatelasers",1f,0.5f);
        
    }

    void Update()
    {
        Stoplasers();
    }

    void activatelasers()
    {
        int Randomnumber = Random.Range(0, lasers.Length);
        if (!lasers[Randomnumber].activeInHierarchy)
        {
            lasers[Randomnumber].SetActive(true);
           // lasers[Randomnumber].transform.position = lasersPositions[Randomnumber].position;
           
        }
        

    }

    void Stoplasers()
    {
        if (GameManager.Instance.gameover)
        {
            CancelInvoke("activatelasers");
        }
    }
    
}
