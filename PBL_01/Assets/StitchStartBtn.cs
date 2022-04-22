using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StitchStartBtn : MonoBehaviour
{
    public GameObject parent; //±×¸®µå

    // Start is called before the first frame update
    void Start() {
        parent.transform.gameObject.GetComponent<LockPattern>().enabled = false;
    }

    // Update is called once per frame
    public void Onclick() {
        this.gameObject.SetActive(false);
        parent.transform.gameObject.GetComponent<LockPattern>().enabled = true;
    }
}
