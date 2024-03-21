using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class SahneYonetim : MonoBehaviour
{
    /*Bu script tüm sahne aralarýnda geçiþ yapmayý butonlarý,inputlarý ve prefs kayýtlarýný tutan
     scripttir. Bu yüzden her sahnede destroyonload ile tutulur*/
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
        AyarlarýGuncelle();
    }
    public void SahneYukle(string sahneAdi)//Sahne yükler
    {
        
        SceneManager.LoadScene(sahneAdi);
        
        StartCoroutine(sahneyuklendi());
        //Coroutine baslatýr Sahnenin yüklenip referans objeleri eklemek iiçn coroutine
        IEnumerator sahneyuklendi()
        {
            while (true)//dngüye girer
            {
                bool yuklendi = SceneManager.GetSceneByName(sahneAdi).isLoaded;
                if (yuklendi)//sahnenin yüklenme kontrolü
                {
                    switch (sahneAdi)//sahne adýna göre iþlemler
                    {
                        case "karaktersahne":
                            //KarakterSahnesindeki uý'lar
                           
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
                    break;//whiledan çýkar
                }
                yield return null;  
            }          
        }    
    }
    public void Cikis()//Oyunu kapatýr
    {
        Application.Quit();
    }
    //private void ResimGoster()//Resimlerin oldugu paneli açar kapar
    //{
    //    degis = !degis;
    //    panel.SetActive(degis);
    //}
    private void OyunSahnesi()//KarakterSahnesindeki tüm panel etiketli objeleri gizler ve loading panelini açmak iiçn coroutine baþlatýr
    {
        //PlayerPrefs.SetString("isim", isimTxt.text);//ismi kaydeder
        PanelleriGizle();
        StartCoroutine(oyunyuklendimi());

    }

    IEnumerator oyunyuklendimi()
    {
        //Senkronize þekilde oyun sahensini yükeleyecektir bylece loading sliderýný çalýþtýrýr.
        AsyncOperation operation = SceneManager.LoadSceneAsync("Scene 3");
       //Oyun sahnesini yükler
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
    void PanelleriGizle()//panelleri gizleyip loading sliderýn grünmesini saðlar
    {
        GameObject[] paneller = GameObject.FindGameObjectsWithTag("panel1");
        for (int i = 0; i < paneller.Length; i++)
        {
            paneller[i].SetActive(false);
        }
        //if (degis) { ResimGoster(); }//Eðer resim paneli açýksa kapatýr açýk deðilse baþlata basýldýðýnda açmaz burasý çalýþmaz
        
        loading.SetActive(true);
    }
    //private void TextKontrolu(string Arg0)//InputField'daki deðerin deðiþmesiyle çalýþýr
    //{
        
    //    if (isimTxt.text != string.Empty)//Eðer input field a girilen deðer yoksa buton aktif olmayacaktýr
    //    {
    //        baslaButon.interactable = true;
    //    }
    //    else
    //    {
    //        baslaButon.interactable = false;

    //    }

    //}
    void AyarlarýGuncelle()
    {
        
        muziksesi.volume = PlayerPrefs.GetFloat("müziksesi");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("grafik"));
        
        if(SceneManager.GetActiveScene().name=="Scene 3")
            AudioListener.volume = PlayerPrefs.GetFloat("oyunsesi");      
    }
            
}
        

