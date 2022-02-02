using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Script Parameters
	public GameObject impactEffect;
	public float Speed = 70f;
	public float ExplosionRadius = 0f;
    #endregion

    #region Fields
    private Transform target;
    #endregion

    #region Unity Methods
	void Update()
	{

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float currentDistance  = Speed * Time.deltaTime;

		if (dir.magnitude <= currentDistance)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * currentDistance, Space.World);
		transform.LookAt(target); 

	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
	}
	#endregion

	#region Methods
	public void Seek(Transform _target)
	{
		target = _target;
	}
    #endregion

    #region Implementations
    void HitTarget()
	{
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
		if (ExplosionRadius > 0f)
		{
			Explode();
		}
		else
		{
			Damage(target, TurretType.MachineGun);
		}
        Destroy(gameObject);
	}

	void Damage(Transform enemy, TurretType from)
    {
		Enemy e = enemy.GetComponent<Enemy>();
		if(e != null)
			e.TakeDamage(GameManager.sIntance.configuration.GetHitDamage(e.Type, from), from);
    }

	void Explode()
    {
		Collider[] hitObjects = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider hitObject in hitObjects)
        {
			if(hitObject.tag == "Enemy")
            {
				Damage(hitObject.transform, TurretType.MissleLauncher);
            }
        }
    }
    #endregion
}
