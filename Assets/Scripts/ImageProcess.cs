
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ImageProcess : MonoBehaviour, IPointerClickHandler
{
    /*Her bir image da bulunan scripttir. Event system k�t�phanesinde bulunan Ipointer dan miras al�nd�.
     B�t�n image gameobjelerine at�ld�.T�klan�lan �mage butonun imag�na at�lacakt�r.*/
    [SerializeField]//Buton ve image u�lar� al�nd�.
    Button btn;
    Image resim;
    void Start()
    {
        resim = GetComponent<Image>();//Image Gameobjesinin �mage componenti referans al�nd�.
    }
    public void OnPointerClick(PointerEventData eventData)//Image gameobjesine t�kland���nda �al��acakt�r
    {
        btn.image.sprite = resim.sprite;//Image gameobjesinin sprite'� buton sprite'�na atand�.
        PlayerPrefs.SetInt("spriteidx", int.Parse(gameObject.name));
    }
}
