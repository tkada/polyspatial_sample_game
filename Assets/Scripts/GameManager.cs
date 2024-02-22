using System.Collections.Generic;
using Unity.PolySpatial.InputDevices;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class GameManager : MonoBehaviour
{
    [SerializeField] Enemy[] enemyPrefabs;
    [SerializeField] Transform spawnPoint;

    float elapsedTime = 0f;
    float nextSpawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
        SpawnEnemyUpdate();
    }

    void CheckTouch()
    {
        foreach (var touch in Touch.activeTouches)
        {
            var spatialPointerState = EnhancedSpatialPointerSupport.GetPointerState(touch);

            if (spatialPointerState.Kind == SpatialPointerKind.Touch)
                continue;

            var pieceObject = spatialPointerState.targetObject;
            if (pieceObject != null)
            {
                if (pieceObject.TryGetComponent<Enemy>(out var enemy))
                {
                    if (enemy.IsDead == false)
                    {
                        enemy.Death();

                        SpawnEnemy();

                        //5%ずつ生成速度が上がる
                        //ただし0.2sec未満にはならない
                        this.nextSpawnTime = Mathf.Max(0.2f, this.nextSpawnTime * 0.95f);
                    }
                }
            }
        }
    }

    void SpawnEnemyUpdate()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime < this.nextSpawnTime)
        {
            return;
        }

        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        var enemy = Instantiate(this.enemyPrefabs[Random.Range(0, this.enemyPrefabs.Length)]);
        enemy.transform.position = this.spawnPoint.position + Random.Range(-2f, 2f) * Vector3.right;

        this.elapsedTime = 0f;
    }
}
