using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GhostSelector : NetworkBehaviour
{
    public GameObject Player;
    public Material Highlight;
    public Material Default;
    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.tag == "Human")
        {
            if (_selection != null)
            {
                var selectionRenderer = _selection.GetComponent<Renderer>();
                if (selectionRenderer.CompareTag("Ghost"))
                {
                    selectionRenderer.material = Default;
                }
                _selection = null;
            }
            var ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                var selection = hit.transform;
                if (selection.CompareTag("Ghost"))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        selectionRenderer.material = Highlight;
                        if (Input.GetKeyDown(KeyCode.I))
                        {
                            GameObject Ghost = hit.collider.gameObject;
                            //SpawnGhost ghosts = Player.GetComponent<SpawnGhost>();
                            GameObject GhostMaster = GameObject.FindWithTag("GhostMaster");
                            SpawnGhost ghosts = GhostMaster.GetComponent<SpawnGhost>();
                            if (ghosts != null)
                            {
                                ghosts.DeleteGhost();
                                Debug.Log("DGhost");
                            }
                            //Destroy(Ghost);
                            CmdDestroyGhost(Ghost);
                            Debug.Log("Delete Ghost");
                        }
                    }
                    _selection = selection;
                }
            }
        }
    }

    [Command]
    void CmdDestroyGhost(GameObject obj)
    {
        //if (!obj) return;
        NetworkServer.Destroy(obj);
    }
}
