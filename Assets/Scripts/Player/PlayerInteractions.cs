using UnityEngine;
using System.Collections;
using System.Collections.Generic;

interface IInteractable
{
    public void Interact();
}

public class PlayerInteractions : MonoBehaviour
{
    public Transform startPosition;
    private List<Collider> itemsInTrigger = new List<Collider>();

    //public Transform InteractorSource;
    //public float interactRange;
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.I))
        {
            for (int i = itemsInTrigger.Count - 1; i >= 0; i--)
            {
                Collider other = itemsInTrigger[i];

                if (other.gameObject.CompareTag("GunAmmo"))
                {
                    //accedemos al gamemanager , le añadimos la municion de la caja , del script ammobox
                    GameManager.Instance.gunammo += other.gameObject.GetComponent<AmmoBox>().ammo;

                    Destroy(other.gameObject);
                }

            }
        }

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        //    if (Physics.Raycast(r, out RaycastHit hitinfo, interactRange))
        //    {
        //        // Primero, intentar la interfaz genérica
        //        if (hitinfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
        //        {
        //            interactObj.Interact();
        //            return;
        //        }

        //        // Fallback específico para cajas de munición tipo cofre
        //        var go = hitinfo.collider.gameObject;
        //        if (go.CompareTag("GunAmmo"))
        //        {
        //            var box = go.GetComponent<AmmoBox>();
        //            if (box != null)
        //            {
        //                GameManager.Instance.gunammo += box.ammo;
        //                Destroy(go);
        //            }
        //        }
        //    }
        //}

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("HealthObject"))
        {
            //accedemos al gamemanager , le añadimos la municion de la caja , del script ammobox
            GameManager.Instance.AddHealth(other.gameObject.GetComponent<HealthObject>().health);

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("DeathFloor"))
        {
            //perder vida
            GameManager.Instance.LoseHealth(50);
            //respawnear a nuestro player

            GetComponent<CharacterController>().enabled = false; // Desactivar el CharacterController temporalmente
            gameObject.transform.position = startPosition.position;
            GetComponent<CharacterController>().enabled = true; // Desactivar el CharacterController temporalmente

        }

        if (other.gameObject.CompareTag("GunAmmo"))
        {
            //accedemos al gamemanager , le añadimos la municion de la caja , del script ammobox
            itemsInTrigger.Add(other);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            //perder vida
            GameManager.Instance.LoseHealth(5);
            
        }

    }


}
