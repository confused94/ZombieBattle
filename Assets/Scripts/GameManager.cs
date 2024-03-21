using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] karakterler;
    [SerializeField] Transform olusmaNoktasi;
    [SerializeField]
    TextMeshProUGUI suretxt;
    [Header("Oyun Ayarlarý")]
    public int sure;
    [Header("Resimler")]
    public Sprite[] sprites;
    //[SerializeField]
    //Image resim;
    
    [Header("MEsaj Paneli Aç Kapat")]
    public GameObject panel;
    [SerializeField]string[] metin;
    int metinidx;

    private void Awake()
    {
        GameObject oyuncu=Instantiate(karakterler[PlayerPrefs.GetInt("karakterdeger")], olusmaNoktasi.position, transform.rotation);
        GetComponent<AracaBin>().oyuncular[0] = oyuncu;
        GetComponent<AracaBin>().oyuncular[2] = oyuncu.transform.Find("Main Camera").gameObject;
    }
    void Start()
    {
        StartCoroutine(sureguncelle());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //resim.sprite = sprites[PlayerPrefs.GetInt("spriteidx")];
        //isimtxt.text = PlayerPrefs.GetString("isim");
        
    }
    void Update()
    {
        suretxt.text = "SÜRE: " + sure;
    }
    IEnumerator sureguncelle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            sure--;
            if (sure <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    public void MesajPanelKapa()
    {
        
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        metinidx++;
        Time.timeScale = 1;
        
        
    }
    public void MesajYaz()
    {
        panel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        panel.GetComponentInChildren<Yazi>().yaziyaz(metin[metinidx], .1f);
        
    }
    
        

    

}
