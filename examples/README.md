# ImAnim Examples

Standalone examples demonstrating ImAnim integration with Dear ImGui.

These examples are modeled after [imgui/examples](https://github.com/ocornut/imgui/tree/master/examples) - each is a complete, buildable application that shows the full ImAnim demo (`ImAnimDemoWindow()` from `demo_im_anim.cpp`).

## Available Examples

| Folder | Platform | Graphics | Description |
|--------|----------|----------|-------------|
| `glfw_opengl3/` | GLFW | OpenGL 3 | Cross-platform (Windows, macOS, Linux) |
| `sdl2_opengl3/` | SDL2 | OpenGL 3 | Cross-platform (Windows, macOS, Linux) |
| `win32_directx11/` | Win32 | DirectX 11 | Windows native |
| `implatform/` | ImPlatform | Multiple | Uses ImPlatform abstraction (Win32/GLFW/SDL + DX/GL/Vulkan) |

## Building

Each example includes:
- `main.cpp` - Minimal main loop with ImAnim setup
- `Makefile` - For Linux/macOS (GLFW/SDL2 examples)
- `build_win32.bat` - For Windows (requires Visual Studio)

The build links against `demo_im_anim.cpp` (in repository root) which provides `ImAnimDemoWindow()`.

### Prerequisites

1. **ImGui source files** - Included via `examples/extern/imgui/`

2. **ImAnim source files** - In repository root (`im_anim.h`, `im_anim.cpp`)

3. **Platform library** - GLFW, SDL2, ImPlatform, or Windows SDK

### Quick Start (GLFW + OpenGL3)

```bash
# Linux/macOS
cd glfw_opengl3
make

# Windows (from Visual Studio Developer Command Prompt)
cd glfw_opengl3
build_win32.bat
```

### Quick Start (SDL2 + OpenGL3)

```bash
# Linux/macOS
cd sdl2_opengl3
make

# Windows
cd sdl2_opengl3
build_win32.bat
```

### Quick Start (ImPlatform / Sharpmake)

The Sharpmake-based build system generates a Visual Studio solution with all 4 configurations:

```bash
# From examples folder
cd examples
bootstrap.bat
# Open ImAnim_vs2022_win64.sln
```

The solution includes configurations for GLFW+OpenGL3, SDL2+OpenGL3, Win32+DX11, and ImPlatform.

## What Each Example Shows

Each example runs `ImAnimDemoWindow()` from `demo_im_anim.cpp`, showcasing all ImAnim features in one window.

## Code Structure

The `main.cpp` in each example is minimal - it just sets up the platform/graphics and calls the demo:

```cpp
#include "im_anim.h"

// From demo_im_anim.cpp
extern void ImAnimDemoWindow();

// In main loop, after ImGui::NewFrame():
iam_update_begin_frame();
iam_clip_update(io.DeltaTime);

// Show the demo
ImAnimDemoWindow();
```

## Integrating Into Your Project

To add ImAnim to your existing project:

1. Copy `im_anim.h` and `im_anim.cpp` to your project
2. Add the two frame setup calls after `ImGui::NewFrame()`
3. Start animating!

See [docs/integration.md](../docs/integration.md) for detailed integration instructions.
