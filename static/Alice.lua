--package.path = os.getenv("UserProfile").."/AppData/Roaming/YimMenu/scripts/?.lua"
require("Alice-lib/lib")
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

menu["全部爆炸"] = Alice["Alice"]:add_checkbox("全部爆炸") Alice["Alice"]:add_sameline()

menu["全部崩溃"] = Alice["Alice"]:add_checkbox("全部崩溃") Alice["Alice"]:add_sameline()

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
end) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

Alice["Alice"]:add_button("CEO仓库板条箱一键满仓", function()
	menu.get_crate_ceo(111)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("机库一键满仓", function()
	menu.get_cargo_hangar(50)
end) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

Alice["Alice"]:add_button("幸运轮盘获得奖品载具", function()
	menu.casino_select_lucky_wheel_slot(18)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("赌场老虎机100%中奖", menu.casion_rig_slot) Alice["Alice"]:add_sameline()

menu["自动玩赌场老虎机"] = Alice["Alice"]:add_checkbox("自动玩赌场老虎机") Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("抢劫杂项")

Alice["Alice"]:add_button("呼叫虎鲸", menu.call_kosatka) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("传送到虎鲸", function()
	entity.teleport_to_position(PLAYER.PLAYER_ID(), {1561.115845, 385.872559, -50.985352})
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("刷新虎鲸面板", menu.restart_kosatka_board) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("传送到设施策划屏幕", function()
	entity.teleport_to_position(PLAYER.PLAYER_ID(), {352.001526, 4873.938965, -61.787357})
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("刷新设施面板", menu.restart_facility_board) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

Alice["Alice"]:add_button("末日豪劫强制玩家准备", menu.doomsday_heist_force_player_ready) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("名钻赌场豪劫强制玩家准备", menu.casino_heist_force_player_ready) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("佩里科岛强制玩家准备", menu.cayo_heist_force_player_ready) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

Alice["Alice"]:add_button("无限团队生命数", function()
	menu.instant_mission_team_life("fm_mission_controller", 999999999)
	menu.instant_mission_team_life("fm_mission_controller_2020", 999999999)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("自动完成任务", function()
	menu.instant_mission_passed("fm_mission_controller", false)
	menu.instant_mission_passed("fm_mission_controller_2020", false)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("自动完成名钻赌场豪劫 [气势汹汹]", function()
	menu.instant_mission_passed("fm_mission_controller", true)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("自动完成佩里科岛", function()
	menu.instant_mission_passed("fm_mission_controller_2020", true)
end) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

menu["自动破解任务小游戏"] = Alice["Alice"]:add_checkbox("自动破解任务小游戏") Alice["Alice"]:add_sameline()

menu["开启公寓抢劫 [大结局]"] = Alice["Alice"]:add_checkbox("开启公寓抢劫 [大结局]") Alice["Alice"]:add_sameline()

menu["自动配置名钻赌场豪劫"] = Alice["Alice"]:add_checkbox("自动配置名钻赌场豪劫") Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

menu["自动配置佩里科岛"] = Alice["Alice"]:add_checkbox("自动配置佩里科岛") Alice["Alice"]:add_sameline()

menu["自动配置别惹德瑞"] = Alice["Alice"]:add_checkbox("自动配置别惹德瑞") Alice["Alice"]:add_sameline()

menu["自动配置联合储蓄"] = Alice["Alice"]:add_checkbox("自动配置联合储蓄") Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

Alice["Alice"]:add_button("开启末日豪劫 1 [大结局]", function()
	stats.stat_set_int("MPx_GANGOPS_HEIST_STATUS", -229383)
	stats.stat_set_int("MPx_GANGOPS_FLOW_MISSION_PROG", 65535)
	stats.stat_set_int("MPx_GANGOPS_FLOW_NOTIFICATIONS", 1557)
	menu.restart_facility_board()
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("开启末日豪劫 2 [大结局]", function()
	stats.stat_set_int("MPx_GANGOPS_HEIST_STATUS", -229382)
	stats.stat_set_int("MPx_GANGOPS_FLOW_MISSION_PROG", 65535)
	stats.stat_set_int("MPx_GANGOPS_FLOW_NOTIFICATIONS", 1557)
	menu.restart_facility_board()
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("开启末日豪劫 3 [大结局]", function()
	stats.stat_set_int("MPx_GANGOPS_HEIST_STATUS", -229380)
	stats.stat_set_int("MPx_GANGOPS_FLOW_MISSION_PROG", 65535)
	stats.stat_set_int("MPx_GANGOPS_FLOW_NOTIFICATIONS", 1557)
	menu.restart_facility_board()
end) Alice["Alice"]:add_sameline() Alice["Alice"]:add_separator()

Alice["Alice"]:add_button("困难全福银行 [人均600w]", function()
	menu.apartment_heist_player_cut(0--[[ 房主[player_0] --]], 2385)
	menu.apartment_heist_player_cut(1--[[ 队友[player_1] --]], 2385)
	--menu.apartment_heist_player_cut(2--[[ 队友[player_2] --]], 2385) --[[ 由于全福是2个人, 如需设置例如越狱等4人抢劫请把注释去掉并参考实例 --]]
	--menu.apartment_heist_player_cut(3--[[ 队友[player_3] --]], 2385) --[[ 由于全福是2个人, 如需设置例如越狱等4人抢劫请把注释去掉并参考实例 --]]
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("困难全福银行 [人均1500w]", function()
	menu.apartment_heist_player_cut(0--[[ 房主[player_0] --]], 5962)
	menu.apartment_heist_player_cut(1--[[ 队友[player_1] --]], 5962)
	--menu.apartment_heist_player_cut(2--[[ 队友[player_2] --]], 5962) --[[ 由于全福是2个人, 如需设置例如越狱等4人抢劫请把注释去掉并参考实例 --]]
	--menu.apartment_heist_player_cut(3--[[ 队友[player_3] --]], 5962) --[[ 由于全福是2个人, 如需设置例如越狱等4人抢劫请把注释去掉并参考实例 --]]
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("解锁选项")

Alice["Alice"]:add_button("解锁全部DLC物品", menu.unlock_all_packed_bool) Alice["Alice"]:add_sameline()

VehicleList = {
	"inductor", 
	"inductor2", 
	"raiju", 
	"monstrociti", 
	"coureur", 
	"ratel", 
	"stingertt", 
	"avenger3", 
	"avenger4", 
	"clique2", 
	"streamer216", 
	"brigham", 
	"gauntlet6", 
	"conada2", 
	"l35", 
	"speedo5", 
	"buffalo5"
}
Alice["Alice"]:add_button("打印VehicleMods", function()
	for i = 1, #VehicleList do
		local vehicles = vehicle.create_vehicle(VehicleList[i], {ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID())).x, ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID())).y, ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID())).z + 5}, true)
		local VehicleMods = {}
		for mod = 0, 48 do
			VehicleMods[mod + 1] = VEHICLE.GET_NUM_VEHICLE_MODS(vehicles, mod) - 1
		end
		menu.print("joaat".."("..'"'..VehicleList[i]..'"'..")"..", ".."{"..VehicleMods[1]..", "..VehicleMods[2]..", "..VehicleMods[3]..", "..VehicleMods[4]..", "..VehicleMods[5]..", "..VehicleMods[6]..", "..VehicleMods[7]..", "..VehicleMods[8]..", "..VehicleMods[9]..", "..VehicleMods[10]..", "..VehicleMods[11]..", "..VehicleMods[12]..", "..VehicleMods[13]..", "..VehicleMods[14]..", "..VehicleMods[15]..", "..VehicleMods[16]..", "..VehicleMods[17]..", "..VehicleMods[18]..", "..VehicleMods[19]..", "..VehicleMods[20]..", "..VehicleMods[21]..", "..VehicleMods[22]..", ".."math.random(0, 14)"..", "..VehicleMods[24]..", "..VehicleMods[25]..", "..VehicleMods[26]..", "..VehicleMods[27]..", "..VehicleMods[28]..", "..VehicleMods[29]..", "..VehicleMods[30]..", "..VehicleMods[31]..", "..VehicleMods[32]..", "..VehicleMods[33]..", "..VehicleMods[34]..", "..VehicleMods[35]..", "..VehicleMods[36]..", "..VehicleMods[37]..", "..VehicleMods[38]..", "..VehicleMods[39]..", "..VehicleMods[40]..", "..VehicleMods[41]..", "..VehicleMods[42]..", "..VehicleMods[43]..", "..VehicleMods[44]..", "..VehicleMods[45]..", "..VehicleMods[46]..", "..VehicleMods[47]..", "..VehicleMods[48]..", "..VehicleMods[49].."}")
		ENTITY.DELETE_ENTITY(vehicles)
	end
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("null")

script.register_looped("OnScriptLoaded", function()
	menu.disable_bounds_death() -- 禁用越界死亡
	if menu["全部爆炸"]:is_enabled() then
		for i = 0, 31 do
			if PLAYER.PLAYER_ID() ~= i then
				FIRE.ADD_OWNED_EXPLOSION(PLAYER.GET_PLAYER_PED(i), ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(i)).x, ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(i)).y, ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(i)).z, 82, 1, true, false, 64)
			end
		end
	end
	if menu["全部崩溃"]:is_enabled() then
		local ParachuteModel = {"v_ind_chickensx3", "prop_int_cf_chick_01", "prop_int_cf_chick_02", "prop_int_cf_chick_03"}
		for i = 0, #ParachuteModel do
			local peds = ped.create_ped(-1, "mp_m_freemode_01", {-75.238838, -818.931763, 350.166351})
			local vehicles = vehicle.create_vehicle("ruiner2", {-75.238838, -818.931763, 350.166351}, true)
			PED.SET_PED_INTO_VEHICLE(peds, vehicles, -1)
			script_util:yield()
			VEHICLE.VEHICLE_SET_PARACHUTE_MODEL_OVERRIDE(vehicles, MISC.GET_HASH_KEY(ParachuteModel[i]))
			VEHICLE.VEHICLE_START_PARACHUTING(vehicles, true)
			script_util:sleep(200)
			ENTITY.DELETE_ENTITY(peds)
			ENTITY.DELETE_ENTITY(vehicles)
		end
	end
	if menu["自动玩赌场老虎机"]:is_enabled() then
		menu.casino_force_slot_transaction()
	end
	if menu["自动破解任务小游戏"]:is_enabled() then
		menu.instant_mission_minigame_passed()
	end
	if menu["开启公寓抢劫 [大结局]"]:is_enabled() then
		stats.stat_set_int("MPx_HEIST_PLANNING_STAGE", -1)
	end
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
	if menu["自动配置别惹德瑞"]:is_enabled() then
		stats.stat_set_int("MPx_FIXER_GENERAL_BS", -1)
		stats.stat_set_int("MPx_FIXER_STORY_BS", 4095)
		menu.dre_mission_localplayer_pay(2500000)
	end
	if menu["自动配置联合储蓄"]:is_enabled() then
		stats.stat_set_int("MPx_TUNER_CURRENT", 0)
		stats.stat_set_int("MPx_TUNER_GEN_BS", 65535)
		menu.lscar_mission_localplayer_pay(2000000)
	end
end)
