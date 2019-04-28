using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    Vector3 startpos;
    Vector3 endpos;

    float radiusRange = .1f;

    public GameObject explosion;
    public GameObject spherecastpoint;

    int bulletID;

    public float castdisttest = .1f;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DeterminePlayer();
        if (bulletID == 0)
        {
            endpos = PlayerMovement.gizmosPoint0;
        }
        if (bulletID == 1)
        {
            endpos = PlayerMovement.gizmosPoint1;
        }
    }

    void DeterminePlayer()
    {
        if (this.gameObject.name[0] == '0')
        {
            bulletID = 0;
        }
        if (this.gameObject.name[0] == '1')
        {
            bulletID = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, endpos, Time.deltaTime * 30);

        //if ((transform.position == endpos))
        //{
        //    //Debug.Log("boomer");
        //    Instantiate(explosion, transform.position, Quaternion.identity);
        //    Destroy(this.gameObject);
        //}


        if ((transform.position.x >= endpos.x - radiusRange && transform.position.x <= endpos.x + radiusRange) &&
            (transform.position.z >= endpos.z - radiusRange && transform.position.z <= endpos.z + radiusRange))
        {
            Boolhub.screenShaking = true;
            DestroyOnCollision();
            //Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void DestroyOnCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, .3f);

            foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Player")
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                hitCollider.gameObject.GetComponent<HitTarget>().enabled = false;
            }
        }
    }
}
