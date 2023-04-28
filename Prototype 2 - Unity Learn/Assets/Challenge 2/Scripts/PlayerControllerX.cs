using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawn = true;
    public float delaySpawnDog;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpawn = false;
            StartCoroutine(EnableToSpawnDog());
        }
    }

    IEnumerator EnableToSpawnDog()
    {
        yield return new WaitForSeconds(delaySpawnDog);
        canSpawn = true;
    }
}
