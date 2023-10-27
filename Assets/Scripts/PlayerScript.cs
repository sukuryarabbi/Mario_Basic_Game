using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField]
    private float speed;

    private float Horizontal;

    [SerializeField]
    private float JumpForce;

    private bool FacingRight;

    private Animator anim;

    [SerializeField]
    private bool isJump;

    public int Gold = 0;

    public Text GoldAmount;

    public Text HeartAmount;

    public float Health = 5 ;


    [SerializeField]
    private float BadBallCharacterHealth = 1;

    [SerializeField]
    private bool Dead = false ;
    
    void Start()
    {

        Dead = false;
        FacingRight = true;
       
        rigid = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

       

    }

    private void Update()
    {

        //oyunu yeniden baþlatmaya yarayan kod
        //if(Input.GetKeyDown(KeyCode.R))
        //{
            //Application.LoadLevel(Application.loadedLevel);
        //}
    
        if(Health == 0)
        {

            Dead = true;
            anim.SetBool("Dead", true);
        }

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isJump == false)
            {
                rigid.AddForce(new Vector2(rigid.velocity.x, JumpForce));

                isJump = true;
            }

            

            anim.SetBool("jump", true);
        }

        GoldAmount.text = "" + Gold;

        HeartAmount.text = "X" + Health;

        
    }
    void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");

        moved(Horizontal);

        flip(Horizontal);

        
        if(Mathf.Approximately(rigid.velocity.y , -1) && anim.GetBool("jump"))
        {
            anim.SetBool("jump", false);
        }
    }

    void moved (float Horizontal)
    {
        rigid.velocity = new Vector2(speed * Horizontal, rigid.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(Horizontal));
    }

    void flip(float Horizontal)
    {
        if ((Horizontal > 0 && !FacingRight) || (Horizontal < 0 && FacingRight))
        {

            FacingRight = !FacingRight;

            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    //Nesneler çarpýþtýðý zaman bu fonksiyonu kullanmalýyýz
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) ;
        

            isJump = false;

            anim.SetBool("jump", false);
           

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Health = Health - 1;

        }

        

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Gold"))
        {

            Destroy(collision.gameObject);

            Gold = Gold + 1;

        }

      
    }


}
