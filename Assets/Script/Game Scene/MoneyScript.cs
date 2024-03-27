using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    
    [SerializeField] GameObject smallMoney;
    [SerializeField] GameObject bigMoney;
    SpriteRenderer theSprite;

    // Start is called before the first frame update
    void Start()
    {
        instanciateMoney();
        theSprite = this.GetComponent<SpriteRenderer>();
        theSprite.color = new Color(0f, 0f, 0f, 0f);
    }

    void instanciateMoney()
    {
        int num = Random.Range(1, 100);
        if(num < 80)
        {
            Instantiate(smallMoney.gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
            print("init small money" + num);
        }
        if(num >= 80)
        {
            Instantiate(bigMoney.gameObject, gameObject.transform.position, Quaternion.identity, this.transform);
            print("init big money" + num);
        }
    }
}
