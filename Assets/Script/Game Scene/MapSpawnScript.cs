using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject[] maplist;
    [SerializeField] GameObject mapParents;
    Database theDB;
    [SerializeField] int randomNum;

    private void Start()
    {
        theDB = FindObjectOfType<Database>();
    }

    private void Update()
    {
        MapSpawnner();
    }
    //A : 0-15 B:16-31 C:32-47 D:48-63 E:64-79 F:80-95 G:96-111 H:112-127
    //AB    //BC    //CD    //DEF   //EFG   //FGH   //EFGH
    //0-31  //16-47 //32-63 //48-95 //64-111//80-127//64-127
    public void MapSpawnner()
    {
        if (theDB.mapInstantiateFlag)
        {
            switch(theDB.level)
            {
                case 1:
                    randomNum = Random.Range(0,31);
                    break;

                case 2:
                    randomNum = Random.Range(16,47);
                    break;

                case 3:
                    randomNum = Random.Range(32,63);
                    break;

                case 4:
                    randomNum = Random.Range(48,95);
                    break;

                case 5:
                    randomNum = Random.Range(64,111);
                    break;

                case 6:
                    randomNum = Random.Range(80,127);
                    break;

                case 7:
                    randomNum = Random.Range(64,127);
                    break;
            }
            print("Map RandomNum is "+randomNum);

            Instantiate(maplist[randomNum].gameObject, this.transform.position, Quaternion.identity, mapParents.transform);
            theDB.mapInstantiateFlag = false;
            theDB.wormholeCount += 1;
        }
    }
}
