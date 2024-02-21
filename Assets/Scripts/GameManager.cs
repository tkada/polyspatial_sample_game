using System.Collections.Generic;
using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class GameManager : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var touch in Touch.activeTouches)
        {
            var spatialPointerState = EnhancedSpatialPointerSupport.GetPointerState(touch);

            if (spatialPointerState.Kind == SpatialPointerKind.Touch)
                continue;

            var pieceObject = spatialPointerState.targetObject;
            if(pieceObject != null)
            {
                if(pieceObject.TryGetComponent<Enemy>(out var enemy))
                {
                    Destroy(pieceObject);
                }
            }
        }
    }
}
