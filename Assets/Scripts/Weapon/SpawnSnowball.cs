using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowball : MonoBehaviour
{
    public Transform bolaSpawnPoint;
    public GameObject snowballPrefab;
    public float bolaSpeed = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var bullet = Instantiate(snowballPrefab, bolaSpawnPoint.position, bolaSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = bolaSpawnPoint.forward * bolaSpeed;
        }
    }
}
