﻿namespace _SCRIPTS
{
    public interface IGameManager
    {
        ManagerStatus status { get; }

        void Startup();
    }
}