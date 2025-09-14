using System;
using UnityEngine;

namespace Clockies
{
    public class Vars : MonoBehaviour
    {
        public static Vars Instance { get; private set; }

        public UI ui;

        public Modules modules;

        public Content content;

        public DesktopInput input;

        public SceneInjection sceneInjection;


        [NonSerialized] public GameState state;


        public void Awake()
        {
            Instance = this;
            Init();
        }

        public void Init()
        {
            state = GameState.Running;

            content.Init();

            modules = new();
            modules.Init();

            input = new();
            input.Init();

            ui.Init();
        }

        public void Reset()
        {
            content.Reset();

            modules.Reset();

            ui.Reset();
        }

        public void Restart()
        {
            content.Restart();

            modules.Restart();

            ui.Restart();
        }

        public void Update()
        {
            input.Update();

            modules.Update();

            ui._Update();
        }
    }

    public enum GameState
    {
        Running,
        Win
    }
}
