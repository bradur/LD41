// Date   : 22.04.2018 08:33
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    private GroundSituation situation;

    void Start () {

    }

    void Update () {
    
    }

    public void Initialize(Transform targetCamera, GroundSituation situation)
    {
        this.situation = situation;
        Aim();
        transform.LookAt(
            transform.position + targetCamera.transform.rotation * Vector3.forward,
            targetCamera.transform.rotation * Vector3.up
        );
    }

    public void Aim()
    {
        animator.SetTrigger("Aim");
    }

    public void Shoot()
    {
        Debug.Log("pew!");
        Aim();
    }

    public void Die()
    {
        situation.EnemyDie(this);
        Destroy(gameObject);
    }
}
