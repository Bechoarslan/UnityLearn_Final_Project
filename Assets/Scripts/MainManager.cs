using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public Text characterNameText;
   



    // Start is called before the first frame update
    void Start()
    {
       
       
        

        SelectedPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        characterNameText.text = DestroyOnLoad.Instance.characterName.text;
        
         



    }



    private void SelectedPlayer()
    {
        if (DestroyOnLoad.Instance.pressed == 0)
        {
            Instantiate(player1, LocalPosition(), transform.rotation);
        }
        else if (DestroyOnLoad.Instance.pressed == 1)
        {
            Instantiate(player2, LocalPosition(), transform.rotation);
        }
        else if (DestroyOnLoad.Instance.pressed == 2)
        {
            Instantiate(player3, LocalPosition(), transform.rotation);

        }
    }

    Vector3 LocalPosition()
    {
        Vector3 local = new Vector3(0, 0, 0);
        return local;
    }









    
}

