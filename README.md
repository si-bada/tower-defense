# About Tower Defense

This is a Tower Defense Game.
This project is composed of two parts.

[Unity(Front End)](https://github.com/si-bada/tower-defense)

[Laravel(Back End)](https://github.com/si-bada/tower-defense-backend)

# Installation
## Clone the front end project
If you want to test the game, just clone this project, Open it with [Unity 2019.4.13f1](https://unity3d.com/fr/get-unity/download/archive) and click play.
### Clone the back end project
[Laravel(Back End)](https://github.com/si-bada/tower-defense-backend)
### Install it
```bash
composer install
```
```bash
php artisan migrate
```
```bash
php artisan serve
```
Go to unity and click Play or (CTRL + P) to start playing.

## Customisation
You can easily costomise the game parameters.
### Game Configration File
A scriptableObject found in `Assets/ScriptableObjects` where you can change the damage amount every turret do on the different enemies.
### Creating new enemy type
1 - Open `Assets/Scripts/Enemy` 

2 - Add the new type to `enum EnemyType`

3 - Go to `Assets/Prefabs/Enemies` and duplicate a folder of your choice then rename it and the prefabs inside.

2 - Select your new enemy prefab and change its parameters as you like.

### Creating new turret type
1 - Open `Assets/Scripts/Turret`

2 - Add the new type to `enum TurretType`

3 - Go to `Assets/Prefabs/Turrets` and duplicate a turret of your choice and rename it.

4 - Configure it to whatever you like.

5 - On the unity menu go to `Assets/Create/TurretInfo`, name it and assign your new prefab to it and define its cost.

6 - Go to `Assets/Prefabs`, open PanelShop Prefab and add this new Scriptable object to the TurretShop script and on the UI.

### Creating new level
1 - Go to `Assets/Scenes` and duplicate a level of your choice then rename it `Level4`.

2 - Open the scene `LevelSelector`

3 - Under `Canvas/Panel/ScrollView/Viewport/Content`, duplicate LevelButton and 
add it to the Levels list on the Level Selector Script attached to LevelSelector gameObject.

### Creating new wave
1 - On the unity menu go to `Assets/Create/Wave`, name it and configure it.

2 - Select the level scene you want to edit.

3 - Select LevelManager gameObject, you will find a WaveSpawner Script attached to it.

4 - Edit the waves attribute as you wish.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
## License
[MIT](https://choosealicense.com/licenses/mit/)
