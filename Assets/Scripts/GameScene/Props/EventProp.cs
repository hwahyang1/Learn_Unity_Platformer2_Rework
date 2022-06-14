using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220531_Platform2Rework.GameScene.Player;
using _20220531_Platform2Rework.GameScene.Managers;
using _20220531_Platform2Rework.GameScene.UI;

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
		protected List<ItemCode> _takeItem;
		protected ItemCode[] takeItem;

		[SerializeField]
		protected List<ItemCode> _giveItem;
		protected ItemCode[] giveItem;

		protected bool isUsed = false;

		protected PlayerInventory playerInventory;
		protected ShowScript script;

		protected virtual void Start()
		{
			playerInventory = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerInventory>();
			script = GameObject.FindGameObjectWithTag("Scripter").gameObject.GetComponent<ShowScript>();

			takeItem = _takeItem.ToArray();
			giveItem = _giveItem.ToArray();
		}

		public abstract void OnInteract();

		/*
		 * [Method] getItemNames(ItemCode[] item): string
		 * 아이템의 이름을 자연스럽게 바꿔줍니다.
		 * 
		 * <ItemCode[] item>
		 * 반환받고 싶은 아이템의 목록을 전달합니다.
		 * 
		 * <RETURN: string>
		 * 아이템의 이름이 문장의 형식으로 반환됩니다.
		 */
		protected string getItemNames(ItemCode[] item)
		{
			string itemNames = "";

			for (int i = 0; i < item.Length; i++)
			{
				itemNames += ItemManager.Instance.GetItemName(item[i]);

				if (i == 0 && item.Length != 1)
				{
					itemNames += "(와)과 ";
				}
				else if (i != item.Length - 1)
				{
					itemNames += ", ";
				}
			}

			return itemNames;
		}
	}
}
