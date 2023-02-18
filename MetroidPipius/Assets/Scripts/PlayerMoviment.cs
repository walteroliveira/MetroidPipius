using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float MovimentSpeed;                 // Velocidade de movimento do player
     Vector3 Moviment = new Vector3();           // Detectar movimento pelo teclado
    Rigidbody2D Rb2D;                           // Armazena o Rigidbody do player

    void Start()
    {
        // Carrega o Rigidbody e o Animator do player e seta attacking para falso
        Rb2D = GetComponent<Rigidbody2D>();
    }

    /* Pega os inputs dos botões de entrada e normaliza
     * Caso o botão de ataque (F) seja acionado, seta attacking para true
     * Atualiza a o estado do player
     */
    void Update()
    {
        Moviment = Vector3.zero;
        Moviment.x = Input.GetAxisRaw("Horizontal");
        Moviment.y = Input.GetAxisRaw("Vertical");
        Moviment.Normalize();
        UpdateState();
    }
    // Muda a velocidade do rb2d do player pela moviment speed 
    private void MoveCharacter()
    {
        Rb2D.velocity = Moviment * MovimentSpeed;
    }
    // Muda a animação de direção e ataque
    private void UpdateState()
    {
        
        if (Moviment != Vector3.zero)
        {
            MoveCharacter();                        // Move o personagem
        }
        else
        {
            Rb2D.velocity = Vector3.zero;           // Zera a velocidade do player, já que ele está parado
        }

    }
}