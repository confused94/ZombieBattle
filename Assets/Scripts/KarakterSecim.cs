
using UnityEngine;



public class KarakterSecim : MonoBehaviour
{
    [SerializeField] GameObject[] karakterler;
    int karakterCount = 0;

    public void SagTus()
    {
        if (karakterCount < karakterler.Length - 1)
        {
            karakterler[karakterCount].SetActive(false);
            karakterCount++;
            karakterler[karakterCount].SetActive(true);
            
        }
        else
        {
            karakterler[karakterCount].SetActive(false);
            karakterCount = 0;
            karakterler[karakterCount].SetActive(true);
        }
        PlayerPrefs.SetInt("karakterdeger", karakterCount);
    }
    public void SolTus()
    {
        if (karakterCount < karakterler.Length&&karakterCount>0)
        {
            karakterler[karakterCount].SetActive(false);
            karakterCount--;
            karakterler[karakterCount].SetActive(true);
        }
        else
        {
            karakterler[karakterCount].SetActive(false);
            karakterCount = karakterler.Length - 1;
            karakterler[karakterCount].SetActive(true);
        }
        PlayerPrefs.SetInt("karakterdeger", karakterCount);
    }


}













