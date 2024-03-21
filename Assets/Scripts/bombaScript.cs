
using UnityEngine;

public class bombaScript : MonoBehaviour
{

    [SerializeField]
    float guc, alan, upguc;
    [SerializeField]
    GameObject patlamaefekt;
    int hedefsayisi;
    void OnCollisionEnter(Collision collision)
    {
        //At�lan bomban�n herhangi bir collider ta��yan objesine �arp�p �arpamad��� kontreol edildi.
        //e�er herhangi bir collision saptan�rsa patlama fopnksiyonu �al���r*/
        if (collision!=null)
        {   
            Patlama();  
        }
        
    }
    void Patlama()
    {
        //patlama fonksiyonu �al��t��� anda bomban�n pozisyonu al�n�r.
        Vector3 bombapos = transform.position;
        //bomban�n pozisyonunda patlama efewkti olu�rturulur
        Instantiate(patlamaefekt,bombapos,Quaternion.identity);
        //Collider de�i�keninde overlapsphere ile g�r�nmez bir daire i�erisine, bomban�n pozisyonunda ve �ap�na
        //giren t�m objelerin colliderlari dizide saklan�r*/
        Collider[] colliders = Physics.OverlapSphere(bombapos, alan);
        
        foreach (Collider target in colliders)
        {   
            /*For each ile colliders dizisinde gezilir ve her bir objenin rigidbodyi tek tek yakalan�r*/
            Rigidbody rb=target.GetComponent<Rigidbody>();
            //E�er target olarak ifade edilen colliders i�erisindeki collider indexini tutan deger bo� de�ilse
            //ve rigidbodye sahipse ve d��man etiketine sahipse kod blo�u �al���r*/
            if (target != null && rb&&target.CompareTag("dusman"))
            {
                //Rigidbodynin �zel fonksiyonu olan explosionforce patlamay� sim�le eder.
                rb.AddExplosionForce(guc, bombapos, alan, 0, ForceMode.Impulse);
                //patlad�ktan sonra dusman scriptinin i�erisindeki �ld� metodu �al���r
                target.GetComponent<dusman>().oldu("bomba");
                
                
            }
            
        }
        

        //obje 0.1ms sonra yok edilir
        Destroy(gameObject, 0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kirilabilir")
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            Transform[] kapilar = other.transform.GetComponentsInChildren<Transform>();
            foreach(var item in kapilar)
            {
                item.gameObject.AddComponent<Rigidbody>();
                item.gameObject.GetComponent<Rigidbody>().AddExplosionForce(20,transform.position,20,5,ForceMode.Impulse);
                Destroy(item.gameObject, 10f);
            }
            
        }
    }

}
    
