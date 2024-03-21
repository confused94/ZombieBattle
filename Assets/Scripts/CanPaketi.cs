
using UnityEngine;

public class CanPaketi : MonoBehaviour, Iitemler
{
    public void Al(GameObject g)
    {
        g.GetComponent<PlayerController>().SaglikArttir(50);
        Destroy(gameObject);
    }
}
