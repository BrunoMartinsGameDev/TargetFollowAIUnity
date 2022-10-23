using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//COLOCAR ESSE SCRIPT NO GAMEOBJECT DO INIMIGO
public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    bool facingRight = false; 

    projectileBehaviour projectile;
    Vector2 direction;
    
    void Update()
    {
        direction = target.position - transform.position;//Pega a direção que o Inimigo está virado
        Flip();        
        transform.position = Vector2.MoveTowards(this.transform.position, target.position,speed* Time.deltaTime);//Pega a posição do Alvo
    }

    //SCRIPT DA IA
    //Altera o Alvo de Ataque do Inimigo, com base na colisão com o projetil, pegando a partir do objeto do projetil
    //O dono da fonte que o projetil saiu
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("projectile")){
            projectile = other.gameObject.GetComponent<projectileBehaviour>();
            target = projectile.source;
        }
    }
    //Vira o Inimigo para a posição correta a qual ele está caminhando.
    void Flip(){
        if(facingRight && direction.x<0f || !facingRight && direction.x>0f){
            facingRight = !facingRight;
            transform.Rotate(0f,180f,0f);
        }
    }
}
