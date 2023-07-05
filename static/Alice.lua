--package.path = os.getenv("UserProfile").."/AppData/Roaming/YimMenu/scripts/?.lua"
require("lib/lib[Alice]")
Alice = {}
Alice["Alice"] = gui.get_tab("GUI_TAB_LUA_SCRIPTS")

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("世界选项")

Alice["Alice"]:add_button("离开GTA线上模式", function()
	menu.change_session(-1)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("仅限邀请的战局", function()
	menu.change_session(11)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("全部人爆炸", function()
    for i = 0, 31 do
		FIRE.ADD_OWNED_EXPLOSION(PLAYER.GET_PLAYER_PED(i), ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(i)).x, ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(i)).y, ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(i)).z, 82, 1, true, false, 64)
	end
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("全部崩溃", function()
	--[[]]local ParachuteModel = {"v_ind_chickensx3", "prop_int_cf_chick_01", "prop_int_cf_chick_02", "prop_int_cf_chick_03"}
    for i = 0, #ParachuteModel do
		local peds = ped.create_ped(-1, "mp_m_freemode_01", {-75.238838, -818.931763, 350.166351})
		local vehicles = vehicle.create_vehicle("ruiner2", {-75.238838, -818.931763, 350.166351}, true)
		PED.SET_PED_INTO_VEHICLE(peds, vehicles, -1)
		script_util:sleep(100)
		VEHICLE.VEHICLE_SET_PARACHUTE_MODEL_OVERRIDE(vehicles, MISC.GET_HASH_KEY(ParachuteModel[i]))
		VEHICLE.VEHICLE_START_PARACHUTING(vehicles, true)
		script_util:sleep(200)
		ENTITY.DELETE_ENTITY(peds)
		ENTITY.DELETE_ENTITY(vehicles)
	end--]]
	--[[]local oldpos = ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()), false)
	local oldhash = PLAYER.GET_PLAYER_PARACHUTE_MODEL_OVERRIDE(PLAYER.PLAYER_ID())
	for i = 1, 10 do
		PLAYER.SET_PLAYER_PARACHUTE_MODEL_OVERRIDE(PLAYER.PLAYER_ID(), MISC.GET_HASH_KEY("prop_beach_parasol_0"..i))
		ENTITY.SET_ENTITY_COORDS_NO_OFFSET(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()), -75.238838, -823.931763, 360.166351, false, false, false)
		WEAPON.GIVE_DELAYED_WEAPON_TO_PED(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()), MISC.GET_HASH_KEY("gadget_parachute"), 9999, false)
		script_util:sleep(500)
		PED.FORCE_PED_TO_OPEN_PARACHUTE(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()))
		script_util:sleep(1000)
	end
	script_util:sleep(100)
	ENTITY.SET_ENTITY_COORDS_NO_OFFSET(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()), oldpos.x, oldpos.y, oldpos.z, false, false, false)
	PLAYER.SET_PLAYER_PARACHUTE_MODEL_OVERRIDE(PLAYER.PLAYER_ID(), oldhash)--]]
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("资产选项")

Alice["Alice"]:add_button("打开地堡APP", function()
	script.start_new_script("appBunkerBusiness", 1424)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("打开恐霸APP", function()
	script.start_new_script("appHackerTruck", 4592)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("打开机库APP", function()
	script.start_new_script("appSmuggler", 4592)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("CEO仓库板条箱一键满仓", function()
	menu.get_crate_ceo(111)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("机库一键满仓", function()
	menu.get_cargo_hangar(50)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("名钻老虎机100%中奖", menu.casion_rig_slot) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("幸运轮盘获得奖品载具", function()
	menu.casino_select_lucky_wheel_slot(18)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("抢劫杂项")

Alice["Alice"]:add_button("自动完成fm_mission_controller", function()
	menu.instant_mission_passed("fm_mission_controller", false)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("自动完成fm_mission_controller_2020", function()
	menu.instant_mission_passed("fm_mission_controller_2020", false)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("自动完成名钻赌场豪劫 [气势汹汹]", function()
	menu.instant_mission_passed("fm_mission_controller", true)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("自动完成佩里科岛", function()
	menu.instant_mission_passed("fm_mission_controller_2020", true)
end) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

Alice["Alice"]:add_button("呼叫虎鲸", menu.call_kosatka) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("传送到虎鲸", function()
	entity.teleport_to_position(PLAYER.PLAYER_ID(), {1561.115845, 385.872559, -50.985352})
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("末日豪劫强制玩家准备", menu.doomsday_heist_force_player_ready) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("名钻赌场豪劫强制玩家准备", menu.casino_heist_force_player_ready) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("佩里科岛强制玩家准备", menu.cayo_heist_force_player_ready) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

menu["自动配置名钻赌场豪劫"] = Alice["Alice"]:add_checkbox("自动配置名钻赌场豪劫") Alice["Alice"]:add_sameline()

menu["自动配置佩里科岛"] = Alice["Alice"]:add_checkbox("自动配置佩里科岛") Alice["Alice"]:add_sameline()

menu["自动破解任务小游戏"] = Alice["Alice"]:add_checkbox("自动破解任务小游戏") Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("解锁选项")

Alice["Alice"]:add_button("解锁全部DLC物品", menu.unlock_all_packed_bool) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("null")

script.register_looped("OnScriptLoaded", function()
	menu.disable_bounds_death() -- 禁用越界死亡
	script.run_in_fiber(function()
		if menu["自动破解任务小游戏"]:is_enabled() then
			menu.instant_mission_minigame_passed()
		end
	end)
	script.run_in_fiber(function()
		if menu["自动配置名钻赌场豪劫"]:is_enabled() then
			if stats.stat_get_int("MPx_CAS_HEIST_FLOW") < -1610744257 then
				stats.stat_set_int("MPx_CAS_HEIST_FLOW", -1610744257)
			end
			if stats.stat_get_int("MPx_CAS_HEIST_FLOW") >= -1610744257 then
				if stats.stat_get_int("MPx_CAS_HEIST_FLOW") >= -1610743809 then
					stats.stat_set_int("MPx_CAS_HEIST_FLOW", -1)
				end
				stats.stat_get_int("MPx_H3OPT_ACCESSPOINTS", 2047)
				stats.stat_get_int("MPx_H3OPT_POI", 1023)
				stats.stat_get_int("MPx_H3OPT_BITSET1", -1)
				stats.stat_get_int("MPx_H3OPT_DISRUPTSHIP", 3)
				stats.stat_get_int("MPx_H3OPT_KEYLEVELS", 2)
				stats.stat_get_int("MPx_H3OPT_VEHS", 3)
				stats.stat_get_int("MPx_H3OPT_WEAPS", 0)
				stats.stat_get_int("MPx_H3OPT_MASKS", 4)
				stats.stat_get_int("MPx_H3OPT_BITSET0", -17)
				stats.stat_set_int("MPx_H3OPT_TARGET", 3)
				stats.stat_set_int("MPx_H3OPT_APPROACH", 3)
				stats.stat_set_int("MPx_H3_LAST_APPROACH", 0)
				stats.stat_set_int("MPx_H3_HARD_APPROACH", 3)
				stats.stat_set_int("MPx_H3OPT_CREWWEAP", 1)
				stats.stat_set_int("MPx_H3OPT_CREWDRIVER", 1)
				stats.stat_set_int("MPx_H3OPT_CREWHACKER", 5)
			end
			for i = 0, 3 do
				menu.casino_heist_player_cut(i, 107)
			end
			menu.instant_mission_take("fm_mission_controller", 10000000)
		end
	end)
	script.run_in_fiber(function()
		if menu["自动配置佩里科岛"]:is_enabled() then
			if stats.stat_get_int("MPx_H4_PLAYTHROUGH_STATUS") == 0 then
				stats.stat_set_int("MPx_H4_PLAYTHROUGH_STATUS", 1)
			end
			if stats.stat_get_int("MPx_H4_PLAYTHROUGH_STATUS") > 0 then
				stats.stat_set_int("MPx_H4_PROGRESS", -4097)
				stats.stat_set_int("MPx_H4CNF_TROJAN", 2)
				stats.stat_set_int("MPx_H4CNF_WEAPONS", 1)
				stats.stat_set_int("MPx_H4CNF_TARGET", 5)
				stats.stat_set_int("MPx_H4CNF_BS_ENTR", 63)
				stats.stat_set_int("MPx_H4CNF_APPROACH", 65535)
				stats.stat_set_int("MPx_H4CNF_GRAPPEL", 5156)
				stats.stat_set_int("MPx_H4CNF_UNIFORM", 5256)
				stats.stat_set_int("MPx_H4CNF_BOLTCUT", 4424)
				stats.stat_set_int("MPx_H4CNF_BS_GEN", -1)
				stats.stat_set_int("MPx_H4_MISSIONS", 65535)
				stats.stat_set_int("MPx_H4CNF_WEP_DISRP", 3)
				stats.stat_set_int("MPx_H4CNF_ARM_DISRP", 3)
				stats.stat_set_int("MPx_H4CNF_HEL_DISRP", 3)
				stats.stat_set_int("MPx_H4CNF_BS_ABIL", 63)
				stats.stat_set_int("MPx_H4LOOT_CASH_I_SCOPED", stats.stat_get_int("MPx_H4LOOT_CASH_I"))
				stats.stat_set_int("MPx_H4LOOT_CASH_C_SCOPED", stats.stat_get_int("MPx_H4LOOT_CASH_C"))
				stats.stat_set_int("MPx_H4LOOT_CASH_V", stats.stat_get_int("MPx_H4LOOT_CASH_V"))
				stats.stat_set_int("MPx_H4LOOT_WEED_I_SCOPED", stats.stat_get_int("MPx_H4LOOT_WEED_I"))
				stats.stat_set_int("MPx_H4LOOT_WEED_C_SCOPED", stats.stat_get_int("MPx_H4LOOT_WEED_C"))
				stats.stat_set_int("MPx_H4LOOT_WEED_V", stats.stat_get_int("MPx_H4LOOT_WEED_V"))
				stats.stat_set_int("MPx_H4LOOT_COKE_I_SCOPED", stats.stat_get_int("MPx_H4LOOT_COKE_I"))
				stats.stat_set_int("MPx_H4LOOT_COKE_C_SCOPED", stats.stat_get_int("MPx_H4LOOT_COKE_C"))
				stats.stat_set_int("MPx_H4LOOT_COKE_V", stats.stat_get_int("MPx_H4LOOT_COKE_V"))
				stats.stat_set_int("MPx_H4LOOT_GOLD_I_SCOPED", stats.stat_get_int("MPx_H4LOOT_GOLD_I"))
				stats.stat_set_int("MPx_H4LOOT_GOLD_C_SCOPED", stats.stat_get_int("MPx_H4LOOT_GOLD_C"))
				stats.stat_set_int("MPx_H4LOOT_GOLD_V", stats.stat_get_int("MPx_H4LOOT_GOLD_V"))
				stats.stat_set_int("MPx_H4LOOT_PAINT_SCOPED", stats.stat_get_int("MPx_H4LOOT_PAINT"))
				stats.stat_set_int("MPx_H4LOOT_PAINT_V", stats.stat_get_int("MPx_H4LOOT_PAINT_V"))
			end
			for i = 0, 3 do
				menu.cayo_heist_player_cut(i, 149)
			end
		end
	end)
end)