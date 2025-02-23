﻿namespace DungeonGunner {
    public enum Orientation {
        NORTH,
        EAST,
        SOUTH,
        WEST,
        NONE
    }



    public enum Direction {
        UP,
        UP_RIGHT,
        UP_LEFT,
        RIGHT,
        DOWN,
        LEFT,
        NONE
    }



    public enum GameState {
        GAME_STARTED,
        PLAYING_LEVEL,
        ENGAGING_ENEMY,
        LEVEL_COMPLETED,
        GAME_WON,
        GAME_LOST,
        GAME_PAUSED,
        DUNGEON_OVERVIEW_MAP,
        RESTART_GAME
    }
}

