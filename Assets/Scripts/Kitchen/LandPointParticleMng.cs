using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandPointParticleMng : MonoBehaviour//着落点粒子特效管理
{
    public static LandPointParticleMng Instance;
    private void Awake() { Instance = this; }

    public GameObject landPointParticle;


    public void SetLandParticle(Vector3 landPoint)
    {
        if (!landPointParticle.active)
        {
            landPointParticle.SetActive(true);
        }
        landPointParticle.transform.position = landPoint;
    }

    public void DisableParticle()
    {
        landPointParticle.SetActive(false);
    }

}
