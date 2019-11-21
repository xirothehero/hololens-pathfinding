using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChange : MonoBehaviour {

    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite closeSprite;
    [SerializeField] private SpriteRenderer renderer;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Main Camera")) {
            return;
        }
        renderer.sprite = closeSprite;
    }

    public void OnTriggerExit(Collider other) {
        if (!other.tag.Equals("Main Camera")) {
            return;
        }
        renderer.sprite = normalSprite;
    }
}
