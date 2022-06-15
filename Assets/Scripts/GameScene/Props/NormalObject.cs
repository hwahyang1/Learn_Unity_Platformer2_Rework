using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Namespace] _20220531_Platform2Rework.GameScene.Props
 * EventProp의 상호작용을 관리합니다.
 */
namespace _20220531_Platform2Rework.GameScene.Props
{
	/*
	 * [Class] NormalObject
	 * 대사만 출력하는 오브젝트의 상호작용을 관리합니다.
	 */
	public class NormalObject : EventProp
	{
		[SerializeField]
		private List<string> scripts = new List<string>();

		[Header("해당 스크립트에서 takeItem/giveItem 변수는 사용되지 않습니다!!!!")]
		[SerializeField]
		private bool dummy;

		protected override void Start()
		{
			base.Start();

			for (int i = 0; i < scripts.Count; i++)
			{
				scripts[i] = scripts[i].Replace("\\n", "\n"); // 유니티 에디터 상에서 줄바꿈이 되지 않음.
			}
		}

		public override void OnInteract()
		{
			script.PrintScript(scripts.ToArray());
		}
	}
}
