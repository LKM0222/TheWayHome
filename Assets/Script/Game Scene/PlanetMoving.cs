using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoving : MonoBehaviour
{
    Database theDB;

    [SerializeField] float planetMovingSpeed;
    Rigidbody2D theRigid;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
        planetMovingSpeed = theDB.mapMovingSpeed * 1.5f;
        //theRigid = GetComponent<Rigidbody2D>();
        //theRigid.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * planetMovingSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("planet collider hit");
            planetMovingSpeed = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            print("planet tirrger hit");
            planetMovingSpeed = 0f;
        }
    }


}
