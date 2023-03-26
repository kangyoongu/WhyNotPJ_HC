using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Plus")
        {
            other.gameObject.SetActive(false);
            this.transform.localScale += new Vector3(.1f, .1f, .1f);
            Invoke("MinusSize", 3);
            Debug.Log("Minus");
            
        }
        if (other.gameObject.tag == "Minus")
        {
            other.gameObject.SetActive(false);
            this.transform.localScale -= new Vector3(.1f, .1f, .1f);
            Invoke("PlusSize", 3);
            Debug.Log("Plus");
           
        }
    }
    void MinusSize()
    {
        this.transform.localScale -= new Vector3(.1f, .1f, .1f);
    }

    void PlusSize()
    {
        this.transform.localScale += new Vector3(.1f, .1f, .1f);
    }
    
}
