using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject puanSurePanel;

    [SerializeField]
    private GameObject pausePanel,sonucPanel;


    [SerializeField]
    private GameObject puaniKapYazisi,buyukOlanSayiyiSecYazisi;

    //[SerializeField]
    //private GameObject ustDikdortgen;

    //[SerializeField]
    //private GameObject altDikdortgen;

    [SerializeField]
    private TextMeshProUGUI ustText, altText, puanText;

    TimerManager timerManager;
    DairelerManager dairelerManager;
    TrueFalseManager trueFalseManager;
    SonucManager sonucManager;

    int oyunSayac, kacinciOyun;
    int ustDeger, altDeger; //baloncuklarda ��kan degerler i�in tan�mland�
    int buyukDeger;
    int butonDeger;
    int toplamPaun, artisPuan;
    int dogruAdet, yanlisAdet;

    private AudioSource audioSource;

    [SerializeField]//Sesleri d��ar�dan ataca��m i�in SerializeField dedim
    private AudioClip baslangicSes,dogruSes,yanlisSes,bitisSes;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
        dairelerManager=Object.FindObjectOfType<DairelerManager>();//< Script dosyas�n�n ad� >
        trueFalseManager= Object.FindObjectOfType<TrueFalseManager>();


          /*sonucManager = Object.FindObjectOfType<SonucManager>(); */
        //Unity ekran�nda Sonuc paneli set aktive = false oldu�u i�in bunun alt�ndaki hi�bir component a��k deil.Bu y�zden SonucManager scriptine ula�mas� imkans�zd�r.
        //Kod �al��t�r�ld��� zman hata ile kar��la��r.BU y�zden Awake fonk i�erisine de�il de Set Aktiv=true old. zman bu script dosyas�n� �a��rraca��m.

        audioSource=GetComponent<AudioSource>();

    }
    void Start()
    {
        kacinciOyun = 0;
        oyunSayac = 0;
        toplamPaun = 0;

        ustText.text = "";
        altText.text = "";
        puanText.text = "0";

        SahneEkraniniGuncelle();

    }


    void SahneEkraniniGuncelle()
    {
        puanSurePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);
        //ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(-15f, 2f).SetEase(Ease.OutBack);
        //altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(39f, 2f).SetEase(Ease.OutBack);


        OyunaBasla();
    }

    public void OyunaBasla()
    {
        audioSource.PlayOneShot(baslangicSes);//1 kere fonk. tetiklenir

        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0, 1f);//CanvasGroup'daki Alpha de�eri 0 yap�yoruz

        buyukOlanSayiyiSecYazisi.GetComponent<CanvasGroup>().DOFade(1, 1f);

        KacinciOyun();

        timerManager.SureyiBaslat();
    }

    void KacinciOyun()
    {
        if (oyunSayac < 5)
        {
            kacinciOyun = 1;
            artisPuan = 5;

        }
        else if(oyunSayac >= 5 && oyunSayac<10)
        {
            kacinciOyun = 2;
            artisPuan = 10;
        }
        else if(oyunSayac>=10 && oyunSayac<15 ) 
        {
            kacinciOyun = 3;
            artisPuan = 25;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            kacinciOyun = 4;
            artisPuan = 50;
        }
        else if (oyunSayac >= 20 && oyunSayac < 25)
        {
            kacinciOyun = 5;
            artisPuan = 100;
        }
        else
        {
            kacinciOyun = Random.Range(1, 6); //25den b�y�k old. kacinciOyun = .... rastgele bir de�er d�nd�recek 
         }


        switch (kacinciOyun)
        {
            case 1:
                BirinciFonksiyon();
                break;
            case 2:
                IkinciFonksiyon();
                break;
            case 3:
                UcuncuFonksiyon();
                break;
            case 4:
                DorduncuFonksiyon();
                break;
            case 5:
                BesinciFonksiyon();
                break;

        }
    }
    void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range(1, 50);
        if (rastgeleDeger <= 25)
        {
            ustDeger = Random.Range(2, 50);//2-49 
            altDeger = ustDeger + Random.Range(1, 20); //Bu sayede ust ve alt deger birbirine e�it olma ihtimalini ortadan kald�rm�� olduk.
        }
        else
        {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 16));
        }
        if (ustDeger > altDeger)
        {
            buyukDeger= ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger = altDeger;
        }
        if(ustDeger==altDeger)
        {
            BirinciFonksiyon();
            return;
        }

        ustText.text = ustDeger.ToString();
        altText.text=altDeger.ToString();
    }

    void IkinciFonksiyon()
    {
        int birinciSayi=Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 20);
        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSayi;
        altDeger=ucuncuSayi+ dorduncuSayi;

        if(ustDeger>altDeger) 
        {
            buyukDeger= ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger = altDeger;
        }
        if(ustDeger==altDeger)
        {
            IkinciFonksiyon();
            return;
        }
        ustText.text = birinciSayi + " + " + ikinciSayi;
        altText.text = ucuncuSayi + " + " + dorduncuSayi;
    }

    void UcuncuFonksiyon()
    {

        int birinciSayi = Random.Range(11, 30);
        int ikinciSayi = Random.Range(1, 11);
        int ucuncuSayi = Random.Range(11, 40);
        int dorduncuSayi = Random.Range(1, 11);

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
            UcuncuFonksiyon(); //E�er e�it ise UcuncuFonksiyonu "return" ederek fonksiyonu tekrar �al��t�r�yor.
            return;
        }
        ustText.text = birinciSayi + " - " + ikinciSayi;
        altText.text = ucuncuSayi + " - " + dorduncuSayi;
    }

    void DorduncuFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 10);
        int ucuncuSayi = Random.Range(1, 10);
        int dorduncuSayi = Random.Range(1, 10);

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
            DorduncuFonksiyon();
            return;  // DorduncuFonksiyon "return" ederek fonksiyonu tekrar �al��t�r�yor.
        }
        ustText.text = birinciSayi + " x " + ikinciSayi;
        altText.text = ucuncuSayi + " x " + dorduncuSayi;
    } 

    void BesinciFonksiyon()
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2,10);//bolum de�eri

        int bolunen1 = bolen1 * ustDeger;

        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);

        int bolunen2 = bolen2 * altDeger;

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
           BesinciFonksiyon();
            return; 
        }
        ustText.text = bolunen1 + " / " + bolen1;
        altText.text = bolunen2 + " / " + bolen2;
    }

    public void ButonDegeriniBelirle(string butonAdi)
    {
        if(butonAdi=="ustButon")
        {
            butonDeger = ustDeger;
        }
        else if(butonAdi=="altButon")
        {
            butonDeger=altDeger;
        }

        if(butonDeger==buyukDeger) //Bas�lan de�er do�ruysa
        {

            trueFalseManager.TrueFalseScaleAc(true); /*trueFalseManager asl�nda TrueFalseManager Scripti ve o script i�erindeki hangi fonk �a��rmak
                                                     istiyorsak o fonk. yaz�yoruz(TrueFalseScaleAc) ve bu fonk. bool tipinde dedi�imiz i�in tue mu false
                                                     hangisi �al��acak ise onu belirtiyoruz.*/

            dairelerManager.DaireninScaleAc(oyunSayac % 5 );
            oyunSayac++;

            toplamPaun += artisPuan;
            puanText.text = toplamPaun.ToString();

            dogruAdet++;

            audioSource.PlayOneShot(dogruSes);

            KacinciOyun();//Do�ru yap�ld���nda sonraki soru ekrana gelir.
        }
        else //Bas�lan de�er yanl��sa
        {
            trueFalseManager.TrueFalseScaleAc(false);

            HatayaGoreSayacAzalt();

            yanlisAdet++;

            audioSource.PlayOneShot(yanlisSes);

            KacinciOyun();
        }

    }

    void HatayaGoreSayacAzalt()
    {
        oyunSayac -= (oyunSayac%5+5); //Casedeki +, -, *, /   k�s�mlar�n�n de�i�ikli�ini sa�lad���m�z k�s�m(hata yap�nca onlar bir alt seviyeye d���yor.)
        if(oyunSayac<0)
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
        audioSource.PlayOneShot(bitisSes);

        sonucPanel.SetActive(true); //s�re bitti�i zaman sonucpanelini ekranda aktif ediyoruz.

        sonucManager = Object.FindObjectOfType<SonucManager>();

        sonucManager.Sonuclar�Goster(dogruAdet,yanlisAdet,toplamPaun);
    }
}
