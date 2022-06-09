using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using _20220531_Platform2Rework.GameScene.Managers;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.UI
 * UI와 관련한 내용들을 정의합니다.
 */
namespace _20220531_Platform2Rework.GameScene.UI
{
	/*
	 * [Class] InventoryUI
	 * 인벤토리 UI를 제어합니다.
	 */
	public class InventoryUI : MonoBehaviour
	{
		private Image[] objects;

		private void Start()
		{
			int childCount = gameObject.transform.childCount;

			objects = new Image[childCount];

			for (int i = 0; i < childCount; i++)
			{
				objects[i] = gameObject.transform.GetChild(i).gameObject.GetComponent<Image>();
				objects[i].enabled = false;
			}
		}

		/*
		 * [Method] UpdateUI(ItemCode[] inventory): void
		 * 인벤토리 UI를 갱신합니다.
		 * 
		 * <ItemCode[] inventory>
		 * 현재 인벤토리 목록을 배열로 받습니다.
		 */
		public void UpdateUI(ItemCode[] inventory)
		{
			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i] == ItemCode.None)
				{
					objects[i].enabled = false;
					continue;
				}

				objects[i].enabled = true;
				objects[i].sprite = ItemManager.Instance.GetItemImage(inventory[i]);
			}
		}
	}
}
