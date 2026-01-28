using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteractions : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            //accedemos al gamemanager , le añadimos la municion de la caja , del script ammobox
            GameManager.Instance.gunammo += other.gameObject.GetComponent<AmmoBox>().ammo;
            
            Destroy(other.gameObject);
        }
    }
}
