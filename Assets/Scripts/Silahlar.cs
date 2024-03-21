
using TMPro;
using UnityEngine;


public class Silahlar : MonoBehaviour
{

    [SerializeField] protected float atesEtmeHizi, mesafe;
    [SerializeField] public int mermiAdet, toplamMermi, sarjor;
    [SerializeField] protected ParticleSystem[] efektler;
    [SerializeField] protected AudioSource[] sesler;
    [SerializeField] Light isik;
    protected float gecenSure;
    int darbegucu;
    bool isikacikmi = true;
    CameraController benimcam;
    TextMeshProUGUI mermiText;
    Animator karakterAnimator;


    public void Start()
    {
        benimcam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        mermiText = GameObject.FindGameObjectWithTag("MermiText").GetComponent<TextMeshProUGUI>();
        mermiText.text = string.Format("{0}" + "/" + "{1}", mermiAdet, toplamMermi);
        karakterAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        darbegucu = 15;
    }
     void LateUpdate()
    {
        if (Time.timeScale != 0)
        {
            AtesEt();
            IsikAc();
        }
        

    }
    void AtesEt()
    {
        mermiText.text = string.Format("{0}" + "/" + "{1}", mermiAdet, toplamMermi);
        RaycastHit hit;
        Vector3 raydirection = benimcam.donusual * Vector3.forward;
        if (Input.GetKeyDown(KeyCode.R) && toplamMermi != 0)
        {
            if (mermiAdet < sarjor && toplamMermi > 0)
            {
                karakterAnimator.Play("Reloading");
                sesler[2].Play();
            }

        }
        if (karakterAnimator.GetBool("bittiMi"))
        {
            MermiYenile();
        }

        if (Input.GetMouseButton(0) && Time.time > gecenSure && !Input.GetKey(KeyCode.LeftShift))
        {

            if (Physics.Raycast(benimcam.transform.position, raydirection, out hit, mesafe))
            {
                if (mermiAdet != 0)
                {
                    sesler[0].Play();
                    efektler[0].Play();
                    mermiAdet--;
                    gecenSure = Time.time + atesEtmeHizi;

                    mermiText.text = string.Format("{0}" + "/" + "{1}", mermiAdet, toplamMermi);

                    if (hit.collider.CompareTag("dusman"))
                    {
                        Instantiate(efektler[2], hit.point, Quaternion.LookRotation(hit.normal));
                        hit.transform.GetComponent<dusman>().DarbeAl(darbegucu);

                    }
                    if (hit.collider.CompareTag("Obje"))
                    {
                        Instantiate(efektler[1], hit.point, Quaternion.LookRotation(hit.normal));
                    }
                }
                else { sesler[1].Play(); }

            }
        }
    }
    void MermiYenile()
    {
        int fark = Mathf.Abs(mermiAdet - sarjor);
        int sonmermi = toplamMermi - fark;
        if (sonmermi < 0) { mermiAdet = toplamMermi; toplamMermi = 0; }
        else { toplamMermi -= fark; mermiAdet = sarjor; }
        karakterAnimator.SetBool("bittiMi", false);
        mermiText.text = string.Format("{0}" + "/" + "{1}", mermiAdet, toplamMermi);
    }
    private void IsikAc()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(isikacikmi)
            {
                isik.enabled = isikacikmi;
                isikacikmi =! isikacikmi;
            }
            else
            {
                isik.enabled = isikacikmi;
                isikacikmi = !isikacikmi;
            }
            
        }
       
    }
}
