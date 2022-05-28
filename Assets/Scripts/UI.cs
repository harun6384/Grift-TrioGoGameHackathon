using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button btnBaslat, btnSkor, btnHakkinda, btnCikis;
    public Image logo;

    public void baslat(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void hakkinda(){
        SceneManager.LoadScene("Hakkinda", LoadSceneMode.Single);
    }

    public void yuksekSkor(){
        SceneManager.LoadScene("YuksekSkorlar", LoadSceneMode.Single);
    }

    public void cikis(){
        Application.Quit();
    }
}
