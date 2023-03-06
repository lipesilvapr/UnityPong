using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    public Vector3 minhaPosicao;
    private float meuY;
    public float velocidade = 7f;
    public float limiteCima = 3.5f;
    public bool player1;
    public bool automatico= false;
    public Transform transformBola;

    // Start is called before the first frame update
    void Start()
    {
        
    minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Transformando a posição do eixo y
        minhaPosicao.y = meuY;
        transform.position = minhaPosicao;

        //Criando a velocidade estável com o delta time
        float deltaVelocidade = velocidade * Time.deltaTime;

        if (!automatico)
        {

            //Criando movimentação da raquete
            if (player1)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    meuY = meuY + deltaVelocidade;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    meuY = meuY - deltaVelocidade;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    meuY = meuY + deltaVelocidade;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    meuY = meuY - deltaVelocidade;
                }
                if (Input.GetKey(KeyCode.Return))
                {
                    automatico = true;
                }
            }
           
           
        }
        else
        {
            //Alternando de bot para player 2
            if(Input.GetKey(KeyCode.UpArrow) ||  Input.GetKey(KeyCode.DownArrow))
            {
                automatico = false;
            }
           

            //Criando uma IA para o player 2
            meuY = Mathf.Lerp(meuY, transformBola.position.y, 0.05f);
        }
       
         //Impedindo que as raquetes saiam dos limites da tela
        if (meuY < -limiteCima)
        {
            meuY = -limiteCima;
        }
        if (meuY > limiteCima)
        {
            meuY = limiteCima;
        }


    }
}
