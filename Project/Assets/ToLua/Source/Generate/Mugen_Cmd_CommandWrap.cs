﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Mugen_Cmd_CommandWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Mugen.Cmd_Command), typeof(System.Object));
		L.RegFunction("AttachKeyCommands", AttachKeyCommands);
		L.RegFunction("New", _CreateMugen_Cmd_Command);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("name", get_name, set_name);
		L.RegVar("time", get_time, set_time);
		L.RegVar("buffer__time", get_buffer__time, set_buffer__time);
		L.RegVar("aiName", get_aiName, set_aiName);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMugen_Cmd_Command(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Mugen.Cmd_Command obj = new Mugen.Cmd_Command();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Mugen.Cmd_Command.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AttachKeyCommands(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)ToLua.CheckObject<Mugen.Cmd_Command>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.AttachKeyCommands(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			string ret = obj.name;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index name on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			int ret = obj.time;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index time on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_buffer__time(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			int ret = obj.buffer__time;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index buffer__time on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_aiName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			string ret = obj.aiName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index aiName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.name = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index name on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.time = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index time on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_buffer__time(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.buffer__time = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index buffer__time on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_aiName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Mugen.Cmd_Command obj = (Mugen.Cmd_Command)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.aiName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index aiName on a nil value");
		}
	}
}

