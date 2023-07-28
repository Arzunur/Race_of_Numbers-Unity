using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dogruAdetTxt, yanlisAdetTxt, puanTxt;

    int puanSure = 10;
    bool sureBittimi = true;
    int toplamPuan, yazdirilacakPuan, artisPuan;

    private void Awake()
    {
        sureBittimi = true;
    }

    public void Sonuclar�Goster(int dogruAdet, int yanlisAdet, int puan)
    {
        dogruAdetTxt.text = dogruAdet.ToString();
        yanlisAdetTxt.text = yanlisAdet.ToString();
        puanTxt.text = puan.ToString();
        toplamPuan = puan;
        artisPuan = toplamPuan / 10;//10 ad�mda ger�ekle�ecek

        StartCoroutine(PuaniYazdirRoutine());

    }
    IEnumerator PuaniYazdirRoutine()//puan� 10ar 10ar artt�rarak mevcut olan puana kadar gelmesi
    {
        while (sureBittimi)
        {
            yield return new WaitForSeconds(0.1f);
            yazdirilacakPuan += artisPuan;

            if(yazdirilacakPuan>=toplamPuan)
            {
                yazdirilacakPuan = toplamPuan;
            }

            puanTxt.text=yazdirilacakPuan.ToString();

            if(puanSure<=0)
            {
                sureBittimi= false;
            }
            puanSure--;
        }

    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameLevel");
    }

}
