﻿using Entitas;

namespace ECS.Systems.Navigation
{
    public class SyncAgentPosition : IExecuteSystem
    {                                                       
        private readonly INavigationService _navigationService;
        private readonly GameContext _gameContext;

        public SyncAgentPosition(Contexts contexts, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _gameContext = contexts.game;
        }

        public void Execute()
        {
            var agentPositions = _navigationService.GetAgentPositions();
            foreach (var agentPosition in agentPositions)
            {
                _gameContext.GetEntityWithId(agentPosition.Key).ReplacePosition(agentPosition.Value);
            }                                   
        }      
    }
}     
