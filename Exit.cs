using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject Player;
    public bool BExit = false;
    public bool BWin = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetKeyDown(KeyCode.Q)) && (BExit == true) && (Player.tag == "PlayerWin") )
        {
            BWin = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerWin")
        {
            BExit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerWin")
        {
            BExit = false;
        }
    }

    private void OnGUI()
    {
        if (BWin == true)
        {
            GUI.Box(new Rect((Screen.width / 2) - 100, 50, 200, 35), "You Win");
        }
    }
}
