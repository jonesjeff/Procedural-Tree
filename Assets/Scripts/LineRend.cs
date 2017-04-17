using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRend : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;

    private LineRenderer line;
    private Force[] textObjects;

	// Use this for initialization
	void Start () {
        textObjects = FindObjectsOfType(typeof(Force)) as Force[];

        line = this.GetComponent<LineRenderer>();
        line.numPositions = textObjects.Length;
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < textObjects.Length; i++)
        {
            line.SetPosition(i, textObjects[i].gameObject.transform.position);
        }

    }
}
