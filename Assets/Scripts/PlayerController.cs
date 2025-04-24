using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce;
    public bool hasPowerup;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float inputVertical = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * inputVertical * moveForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("대상: " + collision.gameObject.name + "파워업 상태: " + hasPowerup);
        }
    }
}
