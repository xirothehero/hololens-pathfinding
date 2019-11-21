using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayGenerator : MonoBehaviour
{
    
    [SerializeField] private Vector3[] coordinates;

    [SerializeField] private GameObject doorway;

    private List<GameObject> _doorList;
    
    // Start is called before the first frame update
    void Start() {
        _doorList = new List<GameObject>();
        CreateDoors();
        StartColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void CreateDoors() {
        foreach (Vector3 coord in coordinates)
        {
            var newDoor = Instantiate(doorway);
            newDoor.transform.position = coord;
            _doorList.Add(newDoor);
        }
    }

    private void StartColorChange() {
        foreach (GameObject door in _doorList)
        {
            float offsetTime = _doorList.FindIndex(d => d.Equals(door)) * 2.0f;
            door.GetComponent<DoorwayColorChange>().SetColorChange(offsetTime);
        }
    }
}
