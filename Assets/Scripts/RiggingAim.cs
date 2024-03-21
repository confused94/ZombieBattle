using UnityEngine;


public class RiggingAim : MonoBehaviour
{
    
    
    void LateUpdate()
    {
        transform.position = Camera.main.transform.position+new Vector3(0,0,20); 
    }

}
