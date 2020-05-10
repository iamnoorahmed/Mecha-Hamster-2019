﻿// Copyright 2017 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

namespace Hamster.InputControllers {

  // Class for controlling the ball via the daydream controller.
  // Uses the analog touchpad for direction.
  public class DaydreamController : BasePlayerController {
    // Velocity, in world-units-per-second, from holding down
    // a direction at an extreme.
    const float VelocityScale = 16.0f;
    static Vector2 TouchPadOffset = new Vector2(-0.5f, -0.5f);

    public override Vector2 GetInputVector() {
      Vector2 result = Vector2.zero;
#if UNITY_HAS_GOOGLEVR && (UNITY_ANDROID || UNITY_EDITOR)
      if (GvrController.IsTouching) {
        result += (GvrController.TouchPos + TouchPadOffset) * VelocityScale;
        result.y *= -1;
      }
#endif
      return result;
    }
  }
}
