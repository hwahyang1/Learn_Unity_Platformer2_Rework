using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220531_Platform2Rework.GameScene.Player;
using _20220531_Platform2Rework.GameScene.Managers;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Props
 * EventProp의 상호작용을 관리합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Props
{
	/*
	 * [Class] EventProp
	 * EventProp의 Child Class를 관할합니다.
	 */
	public abstract class EventProp : MonoBehaviour
	{
		[SerializeField]
		protected List<ItemCode> takeItem;

		[SerializeField]
		protected List<ItemCode> giveItem;

		private bool isUsed = false;

		private PlayerInventory playerInventory;

		protected virtual void Start()
		{
			playerInventory = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerInventory>();
		}

		protected abstract void OnInteract();
	}
}
