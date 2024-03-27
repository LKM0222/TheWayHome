using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishPlanet : MonoBehaviour
{
    SpriteRenderer theSprite;
    //float hideTime = 1f;
    //float displayTime = 3f;
    //float waitTime = 1f;

    //bool hideFlag = false;
    //bool displayFlag = false;
    //bool waitFlag = false;

    //float time;


    // 숨기는중엔 콜라이더 istrigger체크
    // 숨겼다가 나왔다가 간격 1초 밝은상태는 3초 어두운상태 1초 (총 6초)

    // Start is called before the first frame update
    void Start()
    {
        theSprite = GetComponent<SpriteRenderer>();

        StartCoroutine(Vanish());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Vanish()
    {
        Color sprColor = this.GetComponent<SpriteRenderer>().color;

        for (int i = 0; ; i++)
        {
            if (i % 2 == 0) //hide 
            {
                this.GetComponent<CircleCollider2D>().isTrigger = true;
                for (float ff = 1f; ff > 0f;)
                {
                    ff -= 0.01f;
                    sprColor.a = ff;
                    theSprite.color = sprColor;

                    this.GetComponent<SpriteRenderer>().color = sprColor;
                    yield return new WaitForSeconds(0.01f);
                }
            }

            if (i % 2 == 1) //display
            {
                for (float ff = 0f; ff < 1f;)
                {
                    ff += 0.01f;
                    sprColor.a = ff;
                    theSprite.color = sprColor;

                    this.GetComponent<SpriteRenderer>().color = sprColor;
                    yield return new WaitForSeconds(0.01f);
                }
            }



            if (i % 2 == 0) //hide wait
            {
                yield return new WaitForSeconds(1f);
            }
            if (i % 2 == 1) //display wait
            {
                this.GetComponent<CircleCollider2D>().isTrigger = false;
                yield return new WaitForSeconds(3f);
            }
        }
    }

}
