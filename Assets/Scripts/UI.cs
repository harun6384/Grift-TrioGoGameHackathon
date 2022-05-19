using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button btnBaslat, btnHakkinda, btnCikis;

    public void baslat(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void hakkinda(){
        SceneManager.LoadScene("Hakkinda", LoadSceneMode.Additive);
    }

    public void cikis(){
        Application.Quit();
    }
}
