using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startUI : MonoBehaviour
{

    public GameObject start_UI;

    public Button startButton;
    // Start is called before the first frame update

    public void StartButtonClick()
    {
        SceneManager.LoadScene("게임화면");
    }
}
