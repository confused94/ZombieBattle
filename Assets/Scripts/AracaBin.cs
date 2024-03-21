
using UnityEngine;

public class AracaBin : MonoBehaviour
{
    public GameObject[] oyuncular;
    [SerializeField] Transform nokta;
    Vector3 kamerapozisyon;
    private void Start()
    {
        oyuncular[0] = GameObject.FindGameObjectWithTag("Player");
    }
    public void degis()
    {
        
        if (oyuncular[0].activeInHierarchy==true)
        {
            kamerapozisyon=oyuncular[0].transform.position - oyuncular[2].transform.position;
            oyuncular[0].SetActive(false);
            oyuncular[1].GetComponent<TankController>().enabled = true;
            oyuncular[2].SetActive(false);//Karakter Camera
            oyuncular[3].SetActive(true);//Tank camera
            
        }
        else if (oyuncular[1].GetComponent<TankController>().enabled)
        {
            oyuncular[0].SetActive(true);
            oyuncular[0].transform.position = nokta.position;
            oyuncular[1].GetComponent<TankController>().enabled = false;
            oyuncular[2].SetActive(true);
            oyuncular[2].transform.position = oyuncular[0].transform.position + kamerapozisyon;
            oyuncular[3].SetActive(false);
            
        }
    }
}
