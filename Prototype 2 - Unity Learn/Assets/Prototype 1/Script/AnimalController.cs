using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float animalVelocity;
    [SerializeField] private float limitXAxis;

    private void Awake()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * animalVelocity * Time.deltaTime);
        if(transform.position.z < limitXAxis)
        {
            Destroy(gameObject);
        }
    }
}
