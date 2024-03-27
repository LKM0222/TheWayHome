using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacScript : MonoBehaviour
{
    public int num;
    float zodiacYSpeed = 3f;
    float zodiacXSpeed = 3f;

    [SerializeField] float max_Y = 1f;
    [SerializeField] float min_Y = -6f;
    [SerializeField] float i;

    [SerializeField] bool upDown;
    [SerializeField] int rnum;

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ZodiacMoving());

        rnum = Random.Range(0, 1);

        if(rnum == 1)
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * zodiacYSpeed);
        if(rnum == 0)
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * zodiacYSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * zodiacXSpeed);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y < 0f)
        {
            pos.y = 0f;
            upDown = false;
        }
        if (pos.y > 0.7f)
        {
            pos.y = 0.7f;
            upDown = true;
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if(upDown)
            transform.Translate(new Vector3(0, -1f, 0) * Time.deltaTime * zodiacXSpeed);
        else
            transform.Translate(new Vector3(0, 1f, 0) * Time.deltaTime * zodiacXSpeed);




    }
    
    

    IEnumerator ZodiacMoving()
    {
        for (int a = 0; ; a++)
        {
            if (a % 2 == 0)//up
            {
                for (i = this.transform.localPosition.y; i < max_Y; i += 0.01f)
                {
                    //transform.position= new Vector3(this.transform.position.x , i * zodiacYSpeed, transform.position.z);
                    transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * zodiacYSpeed);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            if (a % 2 == 1)//down
            {
                for (i = this.transform.localPosition.y; i > min_Y; i -= 0.01f)
                {
                    //transform.position = new Vector3(this.transform.position.x , i * zodiacYSpeed, transform.position.z);
                    transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime  * zodiacYSpeed);
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
    }

}
