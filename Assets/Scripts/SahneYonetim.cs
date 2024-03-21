using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class SahneYonetim : MonoBehaviour
{
    /*Bu script t�m sahne aralar�nda ge�i� yapmay� butonlar�,inputlar� ve prefs kay�tlar�n� tutan
     scripttir. Bu y�zden her sahnede destroyonload ile tutulur*/
    [SerializeField]
    AudioSource muziksesi;
    AudioListener oyunsesi;
    
    Button baslaButon, geriButon;
    GameObject panel, loading;
    

    public static SahneYonetim instance;
    private void Awake()
    {
        
       
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Ayarlar�Guncelle();
    }
    public void SahneYukle(string sahneAdi)//Sahne y�kler
    {
        
        SceneManager.LoadScene(sahneAdi);
        
        StartCoroutine(sahneyuklendi());
        //Coroutine baslat�r Sahnenin y�klenip referans objeleri eklemek ii�n coroutine
        IEnumerator sahneyuklendi()
        {
            while (true)//dng�ye girer
            {
                bool yuklendi = SceneManager.GetSceneByName(sahneAdi).isLoaded;
                if (yuklendi)//sahnenin y�klenme kontrol�
                {
                    switch (sahneAdi)//sahne ad�na g�re i�lemler
                    {
                        case "karaktersahne":
                            //KarakterSahnesindeki u�'lar
                           
                            //panel = GameObject.FindGameObjectWithTag("panel");
                            //panel.SetActive(false);
                            //isimTxt = GameObject.FindGameObjectWithTag("isim").GetComponent<TMP_InputField>();
                            //isimTxt.onValueChanged.AddListener(TextKontrolu);
                            //resimButon = GameObject.FindGameObjectWithTag("buton").GetComponent<Button>();
                            //resimButon.onClick.AddListener(ResimGoster);
                            baslaButon = GameObject.FindGameObjectWithTag("baslabtn").GetComponent<Button>();
                            baslaButon.onClick.AddListener(OyunSahnesi);
                            //baslaButon.interactable = false;
                            geriButon = GameObject.FindGameObjectWithTag("geribtn").GetComponent<Button>();
                            geriButon.onClick.AddListener(geri);
                            loading = GameObject.FindGameObjectWithTag("loading");
                            loading.SetActive(false);
                            break;
                        default:
                            break;
                    }
                    break;//whiledan ��kar
                }
                yield return null;  
            }          
        }    
    }
    public void Cikis()//Oyunu kapat�r
    {
        Application.Quit();
    }
    //private void ResimGoster()//Resimlerin oldugu paneli a�ar kapar
    //{
    //    degis = !degis;
    //    panel.SetActive(degis);
    //}
    private void OyunSahnesi()//KarakterSahnesindeki t�m panel etiketli objeleri gizler ve loading panelini a�mak ii�n coroutine ba�lat�r
    {
        //PlayerPrefs.SetString("isim", isimTxt.text);//ismi kaydeder
        PanelleriGizle();
        StartCoroutine(oyunyuklendimi());

    }

    IEnumerator oyunyuklendimi()
    {
        //Senkronize �ekilde oyun sahensini y�keleyecektir bylece loading slider�n� �al��t�r�r.
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scene 3");
       //Oyun sahnesini y�kler
        while (!operation.isDone)
        {
            loading.GetComponent<Slider>().value = Mathf.Clamp01(operation.progress / .9f);
            yield return null;
        }
    }
    public void geri()
    {
        
        SceneManager.LoadScene("Menu");//menu sahnesi
        Destroy(gameObject);
    }
    void PanelleriGizle()//panelleri gizleyip loading slider�n gr�nmesini sa�lar
    {
        GameObject[] paneller = GameObject.FindGameObjectsWithTag("panel1");
        for (int i = 0; i < paneller.Length; i++)
        {
            paneller[i].SetActive(false);
        }
        //if (degis) { ResimGoster(); }//E�er resim paneli a��ksa kapat�r a��k de�ilse ba�lata bas�ld���nda a�maz buras� �al��maz
        
        loading.SetActive(true);
    }
    //private void TextKontrolu(string Arg0)//InputField'daki de�erin de�i�mesiyle �al���r
    //{
        
    //    if (isimTxt.text != string.Empty)//E�er input field a girilen de�er yoksa buton aktif olmayacakt�r
    //    {
    //        baslaButon.interactable = true;
    //    }
    //    else
    //    {
    //        baslaButon.interactable = false;

    //    }

    //}
    void Ayarlar�Guncelle()
    {
        
        muziksesi.volume = PlayerPrefs.GetFloat("m�ziksesi");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("grafik"));
        
        if(SceneManager.GetActiveScene().name=="Scene 3")
            AudioListener.volume = PlayerPrefs.GetFloat("oyunsesi");      
    }
            
}
        

