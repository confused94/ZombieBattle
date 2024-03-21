
using UnityEngine;

class Mermi : MonoBehaviour,Iitemler
{
    public void Al(GameObject g)
    {
        g.GetComponentInChildren<Silahlar>().toplamMermi += 50;
        Destroy(gameObject);
    }
   
}

