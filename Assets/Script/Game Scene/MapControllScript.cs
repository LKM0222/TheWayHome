using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControllScript : MonoBehaviour
{
    [SerializeField] GameObject wormhole;
    Database theDB;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
        if (theDB.wormholeCount % 4 == 0)
        {
            wormhole.SetActive(true);
            theDB.wormholeCount = 0;
        }
        else
            wormhole.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
