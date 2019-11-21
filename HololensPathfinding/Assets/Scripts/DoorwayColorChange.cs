using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayColorChange : MonoBehaviour {

    [SerializeField] private GameObject door;

    public Color MainColor {
        get => door.GetComponent<Renderer>().material.color;
        set => door.GetComponent<Renderer>().material.color = value;
    }
    
    // Start is called before the first frame update
    void Start() {
        MainColor = Color.green;
    }

    void Update() {
        
    }

    void OnTriggerEnter(Collider collider) {
        MainColor = Color.white;
        StopAllCoroutines();
    }

    public void SetColorChange(float time) {
        StartCoroutine(ColorChangeSequence(time));
    }

    private IEnumerator ColorChangeSequence(float time) {
        yield return new WaitForSeconds(time);
        Color currentColor = MainColor;
        yield return ColorChange(currentColor, Color.yellow);
        currentColor = MainColor;
        yield return ColorChange(currentColor, Color.red);
    }

    private IEnumerator ColorChange(Color color1, Color color2) {
        Color lerpedColor = color1;
        float maxTime = 3.0f;
        float currentTime = 0.0f;
        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            lerpedColor = Color.Lerp(color1, color2, (currentTime/maxTime));
            MainColor = lerpedColor;
            yield return null;
        }
    }
}
