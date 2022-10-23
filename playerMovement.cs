using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//COLOCAR ESSE SCRIPT NO GAMEOBJECT DO PLAYER
public class playerMovement : MonoBehaviour
{
    [SerializeField]float speed;
    float horizontal;
    bool facingRight = true; 
    Rigidbody2D rb;   

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {  
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal *speed,rb.velocity.y);
    }
    void Flip(){
        if(facingRight && horizontal<0f || !facingRight && horizontal>0f){
            facingRight = !facingRight;
            transform.Rotate(0f,180f,0f);
        }
    }
    
}

