using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Configrations")]
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private float trailDelay = 0.02f;
    [SerializeField] private float spawnEffectRate = 20f;
    [SerializeField] private Transform hitPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask toHit;

    private float timeToFire;
    private float timeToSpawnEffect;

    private AudioManger audioManger;
    private LineRenderer lr;

    private void Start()
    {
        audioManger = AudioManger.instance;
        lr = GetComponentInChildren<LineRenderer>();
    }

    #region Shooting.
    public void ShootInput(bool singleShot, bool autoShot)
    {
        if (fireRate == 0)
        {
            if (singleShot)
            {
                StartCoroutine( Shoot() );
            }
        }
        else
        {
            if (autoShot && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1f / fireRate;
                StartCoroutine( Shoot() );
            }
        }
    }

    private IEnumerator Shoot()
    {
        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		float mousePoxY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		Vector2 mousePos = new Vector2(mousePosX, mousePoxY);

		Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);

		RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePos - firePointPos, 100f, toHit);

		Debug.DrawLine(firePointPos, (mousePos - firePointPos ) * 100,Color.green);

		if (hit.collider != null && hit.collider.gameObject != gameObject)
		{
			Debug.DrawLine(firePointPos, hit.point, Color.red);

            lr.SetPosition(0, firePointPos);
            lr.SetPosition(1, hit.point);

            minionhealth minionhealth = hit.collider.GetComponent<minionhealth>();

            if(minionhealth != null && !minionhealth.phase)
            {
                minionhealth.health--;
                minionhealth.phase = true;
            }
		}
        else
        {
            lr.SetPosition(0, firePointPos);
            lr.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1f / spawnEffectRate;
        }
        
        lr.enabled = true;
        yield return new WaitForSeconds(trailDelay);
        lr.enabled = false;
    }

    private void Effect()
    {
        audioManger.Play("Shot");
    }
    #endregion
}