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

### 2. Game Elements

#### 2.1 Player Spaceship
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
- **Properties**:
  - 2 health points
  - Moves downward at 2 units per second
  - Explodes on destruction with sound effects

- **Spawn System (AsteroidSpawner)**:

  - Initial spawn rate: 5 seconds maximum
  - Adaptive spawn rate that decreases by 1 second every 30 seconds
  - Minimum spawn interval: 1 second

#### 2.3 Enemy Ships (EnemyController)

- **Features**:
  - Different enemy types with varying health and behaviors
  - Downward movement at 2 units per speed
  - Shooting capability with player tracking
  - Explosion animation and sound effects on destruction
  - Score rewards when destroyed

#### 2.4 Boss Ships (BossController)

- **Features**:
  - Complex movement patterns
  - Multi-phase attack system:
    - Initial shooting phase (2 attacks)
    - Movement phase with rapid-fire attacks
  - Entrance and exit animations
  - Custom bullet patterns

#### 2.5 Stars
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

### 6. Additional Notes

- The game features a complete audio feedback system
- All enemy types have unique movement and attack patterns
- Smooth animations and visual feedback for all interactions
- Persistent data storage for high scores
