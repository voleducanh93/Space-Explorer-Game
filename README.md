## Space Explorer 🚀

A 2D space arcade game where players navigate through space, avoiding asteroids while collecting stars and earning points.

### Technical Requirements
    Unity Version: Unity 6000.0.37f1
    Target Platform: Windows.

### 1. Game Overview
Space Explorer is a 2D arcade-style game built in Unity where players control a spaceship through increasingly challenging levels. The game features asteroid avoidance, star collection, and a scoring system that rewards skilled gameplay.

### 2. Game Elements

#### 2.1 Player Spaceship
- **Controls**:
  - Horizontal movement using A/D or Left/Right arrow keys
  - Vertical movement using W/S or Up/Down arrow keys
  - Shoot with Spacebar
- **Features**:
  - Smooth ship tilting animation when moving horizontally
  - Health system with 3 hearts
  - Shooting cooldown of 0.2 seconds
  - Initial entrance animation from bottom of screen

#### 2.2 Asteroids
- **Level-based Properties**:
  - Level 1: 3 health points
  - Level 2: 6 health points and 20% larger
- **Spawn System**:
  - Level 1: Every 2-5 seconds
  - Level 2: Every 0.8-2 seconds
  - Spawn rate increases over time (decreases by 1 second every 20 seconds until reaching 0.8 seconds)
- **Interaction**:
  - Can be destroyed by player bullets
  - Collision with player reduces health by 1 heart

#### 2.3 Stars
- Worth 10 points when collected
- Spawn every 1-5 seconds
- Spawn rate increases over time (decreases by 1 second every 30 seconds until reaching 1 second)
- No damage to player on collision

#### 2.4 Scoring System
- Stars: +10 points
- Hitting asteroids: -10 points
- High score system with persistent storage
- 5-digit score display

#### 2.5 Background Elements
- Scrolling background
- Decorative planets that move down periodically (every 20 seconds)

### 3. Game Flow

#### 3.1 Main Menu
- Level selection system
- High score display

#### 3.2 Gameplay
- Progressive difficulty between levels
- Pause system (ESC key)
- Pause Menu options:
  - Resume game
  - Return to main menu
  - Exit game

#### 3.3 Game Over
- Displays current score
- Updates high score if current score is higher
- Options to:
  - Return to main menu
  - Exit game

### 4. Technical Features
- Persistent high score system using PlayerPrefs
- Level-based difficulty scaling
- Smooth object movement and rotation
- Screen boundary detection for all game objects
- Particle effects for explosions
- Audio feedback for shooting and collisions

### 5. Controls Summary
- **Movement**: WASD or Arrow keys
- **Shoot**: Spacebar
- **Pause**: ESC

### 6. Level System
- Multiple levels with increasing difficulty
- Level differences:
  - Level 1: Standard difficulty
  - Level 2: Harder asteroids, faster spawn rates