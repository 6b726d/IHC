using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCounter : MonoBehaviour
{
    public GameObject Player;
    public int Books = 0;
    public int TBooks = 1;

    void OnTriggerEnter(Collider CBook)
    {
        if (CBook.gameObject.tag == "Book")
        {
            Books += 1;
            Debug.Log("A book was picked up. Total books = " + Books);
            Destroy(CBook.gameObject);
        }
    }

    void OnGUI()
    {
        if (Books < TBooks)
        {
            GUI.Box(new Rect((Screen.width/2)-100,10,200,35), "" + Books + " Books");
        }
        else
        {
            Player.tag = "PlayerWin";
            GUI.Box(new Rect((Screen.width/2)-100,10,200,35), "All Books Collected");
        }
    }
}
