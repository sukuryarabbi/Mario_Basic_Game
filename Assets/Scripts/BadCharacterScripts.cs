using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCharacterScripts : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jump;

    private Animator anim;

    private bool BadBallCharacterDead = false;

    private PlayerScript player;




    public float BadBallCharacterHealth = 1;
    void Start()
    {

        BadBallCharacterDead = false;

        rigid = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        int x = Mathf.RoundToInt(transform.position.x);

        int y = Mathf.RoundToInt(transform.position.y);

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        transform.Translate(Vector3.up * jump * Time.deltaTime);


        if (x <= -3)
        {

            transform.localPosition = new Vector3(1, transform.localPosition.y, transform.localPosition.z);
        }

        

        if (y > 6)
        {

            transform.localPosition = new Vector3(transform.localPosition.x, -3, transform.localPosition.z);

        }

        if(BadBallCharacterHealth == 0)
        {

            BadBallCharacterDead = true;


            anim.SetBool("Dead", true);

        }



          void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("BadBallCharacterDead"))
            {
                BadBallCharacterHealth -= 1;

               player.Health += 1;

            }
        }

}

    




}
