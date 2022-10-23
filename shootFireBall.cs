using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//COLOCAR ESSE SCRIPT EM QUEM FOR ATIRAR UM PROJETIL
public class shootFireBall : MonoBehaviour
{
    public projectileBehaviour fireBall;
    public Transform LaunchOffset;
    Transform source;
    private void Start() {
        //Pega a posiçao do dono da fonte que o projetil saiu
        source = GetComponentInParent<Transform>();
        StartCoroutine(shootInTime(3));//Executa a thread do Inimigo
    }
    void Update()
    {
        //Verifica se o Player apertou o botao direito do mouse, ai ele atira um Projetil
        if(Input.GetMouseButtonDown(1) && this.CompareTag("Player")){
            Shoot();
        }        
    }
    //Função que executa o tiro
    public void Shoot(){
        fireBall.source = source;
        Instantiate(fireBall,LaunchOffset.position,transform.rotation); 
    }
    //Thread que faz o inimigo menor atirar a cada x segundos
    IEnumerator shootInTime(float time){
        if(this.CompareTag("Enemy")){
            yield return new WaitForSeconds(time);
            Shoot();
            StartCoroutine(shootInTime(time));
        }        
    }
}
