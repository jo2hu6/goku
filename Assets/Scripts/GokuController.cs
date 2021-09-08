using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator _animator;
    private Rigidbody2D rb2d;
    private BoxCollider2D col;

    private bool puedeSaltar = true;
    private int contador = 0;
    private float upSpeed = 20;


    private bool puedeVolar = false;

    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //CORRER A LA DERECHA
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX= false;
            setRunAnimation();
            rb2d.velocity = new Vector2(7,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.S))
            {
                sr.flipX= false;
                setRunFastAnimation();
                rb2d.velocity = new Vector2(12,rb2d.velocity.y);
            }
        }else //DETENERSE
        {
            setIdleAnimation();
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
        }

        //CORRER A LA IZQUIERDA
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            setRunAnimation();
            rb2d.velocity = new Vector2(-7,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.S))
            {
                sr.flipX = true;
            setRunFastAnimation();
            rb2d.velocity = new Vector2(-12,rb2d.velocity.y);
            }
        }


        //SALTAR
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            setJumpAnimation();
            rb2d.velocity = Vector2.up * upSpeed;
            puedeSaltar = false;
        }


        //VOLAR
        if(puedeVolar)
        {
            setFlyAnimation();
            rb2d.gravityScale = 0;
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x,7);
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x,-7);
            }
        }


        if(Input.GetKeyDown(KeyCode.X) && puedeVolar)
        {
            setJumpAnimation();
            rb2d.gravityScale = 6;
            puedeVolar = false;
        }



    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 7)
        {
            puedeSaltar = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EndFloor")
        {
            puedeVolar = true;
        }
    }

    private void setIdleAnimation(){
       _animator.SetInteger("State",0);
    }
    
    private void setRunAnimation(){
        _animator.SetInteger("State",1);
    }

    private void setRunFastAnimation(){
        _animator.SetInteger("State",2);
    }
    
    private void setJumpAnimation(){
        _animator.SetInteger("State",3);
    }

    private void setFlyAnimation(){
        _animator.SetInteger("State",4);
    } 

}
