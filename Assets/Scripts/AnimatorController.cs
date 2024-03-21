
using UnityEngine;


namespace Animasyonlar
{
    public class AnimatorController : MonoBehaviour
    {
        float maksimumHizC;
        float verticalC;
        Vector3 hareketyon;
        float maksimumUzunluk=1;
        float adimZamani;
        float adimAraligi;
        public AudioSource walksound;
        

        
        public void Ileriyuru(float maksimumHiz,float vertical)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                maksimumHiz = 1f;
                vertical = maksimumHiz * Input.GetAxis("Vertical");
                WalkSound(0.35f);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                maksimumHiz = .2f;
                vertical = maksimumHiz * Input.GetAxis("Vertical");
                WalkSound(0.5f);
                
            }
            else
            {
                maksimumHiz = 0f;
                vertical = maksimumHiz * Input.GetAxis("Vertical");
                
            }
            maksimumHizC = maksimumHiz;
            verticalC= vertical;
            
        }
        public void Solyuru(Animator anim,string animAdi,string animKontrol)
        {
            if (Input.GetKey(KeyCode.A))
            {
               
                anim.SetBool(animKontrol, true);
                if (Input.GetKey(KeyCode.LeftShift)) { anim.SetFloat(animAdi, 0.3f); WalkSound(0.35f);
                }
                else if (Input.GetKey(KeyCode.W)) { anim.SetFloat(animAdi, 0.6f); WalkSound(0.35f);
                }
                else if (Input.GetKey(KeyCode.S)) { anim.SetFloat(animAdi, 1f); WalkSound(0.35f);
                }
                else { anim.SetFloat(animAdi, 0.15f); WalkSound(0.5f); }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetFloat(animAdi, 0);
                anim.SetBool(animKontrol, false);
               
            }
            
        }
        public void Sagyuru(Animator anim,string animAdi,string animKontrol)
        {

            if (Input.GetKey(KeyCode.D))
            {
               
                anim.SetBool(animKontrol, true);
                if (Input.GetKey(KeyCode.LeftShift)) { anim.SetFloat(animAdi, 0.3f); WalkSound(0.35f);
                }
                else if (Input.GetKey(KeyCode.W)) { anim.SetFloat(animAdi, 0.6f); WalkSound(0.35f);
                }
                else if (Input.GetKey(KeyCode.S)) { anim.SetFloat(animAdi, 1f); WalkSound(0.35f);
                }
                else { anim.SetFloat(animAdi, 0.15f); WalkSound(0.5f); }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetFloat(animAdi, 0);
                anim.SetBool(animKontrol, false);
                
            }
            
        }
        public void Arkaya(Animator anim,string animKontrol)
        {
            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool(animKontrol, true);
                WalkSound(0.35f);

                
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool(animKontrol, false);
                

            }
           
        }
        void WalkSound(float adimSuresi)
        {
            adimAraligi = adimSuresi;
            adimZamani += Time.deltaTime;
            if (adimZamani > adimAraligi)
            {
                walksound.Play();
                adimZamani = 0;
            }
        }
        public float YonDeger()
        {
            return maksimumHizC;
        }
        public float HizDeger()
        {
            return verticalC;
        }
        public void hareket(Animator anim,string animAdi)
        {
            hareketyon = new Vector3(0, 0, verticalC);
            anim.SetFloat(animAdi, Vector3.ClampMagnitude(hareketyon, maksimumHizC).magnitude, maksimumUzunluk, Time.deltaTime * 30);

        }





    }
}

