## Space Explorer 🚀

A 2D space arcade game where players navigate through space, avoiding asteroids while collecting stars and earning points.

### Technical Requirements
    Unity Version: Unity 6000.0.37f1
    Target Platform: Windows.
### Team Members
    _Nguyễn Quang Sơn
    _Võ Lê Đức Anh
    _Phan Đức Hậu
    _Nguyễn Minh Thành

### 1. Game Overview
Space Explorer is a 2D arcade-style game built in Unity where players control a spaceship through increasingly challenging levels. The game features asteroid avoidance, star collection, and a scoring system that rewards skilled gameplay.

![Screenshot 2025-02-22 074209](https://github.com/user-attachments/assets/79eb7697-0b4c-4dda-8f3b-e07bb109bac7)

### 2. Game Elements

#### 2.1 Player Spaceship
![Main Ship - Base - Full health](https://github.com/user-attachments/assets/1a5f13aa-a498-45bc-ac0b-5be32e874712)

- **Controls**:
  - Horizontal movement using A/D or Left/Right arrow keys
  - Vertical movement using W/S or Up/Down arrow keys
  - Shoot with Spacebar

- **Features**:
  - Smooth movement with tilt animation (20-degree maximum tilt)
  - Health system with 3 hearts
  - Entrance animation from bottom of screen
  - Screen boundary limitations
  - Particle effects for explosions
  - Score tracking

#### 2.2 Asteroids
![Asteroid1](https://github.com/user-attachments/assets/c22da87a-2a0d-483a-afda-89376af66a46)

- **Properties**:
  - 2 health points
  - Moves downward at 2 units per second
  - Explodes on destruction with sound effects

- **Spawn System (AsteroidSpawner)**:
  - Initial spawn rate: 5 seconds maximum
  - Adaptive spawn rate that decreases by 1 second every 30 seconds
  - Minimum spawn interval: 1 second

#### 2.3 Enemy Ships (EnemyController)
![Nairan - Scout - Base](https://github.com/user-attachments/assets/0a34b1de-7811-40a6-a29f-a0d92a3f5116)
![Nautolan Ship - Scout - Base](https://github.com/user-attachments/assets/48a01508-7c6e-4317-bc77-bd23769124e3)

- **Features**:
  - Different enemy types with varying health and behaviors
  - Downward movement at 2 units per speed
  - Shooting capability with player tracking
  - Explosion animation and sound effects on destruction
  - Score rewards when destroyed

#### 2.4 Boss Ships (BossController)
![Nairan - Dreadnought - Base](https://github.com/user-attachments/assets/4c1a5fbd-9874-4a13-9788-c2475d922cea)

- **Features**:
  - Complex movement patterns
  - Multi-phase attack system:
    - Initial shooting phase (2 attacks)
    - Movement phase with rapid-fire attacks
  - Entrance and exit animations
  - Custom bullet patterns

#### 2.5 Stars
![Star](https://github.com/user-attachments/assets/598e7f7e-cbb0-4fdb-b7f3-cef1236e3504)

- Worth 10 points when collected
- Spawn every 1-5 seconds
- Spawn rate increases over time (decreases by 1 second every 30 seconds until reaching 1 second)
- No damage to player on collision

#### 2.6 Scoring System
- Stars: +10 points
- Hitting asteroids: -10 points
- High score system with persistent storage
- 5-digit score display

#### 2.7 Background Elements
- Scrolling background
- Decorative planets that move down periodically (every 20 seconds)

### 3. Game Flow

#### 3.1 Main Menu
- Level selection system
- High score display
  
![Screenshot 2025-02-22 080907](https://github.com/user-attachments/assets/c6fde999-b006-420e-a63c-666282143e61)

#### 3.2 Gameplay
- Progressive difficulty between levels
- Pause system (ESC key)
- Pause Menu options:
  - Resume game
  - Return to main menu
  - Exit game
    
![Screenshot 2025-02-22 074338](https://github.com/user-attachments/assets/4a10003c-6a30-4f52-ad62-0091f60b2c71)

#### 3.3 Game Over
- Displays current score
- Updates high score if current score is higher
- Options to:
  - Return to main menu
  - Exit game

#### 3.4 Score System (ScoreManager)

- **Point System:**
  - Stars: +10 points
  - Collisions: -10 points

- **Features**:
  - Persistent high score system using PlayerPrefs
  - Sprite-based number display
  - Real-time score updates

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
![Screenshot 2025-02-22 080942](https://github.com/user-attachments/assets/1a5c77d0-3d3b-40f4-b0b3-aef4d465f8a0)

### 6. Additional Notes

- The game features a complete audio feedback system
- All enemy types have unique movement and attack patterns
- Smooth animations and visual feedback for all interactions
- Persistent data storage for high scores
