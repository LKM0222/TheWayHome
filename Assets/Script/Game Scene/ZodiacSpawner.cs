using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] zodiac;
    float time;
    UIScript theUI;
    [SerializeField] float spawnerMovingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        theUI = FindObjectOfType<UIScript>();
        StartCoroutine(SpawnerMoving());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 5f)
        {
            int random = Random.Range(0, zodiac.Length);

            if (!theUI.zodiacFlag[random + 1])
            {
                Instantiate(zodiac[random].gameObject, this.transform.position, Quaternion.identity, this.transform.parent);
                time = 0f;
            }
            else return;
        }
    }

    IEnumerator SpawnerMoving()
    {
        float max_Y = 3f;
        float min_Y = -4.5f;
        float i;
        for(int a=0; ; a++)
        {
            if (a % 2 == 0)//up
            {
                for (i = min_Y; i < max_Y; i += 0.01f)
                {
                    transform.position = new Vector3(transform.position.x, i, transform.position.z);
                    
                    yield return new WaitForSeconds(0.01f);
                }
            }
            if(a % 2 == 1)
            {
                for (i = max_Y; i > min_Y; i -= 0.01f)
                {
                    transform.position = new Vector3(transform.position.x, i, transform.position.z);
                    
                    yield return new WaitForSeconds(0.01f);
                }
            }
            
        }
        
        
    }
}
