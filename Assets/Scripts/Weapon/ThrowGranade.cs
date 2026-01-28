using UnityEngine;

public class ThrowGranade : MonoBehaviour
{
    public float throwForce = 400f;

    public GameObject granadePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw();
        }
    }

    public void Throw()
    {
        GameObject newgranade = Instantiate(granadePrefab, transform.position, transform.rotation);


        newgranade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }
}
