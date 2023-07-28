using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI SureText;

    int kalanSure;
    bool sureSaysinMi;//bool sureSaysinMi=true;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        kalanSure = 90; 
        sureSaysinMi= true;
        
    }

    public void SureyiBaslat()
    {
        StartCoroutine(SureTimerRoutine());
    }
   IEnumerator SureTimerRoutine()
    {
        while(sureSaysinMi)
        {
            yield return new WaitForSeconds(1f);

            if(kalanSure<10)
            {
                SureText.text="0"+kalanSure.ToString();
            }
            else
            {
                SureText.text = kalanSure.ToString();
            }
            if(kalanSure<=0)//Süre 0 olduðunda 
            {
                sureSaysinMi = false;
                SureText.text = "";
                gameManager.OyunuBitir();

            }
            kalanSure--;
        }
    }
}
