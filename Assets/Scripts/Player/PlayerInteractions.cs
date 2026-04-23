using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

//interface IInteractable
//{
//    public void Interact();
//}

public class PlayerInteractions : MonoBehaviour
{
    public Transform startPosition;
    private List<Collider> itemsInTrigger = new List<Collider>();

    //lo de la mascara que te dije
    LayerMask mask;
    public float distancia;

    //para el canvas
    
    public Texture2D puntero;
    //public GameObject TextDetect;
    GameObject ultimoReconocido = null;
    MeshRenderer ultimoPlaneRenderer = null;
    //public Transform InteractorSource;
    //public float interactRange;

    private void Start()
    {
        //definimos la mascara para que solo interactue con los objetos que queremos
        mask = LayerMask.GetMask("RaycastDetect");
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deselect();


            //tarea de color
            SelectedObject(hit.transform);
            //tarea de color


            if (hit.collider.tag == "GunAmmo")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.Instance.gunammo += hit.collider.gameObject.GetComponent<AmmoBox>().ammo;

                    Destroy(hit.collider.gameObject);
                    ////hit.collider.gameObject.GetComponent<AmmoBox>().Interact();
                    //for (int i = itemsInTrigger.Count - 1; i >= 0; i--)
                    //{
                    //    Collider other = itemsInTrigger[i];

                    //    if (other.gameObject.CompareTag("GunAmmo"))
                    //    {
                    //        //accedemos al gamemanager , le a�adimos la municion de la caja , del script ammobox
                    //        GameManager.Instance.gunammo += other.gameObject.GetComponent<AmmoBox>().ammo;

                    //        Destroy(other.gameObject);
                    //    }

                    //}
                }
            }
            if (hit.collider.tag == "HealthObject")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //accedemos al gamemanager , le a�adimos la municion de la caja , del script ammobox
                    GameManager.Instance.AddHealth(hit.collider.gameObject.GetComponent<HealthObject>().health);

                    Destroy(hit.collider.gameObject);

                }
            }



            //tarea de color


            //if (hit.collider.tag == "cambiar_color")
            //{
            //    if (Input.GetKeyDown(KeyCode.E))
            //    {

            //        //accedemos al gamemanager , le a�adimos la municion de la caja , del script ammobox
            //        cambiar_color script_color = hit.collider.gameObject.GetComponent<cambiar_color>();

            //        script_color.cambiar();

            //    }
            //}


            //tarea de color


            //esta linea es para ver el rayo en la escena
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);


        }
        else
        {
            Deselect();
        }
    }
    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.cyan;
        ultimoReconocido = transform.gameObject;
        
        // Buscar el Plane en la jerarquía (hijo del hijo)
        Transform pivot = transform.Find("Pivot");
        if (pivot != null)
        {
            Transform plane = pivot.Find("Plane");
            if (plane != null)
            {
                ultimoPlaneRenderer = plane.GetComponent<MeshRenderer>();
                if (ultimoPlaneRenderer != null)
                {
                    ultimoPlaneRenderer.enabled = true;
                }
            }
        }
    }

    void Deselect()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
        
        if (ultimoPlaneRenderer != null)
        {
            ultimoPlaneRenderer.enabled = false;
            ultimoPlaneRenderer = null;
        }
    }

    void OnGUI()
    {

        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);

        GUI.DrawTexture(rect, puntero);
    }

    private void OnTriggerEnter(Collider other)
    {


        //if (other.gameObject.CompareTag("HealthObject"))
        //{
        //    //accedemos al gamemanager , le a�adimos la municion de la caja , del script ammobox
        //    GameManager.Instance.AddHealth(other.gameObject.GetComponent<HealthObject>().health);

        //    Destroy(other.gameObject);
        //}

        if (other.gameObject.CompareTag("DeathFloor"))
        {
            //perder vida
            GameManager.Instance.LoseHealth(50);
            //respawnear a nuestro player

            GetComponent<CharacterController>().enabled = false; // Desactivar el CharacterController temporalmente
            gameObject.transform.position = startPosition.position;
            GetComponent<CharacterController>().enabled = true; // Desactivar el CharacterController temporalmente

        }

        //if (other.gameObject.CompareTag("GunAmmo"))
        //{
        //    //accedemos al gamemanager , le añadimos la municion de la caja , del script ammobox
        //    itemsInTrigger.Add(other);
        //}


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