using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider : MonoBehaviour {

    public static float TEXT_PADDING_X = 0f;
    public static float TEXT_PADDING_Y = -.15f;

    private Renderer rend;
    private BoxCollider boxCollider;

    void OnEnable()
    {
        WordChange.OnWordChanged += UpdateCollider;
    }


    void OnDisable()
    {
        WordChange.OnWordChanged -= UpdateCollider;
    }

    // Use this for initialization
    void Start() {
        rend = this.GetComponent<Renderer>();
        boxCollider = (BoxCollider)gameObject.AddComponent(typeof(BoxCollider));
        UpdateCollider();
    }

    void UpdateCollider()
    {
        boxCollider.center = new Vector3(rend.bounds.extents.x - rend.bounds.size.x / 2, rend.bounds.extents.y - rend.bounds.size.y / 2, transform.position.z);
        boxCollider.size = new Vector3(rend.bounds.size.x + TEXT_PADDING_X, rend.bounds.size.y + TEXT_PADDING_Y, .1f);
    }
}
