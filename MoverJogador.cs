using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJogador : MonoBehaviour
{
    public float Speed = 10f; // velocidade de movimento do jogador
    public float JumpForce = 10f; // Força do Pulo do Jogador
    public bool inFloor = true; // Verifica se o jogador está no chão  
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Variável para armazenar a direção do movimento no eixo X
        float direcaoX = Input.GetAxis("Horizontal");
        float direcaoY = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(direcaoX, 0f, direcaoY).normalized;
        //Normaliza a direção para evitar velocidade maior em diagonal
        transform.Translate(direcao * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && inFloor)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            inFloor = false; // O jogador não está mais no chão após pular
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            inFloor = true; // O jogador está no chão
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            inFloor = false; // O jogador saiu do chão
        }
    }
}
