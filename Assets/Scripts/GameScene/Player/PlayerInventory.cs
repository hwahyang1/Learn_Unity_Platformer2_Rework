using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220531_Platform2Rework.GameScene.Managers;
using _20220531_Platform2Rework.GameScene.UI;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Player
 * 플레이어와 관련한 내용들을 정의합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Player
{
	/*
	 * [Class] PlayerInventory
	 * 플레이어의 인벤토리를 관리합니다.
	 * 인벤토리 UI의 갱신 타이밍 또한 관리합니다.
	 */
	public class PlayerInventory : MonoBehaviour
	{
		[SerializeField]
		private InventoryUI inventoryUI;

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
		 * [Method] HasItem(ItemCode item): bool
		 * 플레이어가 특정 아이템을 소지하고 있는지 여부를 반환합니다.
		 * 
		 * <ItemCode item>
		 * 조회할 아이템을 입력합니다.
		 * 
		 * <RETURN: bool>
		 * 플레이어가 특정 아이템을 소지하고 있는지 여부를 반환합니다.
		 */
		public bool HasItem(ItemCode item)
		{
			for (int i = 0; i < inventory.Length; i++)
			{
				if (inventory[i] == item)
				{
					return true;
				}
			}

			return false;
		}

		/*
		 * [Method] GiveItem(ItemCode[] item): int
		 * 플레이어에게 특정 아이템을 지급합니다.
		 * 
		 * <ItemCode[] item>
		 * 플레이어에게 지급할 아이템을 입력합니다.
		 * 
		 * <RETURN: int>
		 * 오류 여부를 반환합니다.
		 * 0: 지급 성공. 플레이어에게 성공적으로 아이템을 지급 한 경우 반환됩니다.
		 * 1: 지급 실패. 인벤토리가 꽉 찬 경우 반환됩니다. (인벤토리의 빈칸이 지급할 아이템의 수보다 적은 경우에도 반환됩니다.)
		 */
		public int GiveItem(ItemCode[] item)
		{
			byte availableSlotsCount = 0;
			byte[] availableSlots = new byte[inventorySize]; // 몇 번째 칸이 비었는지

			for (byte i = 0; i < inventorySize; i++)
			{
				if (inventory[i] == ItemCode.None)
				{
					availableSlots[availableSlotsCount] = i;
					availableSlotsCount++;
				}
			}

			if (item.Length > availableSlotsCount)
			{
				return 1;
			}

			for (int i = 0; i < item.Length; i++)
			{
				inventory[availableSlots[i]] = item[i];
			}

			inventoryUI.UpdateUI(inventory);

			return 0;
		}

		/*
		 * [Method] TakeItem(ItemCode[] item): int
		 * 플레이어에게서 특정 아이템을 회수합니다.
		 * 
		 * <ItemCode[] item>
		 * 플레이어에게서 회수할 아이템을 입력합니다.
		 * 
		 * <RETURN: int>
		 * 오류 여부를 반환합니다.
		 * 0: 회수 성공. 플레이어에게 성공적으로 아이템을 회수 한 경우 반환됩니다.
		 * 1: 회수 실패. 인벤토리에 대상 아이템이 없는 경우 반환됩니다. (대상 아이템이 한개 이상 없으면 아이템을 회수하지 않고 해당 값을 반환합니다.)
		 */
		public int TakeItem(ItemCode[] item)
		{
			// 1. 인벤을 스캔, item과 대조해서 일치하는 슬롯이 있으면 다른 변수에 위치를 백업 (대조에 성공한 아이템은 item 변수에서 ItemCode.None 처리)
			// 2. item 변수에 ItemCode.None이 전부 있는지 확인
			// 2-1. 전부 None이면 위치를 백업한 변수를 통해 아이템 회수
			// 2-2. None이 아닌 코드가 하나라도 있으면 회수하지 않고 -1 반환.

			ItemCode[] targetItems = new ItemCode[item.Length];
			for (int i = 0; i < item.Length; i++)
			{
				targetItems[i] = item[i];
			}

			byte targetSlotsCount = 0;
			byte[] targetSlots = new byte[targetItems.Length];

			for (byte i = 0; i < inventorySize; i++) // 인벤
			{
				for (byte j = 0; j < targetItems.Length; j++) // 대상 템
				{
					if (inventory[i] == ItemCode.None)
					{
						continue;
					}

					if (inventory[i] == targetItems[j])
					{
						bool isDuplicate = false;

						for (int k = 0; k < targetSlotsCount; k++) // 같은 템을 여러개 회수 할 경우, 회수 대상 슬롯이 하나만 지정되는 문제 방지
						{
							if (targetSlots[targetSlotsCount] == i)
							{
								isDuplicate = true;
							}
						}

						if (isDuplicate) continue;

						targetItems[j] = ItemCode.None;
						targetSlots[targetSlotsCount] = i;
						targetSlotsCount++;
					}
				}
			}

			if (targetItems.Length != targetSlotsCount)
			{
				return 1;
			}

			for (byte i = 0; i < targetSlotsCount; i++)
			{
				inventory[targetSlots[i]] = ItemCode.None;
			}

			inventoryUI.UpdateUI(inventory);

			return 0;
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
			inventoryUI.UpdateUI(inventory);
		}
	}
}

