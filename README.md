# ML-Agents-Hummingbirds

Course followed on the Unity Learn platforme : ML-Agents: Hummingbirds
> https://learn.unity.com/course/ml-agents-hummingbirds?uv=2019.3

## Observation environment

Observation about the world.

In this project, we do not use the vision of the bird as it will be more complex. 
> Note : In a more complex version it could be interesting to use convolutional neuronal networks.

Multiple elements can be took into consideration to observe the environment. We can use different information from the objects as the **positions**, the **rotations**, the **velocities** or the **raycasts** (line shooted from a point and indicating if it hits anythings). Regarding the values of theses information, we can have **boolean**, **3D Vector**, **Quaternion** or **numerical value**.

For a first step in this project, we will define a simples observations based on:
- Agent current rotation (quaternion)
- Direction to the nearest flower
- Distance to the nearest flower
- How close the agent beak is to poiting at the flower
- How close the agent beak is to being in front o the flower
- Several Raycasts (act LIDAR) to avoir obstacles

One thought could be to complex the observation by only having:
- one 3D Vector for the bird position
- one Quaternions for the bird orientation 
- 5 booleans defines by the flower raycaster
- speed of the bird defined by numerical values
- Mulitple frames (3 observations) to help the agent to understand the evolution of the environment. This last point could be interesting in a competitive environment with other birds.


## Reward

The reward used for this environment will be:

- Small positive reward each timestep if the bird's beak is touching the nectar (while there are still nectar)
- Large negative reward for hitting the ground or boundaries of the training area


## Environment Simplification

Here, we simplify some aspects of the environment. After the agent drinks all the nectar, we remove the flower collider in order to help the agent to move away of the flower. It's simplify the learning process of our agent as it only requieres to go to a flower. It also allow the agent to not being stuck after collecting the nectar.
