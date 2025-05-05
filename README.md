# SpaceShooterGame

# 🚀 Space Shooter Game

## Overview
Space Shooter Game is a 2.5D space-themed shooter game built with Unity. The player controls a spaceship, shoots asteroids, and survives through multiple waves of increasing difficulty. The game features a settings menu for audio customization, a death screen, a game-over menu, and smooth camera shake effects for immersive gameplay.

## Features
- **🛸 Player Controls**: Move the spaceship with WASD or arrow keys, shoot bolts with the fire button.
- **💥 Asteroid Waves**: Survive 5 waves of asteroids with increasing health and spawn counts.
- **❤️ Health System**: The player starts with 3 lives, represented by hearts in the UI. Lives decrease upon asteroid collision.
- **🔊 Audio Settings**: Adjust master, music, and SFX volumes via a settings menu (accessible with the Escape key).
- **🎮 Camera Shake**: Visual feedback with camera shake when the player takes damage.
- **🕹️ Game Over & Death Screen**: Game over menu after completing all waves, death screen upon losing all lives.
- **📊 FPS Counter**: Displays real-time FPS in the UI.
- **🎬 Smooth Animations**: Wave text animations and smooth spaceship rotation.

## How to Play

### Download
You can download the built version of the game here:

- **Windows**: [Download](https://drive.google.com/file/d/1jDoh5UxkL6rh7dfKbWnyGiZUIYRcM3de/view?usp=sharing)
- **Linux**: [Download](https://drive.google.com/file/d/1rkerq04vX1JuKjjuozr7XJGQzgJcmqOv/view?usp=sharing)
- **Mac**: [Download](https://drive.google.com/file/d/1FybdtVulgionEODvZwuTJlyKRlkULMs3/view?usp=sharing)

### Main Menu:
- Start the game from the **StartingScene** and navigate to the gameplay scene (**SampleScene**).

### Gameplay:
- **Move** the spaceship using **WASD** or arrow keys.
- **Press** the fire button to shoot bolts at asteroids.
- **Survive** 5 waves of asteroids. Each wave increases in difficulty (more asteroids, higher health).
- **Avoid** colliding with asteroids to preserve your lives.

### Settings Menu:
- Press **Escape** to open the settings menu during gameplay.
- Adjust audio sliders (Master, Music, SFX) and save your preferences.

### Game Over:
- Complete all 5 waves to see the **game-over menu**.
- Lose all lives to see the **death screen**.

## Installation (For Developers)

### Prerequisites
- Unity 2022.3 or later (recommended).
- GitHub Desktop (recommended for cloning the repository, or use Git if preferred).
- A compatible code editor (e.g., **Visual Studio**, **VS Code**).

### Steps

#### Clone the Repository Using GitHub Desktop:
1. Click **File > Clone Repository** (or the Clone a Repository button).
2. In the dialog, select the **URL** tab and paste the repository URL:  
   `https://github.com/GalipEfeOncu/SpaceShooterGame.git`
3. Choose a local path to save the project and click **Clone**.

Alternatively, if you prefer using Git via terminal:

git clone https://github.com/GalipEfeOncu/SpaceShooterGame.git
## Open in Unity:
1. Open **Unity Hub**.
2. Click **Add** and select the cloned project folder.
3. Open the project with **Unity 2022.3** or later.

## Set Up Scenes:
1. Ensure **StartingScene** and **SampleScene** are added to the Build Settings (**File > Build Settings > Scenes in Build**).
2. Set **StartingScene** as the first scene (index 0).

## Play:
1. Open **StartingScene** in the Unity Editor.
2. Press the **Play** button to start the game.

## Technical Details
- **Unity Version**: Built with **Unity 2022.3**.
- **Language**: **C#**.
- **Game Type**: 2.5D (3D models and animations on a 2D gameplay plane).
- **Audio Management**: Uses **AudioMixer** for controlling Master, Music, and SFX volumes with logarithmic scaling.
- **PlayerPrefs**: Saves audio settings persistently.
- **Coroutines**: Utilized for smooth animations, camera shake, and asteroid spawning.
- **UI**: Built with **Unity UI** and **TextMeshPro** for text elements.
- **Physics**: Uses **Rigidbody** for player and asteroid movement.

## Contributing
Contributions are welcome! If you’d like to contribute:

1. **Fork** the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Make your changes and commit (`git commit -m "Add your feature"`).
4. Push to your branch (`git push origin feature/your-feature`).
5. Create a **pull request**.

Please ensure your code follows **Unity best practices** and includes comments where necessary.

## License
This project is licensed under the **MIT License**. See the **LICENSE** file for details.

## Acknowledgements
- Built with using **Unity**.
- Inspired by classic space shooter games.
- Special thanks to the **Unity community** for tutorials and resources.

## Contact
For questions or feedback, reach out to [galipefe75@gmail.com] or open an issue on **GitHub**.
