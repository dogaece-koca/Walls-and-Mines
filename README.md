# Walls-and-Mines

A logic-driven, procedural console-based navigation game developed in C#. This project demonstrates core programming principles, including **real-time game loops**, **procedural map generation**, and **autonomous agent (AI) logic** using the .NET framework.

## 🚀 Key Technical Highlights

* **Procedural Map Generation:** Features a dynamic wall generation algorithm (`wallFunction`) that creates a unique 23x53 maze layout for every session.
* **Dynamic Environment:** Implements a `Wallchanges` mechanism that periodically alters the maze structure during gameplay, forcing the player to adapt to new paths in real-time.
* **Enemy AI Logic:** Includes two distinct enemy types ("X" and "Y") with tracking logic that calculates coordinate-based paths to follow and intercept the player.
* **Resource Management:** Managed through an integrated **Energy System**. Players must collect items to replenish energy; otherwise, the game movement speed is penalized once energy hits zero.
* **Advanced Console UI:** Utilizes `Console.SetCursorPosition` and `ConsoleColor` manipulation to create a structured UI overlay that tracks scores, time, mines, and difficulty-based high scores.

---

## 🛠 Technology Stack

* **Language:** C#
* **Framework:** .NET / Console Application
* **Concepts:** Game Loops, Collision Detection, Procedural Generation, State Management.

---

## 🎮 Game Mechanics

* **Player (P):** Controlled via arrow keys. Consumes energy with every move.
* **Mines (+):** Collected via items and placed using the Spacebar to eliminate enemies in the vicinity.
* **Difficulty Levels:** Supports three distinct levels (1, 2, or 3) that scale the game speed and difficulty.
* **Collectibles:**
    * **1:** Low score boost.
    * **2:** Moderate score and energy boost.
    * **3:** High score, high energy, and grants a mine.

---

## 📂 Project Structure

| File | Description |
| :--- | :--- |
| `Program.cs` | Contains the complete game engine, including rendering, logic, and state management. |

---

## ⚙️ How to Run

1.  **Open the project** in Visual Studio or any C# compatible IDE.
2.  **Ensure you are on Windows** (as it uses the `System.Console` Windows-specific methods).
3.  **Build and Run** the application.
4.  **Press Enter** to start a new game and follow the on-screen difficulty prompts.

---

## 📝 Learning Objectives

This project was developed to master:
1.  **C# Thread Management:** Using `Thread.Sleep` to manage frame rates and game speed.
2.  **Buffer & UI Management:** Efficiently updating specific console coordinates without refreshing the whole screen.
3.  **Conditional Logic:** Developing complex movement rules and win/loss conditions.
