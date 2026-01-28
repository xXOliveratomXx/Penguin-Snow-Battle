using UnityEngine;

public class Granada : MonoBehaviour
{

    public float delay = 3f;

    float countdown;

    public float radius = 5f;

    public float explotionforce = 70f;

    bool exploted = false;

    public GameObject explotionEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;




        if (countdown <= 0f && !exploted)
        {
            Explode();
            exploted = true;
        }

    }



    void Explode()
    {
        Instantiate(explotionEffect, transform.position, transform.rotation);

        //generar coliders para colisionar con todos los rigibody
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var rangeObjects in colliders)
        {
            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explotionforce*10,transform.position,radius);
            }
        }

        //destruir granada
        Destroy(gameObject);
    }
}
