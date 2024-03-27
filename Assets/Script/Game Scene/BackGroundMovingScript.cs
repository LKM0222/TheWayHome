using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovingScript : MonoBehaviour
{
    SpriteRenderer spr;
    [SerializeField] float speed;
    [SerializeField] Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);

        var height = 2 * Camera.main.orthographicSize;
        var weigh = height * Camera.main.aspect; //스크린의 가로 크기를 구함.
        Vector3 pos = transform.localPosition;
        if (pos.x + spr.bounds.size.x / 2 < -10.8)// spr.bounds.size.x / 2를 수정함
        {
            float size = spr.bounds.size.x * 2;//이미지 갯수만큼 곱해
            pos.x += size;
            transform.localPosition = pos;
        }

    }
}
