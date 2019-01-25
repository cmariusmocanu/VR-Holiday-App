using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wellcome : MonoBehaviour {

    public GameObject wellcome;

    // Update is called once per frame
    void Update () {

        Event e = Event.current;
        if (e.isKey)
        {
            Destroy(wellcome);
        }

    }
}
