using System;
using System.Collections.Generic;
using MIG.API;

namespace MIG.StateMachine
{
    public sealed class SimpleStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _currentState;

        public void Add<TState>(TState state) where TState : IState
        {
            var type = typeof(TState);

            if (_states.ContainsKey(type))
            {
                throw new ArgumentException($"State of type {type} already exists");
            }

            _states[type] = state;
        }

        public void ChangeState<TState>() where TState : IEnterableState
        {
            if (_currentState is TState)
            {
                return;
            }

            TryToExitFromCurrentState();
            _currentState = GetState<TState>();
            (_currentState as IEnterableState)?.Enter();
        }

        public void ChangeState<TState, TParam>(TParam data) where TState : IEnterableState<TParam>
        {
            if (_currentState is TState)
            {
                return;
            }

            TryToExitFromCurrentState();
            _currentState = GetState<TState>();
            (_currentState as IEnterableState<TParam>)?.Enter(data);
        }

        public void ChangeState<TState, TParam1, TParam2>(TParam1 param1, TParam2 param2)
            where TState : IEnterableState<TParam1, TParam2>
        {
            if (_currentState is TState)
            {
                return;
            }

            TryToExitFromCurrentState();
            _currentState = GetState<TState>();
            (_currentState as IEnterableState<TParam1, TParam2>)?.Enter(param1, param2);
        }

        public TState GetCurrentState<TState>() where TState : class, IState =>
            (_currentState as TState);

        private void TryToExitFromCurrentState()
            => (_currentState as IExitableState)?.Exit();

        private IState GetState<TState>() where TState : IState
        {
            var type = typeof(TState);
            if (!_states.TryGetValue(type, out var result))
            {
                throw new ArgumentException($"State of type {type} is not found");
            }

            return result;
        }
    }
}
