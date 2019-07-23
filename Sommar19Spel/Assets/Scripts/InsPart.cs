using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsPart : MonoBehaviour
{
    public ParticleSystem part;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ParticleSystem ps = Instantiate(part, gameObject.transform.position, Quaternion.identity);
            Destroy(ps, ps.main.duration);
        }
    }
}
