using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    //True ve False Iconlarýn gözükmesi. Bu scripti GameManager Script'inde de çaðýrdým

    [SerializeField]
    private GameObject trueIcon, falseIcon;


    void Start()
    {
        ScaleDegeriniKapat();
    }

  public void TrueFalseScaleAc(bool dogrumuYanlismi)
    {
        if(dogrumuYanlismi) //dogrumuYanlismi==true 
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1,0.2f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero; //her ihtimale karþý yazalim
        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero; 
        }

        Invoke("ScaleDegeriniKapat",0.4f);//belli bir süre sonra fonk calýstýrmak.Invoke("fonksiyonun_ismi",bekleme_süresi);
    }

    void ScaleDegeriniKapat()//Iconlarý kapatmak
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero; //ekranda gözükmez
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
