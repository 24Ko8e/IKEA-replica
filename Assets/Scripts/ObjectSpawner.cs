using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectSpawner : MonoBehaviour
{
    ARRaycastManager raycastManager;
    GameObject spawnedObject;

    List<GameObject> placedPrefabList = new List<GameObject>();

    [HideInInspector]
    public GameObject selectedObject;

    [SerializeField]
    GameObject placeablePrefab;

    [SerializeField]
    GameObject plane;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Start()
    {
        plane.transform.Translate(Vector3.down * 1.7f);
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                touchPosition = default;
                return false;
            }
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "Spawnable")
            {
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<EditableObject>().DisableEditor();
                }
                selectedObject = hit.collider.gameObject;
                selectedObject.GetComponent<EditableObject>().EnableEditor();
                ObjectManager._instance.state = ObjectManager.State.ObjectEdit;
            }
            else if (hit.collider.tag == "Plane")
            {
                //if (ObjectManager._instance.state == ObjectManager.State.ObjectPlacement)
                //{
                //    var hitPose = hits[0].pose;
                //    SpawnPrefab(hitPose);
                //}
                SpawnPrefab(hit.point);
            }
        }
    }

    public void SetSpawnableObject(GameObject prefab)
    {
        placeablePrefab = prefab;
    }

    public void SpawnPrefab(Pose pose)
    {
        if (placeablePrefab != null)
        {
            spawnedObject = Instantiate(placeablePrefab, pose.position, pose.rotation);
            placedPrefabList.Add(spawnedObject);
        }
    }
    
    public void SpawnPrefab(Vector3 position)
    {
        if (placeablePrefab != null)
        {
            spawnedObject = Instantiate(placeablePrefab, position, Quaternion.identity);
            placedPrefabList.Add(spawnedObject);
        }
    }
}
