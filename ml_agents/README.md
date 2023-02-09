# ML Agent

Train a new ML Agent model.

## Project initialization

In this project, we use the python package manager [`Poetry`](https://python-poetry.org/). If you are not familiar with it, you can simply take a look on the documentation in the website and [install it](https://python-poetry.org/docs/#installing-with-the-official-installer). Then, to install the dependencies of this project run:

```bash
poetry install
```

# Run ML Agent training.

For the training, we will use `mlagents` library created by Unity. To have a first view of the paramaters, you can do:
```bash
poetry run mlagents-learn -h
```

Before the training, you will need to modify the `trainer_config.yml` file that defined the parameters of our model. You can have a look at the [documentation of Unity](https://github.com/Unity-Technologies/ml-agents/blob/develop/docs/Training-ML-Agents.md). Then, for the training, you will have two ways of doing it. The first and easy one will be to run with the Unity editor. This approach also allow you to see how your model performed in real time during the training process. To do so, you will have to run:

```bash
poetry run mlagents-learn ./trainer_config.yaml --run-id hb_01
```

Then, in the Unity Editor, you will have to be in the training scene and launch the simulation.

> Note: Here, we specified a `--run-id` parameter. You could modify it to have something that match better your model name.

To optimize and to portable your training on a cloud instance, it could be interesting to run your model without graphic. To do so, you can first build your training scene with Unity. This will create an executable of your environment. In our case, it created a file named `HummingBird.x86_64` for Linux. Then, you can run the training command with additional parameters:

```bash
poetry run mlagents-learn ./trainer_config.yaml --env ../HummingBirds/bin/HummingBird.x86_64 --run-id hb_02 --no-graphics --torch-device cuda:0
```

> Note: For this step, only the `--env` and `--no-graphics` parameters are requiere. The `--torch-device` refers to the GPU device you want to use.

Finally, you can stop early a training by doing a ctr+c command. You should only do it once as it will save the last model. And, if you want to resume the training, you can simply run the same command with the `--resume` parameter.

At the end of the training, you should have a new model saved, as follow: `results/hb_01/Hummingbird.onnx`

# Analyse your model with tensorboard

In order to see the evolution of the training model, you can use tensorboard. 

```bash
poetry run tensorboard --logdir results/
```
