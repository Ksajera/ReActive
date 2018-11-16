using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{

    //MATCH DEFAULTS
    public const int MATCH_SIZE = 2;
    public const string MATCH_NAME = "ddduel";
    public const double MATCH_DURATION = 60; //seconds
    public const string MATCH_PASSWORD = "";
    public const int MATCH_MAX_ROOMS = 10;
    public const int MATCH_MAX_TRIES = 3;
    public const int WAIT_DELAY = 3;

    public const int TIMER_READY_DURATION = 3;

    //PLAYER STATS
    public const int PLAYER_HEALTH_MAX = 100;
    public const int PLAYER_ATTACK = 10;
    public const int PLAYER_DEFENSE = 5;
    public static int PLAYER_STARTING_LEVEL = 0;

    //UI
    public const float HUD_HP_BAR_WIDTH = 200f;

    //TAGS
    public const string TAG_HUD = "GameHUD";
    public const string TAG_GAMEOVER = "gameover";

    //SCENES
    public const string SCENE_START = "Start Page";
    public const string SCENE_LOGIN_REGISTER = "Login & Registration";
    public const string SCENE_LOGIN = "Login";
    public const string SCENE_REGISTER = "Register";

    //MAIN MENU
    public const string SCENE_MAIN = "Main Menu";
    public const string SCENE_CAMPAIGN = "Campaign";
    public const string SCENE_ARENA = "Arena Menu";
    public const string SCENE_INVENTORY = "Inventory Menu";
    public const string SCENE_SHOP = "Shop Menu";
    public const string SCENE_SETTINGS = "Settings Menu";
        
    //CAMPAIGN
    public const string SCENE_CAMPAIGN_PUSHUP_LEVELS = "Push Up";
    public const string SCENE_CAMPAIGN_PUSHUP_LEVELS_1 = "Push Up(Level 1)";
    public const string SCENE_CAMPAIGN_SITUP = "Sit Up";

    //ARENA
    public const string SCENE_PUSHUP_NAME = "PVP_Duel_PushUp";
    public const string SCENE_SITUP_NAME = "PVP_Duel_SitUp";

    //INVENTORY CATEGORIES
    public const int CATEGORY_WEAPON = 1;
    public const int CATEGORY_ARMOUR = 2;
    public const int CATEGORY_COSMETIC = 3;

    //GYROSCOPE PROPERTIES (SIT UP)
    public static double GYRO_X_MAX = 3.0;
    public static double GYRO_X_MIN = -3.0;

}