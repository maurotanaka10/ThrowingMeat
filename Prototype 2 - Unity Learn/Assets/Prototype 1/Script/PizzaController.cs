using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    [Tooltip("Velocity of pizza")]
    [SerializeField] private float speedPizza;
    [SerializeField] private float limitZAxis;

    private void Awake()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speedPizza * Time.deltaTime);

        if(transform.position.z > limitZAxis)
        {
            Destroy(gameObject);
        }
    }
}
