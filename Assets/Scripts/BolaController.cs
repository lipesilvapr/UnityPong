using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;
    public float velocidade = 7f;
    public float meuLimiteX = 10.5f;
    public AudioClip boing;
    public Transform transformCamera;
    public float delay = 1.75f;
    public bool jogoIniciado = false;
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        //Iiniciando a bola com delay
        delay = delay - Time.deltaTime;
        if (delay <= 0 && jogoIniciado == false)
        {
            Debug.Log("Cheguei a zero");

            jogoIniciado = true;

            //Gerando aleatoriedade para a direção da bola
            int direcao = Random.Range(0, 4);
            Debug.Log(direcao);
            if (direcao == 0)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 1)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 2)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = -velocidade;
            }
            else
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = -velocidade;
            }
            meuRB.velocity = minhaVelocidade;
        } 

        //Checando se a bola saiu
        if (transform.position.x > meuLimiteX || transform.position.x < -meuLimiteX)
        {
            SceneManager.LoadScene(0);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Som de colisão
      
        AudioSource.PlayClipAtPoint(boing, transformCamera.position);
    }
}
