using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GeriSayımManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayimObje;

    [SerializeField]
    private Text geriSayımText;

    GameManager gameManager;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GeriSayRoutine());        
    }

    IEnumerator GeriSayRoutine()
    {
        geriSayımText.text = "3";
        yield return new WaitForSeconds(0.5f); //SAYAÇ

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        geriSayımText.text = "2";
        yield return new WaitForSeconds(0.5f); //SAYAÇ

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);
        geriSayımText.text = "1";
        yield return new WaitForSeconds(0.5f); //SAYAÇ

        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        StopAllCoroutines();

        gameManager.OyunaBaşla();
    }
    
}
