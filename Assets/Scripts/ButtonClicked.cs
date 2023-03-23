using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClicked : MonoBehaviour
{
    public Button[] playerSelectionButton = new Button[3];

    private static int SelectedButton;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerSelectionButton.Length; i++)
        {
            int closureIndex = i;
            Button btn = playerSelectionButton[i].GetComponent<Button>();
            playerSelectionButton[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));

        }
    }

    private void Update()
    {
        
    }

    // Update is called once per frame


    public void TaskOnClick(int buttonIndex)
    {

        DestroyOnLoad.Instance.pressed = buttonIndex;



    }

    public void NextScene()
    {
        SceneManager.LoadScene("Game");
        DestroyOnLoad.Instance.isStarted = true;
    }

    

    










    
}
