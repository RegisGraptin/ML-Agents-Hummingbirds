# ML Agent

## Install poetry

```bash
poetry install
```

Run ML Agent training.

```bash
poetry run mlagents-learn -h

poetry run mlagents-learn ./trainer_config.yaml --run-id hb_01
```

To optimize the process, I think it is better to first build your project, then call with the mlagents-learn the build by the env variable. 


--env

poetry run mlagents-learn ./trainer_config.yaml --env ../HummingBirds/bin/HummingBird.x86_64 --run-id hb_01 --no-graphics --torch-device cuda:0 --resume


Configuration of the ML Agent
- https://github.com/Unity-Technologies/ml-agents/blob/develop/docs/Training-ML-Agents.md


Saved model 
ml-agents
results/hb_01/Hummingbird.onnx.



## Run Tensorboard

```bash
poetry run tensorboard --logdir results/
```


