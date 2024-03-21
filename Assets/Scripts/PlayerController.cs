
using UnityEngine;
using Animasyonlar;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    AnimatorController karakteranim = new AnimatorController();
    Animator anim;
    [SerializeField]AudioSource walksound;
    AracaBin aracBin;
    GameManager gm;
    Image saglikimg;
    float maksimumHiz, vertical;
    float saglik = 100;
    bool benzinAlindiMi;
    public bool kacabilirMi;
   

    private void Awake()
    {
        saglikimg = GameObject.FindGameObjectWithTag("canbari").GetComponent<Image>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        aracBin = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AracaBin>();
        anim = GetComponent<Animator>();
        karakteranim.walksound=GetComponent<AudioSource>();
       
        
    }
    void Start()
    {
        
        
        saglik = 100;
        gm.MesajYaz();
        

    }

    private void LateUpdate()
    {
        KarakterAnimasyonu();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toplanabilir"))
        {
            other.gameObject.GetComponent<Iitemler>().Al(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Tank"))
        {
            
            if (Input.GetKeyUp(KeyCode.E)&&benzinAlindiMi)
            {
               aracBin.degis();
                
                
            }
        }
        else
        {
            /****Buraya benzin yok imajý gelecek****/
        }
    }
    void KarakterAnimasyonu()
    {
        
        if (!kacabilirMi)
        {
            karakteranim.Ileriyuru(maksimumHiz, vertical);
            karakteranim.Solyuru(anim, "SolYuru", "SolYuruB");
            karakteranim.Sagyuru(anim, "SagYuru", "SagYuruB");
            karakteranim.Arkaya(anim, "ArkayaYuru");
            karakteranim.hareket(anim, "Speed");
        }
        
    }
    public void benzinAl()
    {
        benzinAlindiMi = true;
        gm.MesajYaz();
    }
    public void SaglikArttir(int candeger)
    {
        saglik += candeger;
        saglikimg.fillAmount = saglik / 100;
    }
    public void SaglikDusur(int hasar)
    {
        saglik -= hasar;
        saglikimg.fillAmount = saglik / 100;
    }

}
