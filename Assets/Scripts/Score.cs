using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] public TMP_Text _score;
    Coroutine cos;

    void Start()
    {
        cos = StartCoroutine(puanGetir());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator puanGetir(){

        using (UnityWebRequest www = UnityWebRequest.Get("https://xn--fatihdomu-wkb02e.com/puan-getir"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if(www.isDone){
                    string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    result = result.Substring(1, result.Length-2);
                    string[] values = result.Split(',');
                    result = "1) "+values[0]+"\n";
                    for(int i=1;i<values.Length;++i){
                        result += (i+1)+") "+values[i]+"\n";
                    }
                    _score.text = result;
                    StopCoroutine(cos);
                }
                
            }
        }
    }

    public void anaSayfa(){
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
    }
}
