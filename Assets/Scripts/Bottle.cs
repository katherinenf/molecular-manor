using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public bool shouldBeClicked;
    public string chemicalName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BottleClick()
    {
        if (this.GetComponent<Bottle>().shouldBeClicked)
        {
            Destroy(this.gameObject);
        }
    }


}
