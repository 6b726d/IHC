using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public GameObject Ghost;
    public Transform Player;
    public float Speed = 2.0f;
    public float MinDist = 4.0f;
    public float MaxDist = 8.0f;
    public float BDist = 12.0f;
    public bool Detection = false;
    public bool BLose = false;
    public Vector3 ipos;

    // Start is called before the first frame update
    void Start()
    {
        ipos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        transform.LookAt(Player);
        if ( (Vector3.Distance(transform.position,Player.position) >= MinDist) &&
             (Vector3.Distance(transform.position, Player.position) <= MaxDist) )
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        else if (Vector3.Distance(transform.position, Player.position) > MaxDist)
        {
            transform.position = ipos;
        }
        else if (Vector3.Distance(transform.position, Player.position) < MinDist)
        {
            BLose = true;
        }
        //Detection
        if (Vector3.Distance(transform.position, Player.position) <= BDist)
        {
            Detection = true;
            Ghost.tag = "GhostT";
        }
        else
        {
            Detection = false;
            Ghost.tag = "GhostF";
        }
    }

    private void OnGUI()
    {
        if (BLose == true)
        {
            GUI.Box(new Rect((Screen.width / 2) - 100, 50, 200, 35), "You Lose");
        }
    }
}
