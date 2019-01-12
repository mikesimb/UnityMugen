﻿/*
 * 简易时钟
 */

using System;
using System.Collections;
using System.Collections.Generic;
using Utils;

public interface ITimerOnce
{
	bool IngoreScaleTime
	{
		get;
	}

	bool IsPlaying
	{
		get;
	}

	bool IsPlayOnce
	{
		get;
	}

	System.Object UserData
	{
		get; set;
	}

	float PerTime
	{
		get; set;
	}

	void AddListener(Timer.OnTimerEvent listener);

	void ClearAllListener();

	bool ContainsEvent(Timer.OnTimerEvent evt);

	void RemoveListener(Timer.OnTimerEvent listener);

	void Dispose();

	void Start();
}

public interface ITimer: ITimerOnce
{
	//void Stop();
}

public class Timer : DisposeObject, ITimer
{
    public delegate void OnTimerEvent(Timer obj, float timer);

    //
    // Properties
    //
    public bool IngoreScaleTime
    {
        get
        {
            return m_IngoreScaleTime;
        }
    }

    public bool IsPlaying
    {
        get
        {
            return m_IsPlaying;
        }
    }

    public bool IsPlayOnce
    {
        get
        {
            return m_IsPlayOnce;
        }
    }

    public System.Object UserData
    {
        get
        {
            return m_UserData;
        }
        set
        {
            m_UserData = value;
        }
    }

    //
    // Constructors
    //
    public Timer(bool isOnce, float delayTime, bool ingoreScaleTime)
    {
        m_TimerNode = new LinkedListNode<Timer>(this);
		Init (isOnce, delayTime, ingoreScaleTime);
    }

	public Timer()
	{
		m_TimerNode = new LinkedListNode<Timer>(this);
	}

	public void Init(bool isOnce, float delayTime, bool ingoreScaleTime)
	{
		m_IsPlayOnce = isOnce;
		m_PerTime = delayTime;
		m_IngoreScaleTime = ingoreScaleTime;
		m_IsDispose = false;
		m_IsRuned = false;
	}

	public void PoolReset()
	{
		ClearAllListener();
		m_UserData = null;
	//	m_IsDispose = false;
		m_IsRuned = false;
		Stop();
	}

    //
    // Methods
    //
    public void AddListener(Timer.OnTimerEvent listener)
    {
        m_EventHandler += listener;
    }

	public bool ContainsEvent(Timer.OnTimerEvent evt)
	{
		if (evt == null)
			return false;
		Delegate[] evts = m_EventHandler.GetInvocationList();
		if (evts == null || evts.Length <= 0)
			return false;
		for (int i = 0; i < evts.Length; ++i)
		{
			Timer.OnTimerEvent curEvt = evts [i] as Timer.OnTimerEvent;
			if (evt == curEvt)
				return true;
		}

		return false;
	}

    public void ClearAllListener()
    {
        if (m_EventHandler != null)
        {
            m_EventHandler = null;
        }
    }

	internal bool IsUsePool
	{
		get;
		set;
	}

	public override void Dispose()
	{
		if (IsUsePool)
			Dispose(true);
		else
			base.Dispose();
	}

	public bool IsDispose
	{
		get {
			return m_IsDispose;
		}
	}

    protected override void OnFree(bool isManual)
    {
		if (isManual && IsUsePool)
		{
			//TimerMgr.Instance._TimerToPool(this);
			if (m_IsPlaying)
				m_IsRuned = false;
			else
				TimerMgr.Instance._TimerToPool(this);
			return;
		}

        ClearAllListener();
        m_UserData = null;
        if (m_TimerNode != null)
        {
            if (m_IsPlaying)
            {
                TimerMgr.Instance._RemovePlayerList(m_TimerNode);
            }
            m_TimerNode = null;
        }
    }

    public void RemoveListener(Timer.OnTimerEvent listener)
    {
        m_EventHandler -= listener;
    }

    public void Start()
    {
        if (m_IsPlaying)
        {
            return;
        }
        m_IsPlaying = true;
        m_DelayTime = m_PerTime;
        OnStart();
    }

	private void Stop()
    {
        if (m_IsPlaying)
        {
            OnStop();
            m_IsPlaying = false;
            m_DelayTime = 0f;
        }
    }

    private void OnStart()
    {
        if (m_TimerNode != null)
        {
            TimerMgr.Instance._AddToPlayerList(m_TimerNode);
        }
    }

    private void OnStop()
    {
        if (m_TimerNode != null)
        {
            TimerMgr.Instance._RemovePlayerList(m_TimerNode);
        }
    }


    public void Tick(float delta)
    {
        if (m_DelayTime - delta <= 0f)
        {
            if (m_EventHandler != null)
            {
				// 因为有可能在Timer回调里产生Timer,所以增加一个判断，
				// 防止里面创建后被删除
				m_IsRuned = true;
				delta = m_PerTime - (m_DelayTime - delta);
                m_EventHandler(this, delta);
			} else
				m_IsRuned = true;

			if (!m_IsRuned)
				return;
			
            if (m_IsPlayOnce)
            {
                Stop();
                Dispose();
            }
            else
            {
                m_DelayTime = m_PerTime;
            }
        }
        else
        {
            m_DelayTime -= delta;
        }
    }

	public float PerTime
	{
		get
		{
			return m_PerTime;
		}

		set
		{
			m_PerTime = value;
		}
	}

    private event Timer.OnTimerEvent m_EventHandler = null;
    private float m_DelayTime = 0;
    private bool m_IsPlayOnce = true;
    private float m_PerTime = 0;
    private System.Object m_UserData = null;
    private bool m_IsPlaying = false;
    private bool m_IngoreScaleTime = false;
    private LinkedListNode<Timer> m_TimerNode = null; 
	// 是否已经运行过了
	private bool m_IsRuned = false;
}


public class TimerMgr : Singleton<TimerMgr>
{
	public TimerMgr()
	{
		m_Pool.Init(50, null, PoolReset);
	}

	private void PoolReset(Timer time)
	{
		if (time != null)
			time.PoolReset();
	}
		          
    //
    // Methods
    //
    public void _AddToPlayerList(LinkedListNode<Timer> node)
    {
        if (node == null)
        {
            return;
        }
        if (node.Value.IngoreScaleTime)
        {
            m_UnScaledPlayerList.AddFirst(node);
        }
        else
        {
            m_PlayerList.AddFirst(node);
        }
    }

	internal void _TimerToPool(Timer timer)
	{
		if (timer == null)
			return;
		m_Pool.Store(timer);
	}

    public void _RemovePlayerList(LinkedListNode<Timer> node)
    {
        if (node == null)
        {
            return;
        }

		var list = node.List;
		if (list != null)
			list.Remove(node);
    }
/*
	public ITimerOnce CreateOnceTimer(float delayTime, bool isRuning, bool ingoreScaleTime = false)
	{
		return CreateTimer(true, delayTime, isRuning, ingoreScaleTime);
	}
*/

	public ITimer CreateTimer(float delayTime, bool isRuning, bool ingoreScaleTime = false)
	{
		return CreateTimer(false, delayTime, isRuning, ingoreScaleTime);
	}

    private Timer CreateTimer(bool isOnce, float delayTime, bool isRuning, bool ingoreScaleTime = false)
    {
       // Timer timer = new Timer(isOnce, delayTime, ingoreScaleTime);

	 	Timer timer = m_Pool.GetObject();
		timer.IsUsePool = true;
		timer.Init(isOnce, delayTime, ingoreScaleTime);

		if (isRuning)
        {
            timer.Start();
        }
        return timer;
    }

    public void ScaleTick(float delta)
    {
        UpdateTimeList(m_PlayerList, delta);
    }

    public void UnScaleTick(float delta)
    {
        UpdateTimeList(m_UnScaledPlayerList, delta);
    }

	public int TimerPoolCount
	{
		get
		{
			return m_Pool.Count;
		}
	}

    protected static void UpdateTimeList(LinkedList<Timer> list, float delta)
    {
        if (list != null)
        {
            LinkedListNode<Timer> playerNode = list.First;
            while (playerNode != null)
            {
				/*
				var node = playerNode.Next;
                if (playerNode.Value != null)
                {
                    playerNode.Value.Tick(delta);
                }
				playerNode = node;*/

				LinkedListNode<Timer> next = playerNode.Next;
				var time = playerNode.Value;
				if (time != null)
				{
					if (!time.IsDispose)
					{
						time.Tick(delta);
						if (time.IsDispose)
							TimerMgr.Instance._TimerToPool(time);
					} else
					{
						TimerMgr.Instance._TimerToPool(time);
					}
				}
				playerNode = next;
            }
        }
    }

    private LinkedList<Timer> m_PlayerList = new LinkedList<Timer>();
    private LinkedList<Timer> m_UnScaledPlayerList = new LinkedList<Timer>();
	private ObjectPool<Timer> m_Pool = new ObjectPool<Timer>();
}