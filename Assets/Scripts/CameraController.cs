
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform character;
    [SerializeField] float rotateSpeed;
    Vector3 distance;
    Quaternion rotate;
    float mouseX;
    float mouseY;
    float invertValue;
    [SerializeField] bool invertY;
    
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
        distance = character.position-transform.position; 
    }

    
    void LateUpdate()
    {
        invertValue = (invertY) ? 1 : -1;
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y")*invertValue;
        mouseY=Mathf.Clamp(mouseY, -45, 45);
        rotate=Quaternion.Euler(mouseY,mouseX,0);
        transform.position = character.position -rotate* distance;
        transform.rotation = rotate;
        Quaternion donus = Quaternion.Euler(0, mouseX, 0);
        Vector3 rotatedForward = donus * Vector3.forward;
        character.forward=Vector3.Slerp(rotatedForward, character.forward,rotateSpeed*Time.deltaTime);
        
        
        
    }
    public Quaternion donusual => rotate;
}
