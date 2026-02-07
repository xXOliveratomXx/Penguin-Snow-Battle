using UnityEngine;

public class Presionar : MonoBehaviour
{
    //public GameObject Pivot;
    //private Transform playerPosition;

    public Transform cameraReferencia;





    private void Start()
    {
        if (cameraReferencia == null)
        {
           Debug.LogWarning("No se ha asignado una referencia de c�mara. El objeto no podr� rotar hacia la c�mara.");
        }
    }

    void LateUpdate()
    {
        if (cameraReferencia != null)
        {
            transform.LookAt(cameraReferencia);
            transform.Rotate(90, 0, 0);

        }

    }
}



