using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class WorkingWithTextFiles : MonoBehaviour
{

    private string [] _textFromFile;
    [SerializeField] private TextAsset _myFile;

    private int _int;
    
    // Start is called before the first frame update
    void Start()
    {
        var _path="";
        _path = AssetDatabase.GetAssetPath(_myFile);
        try
        {
            File.Open(_path, FileMode.Open);
            _textFromFile = File.ReadAllLines(_path);
        }
        catch (Exception e)
        {
            Debug.Log("File didn't open");
        }
       
        
        _int = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_int < 2)
        {
            Debug.Log(_textFromFile[_int]);
            _int++;
        }
    }
}
