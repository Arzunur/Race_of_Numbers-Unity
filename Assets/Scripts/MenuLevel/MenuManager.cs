using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;//Sahne Geçiþleri için bu eklenmeli

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private Transform kafa;

    [SerializeField]
    private Transform startBtn;


    void Start()
    {
        kafa.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        startBtn.transform.GetComponent<RectTransform>().DOLocalMoveX(-120f, 1f).SetEase(Ease.OutBack); //MoveX(-120f, 1f) = x ekseninde -120 konuma 1 saniyede gelsin.
    }

   public void OyunaBasla()
    {
        SceneManager.LoadScene("GameLevel"); //Sahne isminin adý
    }
}
