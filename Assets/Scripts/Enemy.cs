using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool IsDead { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.IsDead)
        {
            return;
        }

        this.transform.localPosition += Vector3.back * Time.deltaTime;
    }

    public void Death()
    {
        this.IsDead = true;

        StartCoroutine(ScaleDown());
    }

    IEnumerator ScaleDown()
    {
        var startScale = this.transform.localScale;
        var scale = 1f;
        while (scale > 0f)
        {
            this.transform.localScale = scale * startScale;

            //1フレーム待つ
            yield return null;

            scale -= 0.03f;
        }

        Destroy(this.gameObject);
    }
}
