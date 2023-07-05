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
		script_util.sleep(100)
		VEHICLE.VEHICLE_SET_PARACHUTE_MODEL_OVERRIDE(vehicles, MISC.GET_HASH_KEY(ParachuteModel[i]))
		VEHICLE.VEHICLE_START_PARACHUTING(vehicles, true)
		script_util.sleep(200)
		ENTITY.DELETE_ENTITY(peds)
		ENTITY.DELETE_ENTITY(vehicles)
	end--]]
	--[[]local oldpos = ENTITY.GET_ENTITY_COORDS(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()), false)
	local oldhash = PLAYER.GET_PLAYER_PARACHUTE_MODEL_OVERRIDE(PLAYER.PLAYER_ID())
	for i = 1, 10 do
		PLAYER.SET_PLAYER_PARACHUTE_MODEL_OVERRIDE(PLAYER.PLAYER_ID(), MISC.GET_HASH_KEY("prop_beach_parasol_0"..i))
		ENTITY.SET_ENTITY_COORDS_NO_OFFSET(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()), -75.238838, -823.931763, 360.166351, false, false, false)
		WEAPON.GIVE_DELAYED_WEAPON_TO_PED(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()), MISC.GET_HASH_KEY("gadget_parachute"), 9999, false)
		script_util.sleep(500)
		PED.FORCE_PED_TO_OPEN_PARACHUTE(PLAYER.GET_PLAYER_PED(PLAYER.PLAYER_ID()))
		script_util.sleep(1000)
	end
	script_util.sleep(100)
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

Alice["Alice"]:add_button("破解任务小游戏", menu.heist_crack_minigame_passed) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("更改右下角总收入", function()
	menu.instant_heist_take("fm_mission_controller", 10000000)
	menu.instant_heist_take("fm_mission_controller_2020", 10000000)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_button("更改右下角团队生命数", function()
	menu.instant_heist_team_life("fm_mission_controller", 999999999)
	menu.instant_heist_team_life("fm_mission_controller_2020", 999999999)
end) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("解锁选项")

Alice["Alice"]:add_button("解锁全部DLC物品", menu.unlock_all_packed_bool) Alice["Alice"]:add_sameline()

Alice["Alice"]:add_separator()
Alice["Alice"]:add_text("null") menu.print(NETWORK.NETWORK_GET_INSTANCE_ID_OF_THIS_SCRIPT())