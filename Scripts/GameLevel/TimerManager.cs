using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    [SerializeField]
    private Text SüreText;

    int kalanSure;

    bool sureSaysýnmi = true;
    GameManager gameManager;
    
   private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
   
    }

    void Start()
    {
        kalanSure = 90            ;
        sureSaysýnmi = true ;
      
    }

    public void SureyiBaslat()
    {
        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                SüreText.text ="0"+ kalanSure.ToString();
            }
            else
            {
                SüreText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysýnmi=false;
                SüreText.text = "";
                gameManager.OyunuBitir();
            }
     
            kalanSure--;
        }
    }
}
