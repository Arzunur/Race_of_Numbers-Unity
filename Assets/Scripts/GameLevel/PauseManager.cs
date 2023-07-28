using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
   
    private void OnEnable() //Aktif olduðunda ilk çalýþan koddur.Awake'den sonra 
    {
        Time.timeScale = 0f;//Zamaný durdurmak. AKTÝF OLUNCA ZAMAN DURUR.
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
