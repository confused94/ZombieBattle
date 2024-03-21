
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ImageProcess : MonoBehaviour, IPointerClickHandler
{
    /*Her bir image da bulunan scripttir. Event system kütüphanesinde bulunan Ipointer dan miras alýndý.
     Bütün image gameobjelerine atýldý.Týklanýlan ýmage butonun imagýna atýlacaktýr.*/
    [SerializeField]//Buton ve image uýlarý alýndý.
    Button btn;
    Image resim;
    void Start()
    {
        resim = GetComponent<Image>();//Image Gameobjesinin ýmage componenti referans alýndý.
    }
    public void OnPointerClick(PointerEventData eventData)//Image gameobjesine týklandýðýnda çalýþacaktýr
    {
        btn.image.sprite = resim.sprite;//Image gameobjesinin sprite'ý buton sprite'ýna atandý.
        PlayerPrefs.SetInt("spriteidx", int.Parse(gameObject.name));
    }
}
