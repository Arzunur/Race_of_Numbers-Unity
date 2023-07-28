using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    //True ve False Iconlar�n g�z�kmesi. Bu scripti GameManager Script'inde de �a��rd�m

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
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero; //her ihtimale kar�� yazalim
        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero; 
        }

        Invoke("ScaleDegeriniKapat",0.4f);//belli bir s�re sonra fonk cal�st�rmak.Invoke("fonksiyonun_ismi",bekleme_s�resi);
    }

    void ScaleDegeriniKapat()//Iconlar� kapatmak
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero; //ekranda g�z�kmez
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
