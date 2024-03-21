using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{/*bu script ayarlar sahnesindeki u�lar� al�p onlar�n de�erlerine g�re playerprefslerini al�r.SceneManager 
  objesinin SahneYnetim scriptine aktar�l�r.*/
    [SerializeField]
    TMP_Dropdown cozunurlukDr, kaliteDr;
    [SerializeField]
    Slider muzikSl, oyunSl;
    [SerializeField]
    Toggle tamekranTg;

    private void Start()
    {
        oyunSl.value = PlayerPrefs.GetFloat("oyunsesi");
        muzikSl.value = PlayerPrefs.GetFloat("m�ziksesi");
        kaliteDr.value = PlayerPrefs.GetInt("grafik");
        tamekranTg.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("tamekran"));
        cozunurlukDr.value = PlayerPrefs.GetInt("cozunurluk");
    }
    public void MuzikSesiDegis()
    {
        if (!PlayerPrefs.HasKey("m�ziksesi"))
        {
            PlayerPrefs.SetFloat("m�ziksesi", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("m�ziksesi", muzikSl.value);
        }

    }//M�ziksesinin d�zeyini kaydeder.
    public void OyunSesi()//Oyunses d�zeyini kaydeder
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
        
        //grafik de�erlerini kaydeder
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
    }//En son t�m i�lemleri kaydedip menuye d�ner
    public void �ptal()//Kaydetme i�lemi yapmadan men�ye d�ner
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
    public void Cozunurluk()//��z�n�rl�k ayar� yap�l�r
    {
        string gelendeger = cozunurlukDr.options[cozunurlukDr.value].text;
        string[] bolunmus = gelendeger.Split("x");
        int x = int.Parse(bolunmus[0]);
        int y = int.Parse(bolunmus[1]);
        Screen.SetResolution(x, y, true);
        PlayerPrefs.SetInt("cozunurluk", cozunurlukDr.value);
    }
  
}
