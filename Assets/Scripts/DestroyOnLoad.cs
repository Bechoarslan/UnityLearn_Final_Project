using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using UnityEngine.UI;

public class DestroyOnLoad : MonoBehaviour
{
    public static DestroyOnLoad Instance;
    public int pressed;
    public bool isStarted;
    public Text characterName;
    

    // Start is called before the first frame update
    void Awake()
    { 
        Instance = this;
         
        DontDestroyOnLoad(gameObject);
        
    }
    private void Update()
    {
        
    }



    // Update is called once per frame













}
