using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float speed = 15f;

    public float gravity = -3f;

    //gravedad velocidad
    Vector3 velocity;




    //comprobacion de suelo
    public Transform groundCheck;

    public float sphereRadius = 0.3f;

    //etiqueta para el suelo, para que el player sepa si esta en el suelo o no
    public LayerMask groundMask;

    bool isGrounded;



    //salto
    public float jumpheigth = 3f;



    void Update()
    {
        //esto es para saber si el player esta en el suelo o no mediante una funcion de unity
        //CheckSphere crea una esfera en el punto que le digamos, en este caso groundCheck.position
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            //si el player esta en el suelo, la velocidad en y se pone a 0
            velocity.y = -2f;
        }



        //esto es para el movimiento del player asignacion de teclas de movimiento
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

    
        //esto es para mover al jugador adelante o hacia atras 
        Vector3 move = transform.right * x + transform.forward * z;


        //salto
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //sqrt raiz cuadrada
            velocity.y = Mathf.Sqrt(jumpheigth * -2f * gravity);
        }



        //esto le asigna el movimiento al caracter controler del player 
        //y le asigna la velocidad que se le dio en el inspector
        characterController.Move(move * speed * Time.deltaTime);

        // si alguien juega a 30 y alguien a 60 fps, el que juega a 30 fps se movera mas lento
        //por eso se multiplica por Time.deltaTime






        //para activarle la gravedad 
        velocity.y += gravity * Time.deltaTime;
        //esto le asigna la gravedad al player
        characterController.Move(velocity * Time.deltaTime);




    }
}
