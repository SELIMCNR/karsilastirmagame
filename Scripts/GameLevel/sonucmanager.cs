using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sonucmanager : MonoBehaviour
{
    [SerializeField]
    private Text dogruAdetTxt, yanlisAdetTxt, puanTxt;
    // Start is called before the first frame update

    int puanSure = 10;
    bool sureBittimi = true;

    int toplamPuan, yazdirilacakPuan, artisPuan;

    private void Awake()
    {
        sureBittimi = true;
    }

    public void SonuclariGoster(int dogruAdet,int puan,int yanlisAdet)
    {
        dogruAdetTxt.text = dogruAdet.ToString();
        yanlisAdetTxt.text = yanlisAdet.ToString();
        puanTxt.text = puan.ToString();

        toplamPuan = puan;
        artisPuan = toplamPuan / 10;

        StartCoroutine(PuaniYazdirRoutine());
        
    }
    
    IEnumerator PuaniYazdirRoutine()
    {
        while (sureBittimi)
        {
            yield return new WaitForSeconds(0.1f);
            yazdirilacakPuan += artisPuan;
            if(yazdirilacakPuan >= toplamPuan)
            {
                yazdirilacakPuan = toplamPuan;
            }
            puanTxt.text = yazdirilacakPuan.ToString();

            if (puanSure <= 0)
            {
                sureBittimi = false;
            }
            puanSure--;
        }

    }

    public void Anamenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
