using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionManager : MonoBehaviour
{   //thanks to infallible code on youtube for the guide
    public string selectableTag = "Selectable";
    public Material selectedMaterial;
    public Material defaultMaterial;
    public GameObject tempobj;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;

    public Camera cam1;
    public Camera cam2;
    public Camera camInUse;

    public int collected;
    public TextMeshProUGUI infotext;

    public Image fader;

    private Transform _selection;

    void Start()
    {
        camInUse = cam1;
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null){
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = camInUse.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitobject;
        if(Physics.Raycast(ray, out hitobject))
        {
            var selection = hitobject.transform;
            tempobj = hitobject.collider.gameObject;
            if(selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null ){
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = selectedMaterial;
                }
                _selection = selection;

                if (Input.GetMouseButtonDown(0)){
                    tempobj.SetActive(false);
                    collected += 1;
                    if( collected ==1)
                    {
                        infotext.text = "this rain really sucks...";
                        obj2.SetActive(true);
                    }

                    if (collected == 2)
                    {
                        infotext.text = "the car outside seems to be out of fuel...";
                        obj3.SetActive(true);
                    }
                    if (collected == 3)
                    {
                        infotext.text = "not the right kind of fuel tank...";
                        obj4.SetActive(true);
                    }
                    if (collected == 4)
                    {
                        infotext.text = "This'll work but where are the keys...";
                        obj5.SetActive(true);
                    }
                    if (collected == 5)
                    {
                        infotext.text = "I need to leave now...";
                    }
                    if (collected == 6)
                    {
                        infotext.text = "...";
                        cam2.enabled = true;
                        camInUse = cam2;
                        cam1.enabled = false;
                        StartCoroutine(fadeout());

                    }
                    //infotext.text = "collected: " + collected;
                }
            }
        }

        
    }

    IEnumerator fadeout()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("happening");
        for(float i = 0; i <= 1.1; i += 0.1f )
        {
            yield return new WaitForSeconds(0.1f);
            fader.color = new Color(fader.color.r, fader.color.g, fader.color.b, i);
            Debug.Log(i);
        }
    }
}
