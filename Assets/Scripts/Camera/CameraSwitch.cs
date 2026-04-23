using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    private bool firtPersonEnable = true;

    // Scripts de cámara
    public Cameralook cameraLookScript;
    public ThirdPersonCamera thirdPersonCameraScript;

    //Armas cambio de vista

    public Transform[] weaponsTransformFirstPerson;
    public Transform[] weaponsTransformThirdPerson;

    public GameObject[] weapons;

    //variables para desabilitar el mesh del player en first person

    public bool disableMeshPlayerFirstPerson = true;

    public SkinnedMeshRenderer meshPlayer;
    public MeshRenderer powerup;

    //variables para desabilitar el mesh del player en first person




    //para desactivar mesh del player en first person
    void Start()
    {
        //if (disableMeshPlayerFirstPerson)
        //{
        //    meshPlayer.enabled = false;
        //}

        // Encontrar los scripts si no están asignados en el inspector
        if (cameraLookScript == null)
        {
            cameraLookScript = firstPersonCamera.GetComponent<Cameralook>();
        }
        if (thirdPersonCameraScript == null)
        {
            thirdPersonCameraScript = thirdPersonCamera.GetComponent<ThirdPersonCamera>();
        }
    }

    //para desactivar mesh del player en first person


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            firtPersonEnable = !firtPersonEnable;
            ChangedCamera();
        }

        //Upgrade();

    }


    public void ChangedCamera()
    {
        if (firtPersonEnable)
        {

            //para desactivar mesh del player en first person    

            if (disableMeshPlayerFirstPerson)
            {
                meshPlayer.enabled = false;
            }
            //para desactivar mesh del player en first person


            firstPersonCamera.enabled = true;
            thirdPersonCamera.enabled = false;

            // Habilitar script de primera persona
            if (cameraLookScript != null)
                cameraLookScript.enabled = true;

            // Deshabilitar script de tercera persona
            if (thirdPersonCameraScript != null)
                thirdPersonCameraScript.enabled = false;

            ChangedWeaponFirtPerson();
        }
        else
        {
            //para desactivar mesh del player en first person
            meshPlayer.enabled = true;
            //para desactivar mesh del player en first person

            firstPersonCamera.enabled = false;
            thirdPersonCamera.enabled = true;

            // Deshabilitar script de primera persona
            if (cameraLookScript != null)
                cameraLookScript.enabled = false;

            // Habilitar script de tercera persona
            if (thirdPersonCameraScript != null)
                thirdPersonCameraScript.enabled = true;

            ChangedWeaponThirdPerson();
        }

    }

    public void ChangedWeaponFirtPerson()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].transform.position = weaponsTransformFirstPerson[i].transform.position;

            weapons[i].transform.rotation = weaponsTransformFirstPerson[i].transform.rotation;

            weapons[i].transform.localScale = weaponsTransformFirstPerson[i].transform.localScale;
        }
    }

    public void ChangedWeaponThirdPerson()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].transform.position = weaponsTransformThirdPerson[i].transform.position;

            weapons[i].transform.rotation = weaponsTransformThirdPerson[i].transform.rotation;

            weapons[i].transform.localScale = weaponsTransformThirdPerson[i].transform.localScale;
        }


    }


    //EJERCICIO CLASE 25/02/2026


    //public void Upgrade()
    //{
    //    if (GameManager.Instance.gunammo >= 514)
    //    {
    //        if (meshPlayer.enabled == true)
    //        {
    //            meshPlayer.enabled = false;
    //        }
            
    //        powerup.enabled = true;
    //    }
        
    //}


}
