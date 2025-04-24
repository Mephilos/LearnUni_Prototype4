using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce;
    public bool hasPowerup;
    public GameObject powerIndicator;
    private float powerStrength = 15.0f;
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
        powerIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        playerRb.AddForce(focalPoint.transform.forward * inputVertical * moveForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerIndicator.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            Debug.Log("대상: " + collision.gameObject.name + "파워업 상태: " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerIndicator.gameObject.SetActive(false);
        hasPowerup = false;
    }
}
