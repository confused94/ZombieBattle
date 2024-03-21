using UnityEngine;
using TMPro;


public class Yazi : MonoBehaviour
{
    private TextMeshProUGUI textyazi;
    float timer;
    int i = 0;
    string metin;
    float sure;
    

    void Start()
    {
        textyazi = GetComponent<TextMeshProUGUI>();
        
        
    }

    void Update()
    {
        if (timer <= 0&&metin!=null)
        {
            textyazi.text = metin.Substring(0, i);
            i++;
            timer += sure;
            if (i > metin.Length)
            {
                metin = null; return;
                
            }
        }
        else
        {
            timer -= Time.unscaledDeltaTime;
        }
    }
   
    public void yaziyaz(string metin,float sure)
    {
        Time.timeScale = 0;
        this.metin = metin;
      this.sure = sure;
        timer = 0;
    }
}
