# ML-Agents-Hummingbirds

Course follow on the Unity Learn platforme : ML-Agents: Hummingbirds
> https://learn.unity.com/course/ml-agents-hummingbirds?uv=2019.3

## Observation environment

Observation about the world.

In this project, we do not use the vision of the bird as it will be more complex. Possibility to use convolutional neuronal network.

- Positions 
- Rotations
- Velocities
- Raycasts : shoots out a ray or a line from a point and then see if it hits anythings (laser point)

Observation values: 
- True / False
- 3D Vectors 
- Quaternions
- Numerical values

Environment definition
- one 3D Vector => Bird position 
- one Quaternions => Bird orientation 
- 5 booleans => flower raycaster
- speed => Numerical values
- Frame ? Repeat 3 times

--- Solution

- Agent current rotation (quaternion)
- Direction to the nearest flower
- Distance to the nearest flower
- How close the agent beak is to poiting at the flower
- How close the agent beak is to being in front o the flower
- Several Raycasts (act LIDAR) to avoir obstacles

-- Reward
- Drink the nectar

-- solution
- Small positive reward each timestep if the bird's beak is touching the nectar
- Large negative reward for hitting the ground or boundaries of the training area



