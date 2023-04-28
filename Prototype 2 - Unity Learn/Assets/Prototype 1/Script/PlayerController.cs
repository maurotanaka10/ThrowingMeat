using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Components
    //private Rigidbody rigidBody;
    private PlayerInputSystem playerInputSystem;

    [Header("Movement Player")]
    [Tooltip("Velocity of the player to move into X Axis")]
    [SerializeField]  private float velocityX;
    [SerializeField]  private float xAxisLimit; 
    private Vector2 characterMovement;

    [Header("Food Variable")]
    public GameObject projectilePrefab;
    private bool isThrowingFood;
    private bool canInstantiateFood = true;
    [SerializeField] private float delayThrowFood;

    private void Awake()
    {
        //rigidBody = GetComponent<Rigidbody>();
        playerInputSystem = new PlayerInputSystem();

        playerInputSystem.Player.Movement.started += OnMovementPlayerInput;
        playerInputSystem.Player.Movement.canceled += OnMovementPlayerInput;
        playerInputSystem.Player.Movement.performed += OnMovementPlayerInput;

        playerInputSystem.Player.Fire.started += OnThrowFoodInput;
        playerInputSystem.Player.Fire.canceled += OnThrowFoodInput;
    }

    void Update()
    {
        SetMovement();
        SetThrowFood();
    }

    void SetMovement()
    {
        if(transform.position.x > xAxisLimit)
        {
            transform.position = new Vector3(xAxisLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xAxisLimit)
        {
            transform.position = new Vector3(-xAxisLimit, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.right * characterMovement.x * velocityX * Time.deltaTime);
    }

    void SetThrowFood()
    {
        if (isThrowingFood && canInstantiateFood)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            canInstantiateFood = false;
            StartCoroutine(EnableToThrowFoodAfterDelay());
        }
    }

    void OnMovementPlayerInput(InputAction.CallbackContext context)
    {
        characterMovement = context.ReadValue<Vector2>();
    }

    void OnThrowFoodInput(InputAction.CallbackContext context)
    {
        isThrowingFood = context.ReadValueAsButton();
    }

    IEnumerator EnableToThrowFoodAfterDelay()
    {
        yield return new WaitForSeconds(delayThrowFood);
        canInstantiateFood = true;
    }

    private void OnEnable()
    {
        playerInputSystem.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputSystem.Player.Disable();
    }
}
