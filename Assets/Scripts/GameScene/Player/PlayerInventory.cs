using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220531_Platform2Rework.GameScene.Managers;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Player
 * 플레이어와 관련한 내용들을 정의합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Player
{
	/*
	 * [Class] PlayerInventory
	 * 플레이어의 인벤토리를 관리합니다.
	 */
	public class PlayerInventory : MonoBehaviour
	{
		public byte inventorySize = 5;
		private ItemCode[] inventory;

		private void Start()
		{
			inventory = new ItemCode[inventorySize];
			TakeAllItem();
		}

		/*
		 * [Method] ShowItem(): ItemCode[]
		 * 현재 플레이어의 인벤토리 목록을 반환합니다.
		 * 
		 * <RETURN: ItemCode[]>
		 * 플레이어의 인벤토리 목록입니다.
		 */
		public ItemCode[] ShowItem()
		{
			return inventory;
		}

		/*
		 * [Method] GiveItem(ItemCode item): int
		 * 플레이어에게 특정 아이템을 지급합니다.
		 * 
		 * <ItemCode item>
		 * 플레이어에게 지급할 아이템을 입력합니다.
		 * 
		 * <RETURN: int>
		 * 성공 여부를 반환합니다.
		 * 0: 지급 성공. 플레이어에게 성공적으로 아이템을 지급 한 경우 반환됩니다.
		 * 1: 지급 실패. 인벤토리가 꽉 찬 경우 반환됩니다.
		 * -1: 정상적인 경우 발생 할 수 없는 값입니다.
		 */
		public int GiveItem(ItemCode item)
		{
			for (byte i = 0; i < inventorySize; i++)
			{
				if (inventory[i] == ItemCode.None)
				{
					inventory[i] = item;
					return 0;
				}
				if (i == inventorySize - 1)
				{
					return 1;
				}
			}
			return -1;
		}

		/*
		 * [Method] TakeItem(ItemCode item): int
		 * 플레이어에게서 특정 아이템을 회수합니다.
		 * 
		 * <ItemCode item>
		 * 플레이어에게서 회수할 아이템을 입력합니다.
		 * 
		 * <RETURN: int>
		 * 성공 여부를 반환합니다.
		 * 0: 회수 성공. 플레이어에게 성공적으로 아이템을 회수 한 경우 반환됩니다.
		 * 1: 회수 실패. 인벤토리에 대상 아이템이 없는 경우 반환됩니다.
		 * -1: 정상적인 경우 발생 할 수 없는 값입니다.
		 */
		public int TakeItem(ItemCode item)
		{
			for (byte i = 0; i < inventorySize; i++)
			{
				if (inventory[i] == item)
				{
					inventory[i] = ItemCode.None;
					return 0;
				}
				if (i == inventorySize - 1)
				{
					return 1;
				}
			}
			return -1;
		}

		/*
		 * [Method] TakeItem(): void
		 * 플레이어의 모든 아이템을 회수합니다.
		 */
		public void TakeAllItem()
		{
			for (byte i = 0; i < inventorySize; i++)
			{
				inventory[i] = ItemCode.None;
			}
		}
	}
}

