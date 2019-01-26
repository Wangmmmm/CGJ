using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum EventEnum
{
	MatrixHit,
	MatrixDestroy,
}
public interface EventObserver
{
	void HandleEvent(EventData eventData);
}
public class EventSystem  {

	private Dictionary<EventEnum,List<EventObserver>> events = new Dictionary<EventEnum,List<EventObserver>>();
	public void RegisterEvent(EventEnum eventEnum,EventObserver observer)
	{
		if(!events.ContainsKey(eventEnum))
		{
			List<EventObserver> list =new List<EventObserver>{observer};
			events.Add(eventEnum,list);
		}
		else{
			foreach(EventObserver obj in events[eventEnum])
			{
				if(obj == observer)
				{
					Debug.Log("Already Add");
					return;
				}
			}
			events[eventEnum].Add(observer);
		}
	}

	public void UnRegisterEvent(EventEnum eventEnum,EventObserver observer)
	{
		if(!events.ContainsKey(eventEnum))
			return;
	

		List<EventObserver> list = events[eventEnum];
		bool find=false;
		foreach(EventObserver obj in events[eventEnum])
		{
			if(obj == observer)
			{
				find=true;
				break;
			}
		}
		if(find)
			list.Remove(observer);
		else{
			Debug.Log("no Add");
		}
	}
	public void Raise(EventData eventData)
	{
		if(!events.ContainsKey(eventData.eventType))
		{
			//Debug.Log("no listener");
			return;
		}
		foreach(EventObserver observer in events[eventData.eventType] )	
		{
			observer.HandleEvent(eventData);
		}
	}
}

public class EventData
{
	public EventEnum eventType;
	public object sender;
	public object param;
}