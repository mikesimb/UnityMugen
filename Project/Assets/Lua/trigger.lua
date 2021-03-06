local setmetatable = setmetatable
local mugen = mugen or {}
local trigger = mugen.trigger
if trigger ~= nil then
  return trigger
end

trigger = {}
mugen.trigger = trigger

local GlobaConfigMgr = MonoSingleton_GlobalConfigMgr.GetInstance()

function trigger:GetLuaCnsCfg(name)
	if name == nil then
		return nil
	end
	local luaCfg = GlobaConfigMgr:GetLuaCnsCfg("Iori-ROTD")
	return luaCfg
end

function trigger:RegisterAnimationState(newState)
	if newState == nil then
		return nil
	end
	GlobaConfigMgr:RegisterAnimationState(newState)
end

-- 条件模块

function trigger:AnimElem(luaPlayer)
   if luaPlayer == nil then
	  return nil
   end
   local display = luaPlayer.PlayerDisplay;
   if display == nil then
	  return nil
   end
   local currentFrame = display.ImageCurrentFrame
   if currentFrame == nil then
	  return nil
   end
   return currentFrame + 1
end

function trigger:AILevel(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	return attribe.AILevel
end

function trigger:Alive(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	local ret = 0
	if attribe.IsAlive then
		ret = 1
	end
	return ret
end

function trigger:Anim(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local ret = display.Stateno
	return ret
end

function trigger.AnimExist(luaPlayer, state)
	if luaPlayer == nil or state == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local ret = display:HasAniGroup(state)
	return ret
end

function trigger:Facing(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local isFlipX = display.IsFlipX
	if not isFlipX then
		return 1
	else
		return 0
	end
end

function trigger:HitCount(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	return attribe.HitCount
end

function trigger:Life(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	return attribe.Life
end

function trigger:Power(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	return attribe.Power
end

function trigger:Statetype(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	return attribe.StandType
end

function trigger:CanCtrl(luaPlayer)
	local ctrl = self:Ctrl(luaPlayer)
	if ctrl == nil then
		return false
	end
	return ctrl ~= 0
end

function trigger:Ctrl(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	return attribe.Ctrl
end

function trigger:ChangeState(luaPlayer, newState, isCns)
	if luaPlayer == nil or newState == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	return display:ChangeState(newState, isCns)
end

function trigger:SetCtrl(luaPlayer, ctrl)
	if luaPlayer == nil or ctrl == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	attribe.Ctrl = ctrl
end

function trigger:VelSet(luaPlayer, x, y)
	if luaPlayer == nil or x == nil or y == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	display:SetVelSet(x, y)
	return true
end

function trigger:VelMul(luaPlayer, x, y)
	if luaPlayer == nil or x == nil or y == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	display:VelMul(x, y)
	return true;
end

function trigger:Time(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local ret  = display:Trigger_Time()
	return ret
end

function trigger:AnimTime(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local ret = display:Trigger_AnimTime()
	return ret
end

function trigger:Stateno(luaPlayer)
	if luaPlayer == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local ret = display.Stateno
	return ret
end

function trigger:Var(luaPlayer, index)
	if luaPlayer == nil or index == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	local isOk, value = attribe:GetIntVars(index)
	if not isOk then
		return nil
	end
	return value
end

function trigger:VarSet(luaPlayer, index, value)
	if luaPlayer == nil or index == nil or value == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	attribe:SetIntVars(index, value)
end

function trigger:fVar(luaPlayer, index)
	if luaPlayer == nil or index == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	local isOk, value = attribe:GetFloatVars(index)
	if not isOk then
		return nil
	end
	return value
end

function trigger:fVarSet(luaPlayer, index, value)
	if luaPlayer == nil or index == nil or value == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local attribe = display.Attribe
	if attribe == nil then
		return nil
	end
	attribe:SetFloatVars(index, value)
end

function trigger:Command(luaPlayer, cmdName)
	if luaPlayer == nil or cmdName == nil then
		return nil
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return nil 
	end
	local ret = display:IsCommandInputKeyOk(cmdName)
	return ret
end

-- 处理模块

function trigger:Do_PlaySnd(luaPlayer, group, index)
	if luaPlayer == nil or group == nil or index == nil then
		return
	end
	local display = luaPlayer.PlayerDisplay;
	if display == nil then
		return 
	end
	display:PlaySound(group, index)
end

function trigger:Do_StatePlaySnd(luaPlayer, state)
	if luaPlayer == nil or state == nil then
		return
	end
	self:Do_PlaySnd(luaPlayer, state.value1, state.value2)
end

-- 帮助模块
function trigger:Help_CreateStateDef(luaCfg, name)
	if luaCfg == nil or name == nil then
		return nil
	end
	local id = luaCfg:CreateStateDef(name)
	return id
end

function trigger:Help_GetStateDef(luaCfg, id)
	if luaCfg == nil or id == nil then
		return nil
	end
	local def = luaCfg:GetStateDef(id)
	return def;
end

function trigger:Help_InitLuaPlayer(newLuaPlayer, basePlayer)
	if newLuaPlayer == nil or basePlayer == nil then
		return
	end
	
	local org = basePlayer.Data
	if org == nil then
		return
	end
	
	local display = newLuaPlayer.PlayerDisplay;
	if display == nil then
		return 
	end
	
	local dst = display.Attribe
	if dst == nil then
		return
	end
	
	if org.life ~= nil then
		dst.life = org.life
	end
	
	if org.attack ~= nil then
		dst.attack = org.attack
	end
	
	if org.defence ~= nil then
		dst.defence = org.defence
	end
	
	if org.fall ~= nil and org.fall.defence_up ~= nil then
		dst.fail__defence_up = org.fall.defence_up
	end
	
	if org.liedown ~= nil and org.liedown.time ~= nil then
		dst.liedown__time = org.liedown.time
	end
	
	if org.airjuggle ~= nil then
		dst.airjuggle = org.airjuggle
	end
	
	if org.sparkno ~= nil then
		dst.sparkno = org.sparkno
	end
	
	if org.guard ~= nil and org.guard.sparkno ~= nil then
		dst.guard__sparkno = org.guard.sparkno
	end
	
	if org.KO ~= nil and org.KO.echo ~= nil then
		dst.ko__echo = org.KO.echo
	end
	
	if org.Power ~= nil then
		dst.Power = org.Power
	end
	
	if org.volume ~= nil then
		dst.volume = org.volume
	end
	
	if org.IntPersistIndex ~= nil then
		dst.IntPersistIndex = org.IntPersistIndex
	end
	
	if org.FloatPersistIndex ~= nil then
		dst.FloatPersistIndex = org.FloatPersistIndex
	end
	-- 初始化變量
	dst:InitVars()
	dst:ResetDatas()
end

return trigger
