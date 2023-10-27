using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBallCharacterİsDead : MonoBehaviour
{
    private Rigidbody2D rigid;


    [SerializeField]
    private float jump;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * jump * Time.deltaTime);

        int y = Mathf.RoundToInt(transform.position.y);

        if (y > 8)
        {

            transform.position = new Vector3(transform.position.x, -5, transform.position.z);

        }
    }
}
