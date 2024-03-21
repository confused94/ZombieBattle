
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
        //Atýlan bombanýn herhangi bir collider taþýyan objesine çarpýp çarpamadýðý kontreol edildi.
        //eðer herhangi bir collision saptanýrsa patlama fopnksiyonu çalýþýr*/
        if (collision!=null)
        {   
            Patlama();  
        }
        
    }
    void Patlama()
    {
        //patlama fonksiyonu çalýþtýðý anda bombanýn pozisyonu alýnýr.
        Vector3 bombapos = transform.position;
        //bombanýn pozisyonunda patlama efewkti oluþrturulur
        Instantiate(patlamaefekt,bombapos,Quaternion.identity);
        //Collider deðiþkeninde overlapsphere ile görünmez bir daire içerisine, bombanýn pozisyonunda ve çapýna
        //giren tüm objelerin colliderlari dizide saklanýr*/
        Collider[] colliders = Physics.OverlapSphere(bombapos, alan);
        
        foreach (Collider target in colliders)
        {   
            /*For each ile colliders dizisinde gezilir ve her bir objenin rigidbodyi tek tek yakalanýr*/
            Rigidbody rb=target.GetComponent<Rigidbody>();
            //Eðer target olarak ifade edilen colliders içerisindeki collider indexini tutan deger boþ deðilse
            //ve rigidbodye sahipse ve düþman etiketine sahipse kod bloðu çalýþýr*/
            if (target != null && rb&&target.CompareTag("dusman"))
            {
                //Rigidbodynin özel fonksiyonu olan explosionforce patlamayý simüle eder.
                rb.AddExplosionForce(guc, bombapos, alan, 0, ForceMode.Impulse);
                //patladýktan sonra dusman scriptinin içerisindeki öldü metodu çalýþýr
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
    
