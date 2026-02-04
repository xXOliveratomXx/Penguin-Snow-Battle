//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////interface IInteractable
////{
////    public void Interact();
////}

//public class InteractorTeclas : MonoBehaviour
//{
//    public Transform InteractorSource;
//    public float interactRange;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.I))
//        {
//            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
//            if (Physics.Raycast(r, out RaycastHit hitinfo, interactRange))
//            {
//                // Primero, intentar la interfaz genérica
//                if (hitinfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
//                {
//                    interactObj.Interact();
//                }

//                // Fallback específico para cajas de munición tipo cofre
//                var go = hitinfo.collider.gameObject;
//                if (go.CompareTag("GunAmmo"))
//                {
//                    var box = go.GetComponent<AmmoBox>();
//                    if (box != null)
//                    {
//                        GameManager.Instance.gunammo += box.ammo;
//                        Destroy(go);
//                    }
//                }
//            }
//        }

//    }
//}
