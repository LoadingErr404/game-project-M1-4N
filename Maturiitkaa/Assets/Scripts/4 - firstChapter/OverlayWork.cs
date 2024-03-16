using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayWork : MonoBehaviour
{
    public bool showYourself;

    [SerializeField] private GameObject picture;
    [SerializeField] private GameObject objectToSetActive;
    
    // Start is called before the first frame update
    private void Start()
    {
        picture.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!showYourself)
        {
            return;
        }
        
        picture.SetActive(true);
        StartCoroutine(WaitCoroutine());
        
    }
    
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3);
        picture.SetActive(false);
        objectToSetActive.SetActive(true);
    }
}
