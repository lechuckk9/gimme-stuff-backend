﻿using Missions.API.Mock.Shared.Business;
using System;

namespace Missions.API.Mock.Shared.States
{
    public class InProgressMissionState : MissionState
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="missionContainer"></param>
        public InProgressMissionState(MissionContainer missionContainer) : base(missionContainer) { }

        /// <inheritdoc/>
        public override EMissionStateType FinishMission()
        {
            Console.WriteLine("Mission was moved to done state.");
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override EMissionStateType MoveToNextStep()
        {
            Console.WriteLine("No previous state.");
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override EMissionStateType MoveToPreviousStep()
        {
            Console.WriteLine("Mission was moved to in-progress state.");
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override EMissionStateType ResetMission()
        {
            Console.WriteLine("Mission was moved to new state.");
            throw new NotImplementedException();
        }
    }
}
