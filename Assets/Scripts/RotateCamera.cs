using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //카메라 회전 스피드
    public float spinSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed * inputHorizontal);
    }
}
