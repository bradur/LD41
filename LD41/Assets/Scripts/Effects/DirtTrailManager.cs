// Date   : 21.04.2018 14:24
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DirtTrailManager : MonoBehaviour
{

    [SerializeField]
    private DirtTrail dirtTrailPrefab;

    private List<DirtTrail> activeTrails = new List<DirtTrail>();
    private List<DirtTrail> inactiveTrails = new List<DirtTrail>();

    /*private DirtTrail SpawnTrail (Transform target)
    {
        DirtTrail dirtTrail = Instantiate(dirtTrailPrefab);
        dirtTrailPrefab.Initialize(target);
        return dirtTrail;
    }*/

    public void SpawnTrail(Transform target)
    {
        DirtTrail dirtTrail = Instantiate(dirtTrailPrefab, target.position, dirtTrailPrefab.transform.rotation, transform);
        dirtTrail.Initialize(target, transform);
        activeTrails.Add(dirtTrail);
    }

    public void StopAllTrails()
    {
        for(int i = activeTrails.Count - 1; i >= 0; i-=1)
        {
            DirtTrail trail = activeTrails[i];
            trail.Stop();
            activeTrails.Remove(trail);
            inactiveTrails.Add(trail);
        }
    }

    public void ClearAllTrails()
    {
        for (int i = inactiveTrails.Count - 1; i >= 0; i -= 1)
        {
            Destroy(inactiveTrails[i].gameObject);
        }
        inactiveTrails.Clear();
    }

}
