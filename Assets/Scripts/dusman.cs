using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class dusman : MonoBehaviour
{
    NavMeshAgent ajan;
    GameObject hedef;
    Animator anim;
    AudioSource ses;
    [SerializeField] Transform[] devriyenoktasi;
    [SerializeField] bool devriyeatsin;
    Coroutine devriyeCoroutine;
    float takipcap, saldircap;
    bool degdi;
    bool playerBulundu, tankbulundu, devriyekontrol;
    int idx, darbegucu, saglik;
    void Start()
    {
        ajan = GetComponent<NavMeshAgent>();
        ses = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        if (devriyeatsin)
        {
            devriyeCoroutine = StartCoroutine(devriyebasla());
        }

        takipcap = 10;
        saldircap = 5;
        idx = 0;
        saglik = 100;
    }


    void LateUpdate()
    {

        Takip();
        Saldir();





    }
    IEnumerator devriyebasla()
    {
        devriyekontrol = true;
        while (true)
        {
            if (Vector3.Distance(ajan.transform.position, devriyenoktasi[idx].transform.position) <= 1)
            {

                if (idx < devriyenoktasi.Length - 1)
                {
                    idx++;
                    ajan.SetDestination(devriyenoktasi[idx].position);

                }
                else
                {
                    idx = 0;

                }
            }
            else
            {

                anim.SetBool("yuru", true);
                ajan.SetDestination(devriyenoktasi[idx].position);
            }
            yield return null;
        }
    }
    private void Takip()
    {

        Collider[] col = Physics.OverlapSphere(transform.position, takipcap);
        foreach (var item in col)
        {
            if (item.gameObject.CompareTag("Player"))
            {
                if (devriyeatsin)
                {
                    StopCoroutine(devriyeCoroutine);
                }

                hedef = item.gameObject;
                ajan.SetDestination(hedef.transform.position);
                anim.SetBool("kos", false);
                anim.SetBool("yuru", true);
                playerBulundu = true;

            }
            if (item.gameObject.CompareTag("Tank"))
            {
                if (item.gameObject.GetComponentInParent<TankController>().enabled)
                {
                    hedef = item.gameObject;
                    ajan.SetDestination(hedef.transform.position);
                    anim.SetBool("kos", false);
                    anim.SetBool("yuru", true);
                    playerBulundu = false;
                    tankbulundu = true;
                }
                if (devriyeatsin)
                {
                    StopCoroutine(devriyeCoroutine);
                }


            }
        }
        if (!playerBulundu && !devriyekontrol)
        {
            hedef = null;
            anim.SetBool("yuru", false);
            if (devriyeatsin)
            {
                StartCoroutine(devriyebasla());
            }


        }
        if (!tankbulundu && !devriyekontrol)
        {
            hedef = null;
            anim.SetBool("yuru", false);
            if (devriyeatsin)
            {
                StartCoroutine(devriyebasla());
            }


        }
        playerBulundu = false;
        tankbulundu = false;
    }
    private void Saldir()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, saldircap);
        foreach (var item in col)
        {
            if (item.gameObject.CompareTag("Player"))
            {
                anim.SetBool("yuru", false);
                anim.SetBool("kos", true);
                if (ajan.remainingDistance < 1 && !degdi)
                {

                    darbegucu = Random.Range(5, 30);
                    anim.SetBool("saldir", true);
                    item.gameObject.GetComponent<PlayerController>().kacabilirMi = true;
                    if (anim.GetBool("zararver"))
                    {
                        item.gameObject.GetComponent<PlayerController>().SaglikDusur(darbegucu);
                        anim.SetBool("zararver", false);

                    }
                }
                else
                {
                    item.gameObject.GetComponent<PlayerController>().kacabilirMi = false;
                    anim.SetBool("saldir", false);

                }
            }


        }
    }
    public void DarbeAl(int darbe)
    {
        saglik -= darbe;
        if (saglik <= 0)
        {
            degdi = true;
            oldu("kursun");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, takipcap);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, saldircap);
    }



    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("saldir", false);

        ajan.enabled = true;
    }
    //oldu fonksiyonu düþmanýmýz öldüðünde navmeshagent ve animasyon özellikleri deaktif edilir. bylece
    //ragdoll sistemi düzgün çalýþýr.*/
    public void oldu(string silah)
    {
        if (silah == "bomba")
        {
            ajan.enabled = false;
            GetComponent<Animator>().enabled = false;
            Destroy(gameObject, 2);
        }
        else
        {
            //////////**********Oldu Animasyonu Ve Destroy************////////////
            ajan.isStopped = true;
            anim.Play("Olme");
            Destroy(gameObject, 3);
            ses.Stop();
        }

    }


}
