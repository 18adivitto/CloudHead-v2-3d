using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    CharacterController mover;
    Vector3 input;
    float speed = 10;

    public int playerID;
    private Player player;

    Vector3 lookDirection;
    float angle;

    public static Vector3 gizmosPoint0;
    public static Vector3 gizmosPoint1;

    public GameObject bullet0;
    public GameObject bullet1;

    MeshRenderer MR;
    bool damaged = false;
    Collider playerCOLL;
    public GameObject nose;
    HitTarget HT;

    int health;
    TextMeshPro healthText;

    Vector3[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        HT = GetComponent<HitTarget>();
        MR = GetComponent<MeshRenderer>();
        playerCOLL = GetComponent<Collider>();
        DeterminePlayer();
        player = ReInput.players.GetPlayer(playerID);
        mover = GetComponent<CharacterController>();
        healthText = GetComponentInChildren<TextMeshPro>();

        HT.enabled = true;

        spawnPoints[0] = new Vector3(-19,1.6f,9);
        spawnPoints[1] = new Vector3(19, 1.6f, 9);
        spawnPoints[2] = new Vector3(-20, 1.6f, -9.7f);
        spawnPoints[3] = new Vector3(20 , 1.6f, -9.7f);
    }

    void DeterminePlayer()
    {
        if (this.gameObject.name == "Player")
        {
            playerID = 0;
        }
        if (this.gameObject.name == "Player1")
        {
            playerID = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();

        PlayerLook();

        if (mover.enabled)
        {
            mover.Move(input * Time.deltaTime * speed);
        }

        CharacterAim();
        ShootingInputs();

        Respawn();
        HealthTextDisplay();

        //Debug.Log("health for player" + playerID + ": " + health);
    }

    void PlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainGame");
        } //restart level

        input = new Vector3(player.GetAxis("Horizontal"),0, player.GetAxis("Vertical"));
    }

    void PlayerLook()
    {
        lookDirection = new Vector3(player.GetAxis("RightHor"), 0, player.GetAxis("RightVert"));
        angle = (Vector3.SignedAngle(Vector3.forward, lookDirection, transform.position));

        if (lookDirection.x != 0 && lookDirection.z != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, angle, 0)), Time.deltaTime * 30); //rotate
        }
        
    }

    void CharacterAim()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                //Debug.Log("Hit.point");
            }
        }

        if (playerID == 0)
        {
            gizmosPoint0 = hit.point;
        }
        if (playerID == 1)
        {
            gizmosPoint1 = hit.point;
        }
        

    }

    void ShootingInputs()
    {
        if (MR.enabled)
        {
            if (player.GetButtonDown("Fire"))
            {
                //Debug.Log("Bang!");
                if (playerID == 0)
                {
                    Instantiate(bullet0, transform.position, Quaternion.identity);
                }
                if (playerID == 1)
                {
                    Instantiate(bullet1, transform.position, Quaternion.identity);
                }


            }
        }
    }

    private void OnDrawGizmos() // debug crosshair
    {
        Gizmos.color = Color.red;

        if (playerID == 0)
        {
            Gizmos.DrawWireSphere(gizmosPoint0, .5f);
        }
        if (playerID == 1)
        {
            Gizmos.DrawWireSphere(gizmosPoint1, .5f);
        }

        
    }

    void Respawn()
    {
        if (!HT.enabled)
        {
            if (health >= 2)
            {
                health--;
                HT.enabled = true;
            }
            else
            {
                StartCoroutine("IGotHit");
            }
            
        }

        playerCOLL.enabled = MR.enabled;
        healthText.enabled = MR.enabled;
        mover.enabled = MR.enabled;
        nose.GetComponent<MeshRenderer>().enabled = MR.enabled;

        if (health <= 0)
        {
            //Debug.Log("Player " + playerID + " Loses!!");
            health = 2;
        }
    }

    void HealthTextDisplay()
    {
        healthText.text = health.ToString();
    }

    IEnumerator IGotHit()
    {
        HT.enabled = true;
        MR.enabled = false;
        health--;
        transform.position = spawnPoints[Random.Range(0,spawnPoints.Length)];
        yield return new WaitForSeconds(1);
        MR.enabled = true;
    }
}
