using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode[] player1Controls = { KeyCode.Q, KeyCode.W };
    public KeyCode[] player2Controls = { KeyCode.O, KeyCode.P };

    public GameObject circle1;
    public GameObject circle2;

    public float speed = .01f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(player1Controls[0]))
        {
            circle1.transform.position = new Vector3(circle1.transform.position.x + speed, circle1.transform.position.y, circle1.transform.position.z);
            AudioManager.S.SetFrequency(circle1.transform.localPosition.x);
        }
        if (Input.GetKey(player1Controls[1]))
        {
            circle1.transform.position = new Vector3(circle1.transform.position.x - speed, circle1.transform.position.y, circle1.transform.position.z);
            AudioManager.S.SetFrequency(circle1.transform.localPosition.x);
        }
        if (Input.GetKey(player2Controls[0]))
        {
            circle2.transform.position = new Vector3(circle2.transform.position.x + speed, circle2.transform.position.y, circle2.transform.position.z);
            AudioManager.S.SetLFOFreq(circle2.transform.localPosition.x);
        }
        if (Input.GetKey(player2Controls[1]))
        {
            circle2.transform.position = new Vector3(circle2.transform.position.x - speed, circle2.transform.position.y, circle2.transform.position.z);
            AudioManager.S.SetLFOFreq(circle2.transform.localPosition.x);
        }

    }
}
