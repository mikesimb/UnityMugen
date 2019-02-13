﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Mugen_CnsStateTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(Mugen.CnsStateType));
		L.RegVar("none", get_none, null);
		L.RegVar("AfterImage", get_AfterImage, null);
		L.RegVar("AfterImageTime", get_AfterImageTime, null);
		L.RegVar("AllPalFX", get_AllPalFX, null);
		L.RegVar("AngleAdd", get_AngleAdd, null);
		L.RegVar("AngleDraw", get_AngleDraw, null);
		L.RegVar("AngleMul", get_AngleMul, null);
		L.RegVar("AngleSet", get_AngleSet, null);
		L.RegFunction("IntToEnum", IntToEnum);
		L.EndEnum();
		TypeTraits<Mugen.CnsStateType>.Check = CheckType;
		StackTraits<Mugen.CnsStateType>.Push = Push;
	}

	static void Push(IntPtr L, Mugen.CnsStateType arg)
	{
		ToLua.Push(L, arg);
	}

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(typeof(Mugen.CnsStateType), L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_none(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.none);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AfterImage(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.AfterImage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AfterImageTime(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.AfterImageTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AllPalFX(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.AllPalFX);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AngleAdd(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.AngleAdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AngleDraw(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.AngleDraw);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AngleMul(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.AngleMul);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AngleSet(IntPtr L)
	{
		ToLua.Push(L, Mugen.CnsStateType.AngleSet);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		Mugen.CnsStateType o = (Mugen.CnsStateType)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}

