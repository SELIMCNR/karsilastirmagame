using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject pausePanel,sonucPaneli,PuanSurePaneli,PuanKapYazýsý,ustDikdortgen,altDikdortgen,büyükOlanYazýSeç;


    [SerializeField]
    private Text ustText, altText,puanText;

    TimerManager timerManager;

    int oyunSayac, kacinciOyun,ustDeger,altDeger,buyukDeger;
    int buttonDegeri;

    DairelerManager dairelerManager;
   trueFalseManager trueFalseManager1;
    sonucmanager Sonucmanager;
    int artispuan, toplampuan,dogruAdet,yanlisAdet;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip baslangicSesi, dogruSesi, yanlisSesi, bitisSesi;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timerManager = Object.FindObjectOfType<TimerManager>();
        dairelerManager = Object.FindObjectOfType<DairelerManager>();
        trueFalseManager1 = Object.FindObjectOfType<trueFalseManager>();
        
    }
    void Start()
    {
        kacinciOyun = 0;
        oyunSayac = 0;

        ustText.text = "";
        altText.text = "";
        puanText.text = "0";
        SahneEkraniniGuncelle();

        toplampuan = 0;
        
    }

    void SahneEkraniniGuncelle()
    {
        PuanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);
        PuanKapYazýsý.GetComponent<CanvasGroup>().DOFade(1, 1f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        
    }

    public void OyunaBaþla()
    {
        audioSource.PlayOneShot(baslangicSesi);
        PuanKapYazýsý.GetComponent<CanvasGroup>().DOFade(0, 0.2f);

        büyükOlanYazýSeç.GetComponent<CanvasGroup>().DOFade(1, 1f);


        Debug.Log("Oyun baþladý");

        KacinciOyun();
        timerManager.SureyiBaslat();

        
    }


    void KacinciOyun()
    {
        if (oyunSayac < 5)
        {
            kacinciOyun = 1;
            artispuan = 25;
        }
        else if (oyunSayac >= 5 && oyunSayac < 10)
        {
            kacinciOyun = 2;
            artispuan = 50;
        }
        else if(oyunSayac >= 10 && oyunSayac < 15)
        {
            artispuan = 75;
            kacinciOyun =3;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            artispuan = 100;
            kacinciOyun = 4;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            artispuan = 150;
            kacinciOyun = 5;
        }
        else if(oyunSayac>=25 )
        {
            artispuan = 200;
            kacinciOyun = Random.Range(1, 6);
        }

        switch (kacinciOyun)
        {
            case 1:
                birinciFonksiyon();
                    break;
            case 2:
                ikinciFonksiyon();
                break;
            case 3:
                ucuncuFonksiyon();
                break;
            case 4:
                dortuncuFonksiyon();
                break;
            case 5:
                besinciFonksiyon();
                break;
        }
    }

    void birinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(1, 100);
        if (rastgeleDeger <= 50)
        {
            ustDeger = Random.Range(2, 100);
            altDeger = ustDeger + Random.Range(1, 50);
        }
        else
        {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs( ustDeger - Random.Range(1, 20));

        }

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if(ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if(ustDeger == altDeger)
        {
            birinciFonksiyon();
            return;
        }

        ustText.text = ustDeger.ToString();
        altText.text = altDeger.ToString();



    }

    void ikinciFonksiyon()
    {
        int birinciSayi = Random.Range(1, 50);
        int ikinciSayi = Random.Range(1, 60);
        int ucuncuSayi = Random.Range(1, 50);
        int dorduncuSayi = Random.Range(1, 60);

        ustDeger = birinciSayi + ikinciSayi;
        altDeger = ucuncuSayi + dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if(ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if(ustDeger == altDeger)
        {
            ikinciFonksiyon();
            return;

        }

        ustText.text = birinciSayi + "+" + ikinciSayi;
        altText.text = ucuncuSayi + "+" + dorduncuSayi;
    }
    void ucuncuFonksiyon()
    {
        int birinciSayi = Random.Range(50, 100);
        int ikinciSayi = Random.Range(1, 50);
        int ucuncuSayi = Random.Range(50, 100);
        int dorduncuSayi = Random.Range(1, 50);

        ustDeger = birinciSayi - ikinciSayi;
        altDeger = ucuncuSayi - dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            ucuncuFonksiyon();
            return;

        }

        ustText.text = birinciSayi + "-" + ikinciSayi;
        altText.text = ucuncuSayi + "-" + dorduncuSayi;

    }
    void dortuncuFonksiyon()
    {
        int birinciSayi = Random.Range(50, 100);
        int ikinciSayi = Random.Range(1, 50);
        int ucuncuSayi = Random.Range(50, 100);
        int dorduncuSayi = Random.Range(1, 50);

        ustDeger = birinciSayi * ikinciSayi;
        altDeger = ucuncuSayi * dorduncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            dortuncuFonksiyon();
            return;

        }

        ustText.text = birinciSayi + "x" + ikinciSayi;
        altText.text = ucuncuSayi + "x" + dorduncuSayi;

    }

    void besinciFonksiyon()
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2, 10);

        int bolunen1 = bolen1 * ustDeger;

        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);

        int bolunen2 = bolen1 * altDeger;


        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            besinciFonksiyon();
            return;

        }

        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;

    }

    public void ButonDegeriniBelirle(string butonAdi)
    {
        if(butonAdi == "ustButton")
        {
            buttonDegeri = ustDeger;
        }
        else if(butonAdi == "altButton")
        {
            buttonDegeri = altDeger;
        }

        if(buttonDegeri == buyukDeger)
        {
            trueFalseManager1.TrueFalseScaleAc(true);
            Debug.Log("Doðru");
            dairelerManager.DaireninScaleAc(oyunSayac % 5);
            oyunSayac++;
            audioSource.PlayOneShot(dogruSesi);
            toplampuan += artispuan;
            puanText.text = toplampuan.ToString();
            dogruAdet++;
            KacinciOyun();
        }
        else
        {
            trueFalseManager1.TrueFalseScaleAc(false);
            HatayaGoreSayaciAzalt();
            yanlisAdet++;
            audioSource.PlayOneShot(yanlisSesi);
            KacinciOyun();
            toplampuan -= artispuan;
            puanText.text = toplampuan.ToString();

        }
    }

    void HatayaGoreSayaciAzalt()
    {
        oyunSayac -= (oyunSayac % 5 + 5);
        if (oyunSayac < 0)
        {
            oyunSayac = 0;
        }

        dairelerManager.DairelerinScaleKapat();
    }

    public void PausePaneliniAc()
    {
        pausePanel.SetActive(true);
    }

    public void OyunuBitir()
    {
        audioSource.PlayOneShot(bitisSesi);
        sonucPaneli.SetActive(true);
        Sonucmanager = Object.FindAnyObjectByType<sonucmanager>();
        Sonucmanager.SonuclariGoster(dogruAdet, toplampuan, yanlisAdet);
    }
}
