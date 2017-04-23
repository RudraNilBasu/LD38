using UnityEngine;
using System.Collections;

public class EnergyReleaser : MonoBehaviour {

    static EnergyReleaser er;
    
    public static void ReleaseEnergy()
    {
        er.Kill();
    }

    void Kill()
    {
        gameObject.GetComponent<Animation>().Play();
    }
}
