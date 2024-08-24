using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    [SerializeField]
    private Text S�reText;

    int kalanSure;

    bool sureSays�nmi = true;
    GameManager gameManager;
    
   private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
   
    }

    void Start()
    {
        kalanSure = 90            ;
        sureSays�nmi = true ;
      
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
                S�reText.text ="0"+ kalanSure.ToString();
            }
            else
            {
                S�reText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSays�nmi=false;
                S�reText.text = "";
                gameManager.OyunuBitir();
            }
     
            kalanSure--;
        }
    }
}
