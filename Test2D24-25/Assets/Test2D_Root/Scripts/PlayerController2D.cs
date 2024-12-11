using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//Librería necesaria para leer el New Input System

public class PlayerController2D : MonoBehaviour
{
    //REferencias privadas generales
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] PlayerInput playerInput;
    Vector2 moveInput; //Variable para referenciar el input de los controladores
    
    [Header("Movement Parameters")]
    public float speed;

    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField]private bool isGrounded;
    
   
    // Start is called before the first frame update
    void Start()
    {
        //Para autoreferenciar: nombre de variable = GetComponent<tipo de vraiable>();
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        playerRb.velocity = new Vector3(moveInput.x * speed, playerRb.velocity.y, 0);
    }

    #region Input Methods
    //Métodos que permiten leer el Input del New Input System
    //Crearemos un método por cada acción

    public void HandleMovement(InputAction.CallbackContext context)
    {
        //Las acciones de tipo VALUE deben almacenarse = ReadValue
        moveInput=context.ReadValue<Vector2>();
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    
    


    #endregion



}
