using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GeriSayimObje;

    [SerializeField] //using TMPro; eklenmeli
    private TextMeshProUGUI geriSayimText; //  TEXT kullanýyorsan--> private Text TextgeriSayimText;

    GameManager gameManager;
    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
    }
    void Start()
    {
       StartCoroutine(GeriSayRoutine());
    }
    IEnumerator GeriSayRoutine()
    {
        geriSayimText.text = "3";
        yield return new WaitForSeconds(0.5f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack); //OutBack Animasyon bittiðinde 
        yield return new WaitForSeconds(1f); //1 sn beklemek 
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack); //InBack Animasyon basladýðýnda  
        yield return new WaitForSeconds(0.6f); //0.6 sn beklemek (3-2-1 arasýndaki geçiþin)

        geriSayimText.text = "2";
        yield return new WaitForSeconds(0.5f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack); //OutBack Animasyon bittiðinde 
        yield return new WaitForSeconds(1f); //1 sn beklemek 
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack); //InBack Animasyon basladýðýnda  
        yield return new WaitForSeconds(0.6f);  

        geriSayimText.text = "1";
        yield return new WaitForSeconds(0.5f);
        GeriSayimObje.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack); //OutBack Animasyon bittiðinde 
        yield return new WaitForSeconds(1f); //1 sn beklemek 
        GeriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack); //InBack Animasyon basladýðýnda  
        yield return new WaitForSeconds(0.6f); 

       

        StopAllCoroutines();
        gameManager.OyunaBasla();//GameManager Scriptindeki OyunaBasla() Fonksiyonunu Çaðýrmýþ olduk.

    }

}
