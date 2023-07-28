using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
   
    private void OnEnable() //Aktif oldu�unda ilk �al��an koddur.Awake'den sonra 
    {
        Time.timeScale = 0f;//Zaman� durdurmak. AKT�F OLUNCA ZAMAN DURUR.
    }

 
    private void OnDisable() 
    {
        Time.timeScale = 1f;
    }

   public void YenidenOyna()
    {
        pausePanel.SetActive(false);
    }
    public void MenuyeDon()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }

}
