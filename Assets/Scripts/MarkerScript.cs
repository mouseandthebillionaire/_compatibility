using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    public bool onBeat = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("Beat"))
        {   
            onBeat = true;
        }
    }

    void OnTriggerExit(Collider collision){
        if (collision.gameObject.CompareTag("Beat"))
        {
            onBeat = false;
        }
    }
}
