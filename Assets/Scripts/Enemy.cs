using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //추격 방향 (방향 백터 정규화)
        Vector3 chaseDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(chaseDirection * chaseSpeed);
    }
}
