using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponLogic : MonoBehaviour
{


    public Transform spawnPoint;

    public GameObject bullet;


    public float shotforce  = 15f;
    public float shotRate = 0.5f;

    private float shootRateTime = 0f;

    private AudioSource audioSource;

    public AudioClip shotSound;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //fire1 click izquierdo
        //Input.GetKeyDown("Mouse0") 
        //click izquierdo
        if (Input.GetButtonDown("Fire1"))
        {
            //para la cadencia
            if (Time.time > shootRateTime && GameManager.Instance.gunammo > 0)
            {
                audioSource.PlayOneShot(shotSound);

                GameManager.Instance.gunammo--;

                GameObject newBullet;

                //instanciamos una bala 
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotforce);

                shootRateTime = Time.time + shotRate;



                //la bala se destruye despues de 1 segundos
                Destroy(newBullet, 1);

            }
            

        }


    }
}
