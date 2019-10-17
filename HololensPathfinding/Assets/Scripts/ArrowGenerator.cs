using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour {

    [SerializeField] private Vector3[] coordinates;

    [SerializeField] private GameObject arrow;

    private List<GameObject> _arrowList;
    
    // Start is called before the first frame update
    void Start()
    {
        _arrowList = new List<GameObject>();
        CreateArrows();
        OrientArrows();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateArrows() {
        foreach (Vector3 coord in coordinates)
        {
            var newArrow = Instantiate(arrow);
            newArrow.transform.position = coord;
            _arrowList.Add(newArrow);
        }
    }

    private void OrientArrows() {
        for (int i = 0; i < (_arrowList.Count - 1); i++)
        {
            Vector3 distance = _arrowList[i + 1].transform.position - _arrowList[i].transform.position;
            Quaternion newRotation 
                = Quaternion.LookRotation(distance, Vector3.up) 
                  * Quaternion.Euler(0, -90, 0) * Quaternion.Euler(-90, 0, 0);
            _arrowList[i].transform.rotation = Quaternion.Normalize(newRotation);
        }
    }
}
