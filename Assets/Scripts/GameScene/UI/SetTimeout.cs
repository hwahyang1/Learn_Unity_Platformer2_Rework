using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Class] SetTimeout
 * 지정된 시간 후 스크립트가 붙어있는 GameObject를 Destroy 시킵니다.
 */
public class SetTimeout : MonoBehaviour
{
	[SerializeField]
	private float setTimeout = 30f;

	private void Start()
	{
		StartCoroutine("DestroySelf");
	}

	private IEnumerator DestroySelf()
	{
		yield return new WaitForSeconds(setTimeout);
		Destroy(gameObject);
	}
}
