using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{/*bu script ayarlar sahnesindeki uýlarý alýp onlarýn deðerlerine göre playerprefslerini alýr.SceneManager 
  objesinin SahneYnetim scriptine aktarýlýr.*/
    [SerializeField]
    TMP_Dropdown cozunurlukDr, kaliteDr;
    [SerializeField]
    Slider muzikSl, oyunSl;
    [SerializeField]
    Toggle tamekranTg;

    private void Start()
    {
        oyunSl.value = PlayerPrefs.GetFloat("oyunsesi");
        muzikSl.value = PlayerPrefs.GetFloat("müziksesi");
        kaliteDr.value = PlayerPrefs.GetInt("grafik");
        tamekranTg.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("tamekran"));
        cozunurlukDr.value = PlayerPrefs.GetInt("cozunurluk");
    }
    public void MuzikSesiDegis()
    {
        if (!PlayerPrefs.HasKey("müziksesi"))
        {
            PlayerPrefs.SetFloat("müziksesi", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("müziksesi", muzikSl.value);
        }

    }//Müziksesinin düzeyini kaydeder.
    public void OyunSesi()//Oyunses düzeyini kaydeder
    {
        if (!PlayerPrefs.HasKey("oyunsesi"))
        {
            PlayerPrefs.SetFloat("oyunsesi", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("oyunsesi", oyunSl.value);  
        }
    }
    public void Kaydet()
    {
        
        //grafik deðerlerini kaydeder
        if (!PlayerPrefs.HasKey("grafik"))
        {
            PlayerPrefs.SetInt("grafik", kaliteDr.value);
        }
        else
        {
            PlayerPrefs.SetInt("grafik", kaliteDr.value);
        }
        PlayerPrefs.Save();
        SahneYonetim.instance.geri();
    }//En son tüm iþlemleri kaydedip menuye döner
    public void Ýptal()//Kaydetme iþlemi yapmadan menüye döner
    {
        SahneYonetim.instance.geri();
    }
    public void EkranAyari()
    {
        int value=Convert.ToInt32(tamekranTg.isOn);
        PlayerPrefs.SetInt("tamekran", value);
        if(tamekranTg.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
    public void Cozunurluk()//Çözünürlük ayarý yapýlýr
    {
        string gelendeger = cozunurlukDr.options[cozunurlukDr.value].text;
        string[] bolunmus = gelendeger.Split("x");
        int x = int.Parse(bolunmus[0]);
        int y = int.Parse(bolunmus[1]);
        Screen.SetResolution(x, y, true);
        PlayerPrefs.SetInt("cozunurluk", cozunurlukDr.value);
    }
  
}
