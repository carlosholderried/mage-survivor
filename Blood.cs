using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(30f);
		Destroy(gameObject);
	}
}
