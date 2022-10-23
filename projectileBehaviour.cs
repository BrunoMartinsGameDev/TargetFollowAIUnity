using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//COLOCAR ESSE SCRIPT NO PREFAB DO PROJETIL
public class projectileBehaviour : MonoBehaviour
{
    public float speed = 4.5f;
    public Transform source;//Posição do Objeto que atirou este projetil

    void Update()
    {
        transform.position += transform.right *Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
