using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;

	void Awake()
	{
		Init();
	}

	protected virtual void Init()
    {
        if (Managers.Resource == null)
        {
            Debug.LogError("Managers.Resource가 null입니다. 초기화를 확인하세요.");
            return;
        }

        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
        {
            GameObject newEventSystem = Managers.Resource.Instantiate("UI/EventSystem");
            if (newEventSystem != null)
            {
                newEventSystem.name = "@EventSystem";
            }
            else
            {
                Debug.LogError("\"UI/EventSystem\" 리소스가 없습니다.");
            }
        }
    }

    public abstract void Clear();
}
