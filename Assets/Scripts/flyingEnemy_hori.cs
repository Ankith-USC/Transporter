using UnityEngine;
using System.Collections;

public class flyingEnemy_hori : MonoBehaviour
{
    public static float enemy_flySpeed;
    private Transform thisTransform;
    private int moveDirX;
    private Vector3 movementnew;
	private Vector3 enemyPos;

    void Awake()
    {
        thisTransform = transform;
    }

    void Start()
    {
		enemyPos = thisTransform.position;
        moveDirX = 1;
        enemy_flySpeed = 3f;
    }

    void Update()
    {
        movementnew = new Vector3(moveDirX, 0f, 0f) * Time.deltaTime * enemy_flySpeed;
        thisTransform.Translate(movementnew.x, movementnew.y, 0f);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "player")
        {
            Player.alive = false;
        }

		if (xa.levelNumber == 3) {
			if (other.gameObject.name == "SuperMan") {
				gameObject.SetActive (false);
				Invoke ("activateEnemy", 5);
			}
		}

        if (other.gameObject.CompareTag("flyColl"))
        {
            moveDirX *= -1;
        }
    }

	void activateEnemy()
	{
		this.transform.position = new Vector3(enemyPos.x, enemyPos.y, enemyPos.z);
		gameObject.SetActive (true);
	}

}
