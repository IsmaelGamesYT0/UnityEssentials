using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour

{
    public Transform player; // Referência ao Transform do Jogador
    public Vector2 rotation; // Variável para armazenar a rotação da câmera
    public bool cameraEnabled = true; // Variável para habilitar/desabilitar a câmera
    public float sensibilidade = 5f; // Sensibilidade do mouse
    public float distance = 4f; // Distância da câmera ao jogador
    public float height = 2f; // Altura da câmera em relação ao jogador

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            cameraEnabled = !cameraEnabled; // Alterna o estado da câmera
            if (cameraEnabled)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        if (cameraEnabled)
        {

            float mouseX = Input.GetAxis("Mouse X") * sensibilidade;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilidade;

            rotation.x += mouseX;
            rotation.y -= mouseY;

            rotation.y = Mathf.Clamp(rotation.y, -45f, 45f); // Limita a rotação vertical da câmera


            transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
            transform.position = player.position - transform.forward * distance + Vector3.up * height;

        }
    }
}
