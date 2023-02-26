using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HoloMatSceneChange : MonoBehaviour
{
    [SerializeField] GameObject ar_gos;



    private void Awake()
    {
        LoaderUtility.Initialize();



        ar_gos.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
