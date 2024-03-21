using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benzin : MonoBehaviour, Iitemler
{
    public void Al(GameObject g)
    {
        g.gameObject.GetComponent<PlayerController>().benzinAl();
        Destroy(gameObject);
    }
}
