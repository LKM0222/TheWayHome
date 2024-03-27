using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    Database theDB;
    [SerializeField] GameObject[] itemList;
    [SerializeField] int rNum;
    SpriteRenderer theSprite;
    private void Start()
    {
        theDB = FindObjectOfType<Database>();
        theSprite = GetComponent<SpriteRenderer>();
        instanciateItem();
        theSprite.color = new Color(1f, 1f, 1f, 0f);
    }

    void instanciateItem()
    {
        rNum = Random.Range(0, itemList.Length);
        switch(rNum % itemList.Length)
        {
            case 0:
                Instantiate(itemList[0].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 1:
                Instantiate(itemList[1].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 2:
                Instantiate(itemList[2].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 3:
                Instantiate(itemList[3].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 4:
                Instantiate(itemList[4].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 5:
                Instantiate(itemList[5].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 6:
                Instantiate(itemList[6].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 7:
                Instantiate(itemList[7].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 8:
                Instantiate(itemList[8].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 9:
                Instantiate(itemList[9].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 10:
                Instantiate(itemList[10].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 11:
                Instantiate(itemList[11].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 12:
                Instantiate(itemList[12].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 13:
                Instantiate(itemList[13].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 14:
                Instantiate(itemList[14].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            case 15:
                Instantiate(itemList[15].gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
                break;

            default:
                print("length err");
                break;
        }
    }


}
