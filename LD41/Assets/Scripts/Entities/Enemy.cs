// Date   : 22.04.2018 08:33
// Project: LD41
// Author : bradur

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    private GroundSituation situation;

    void Start()
    {

    }

    void Update()
    {
        if (aiming)
        {
            aimTimer += Time.deltaTime;
            if (aimTimer > aimInterval)
            {
                Aim();
                aimTimer = 0f;
            }
        }
    }

    [SerializeField]
    private float aimInterval = 3f;
    private float aimTimer = 0f;


    private bool aiming = false;

    public void Initialize(Transform targetCamera, GroundSituation situation)
    {
        this.situation = situation;
        aiming = true;
        transform.forward = targetCamera.transform.position - transform.position;
        /*transform.LookAt(
            transform.position + targetCamera.transform.rotation * Vector3.forward,
            targetCamera.transform.rotation * Vector3.up
        );*/
    }

    public void Aim()
    {
        animator.SetTrigger("Aim");
    }

    public void Shoot()
    {
        Debug.Log(gameObject.name + " is shooting!");
        SoundManager.main.PlaySound(SoundType.EnemyShoot);
        GameManager.main.GetShot();
    }

    public void Die()
    {
        situation.EnemyDie(this);
        Destroy(gameObject);
    }
}
