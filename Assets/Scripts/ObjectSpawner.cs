using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ObjectSpawner : MonoBehaviour
{
    ARRaycastManager raycastManager;
    GameObject spawnedObject;

    List<GameObject> placedPrefabList = new List<GameObject>();

    [SerializeField]
    GameObject placeablePrefab;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
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

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            SpawnPrefab(hitPose);
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
}
