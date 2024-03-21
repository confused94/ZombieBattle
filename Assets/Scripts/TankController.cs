
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    [SerializeField]
    GameObject tankNamlu,mermi;
    [SerializeField]
    Transform namluNoktasi;
    [SerializeField]
    GameObject atesEfekt;
    [SerializeField]
    AudioSource atesSesi;
    [SerializeField]
    AracaBin aracIn;
    [Header("Tank Ayarlarý")]


    public float donushiz;
    public float harekethizi;
    public float namluDonushizi;
    public float atesgucu;
 

    void Update()
    {
        hareket();
        AtesEt();

        
    }
    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            aracIn.degis();

        }
    }
    
    
    void hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        float mousex = Input.GetAxis("Mouse X");
        Quaternion namluDonus= Quaternion.Euler(0, mousex * namluDonushizi * Time.deltaTime, 0);
        Quaternion donusHareketi = Quaternion.Euler(0, yatay * donushiz * Time.deltaTime, 0);
        Vector3 ileriHareketi= transform.forward * harekethizi * dikey * Time.deltaTime;
        tankNamlu.transform.rotation *= namluDonus;
        transform.rotation *=donusHareketi ;
        transform.position += ileriHareketi;
    }
    void AtesEt()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Instantiate(mermi, namluNoktasi.position, Quaternion.LookRotation(tankNamlu.transform.up, tankNamlu.transform.forward)).GetComponent<Rigidbody>().AddForce(tankNamlu.transform.forward * atesgucu, ForceMode.Impulse);
            Instantiate(atesEfekt, namluNoktasi.position,Quaternion.LookRotation(tankNamlu.transform.forward,tankNamlu.transform.up));
            atesSesi.Play();
        }
       
    }
    
}
