using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DairelerManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] DairelerDizisi ;


    private void Start()
    {
        DairelerinScaleKapat();
    }

   public void DairelerinScaleKapat()
    {
        foreach (GameObject daire in DairelerDizisi)
        {
            daire.GetComponent<RectTransform>().localScale = Vector3.zero;    
        }
    }

   public void DaireninScaleAc(int hangiDaire)
    {
        DairelerDizisi[hangiDaire].GetComponent<RectTransform>().DOScale(1, 0.3f);

        if (hangiDaire % 5 == 0)
        {
            DairelerinScaleKapat();
        }
    }
}
